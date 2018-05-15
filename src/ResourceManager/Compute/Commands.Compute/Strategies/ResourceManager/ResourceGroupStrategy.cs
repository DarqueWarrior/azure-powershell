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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.ResourceManager
{
    static class ResourceGroupStrategy
    {
        public static ResourceStrategy<ResourceGroup> Strategy { get; }
            = ResourceStrategy.Create(
                ResourceType.ResourceGroup,
                (ResourceManagementClient client) => client.ResourceGroups,
                (o, p) => o.GetAsync(p.Name, p.CancellationToken),
                (o, p) 
                    => o.CreateOrUpdateAsync(p.Name, p.Model, p.CancellationToken),
                model => model.Location,
                (model, location) => model.Location = location,
                _ => 3,
                false);

        public static ResourceConfig<ResourceGroup> CreateResourceGroupConfig(string name)
            => Strategy.CreateResourceConfig(null, name);
    }
}
