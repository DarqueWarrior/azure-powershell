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
    [Cmdlet("Set", "AzureRmVmssOsProfile", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public partial class SetAzureRmVmssOsProfileCommand : ResourceManager.Common.AzureRMCmdlet
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
        public string ComputerNamePrefix { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public string AdminUsername { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        public string AdminPassword { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true)]
        public string CustomData { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true)]
        public bool? WindowsConfigurationProvisionVMAgent { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true)]
        public bool? WindowsConfigurationEnableAutomaticUpdate { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipelineByPropertyName = true)]
        public string TimeZone { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 8,
            ValueFromPipelineByPropertyName = true)]
        public AdditionalUnattendContent[] AdditionalUnattendContent { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true)]
        public WinRMListener[] Listener { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true)]
        public bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 11,
            ValueFromPipelineByPropertyName = true)]
        public SshPublicKey[] PublicKey { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 12,
            ValueFromPipelineByPropertyName = true)]
        public VaultSecretGroup[] Secret { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("VirtualMachineScaleSet", "Set"))
            {
                Run();
            }
        }

        private void Run()
        {
            if (MyInvocation.BoundParameters.ContainsKey("ComputerNamePrefix"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.ComputerNamePrefix = ComputerNamePrefix;
            }

            if (MyInvocation.BoundParameters.ContainsKey("AdminUsername"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.AdminUsername = AdminUsername;
            }

            if (MyInvocation.BoundParameters.ContainsKey("AdminPassword"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.AdminPassword = AdminPassword;
            }

            if (MyInvocation.BoundParameters.ContainsKey("CustomData"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.CustomData = CustomData;
            }

            if (MyInvocation.BoundParameters.ContainsKey("WindowsConfigurationProvisionVMAgent"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // WindowsConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new WindowsConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.ProvisionVMAgent = WindowsConfigurationProvisionVMAgent;
            }

            if (MyInvocation.BoundParameters.ContainsKey("WindowsConfigurationEnableAutomaticUpdate"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // WindowsConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new WindowsConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = WindowsConfigurationEnableAutomaticUpdate;
            }

            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // WindowsConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new WindowsConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.TimeZone = TimeZone;
            }

            if (MyInvocation.BoundParameters.ContainsKey("AdditionalUnattendContent"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // WindowsConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new WindowsConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.AdditionalUnattendContent = AdditionalUnattendContent;
            }

            if (MyInvocation.BoundParameters.ContainsKey("Listener"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // WindowsConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new WindowsConfiguration();
                }
                // WinRM
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM = new WinRMConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners = Listener;
            }

            if (MyInvocation.BoundParameters.ContainsKey("LinuxConfigurationDisablePasswordAuthentication"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // LinuxConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration = new LinuxConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration.DisablePasswordAuthentication = LinuxConfigurationDisablePasswordAuthentication;
            }

            if (MyInvocation.BoundParameters.ContainsKey("PublicKey"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                // LinuxConfiguration
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration = new LinuxConfiguration();
                }
                // Ssh
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration.Ssh == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration.Ssh = new SshConfiguration();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.LinuxConfiguration.Ssh.PublicKeys = PublicKey;
            }

            if (MyInvocation.BoundParameters.ContainsKey("Secret"))
            {
                // VirtualMachineProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
                }
                // OsProfile
                if (VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
                {
                    VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile();
                }
                VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets = Secret;
            }

            WriteObject(VirtualMachineScaleSet);
        }
    }
}

