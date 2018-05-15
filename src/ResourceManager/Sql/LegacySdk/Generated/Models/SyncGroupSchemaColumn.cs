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
    /// Represents the simple schema of a column in table.
    /// </summary>
    public partial class SyncGroupSchemaColumn
    {
        private string _dataSize;
        
        /// <summary>
        /// Optional. The data size of the column.
        /// </summary>
        public string DataSize
        {
            get { return _dataSize; }
            set { _dataSize = value; }
        }
        
        private string _dataType;
        
        /// <summary>
        /// Optional. The data type of the column.
        /// </summary>
        public string DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }
        
        private string _quotedName;
        
        /// <summary>
        /// Optional. The quoted name of the column in schema table.
        /// </summary>
        public string QuotedName
        {
            get { return _quotedName; }
            set { _quotedName = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the SyncGroupSchemaColumn class.
        /// </summary>
        public SyncGroupSchemaColumn()
        {
        }
    }
}
