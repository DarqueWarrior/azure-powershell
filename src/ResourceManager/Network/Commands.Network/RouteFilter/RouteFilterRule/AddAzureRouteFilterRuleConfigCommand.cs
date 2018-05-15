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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmRouteFilterRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSRouteFilter))]
    public class AddAzureRouteFilterRuleConfigCommand : AzureRouteFilterRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteFilter")]
        public PSRouteFilter RouteFilter { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = IsRouteFilterRulePresent(RouteFilter.ResourceGroupName, RouteFilter.Name, Name);

            ConfirmAction(
               Force.IsPresent,
               string.Format(Properties.Resources.OverwritingResource, Name),
               Properties.Resources.CreatingResourceMessage,
               Name,
               () =>
               {
                   var rule = RouteFilter.Rules.SingleOrDefault(resource => string.Equals(resource.Name, Name, StringComparison.CurrentCultureIgnoreCase));

                   if (rule != null)
                   {
                       throw new ArgumentException("Rule with the specified name already exists");
                   }

                   rule = new PSRouteFilterRule();

                   rule.Name = Name;
                   rule.Access = Access;
                   rule.RouteFilterRuleType = RouteFilterRuleType;
                   rule.Communities = CommunityList;

                   RouteFilter.Rules.Add(rule);

                   WriteObject(RouteFilter);
               },
               () => present);
        }
    }
}
