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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using Management.Logic.Models;
    using Management.Logic;
    using System.Management.Automation;
    using System.Globalization;
    using Rest.Azure;

    /// <summary>
    /// LogicApp client partial class for integration account certificate operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account certificate.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountCertificateName">The integration account certificate name.</param>
        /// <param name="integrationAccountCertificate">The integration account certificate object.</param>
        /// <returns>Newly created integration account certificate object.</returns>
        public IntegrationAccountCertificate CreateIntegrationAccountCertificate(string resourceGroupName, string integrationAccountName, string integrationAccountCertificateName, IntegrationAccountCertificate integrationAccountCertificate)
        {
            if (!DoesIntegrationAccountCertificateExist(resourceGroupName, integrationAccountName,integrationAccountCertificateName))
            {
                return LogicManagementClient.Certificates.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountCertificateName, integrationAccountCertificate);
            }
            throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                Properties.Resource.ResourceAlreadyExists, integrationAccountCertificateName, resourceGroupName));
        }

        /// <summary>
        /// Checks whether the integration account certifcate exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountCertificateName">The integration account certificate name.</param>
        /// <returns>Boolean result indicating whether the integration account certificate exists or not.</returns>
        private bool DoesIntegrationAccountCertificateExist(string resourceGroupName, string integrationAccountName, string integrationAccountCertificateName)
        {
            bool result = false;
            try
            {
                var certificate = LogicManagementClient.Certificates.Get(resourceGroupName, integrationAccountName, integrationAccountCertificateName);
                result = certificate != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }        

        /// <summary>
        /// Updates the integration account certificate.
        /// </summary>
        /// <param name="resourceGroupName">The integration account certificate resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountCertificateName">The integration account certificate name.</param>
        /// <param name="integrationAccountCertificate">The integration account certificate object.</param>
        /// <returns>Updated integration account certificate.</returns>
        public IntegrationAccountCertificate UpdateIntegrationAccountCertificate(string resourceGroupName, string integrationAccountName, string integrationAccountCertificateName, IntegrationAccountCertificate integrationAccountCertificate)
        {
            return LogicManagementClient.Certificates.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountCertificateName, integrationAccountCertificate);
        }

        /// <summary>
        /// Gets the integration account certificate by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountCertificateName">The integration account certificate name.</param>
        /// <returns>Integration account certificate object.</returns>
        public IntegrationAccountCertificate GetIntegrationAccountCertifcate(string resourceGroupName, string integrationAccountName, string integrationAccountCertificateName)
        {
            return LogicManagementClient.Certificates.Get(resourceGroupName, integrationAccountName, integrationAccountCertificateName);
        }

        /// <summary>
        /// Gets the integration account certificates by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account certificates.</returns>
        public IPage<IntegrationAccountCertificate> ListIntegrationAccountCertificates(string resourceGroupName, string integrationAccountName)
        {
            return LogicManagementClient.Certificates.ListByIntegrationAccounts(resourceGroupName, integrationAccountName, 1000);
        }

        /// <summary>
        /// Removes the specified integration account certificate.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountCertificateName">The integration account certificate name.</param>
        public void RemoveIntegrationAccountCertificate(string resourceGroupName, string integrationAccountName, string integrationAccountCertificateName)
        {
            LogicManagementClient.Certificates.Delete(resourceGroupName, integrationAccountName, integrationAccountCertificateName);
        }
    }
}