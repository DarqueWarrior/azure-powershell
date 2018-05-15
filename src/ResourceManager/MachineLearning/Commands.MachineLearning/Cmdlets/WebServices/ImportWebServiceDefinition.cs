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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.MachineLearning.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{
    [Cmdlet(VerbsData.Import, CommandletSuffix)]
    [OutputType(typeof(WebService))]
    public class ImportWebServiceDefinition : WebServicesCmdletBase
    {
        private const string ImportFromFileParamSet = "ImportFromJSONFile";
        private const string ImportFromStringParamSet = "ImportFromJSONString.";

        [Parameter(
            ParameterSetName = ImportFromFileParamSet, 
            Mandatory = true, 
            HelpMessage = "Path to a file on disk containing the web service definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(
            ParameterSetName = ImportFromStringParamSet, 
            Mandatory = true, 
            HelpMessage = "The actual web service definition as a JSON string.")]
        [ValidateNotNullOrEmpty]
        public string JsonString { get; set; }

        protected override void RunCmdlet()
        {
            string jsonDefinition = JsonString;
            if (string.Equals(
                        ParameterSetName, 
                        ImportFromFileParamSet, 
                        StringComparison.OrdinalIgnoreCase))
            {
                jsonDefinition = CmdletHelpers.GetWebServiceDefinitionFromFile(
                                        SessionState.Path.CurrentFileSystemLocation.Path, 
                                        InputFile);
            }

            WebService serviceDefinition = ModelsSerializationUtil.GetAzureMLWebServiceFromJsonDefinition(jsonDefinition);
            WriteObject(serviceDefinition);
        }
    }
}
