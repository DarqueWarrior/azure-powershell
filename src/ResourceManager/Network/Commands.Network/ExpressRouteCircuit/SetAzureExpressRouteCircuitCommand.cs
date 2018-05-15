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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmExpressRouteCircuit"), OutputType(typeof(PSExpressRouteCircuit))]
    public class SetAzureExpressRouteCircuitCommand : ExpressRouteCircuitBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCircuit")]
        public PSExpressRouteCircuit ExpressRouteCircuit { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!IsExpressRouteCircuitPresent(ExpressRouteCircuit.ResourceGroupName, ExpressRouteCircuit.Name))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var circuitModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteCircuit>(ExpressRouteCircuit);
            circuitModel.Tags = TagsConversionHelper.CreateTagDictionary(ExpressRouteCircuit.Tag, validate: true);

            // Execute the Create ExpressRouteCircuit call
            ExpressRouteCircuitClient.CreateOrUpdate(ExpressRouteCircuit.ResourceGroupName, ExpressRouteCircuit.Name, circuitModel);

            var getExpressRouteCircuit = GetExpressRouteCircuit(ExpressRouteCircuit.ResourceGroupName, ExpressRouteCircuit.Name);
            WriteObject(getExpressRouteCircuit);
        }
    }
}
