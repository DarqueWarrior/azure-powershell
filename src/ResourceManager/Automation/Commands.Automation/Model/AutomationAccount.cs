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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Management.Automation;

    /// <summary>
    /// The automation account.
    /// </summary>
    public class AutomationAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationAccount"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccount">
        /// The automation account.
        /// </param>
        public AutomationAccount(string resourceGroupName, AutomationManagement.Models.AutomationAccount automationAccount)
        {
            Requires.Argument("AutomationAccount", automationAccount).NotNull();


            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                ResourceGroupName = resourceGroupName;
            }
            else
            {
                ResourceGroupName = automationAccount.Id.Substring(1).Split(Convert.ToChar("/"))[3];
            }

            SubscriptionId = automationAccount.Id.Substring(1).Split(Convert.ToChar("/"))[1];

            AutomationAccountName = automationAccount.Name;
            Location = automationAccount.Location;

            Tags = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in automationAccount.Tags)
            {
                Tags.Add(kvp.Key, kvp.Value);
            }

            if (automationAccount.Properties == null) return;

            Plan = automationAccount.Properties.Sku != null ? automationAccount.Properties.Sku.Name : null;
            CreationTime = automationAccount.Properties.CreationTime.ToLocalTime();
            LastModifiedTime = automationAccount.Properties.LastModifiedTime.ToLocalTime();
            State = automationAccount.Properties.State;
            LastModifiedBy = automationAccount.Properties.LastModifiedBy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationAccount"/> class.
        /// </summary>
        public AutomationAccount()
        {
        }

        /// <summary>
        /// Gets or sets the Subscription ID
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        /// Gets or sets the CreationTime.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the LastPublishTime.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the LastModifiedBy.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public Hashtable Tags { get; set; }
    }
}
