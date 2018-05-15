﻿// -----------------------------------------------------------------------------
﻿//
﻿// Copyright Microsoft Corporation
﻿// Licensed under the Apache License, Version 2.0 (the "License");
﻿// you may not use this file except in compliance with the License.
﻿// You may obtain a copy of the License at
﻿// http://www.apache.org/licenses/LICENSE-2.0
﻿// Unless required by applicable law or agreed to in writing, software
﻿// distributed under the License is distributed on an "AS IS" BASIS,
﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
﻿// See the License for the specific language governing permissions and
﻿// limitations under the License.
﻿// -----------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Azure.Batch;
    
    
    public partial class PSJobReleaseTask
    {
        
        internal JobReleaseTask omObject;
        
        private PSTaskContainerSettings containerSettings;
        
        private IList<PSEnvironmentSetting> environmentSettings;
        
        private IList<PSResourceFile> resourceFiles;
        
        private PSUserIdentity userIdentity;
        
        public PSJobReleaseTask()
        {
            omObject = new JobReleaseTask();
        }
        
        public PSJobReleaseTask(string commandLine)
        {
            omObject = new JobReleaseTask(commandLine);
        }
        
        internal PSJobReleaseTask(JobReleaseTask omObject)
        {
            if (omObject == null)
            {
                throw new ArgumentNullException("omObject");
            }
            this.omObject = omObject;
        }
        
        public string CommandLine
        {
            get
            {
                return omObject.CommandLine;
            }
            set
            {
                omObject.CommandLine = value;
            }
        }
        
        public PSTaskContainerSettings ContainerSettings
        {
            get
            {
                if (containerSettings == null 
                    && omObject.ContainerSettings != null)
                {
                    containerSettings = new PSTaskContainerSettings(omObject.ContainerSettings);
                }
                return containerSettings;
            }
            set
            {
                if (value == null)
                {
                    omObject.ContainerSettings = null;
                }
                else
                {
                    omObject.ContainerSettings = value.omObject;
                }
                containerSettings = value;
            }
        }
        
        public IList<PSEnvironmentSetting> EnvironmentSettings
        {
            get
            {
                if (environmentSettings == null 
                    && omObject.EnvironmentSettings != null)
                {
                    List<PSEnvironmentSetting> list;
                    list = new List<PSEnvironmentSetting>();
                    IEnumerator<EnvironmentSetting> enumerator;
                    enumerator = omObject.EnvironmentSettings.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        list.Add(new PSEnvironmentSetting(enumerator.Current));
                    }
                    environmentSettings = list;
                }
                return environmentSettings;
            }
            set
            {
                if (value == null)
                {
                    omObject.EnvironmentSettings = null;
                }
                else
                {
                    omObject.EnvironmentSettings = new List<EnvironmentSetting>();
                }
                environmentSettings = value;
            }
        }
        
        public string Id
        {
            get
            {
                return omObject.Id;
            }
            set
            {
                omObject.Id = value;
            }
        }
        
        public TimeSpan? MaxWallClockTime
        {
            get
            {
                return omObject.MaxWallClockTime;
            }
            set
            {
                omObject.MaxWallClockTime = value;
            }
        }
        
        public IList<PSResourceFile> ResourceFiles
        {
            get
            {
                if (resourceFiles == null 
                    && omObject.ResourceFiles != null)
                {
                    List<PSResourceFile> list;
                    list = new List<PSResourceFile>();
                    IEnumerator<ResourceFile> enumerator;
                    enumerator = omObject.ResourceFiles.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        list.Add(new PSResourceFile(enumerator.Current));
                    }
                    resourceFiles = list;
                }
                return resourceFiles;
            }
            set
            {
                if (value == null)
                {
                    omObject.ResourceFiles = null;
                }
                else
                {
                    omObject.ResourceFiles = new List<ResourceFile>();
                }
                resourceFiles = value;
            }
        }
        
        public TimeSpan? RetentionTime
        {
            get
            {
                return omObject.RetentionTime;
            }
            set
            {
                omObject.RetentionTime = value;
            }
        }
        
        public PSUserIdentity UserIdentity
        {
            get
            {
                if (userIdentity == null 
                    && omObject.UserIdentity != null)
                {
                    userIdentity = new PSUserIdentity(omObject.UserIdentity);
                }
                return userIdentity;
            }
            set
            {
                if (value == null)
                {
                    omObject.UserIdentity = null;
                }
                else
                {
                    omObject.UserIdentity = value.omObject;
                }
                userIdentity = value;
            }
        }
    }
}
