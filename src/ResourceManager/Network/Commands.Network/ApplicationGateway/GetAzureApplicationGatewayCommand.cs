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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmApplicationGateway"), OutputType(typeof(PSApplicationGateway), typeof(IEnumerable<PSApplicationGateway>))]
    public class GetAzureApplicationGatewayCommand : ApplicationGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrEmpty(Name))
            {
                var applicationGateway = GetApplicationGateway(ResourceGroupName, Name);

                WriteObject(applicationGateway);
            }
            else
            {
                IPage<ApplicationGateway> appGatewayPage;
                if (!string.IsNullOrEmpty(ResourceGroupName))
                {
                    appGatewayPage = ApplicationGatewayClient.List(ResourceGroupName);
                }
                else
                {
                    appGatewayPage = ApplicationGatewayClient.ListAll();
                }

                // Get all resources by polling on next page link
                var appGwResponseList = ListNextLink<ApplicationGateway>.GetAllResourcesByPollingNextLink(appGatewayPage, ApplicationGatewayClient.ListNext);

                var psApplicationGateways = new List<PSApplicationGateway>();

                foreach (var appGw in appGwResponseList)
                {
                    var psAppGw = ToPsApplicationGateway(appGw);
                    psAppGw.ResourceGroupName = GetResourceGroup(appGw.Id);
                    psApplicationGateways.Add(psAppGw);
                }

                WriteObject(psApplicationGateways, true);
            }
        }
    }
}

