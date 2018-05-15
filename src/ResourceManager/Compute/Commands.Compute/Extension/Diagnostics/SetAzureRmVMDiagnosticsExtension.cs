﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineDiagnosticsExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureRmVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private Hashtable publicConfiguration;
        private Hashtable privateConfiguration;
        private string extensionName = "Microsoft.Insights.VMDiagnosticsSettings";
        private string location;
        private string version = "1.5";
        private bool autoUpgradeMinorVersion = true;
        private IStorageManagementClient storageClient;

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "XML Diagnostics Configuration")]
        [ValidateNotNullOrEmpty]
        public string DiagnosticsConfigurationPath
        {
            get;
            set;
        }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account name.")]
        public string StorageAccountName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account key.")]
        public string StorageAccountKey { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account endpoint.")]
        public string StorageAccountEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context.")]
        [ValidateNotNullOrEmpty]
        public IStorageContext StorageContext { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [LocationCompleter("Microsoft.Storage/storageAccounts")]
        public string Location
        {
            get
            {
                if (string.IsNullOrEmpty(location))
                {
                    Location = GetLocationFromVm(ResourceGroupName, VMName);
                }
                return location;
            }
            set
            {
                location = value;
            }
        }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        public string Name
        {
            get
            {
                return extensionName;
            }
            set
            {
                extensionName = value;
            }
        }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension version.")]
        public string TypeHandlerVersion
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        [Parameter(
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pass a boolean value indicating whether auto upgrade diagnostics extension minor version.")]
        public bool AutoUpgradeMinorVersion
        {
            get
            {
                return autoUpgradeMinorVersion;
            }
            set
            {
                autoUpgradeMinorVersion = value;
            }
        }

        private Hashtable PublicConfiguration
        {
            get
            {
                if (publicConfiguration == null)
                {
                    var vm = ComputeClient.ComputeManagementClient.VirtualMachines.Get(ResourceGroupName, VMName);
                    publicConfiguration =
                        DiagnosticsHelper.GetPublicDiagnosticsConfigurationFromFile(DiagnosticsConfigurationPath,
                            StorageAccountName, vm.Id, this);
                }

                return publicConfiguration;
            }
        }

        private Hashtable PrivateConfiguration
        {
            get
            {
                if (privateConfiguration == null)
                {
                    privateConfiguration = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(DiagnosticsConfigurationPath,
                        StorageAccountName, StorageAccountKey, StorageAccountEndpoint);
                }

                return privateConfiguration;
            }
        }

        private IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClient == null)
                {
                    storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return storageClient;
            }
        }

        private void ExecuteCommand()
        {
            ExecuteClientAction(() =>
            {
                var parameters = new VirtualMachineExtension
                {
                    Location = Location,
                    Settings = PublicConfiguration,
                    ProtectedSettings = PrivateConfiguration,
                    Publisher = DiagnosticsExtensionConstants.ExtensionPublisher,
                    VirtualMachineExtensionType = DiagnosticsExtensionConstants.ExtensionType,
                    TypeHandlerVersion = TypeHandlerVersion,
                    AutoUpgradeMinorVersion = AutoUpgradeMinorVersion
                };

                var op = VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                    ResourceGroupName,
                    VMName,
                    Name,
                    parameters).GetAwaiter().GetResult();

                var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                WriteObject(result);
            });
        }

        private void InitializeStorageParameters()
        {
            InitializeStorageAccountName();

            // If sas token is provided in private config, skip retrieving storage account key and endpoint.
            if (!IsSasTokenProvided())
            {
                InitializeStorageAccountKey();
                InitializeStorageAccountEndpoint();
            }
        }

        private void InitializeStorageAccountName()
        {
            StorageAccountName = StorageAccountName ??
                DiagnosticsHelper.InitializeStorageAccountName(StorageContext, DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(StorageAccountName))
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionNullStorageAccountName);
            }
        }

        private void InitializeStorageAccountKey()
        {
            StorageAccountKey = StorageAccountKey ??
                DiagnosticsHelper.InitializeStorageAccountKey(StorageClient, StorageAccountName, DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(StorageAccountKey))
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionNullStorageAccountKey);
            }
        }

        private void InitializeStorageAccountEndpoint()
        {
            StorageAccountEndpoint = StorageAccountEndpoint ??
                DiagnosticsHelper.InitializeStorageAccountEndpoint(StorageAccountName, StorageAccountKey, StorageClient,
                    StorageContext, DiagnosticsConfigurationPath, DefaultContext);

            if (string.IsNullOrEmpty(StorageAccountEndpoint))
            {
                throw new ArgumentNullException(Properties.Resources.DiagnosticsExtensionNullStorageAccountEndpoint);
            }
        }

        private bool IsSasTokenProvided()
        {
            return !string.IsNullOrEmpty(DiagnosticsHelper.GetConfigValueFromPrivateConfig(DiagnosticsConfigurationPath, 
                DiagnosticsHelper.PrivateConfigElemStr, DiagnosticsHelper.PrivConfSasKeyAttr));
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            InitializeStorageParameters();
            ExecuteCommand();
        }
    }
}