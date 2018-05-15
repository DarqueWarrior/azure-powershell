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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPacketCaptureStatus
    {
        public DateTime? CaptureStartTime { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> PacketCaptureError { get; set; }

        public string PacketCaptureStatus { get; set; }

        public string StopReason { get; set; }

        [JsonIgnore]
        public string PacketCaptureErrorText
        {
            get { return JsonConvert.SerializeObject(PacketCaptureError, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
