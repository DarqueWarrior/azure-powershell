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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using System.Globalization;
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Compute.Extension.Chef
{
    [Cmdlet(
        VerbsCommon.Remove, ProfileNouns.VirtualMachineChefExtension, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class RemoveAzureRmVMChefExtension : VirtualMachineExtensionBaseCmdlet
    {
        private string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        private string ExtensionDefaultName = "ChefClient";
        private string LinuxExtensionName = "LinuxChefClient";

        protected const string LinuxParameterSetName = "Linux";
        protected const string WindowsParameterSetName = "Windows";

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

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Extension Name.")]
        public string Name
        {
            get
            {
                return ExtensionDefaultName;
            }
            set
            {
                ExtensionDefaultName = value;
            }
        }

        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxParameterSetName,
            HelpMessage = "Set extension for Linux.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsParameterSetName,
            HelpMessage = "Set extension for Windows.")]
        public SwitchParameter Windows { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Linux.IsPresent)
            {
                Name = LinuxExtensionName;
            }
            else if (Windows.IsPresent)
            {
                Name = ExtensionDefaultName;
            }

            ConfirmAction("Remove Chef Extension", VMName,
                () =>
                {
                    if (string.IsNullOrEmpty(Name))
                    {
                        VirtualMachine virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                            ResourceGroupName, VMName);
                        var chefExtension = virtualMachine.Resources != null
                                ? virtualMachine.Resources.FirstOrDefault(extension =>
                                    extension.Publisher.Equals(ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                                    extension.VirtualMachineExtensionType.Equals(Name, StringComparison.InvariantCultureIgnoreCase))
                                : null;

                        if (chefExtension == null)
                        {
                            WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.ChefExtensionNotFound, ResourceGroupName, VMName));
                            return;
                        }
                        Name = chefExtension.Name;
                    }

                    var op = VirtualMachineExtensionClient.DeleteWithHttpMessagesAsync(
                        ResourceGroupName,
                        VMName,
                        Name).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
        }
    }
}
