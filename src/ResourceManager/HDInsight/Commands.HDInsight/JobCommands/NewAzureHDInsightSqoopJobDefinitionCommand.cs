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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.JobDefinitions.AzureHDInsightSqoopJobDefinition),
    OutputType(
        typeof(AzureHDInsightSqoopJobDefinition))]
    public class NewAzureHDInsightSqoopJobDefinitionCommand : HDInsightCmdletBase
    {
        private readonly AzureHDInsightSqoopJobDefinition _job;

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "The files for the jobDetails.")]
        public string[] Files { get; set; }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return _job.StatusFolder; }
            set { _job.StatusFolder = value; }
        }

        [Parameter(HelpMessage = "The query file to run in the jobDetails.")]
        public string File
        {
            get { return _job.File; }
            set { _job.File = value; }
        }

        [Parameter(HelpMessage = "The command to use for a sqoop job.")]
        public string Command
        {
            get { return _job.Command; }
            set { _job.Command = value; }
        }

        [Parameter(HelpMessage = "The directory where the libjar can be found for the Sqoop job.")]
        public string LibDir
        {
            get { return _job.LibDir; }
            set { _job.LibDir = value; }
        }

        #endregion

        public NewAzureHDInsightSqoopJobDefinitionCommand()
        {
            Files = new string[] { };
            _job = new AzureHDInsightSqoopJobDefinition();
        }

        public override void ExecuteCmdlet()
        {
            var sqoopJob = GetSqoopJob();

            WriteObject(sqoopJob);
        }

        public AzureHDInsightSqoopJobDefinition GetSqoopJob()
        {
            foreach (var file in Files)
            {
                _job.Files.Add(file);
            }
            return _job;
        }
    }
}
