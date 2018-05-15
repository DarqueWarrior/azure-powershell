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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Linq;

    [Cmdlet(VerbsCommon.New, "AzureRmExpressRouteCircuitPeeringConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSPeering))]
    public class NewAzureExpressRouteCircuitPeeringConfigCommand : AzureExpressRouteCircuitPeeringConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Peering")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(ParameterSetName, Properties.Resources.SetByResource))
            {
                if (RouteFilter != null)
                {
                    RouteFilterId = RouteFilter.Id;
                }
            }

           var peering = new PSPeering();

            peering.Name = Name;
            peering.PeeringType = PeeringType;
            peering.PeerASN = PeerASN;
            peering.VlanId = VlanId;

            if (!string.IsNullOrEmpty(SharedKey))
            {
                peering.SharedKey = SharedKey;
            }

            if (PeerAddressType == IPv6)
            {
                SetIpv6PeeringParameters(peering);
            }
            else
            {
                // Set IPv4 config even if no PeerAddresType has been specified for backward compatibility
                SetIpv4PeeringParameters(peering);
            }

            ConstructMicrosoftConfig(peering);

            WriteObject(peering);
        }
    }
}
