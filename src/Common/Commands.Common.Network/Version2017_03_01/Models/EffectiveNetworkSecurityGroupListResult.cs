// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Internal.Network.Version2017_03_01.Models
{
    using Azure;
    using Management;
    using Internal;
    using Network;
    using Version2017_03_01;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Response for list effective network security groups API service call.
    /// </summary>
    public partial class EffectiveNetworkSecurityGroupListResult
    {
        /// <summary>
        /// Initializes a new instance of the
        /// EffectiveNetworkSecurityGroupListResult class.
        /// </summary>
        public EffectiveNetworkSecurityGroupListResult()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// EffectiveNetworkSecurityGroupListResult class.
        /// </summary>
        /// <param name="value">A list of effective network security
        /// groups.</param>
        /// <param name="nextLink">The URL to get the next set of
        /// results.</param>
        public EffectiveNetworkSecurityGroupListResult(IList<EffectiveNetworkSecurityGroup> value = default(IList<EffectiveNetworkSecurityGroup>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a list of effective network security groups.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<EffectiveNetworkSecurityGroup> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of results.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
