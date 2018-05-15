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

namespace Microsoft.Azure.Commands.Scheduler.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Models;
    using Properties;
    using Utilities;
    using SchedulerModels = Management.Scheduler.Models;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Update existing storage queue job.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSchedulerStorageQueueJob", SupportsShouldProcess = true), OutputType(typeof(PSSchedulerJobDefinition))]
    public class UpdateAzureSchedulerStorageQueueJobCommand : JobBaseCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The targeted resource group for job.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job collection.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Storage account name.")]
        [ValidateNotNullOrEmpty]
        public string StorageQueueAccount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Storage Queue name.")]
        [ValidateNotNullOrEmpty]
        public string StorageQueueName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The SAS token for storage queue.")]
        [ValidateNotNullOrEmpty]
        public string StorageSASToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The queue message for storage job.")]
        [ValidateNotNullOrEmpty]
        public string StorageQueueMessage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Start Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Interval of the recurrence at the given frequency")]
        [ValidateNotNullOrEmpty]
        public int? Interval { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The frequency of recurrence")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.FrequencyTypeMinute, Constants.FrequencyTypeHour, Constants.FrequencyTypeDay, Constants.FrequencyTypeWeek, Constants.FrequencyTypeMonth, IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The End Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Count of occurrences that will execute. Optional. Default will recur infinitely")]
        [ValidateNotNullOrEmpty]
        public int? ExecutionCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job state.")]
        [ValidateSet(Constants.JobStateEnabled, Constants.JobStateDisabled, IgnoreCase = true)]
        public string JobState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Error action settings")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.HttpAction, Constants.HttpsAction, Constants.StorageQueueAction, Constants.ServiceBusQueueAction, Constants.ServiceBusTopicAction, IgnoreCase = true)]
        public string ErrorActionType { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var storageJobAction = new PSStorageJobActionParams
            {
                StorageAccount = StorageQueueAccount,
                StorageQueueMessage = StorageQueueMessage,
                StorageQueueName = StorageQueueName,
                StorageSasToken = StorageSASToken
            };

            var jobAction = new PSJobActionParams
            {
                JobActionType = SchedulerModels.JobActionType.StorageQueue,
                StorageJobAction = storageJobAction
            };

            var jobRecurrence = new PSJobRecurrenceParams
            {
                Interval = Interval,
                Frequency = Frequency,
                EndTime = EndTime,
                ExecutionCount = ExecutionCount
            };

            var jobParams = new PSJobParams
            {
                ResourceGroupName = ResourceGroupName,
                JobCollectionName = JobCollectionName,
                JobName = JobName,
                JobState = JobState,
                StartTime = StartTime,
                JobAction = jobAction,
                JobRecurrence = jobRecurrence,
                JobErrorAction = GetErrorActionParamsValue(ErrorActionType)
            };

            ConfirmAction(
                string.Format(Resources.UpdateStorageQueueJobResourceDescription, JobName),
                JobCollectionName,
                () =>
                {
                    WriteObject(SchedulerClient.UpdateJob(jobParams));
                }
            ); 
        }

        /// <summary>
        /// Get conditional parameters depending on specified ErrorAction.
        /// </summary>
        /// <returns>List of Powershell dynamic parameters.</returns>
        public object GetDynamicParameters()
        {
            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrWhiteSpace(ErrorActionType))
            {
                runtimeDefinedParameterDictionary.AddRange(AddErrorActionParameters(ErrorActionType, false));
            }

            return runtimeDefinedParameterDictionary;
        }
    }
}
