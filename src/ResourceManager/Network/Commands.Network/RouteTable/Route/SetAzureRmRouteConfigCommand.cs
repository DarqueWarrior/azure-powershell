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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", "AzureRmRouteConfig", SupportsShouldProcess = true), OutputType(typeof(PSRouteTable))]
    public class SetAzureRmRouteConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSRouteTable RouteTable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination CIDR to which the route applies.",
            ValueFromPipelineByPropertyName = true)]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The type of Azure hop the packet should be sent to. Possible values are: 'VirtualNetworkGateway', 'VnetLocal', 'Internet', 'VirtualAppliance', and 'None'",
            ValueFromPipelineByPropertyName = true)]
        public string NextHopType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.",
            ValueFromPipelineByPropertyName = true)]
        public string NextHopIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the route.")]
        public string Name { get; set; }


        public override void Execute()
        {
            var vRoutesIndex = RouteTable.Routes.IndexOf(
                RouteTable.Routes.SingleOrDefault(
                    resource => string.Equals(resource.Name, Name, StringComparison.CurrentCultureIgnoreCase)));
            if (vRoutesIndex == -1)
            {
                throw new ArgumentException("Routes with the specified name does not exist");
            }
            var vRoutes = new PSRoute();

            vRoutes.AddressPrefix = AddressPrefix;
            vRoutes.NextHopType = NextHopType;
            vRoutes.NextHopIpAddress = NextHopIpAddress;
            vRoutes.Name = Name;
            RouteTable.Routes[vRoutesIndex] = vRoutes;
            WriteObject(RouteTable, true);
        }
    }
}

