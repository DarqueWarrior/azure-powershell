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
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// NetworkSecurityGroup resource.
    /// </summary>
    [JsonTransformation]
    public partial class NetworkSecurityGroup : Resource
    {
        /// <summary>
        /// Initializes a new instance of the NetworkSecurityGroup class.
        /// </summary>
        public NetworkSecurityGroup()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NetworkSecurityGroup class.
        /// </summary>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="location">Resource location.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="securityRules">A collection of security rules of the
        /// network security group.</param>
        /// <param name="defaultSecurityRules">The default security rules of
        /// network security group.</param>
        /// <param name="networkInterfaces">A collection of references to
        /// network interfaces.</param>
        /// <param name="subnets">A collection of references to
        /// subnets.</param>
        /// <param name="resourceGuid">The resource GUID property of the
        /// network security group resource.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// public IP resource. Possible values are: 'Updating', 'Deleting',
        /// and 'Failed'.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public NetworkSecurityGroup(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), IList<SecurityRule> securityRules = default(IList<SecurityRule>), IList<SecurityRule> defaultSecurityRules = default(IList<SecurityRule>), IList<NetworkInterface> networkInterfaces = default(IList<NetworkInterface>), IList<Subnet> subnets = default(IList<Subnet>), string resourceGuid = default(string), string provisioningState = default(string), string etag = default(string))
            : base(id, name, type, location, tags)
        {
            SecurityRules = securityRules;
            DefaultSecurityRules = defaultSecurityRules;
            NetworkInterfaces = networkInterfaces;
            Subnets = subnets;
            ResourceGuid = resourceGuid;
            ProvisioningState = provisioningState;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a collection of security rules of the network security
        /// group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.securityRules")]
        public IList<SecurityRule> SecurityRules { get; set; }

        /// <summary>
        /// Gets or sets the default security rules of network security group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.defaultSecurityRules")]
        public IList<SecurityRule> DefaultSecurityRules { get; set; }

        /// <summary>
        /// Gets a collection of references to network interfaces.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkInterfaces")]
        public IList<NetworkInterface> NetworkInterfaces { get; private set; }

        /// <summary>
        /// Gets a collection of references to subnets.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnets")]
        public IList<Subnet> Subnets { get; private set; }

        /// <summary>
        /// Gets or sets the resource GUID property of the network security
        /// group resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the public IP resource.
        /// Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets a unique read-only string that changes whenever the
        /// resource is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

    }
}
