//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", "AzureRmVmssExtension", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public partial class AddAzureRmVmssExtensionCommand : ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSVirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public string Publisher { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        public string Type { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true)]
        public string TypeHandlerVersion { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true)]
        public bool? AutoUpgradeMinorVersion { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true)]
        public Object Setting { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipelineByPropertyName = true)]
        public Object ProtectedSetting { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string ForceUpdateTag { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("VirtualMachineScaleSet", "Add"))
            {
                Run();
            }
        }

        private void Run()
        {
            // VirtualMachineProfile
            if (VirtualMachineScaleSet.VirtualMachineProfile == null)
            {
                VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
            }

            // ExtensionProfile
            if (VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile == null)
            {
                VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile = new VirtualMachineScaleSetExtensionProfile();
            }

            // Extensions
            if (VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions == null)
            {
                VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = new List<VirtualMachineScaleSetExtension>();
            }

            var vExtensions = new VirtualMachineScaleSetExtension();

            vExtensions.Name = MyInvocation.BoundParameters.ContainsKey("Name") ? Name : null;
            vExtensions.ForceUpdateTag = MyInvocation.BoundParameters.ContainsKey("ForceUpdateTag") ? ForceUpdateTag : null;
            vExtensions.Publisher = MyInvocation.BoundParameters.ContainsKey("Publisher") ? Publisher : null;
            vExtensions.Type = MyInvocation.BoundParameters.ContainsKey("Type") ? Type : null;
            vExtensions.TypeHandlerVersion = MyInvocation.BoundParameters.ContainsKey("TypeHandlerVersion") ? TypeHandlerVersion : null;
            vExtensions.AutoUpgradeMinorVersion = MyInvocation.BoundParameters.ContainsKey("AutoUpgradeMinorVersion") ? AutoUpgradeMinorVersion : null;
            vExtensions.Settings = MyInvocation.BoundParameters.ContainsKey("Setting") ? Setting : null;
            vExtensions.ProtectedSettings = MyInvocation.BoundParameters.ContainsKey("ProtectedSetting") ? ProtectedSetting : null;
            VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions.Add(vExtensions);
            WriteObject(VirtualMachineScaleSet);
        }
    }
}

