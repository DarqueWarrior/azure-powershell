// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;

namespace Microsoft.Azure.Management.Sql.LegacySdk.Models
{
    /// <summary>
    /// Represents the properties of an Azure SQL Database Transparent Data
    /// Encryption Scan.
    /// </summary>
    public partial class TransparentDataEncryptionActivityProperties
    {
        private float _percentComplete;
        
        /// <summary>
        /// Optional. Gets the percent complete of the transparent data
        /// encryption scan for a Azure SQL Database.
        /// </summary>
        public float PercentComplete
        {
            get { return _percentComplete; }
            set { _percentComplete = value; }
        }
        
        private string _status;
        
        /// <summary>
        /// Optional. Gets the status of the Azure SQL Database.
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// TransparentDataEncryptionActivityProperties class.
        /// </summary>
        public TransparentDataEncryptionActivityProperties()
        {
        }
    }
}
