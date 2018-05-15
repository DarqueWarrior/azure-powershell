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
using Microsoft.Azure;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Management.Sql.LegacySdk.Models
{
    /// <summary>
    /// Response for long running Azure Sql Database operations.
    /// </summary>
    public partial class DatabaseCreateOrUpdateResponse : AzureOperationResponse
    {
        private Database _database;
        
        /// <summary>
        /// Optional. Gets or sets Database object that represents the Azure
        /// Sql Database.
        /// </summary>
        public Database Database
        {
            get { return _database; }
            set { _database = value; }
        }
        
        private ErrorResponse _error;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public ErrorResponse Error
        {
            get { return _error; }
            set { _error = value; }
        }
        
        private string _operationStatusLink;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string OperationStatusLink
        {
            get { return _operationStatusLink; }
            set { _operationStatusLink = value; }
        }
        
        private int _retryAfter;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int RetryAfter
        {
            get { return _retryAfter; }
            set { _retryAfter = value; }
        }
        
        private OperationStatus _status;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public OperationStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the DatabaseCreateOrUpdateResponse
        /// class.
        /// </summary>
        public DatabaseCreateOrUpdateResponse()
        {
        }
    }
}
