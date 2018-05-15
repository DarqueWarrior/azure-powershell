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

using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSDataset
    {
        private Dataset dataset;

        public PSDataset()
        {
            dataset = new Dataset { Properties = new DatasetProperties() };
        }

        public PSDataset(Dataset dataset)
        {
            if (dataset == null)
            {
                throw new ArgumentNullException("dataset");
            }

            if (dataset.Properties == null)
            {
                dataset.Properties = new DatasetProperties();
            }

            this.dataset = dataset;
        }

        public string DatasetName
        {
            get
            {
                return dataset.Name;
            }
            set
            {
                dataset.Name = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public Availability Availability
        {
            get
            {
                return dataset.Properties.Availability;
            }
            set
            {
                dataset.Properties.Availability = value;
            }
        }

        public DatasetTypeProperties Location
        {
            get
            {
                return dataset.Properties.TypeProperties;
            }
            set
            {
                dataset.Properties.TypeProperties = value;
            }
        }

        public Policy Policy
        {
            get
            {
                return dataset.Properties.Policy;
            }
            set
            {
                dataset.Properties.Policy = value;
            }
        }

        public IList<DataElement> Structure
        {
            get
            {
                return dataset.Properties.Structure;
            }
            set
            {
                dataset.Properties.Structure = value;
            }
        }

        public DatasetProperties Properties
        {
            get
            {
                return dataset.Properties;
            }
            set
            {
                dataset.Properties = value;
            }
        }

        public string ProvisioningState
        {
            get { return Properties == null ? string.Empty : Properties.ProvisioningState; }
        }
    }
}
