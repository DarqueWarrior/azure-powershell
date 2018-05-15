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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Update discovery details for a registered vCenter.
    /// </summary>
    [Cmdlet(
        VerbsData.Update,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Update-ASRvCenter")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the resourceId of vCenter to be updated.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        /// <summary>
        ///     Gets or sets the vCenter object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("vCenter")]
        public ASRvCenter InputObject { get; set; }

        /// <summary>
        ///     Gets or sets vCenter login credentials account.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets the TCP port on the vCenter server to use for discovery.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public int? Port { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByResourceId:
                    vCenterName = Utilities.GetValueFromArmId(
                    ResourceId,
                    ARMResourceTypeConstants.vCenters);

                    fabricName = Utilities.GetValueFromArmId(
                    ResourceId,
                    ARMResourceTypeConstants.ReplicationFabrics);
                    break;

                case ASRParameterSets.Default:
                    vCenterName = InputObject.Name;
                    fabricName = InputObject.FabricArmResourceName;
                    break;
            }

            if (ShouldProcess(vCenterName, VerbsData.Update))
            {
                UpdatevCenter();
            }
        }

        /// <summary>
        ///     Update the vCenter.
        /// </summary>
        private void UpdatevCenter()
        {
            var updatevCenterInput = new UpdateVCenterRequest();

            var vcenterResponse =
               RecoveryServicesClient.GetAzureRmSiteRecoveryvCenter(
                   fabricName,
                   vCenterName);
            var updatevCenterProperties =
                 new UpdateVCenterRequestProperties()
                 {
                     FriendlyName = vcenterResponse.Properties.FriendlyName,
                     IpAddress = vcenterResponse.Properties.IpAddress,
                     ProcessServerId = vcenterResponse.Properties.ProcessServerId,
                     Port = vcenterResponse.Properties.Port,
                     RunAsAccountId = vcenterResponse.Properties.RunAsAccountId
                 };

            if (Account != null && !string.IsNullOrEmpty(Account.AccountId))
            {
                updatevCenterProperties.RunAsAccountId = Account.AccountId;
            }

            if (Port.HasValue)
            {
                updatevCenterProperties.Port = Port.ToString();
            }

            updatevCenterInput.Properties = updatevCenterProperties;

            var response = RecoveryServicesClient.UpdateAzureRmSiteRecoveryvCenter(
                fabricName,
                vCenterName,
                updatevCenterInput);

            var jobResponse = RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        #region private 

        private string vCenterName;

        private string fabricName;
        #endregion
    }
}
