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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmPrivateIPAddressAvailability"), OutputType(typeof(PSIPAddressAvailabilityResult))]
    public class TestAzurePrivateIPAddressAvailabilityCmdlet : VirtualNetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "TestByResource",
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The virtualNetwork name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Private Ip Address")]
        [ValidateNotNullOrEmpty]
        public string IPAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSIPAddressAvailabilityResult result;

            if (string.Equals(ParameterSetName, "TestByResource"))
            {
                result = TestIpAddressAvailability(VirtualNetwork.ResourceGroupName, VirtualNetwork.Name, IPAddress);
            }
            else
            {
                result = TestIpAddressAvailability(ResourceGroupName, VirtualNetworkName, IPAddress);
            }

            WriteObject(result);
        }

        public PSIPAddressAvailabilityResult TestIpAddressAvailability(string resourceGroupName, string vnetName, string ipAddress)
        {
            var result = NetworkClient.NetworkManagementClient.VirtualNetworks.CheckIPAddressAvailability(resourceGroupName, vnetName, ipAddress);
            var psResult = NetworkResourceManagerProfile.Mapper.Map<PSIPAddressAvailabilityResult>(result);

            return psResult;
        }
    }
}
