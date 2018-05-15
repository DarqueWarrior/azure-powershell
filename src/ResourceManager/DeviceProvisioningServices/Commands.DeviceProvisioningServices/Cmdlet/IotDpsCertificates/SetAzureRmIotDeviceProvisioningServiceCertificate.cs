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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Text;
    using Common.Authentication;
    using Models;
    using ResourceManager.Common.ArgumentCompleters;
    using Azure.Management.DeviceProvisioningServices;
    using Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Properties.Resources;

    [Cmdlet(VerbsCommon.Set, "AzureRmIoTDeviceProvisioningServiceCertificate", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Set-AzureRmIoTDpsCertificate")]
    [OutputType(typeof(PSCertificateResponse))]
    public class SetAzureRmIoTDeviceProvisioningServiceCertificate : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string ResourceIdParameterSet = "ResourceIdSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Certificate Object")]
        [ValidateNotNullOrEmpty]
        public PSCertificateResponse InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Certificate Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Iot device provisioning service certificate")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(
           Position = 1,
           Mandatory = true,
           ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "Etag of the Certificate")]
        [Parameter(
           Position = 3,
           Mandatory = true,
           ParameterSetName = ResourceParameterSet,
           HelpMessage = "Etag of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string Etag { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "base-64 representation of X509 certificate .cer file or .pem file path")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "base-64 representation of X509 certificate .cer file or .pem file path")]
        [Parameter(
            Position = 4,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "base-64 representation of X509 certificate .cer file or .pem file path")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.SetCertificate))
            {
                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                        ResourceGroupName = InputObject.ResourceGroupName;
                        Name = InputObject.Name;
                        CertificateName = InputObject.CertificateName;
                        Etag = InputObject.Etag;
                        SetIotDpsCertificate();
                        break;

                    case ResourceIdParameterSet:
                        ResourceGroupName = IotDpsUtils.GetResourceGroupName(ResourceId);
                        Name = IotDpsUtils.GetIotDpsName(ResourceId);
                        CertificateName = IotDpsUtils.GetIotDpsCertificateName(ResourceId);
                        SetIotDpsCertificate();
                        break;

                    case ResourceParameterSet:
                        SetIotDpsCertificate();
                        break;

                    default:
                        throw new ArgumentException("BadParameterSetName");
                }
            }
        }

        private void SetIotDpsCertificate()
        {
            string certificate = string.Empty;
            FileInfo fileInfo = new FileInfo(Path);
            switch (fileInfo.Extension.ToLower(CultureInfo.InvariantCulture))
            {
                case ".cer":
                    var certificateByteContent = AzureSession.Instance.DataStore.ReadFileAsBytes(Path);
                    certificate = Convert.ToBase64String(certificateByteContent);
                    break;
                case ".pem":
                    certificate = AzureSession.Instance.DataStore.ReadFileAsText(Path);
                    break;
                default:
                    certificate = Path;
                    break;
            }

            certificate = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(certificate));

            VerificationCodeRequest verificationCodeRequest = new VerificationCodeRequest();
            verificationCodeRequest.Certificate = certificate;

            CertificateResponse certificateResponse = IotDpsClient.DpsCertificate.VerifyCertificate(CertificateName, Etag, verificationCodeRequest, ResourceGroupName, Name);
            WriteObject(IotDpsUtils.ToPSCertificateResponse(certificateResponse));
        }
    }
}


