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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Common;
    using Models;
    using Azure.Management.IotHub;
    using Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Remove, "AzureRmIotHubEventHubConsumerGroup", SupportsShouldProcess = true), OutputType(typeof(IEnumerable<string>))]
    [Alias("Remove-AzureRmIotHubEHCG")]
    public class RemoveAzureRmIotHubEventHubConsumerGroup : IotHubBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "EventHubEndpointName. Possible values events, operationsMonitoringEvents")]
        [ValidateNotNullOrEmpty]
        [ValidateSetAttribute(EventsEndpointName, OperationsMonitoringEventsEndpointName)]
        public string EventHubEndpointName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the EventHub ConsumerGroupName")]
        [ValidateNotNullOrEmpty]
        public string EventHubConsumerGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(EventHubConsumerGroupName, Properties.Resources.RemoveEventHubConsumerGroup))
            {
                IotHubClient.IotHubResource.DeleteEventHubConsumerGroup(ResourceGroupName, Name, EventHubEndpointName, EventHubConsumerGroupName);
                IEnumerable<EventHubConsumerGroupInfo> iotHubEHConsumerGroups = IotHubClient.IotHubResource.ListEventHubConsumerGroups(ResourceGroupName, Name, EventHubEndpointName);
                WriteObject(IotHubUtils.ToPSEventHubConsumerGroupInfo(iotHubEHConsumerGroups), true);
            }
        }

        private const string EventsEndpointName = "events";
        private const string OperationsMonitoringEventsEndpointName = "operationsMonitoringEvents";
    }
}
