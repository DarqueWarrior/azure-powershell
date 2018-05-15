﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSProbe : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public List<PSResourceId> LoadBalancingRules { get; set; }

        [JsonProperty(Order = 1)]
        public string Protocol { get; set; }

        [JsonProperty(Order = 1)]
        public int Port { get; set; }

        [JsonProperty(Order = 1)]
        public int IntervalInSeconds { get; set; }

        [JsonProperty(Order = 1)]
        public int NumberOfProbes { get; set; }

        [JsonProperty(Order = 1)]
        public string RequestPath { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string LoadBalancingRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancingRules, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializePort()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public bool ShouldSerializeIntervalInSeconds()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public bool ShouldSerializeNumberOfProbes()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
}
