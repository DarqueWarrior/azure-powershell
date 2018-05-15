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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Components;
    using Extensions;
    using Common;
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Gets the policy definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPolicyDefinition", DefaultParameterSetName = ParameterlessSet), OutputType(typeof(PSObject))]
    public class GetAzurePolicyDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// The policy Id parameter set.
        /// </summary>
        internal const string PolicyDefinitionIdParameterSet = "GetByPolicyDefinitionId";

        /// <summary>
        /// The policy name parameter set.
        /// </summary>
        internal const string PolicyDefinitionNameParameterSet = "GetByPolicyDefintionName";

        /// <summary>
        /// The list all policy parameter set.
        /// </summary>
        internal const string ParameterlessSet = "GetAllPolicyDefinitions";

        /// <summary>
        /// Gets or sets the policy definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyDefinitionNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy definition name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyDefinitionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy definition Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            PaginatedResponseHelper.ForEach(
                () => GetResources(),
                nextLink => GetNextLink<JObject>(nextLink),
                CancellationToken,
                resources => WriteObject(GetOutputObjects("PolicyDefinitionId", resources), true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that match the query specified.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources()
        {
            string resourceId = Id ?? GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(ApiVersion) ? Constants.PolicyDefinitionApiVersion : ApiVersion;

            if (!string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId)))
            {
                var resource = await GetResourcesClient()
                    .GetResource<JObject>(
                        resourceId,
                        apiVersion,
                        CancellationToken.Value)
                    .ConfigureAwait(false);
                ResponseWithContinuation<JObject[]> retVal;
                return resource.TryConvertTo(out retVal) && retVal.Value != null
                    ? retVal
                    : new ResponseWithContinuation<JObject[]> { Value = resource.AsArray() };
            }
            return await GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceId,
                    apiVersion,
                    CancellationToken.Value)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            if (string.IsNullOrEmpty(Name))
            {
                return string.Format("/subscriptions/{0}/providers/{1}",
                    subscriptionId.ToString(),
                    Constants.MicrosoftAuthorizationPolicyDefinitionType);
            }
            return string.Format("/subscriptions/{0}/providers/{1}/{2}",
                subscriptionId.ToString(),
                Constants.MicrosoftAuthorizationPolicyDefinitionType,
                Name);
        }
    }
}
