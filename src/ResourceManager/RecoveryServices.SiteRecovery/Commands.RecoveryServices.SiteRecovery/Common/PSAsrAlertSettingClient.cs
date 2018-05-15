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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using AutoMapper;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets azure site recovery alertSettings.
        /// </summary>
        /// <returns>Server list response</returns>
        public List<Alert> GetAzureSiteRecoveryAlertSetting()
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationAlertSettings
                .ListWithHttpMessagesAsync(GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                GetSiteRecoveryClient().ReplicationAlertSettings.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Set the alert settings.
        /// </summary>
        /// <param name="input">Alert setting input.</param>
        /// <returns></returns>
        public Alert SetAzureSiteRecoveryAlertSetting(ConfigureAlertRequest input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationAlertSettings
                .CreateWithHttpMessagesAsync(
                    Constants.DefaultAlertSettingName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            return op;
        }
    }
}