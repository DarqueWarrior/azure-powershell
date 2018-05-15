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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineDiagnosticsExtension),
    OutputType(
        typeof(PSVirtualMachineExtension))]
    public class GetAzureRmVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
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
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(Name))
                {
                    var virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(ResourceGroupName, VMName);
                    var diagnosticsExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(DiagnosticsExtensionConstants.ExtensionPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(DiagnosticsExtensionConstants.ExtensionType, StringComparison.InvariantCultureIgnoreCase))
                            : null;

                    if (diagnosticsExtension == null)
                    {
                        WriteObject(null);
                        return;
                    }
                    Name = diagnosticsExtension.Name;
                }

                AzureOperationResponse<VirtualMachineExtension> virtualMachineExtensionGetResponse = null;
                if (Status.IsPresent)
                {
                    virtualMachineExtensionGetResponse =
                        VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName,
                            VMName, Name);
                }
                else
                {
                    virtualMachineExtensionGetResponse = VirtualMachineExtensionClient.GetWithHttpMessagesAsync(
                        ResourceGroupName,
                        VMName,
                        Name).GetAwaiter().GetResult();
                }

                var returnedExtension = virtualMachineExtensionGetResponse.ToPSVirtualMachineExtension(
                    ResourceGroupName, VMName);

                WriteObject(returnedExtension);
            });
        }
    }
}