// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Internal.Network.Version2017_03_01
{
    using Azure;
    using Management;
    using Internal;
    using Network;
    using Rest;
    using Rest.Azure;
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Composite Swagger for Network Client
    /// </summary>
    public partial interface INetworkManagementClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft
        /// Azure subscription. The subscription ID forms part of the URI for
        /// every service call.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running
        /// Operations. Default value is 30.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated
        /// and included in each request. Default is true.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }


        /// <summary>
        /// Gets the ILoadBalancersOperations.
        /// </summary>
        ILoadBalancersOperations LoadBalancers { get; }

        /// <summary>
        /// Gets the INetworkInterfacesOperations.
        /// </summary>
        INetworkInterfacesOperations NetworkInterfaces { get; }

        /// <summary>
        /// Gets the IPublicIPAddressesOperations.
        /// </summary>
        IPublicIPAddressesOperations PublicIPAddresses { get; }

    }
}
