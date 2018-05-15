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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Application
{
    using Collections;
    using Newtonsoft.Json;

    /// <summary>
    /// The application definition object.
    /// </summary>
    public class ApplicationDefinition
    {
        /// <summary>
        /// The application defintion name.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the application definition location.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Location { get; set; }

        /// <summary>
        /// The application definition properties.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationDefinitionProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public InsensitiveDictionary<string> Tags { get; set; }
    }
}
