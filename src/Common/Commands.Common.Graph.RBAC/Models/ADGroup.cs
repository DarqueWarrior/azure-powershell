// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Graph.RBAC.Version1_6.Models
{
    using Azure;
    using Graph;
    using RBAC;
    using Version1_6;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Active Directory group information.
    /// </summary>
    public partial class ADGroup
    {
        /// <summary>
        /// Initializes a new instance of the ADGroup class.
        /// </summary>
        public ADGroup()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ADGroup class.
        /// </summary>
        /// <param name="objectId">The object ID.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="displayName">The display name of the group.</param>
        /// <param name="securityEnabled">Whether the group is
        /// security-enable.</param>
        /// <param name="mail">The primary email address of the group.</param>
        public ADGroup(string objectId = default(string), string objectType = default(string), string displayName = default(string), bool? securityEnabled = default(bool?), string mail = default(string))
        {
            ObjectId = objectId;
            ObjectType = objectType;
            DisplayName = displayName;
            SecurityEnabled = securityEnabled;
            Mail = mail;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the object ID.
        /// </summary>
        [JsonProperty(PropertyName = "objectId")]
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [JsonProperty(PropertyName = "objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the display name of the group.
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets whether the group is security-enable.
        /// </summary>
        [JsonProperty(PropertyName = "securityEnabled")]
        public bool? SecurityEnabled { get; set; }

        /// <summary>
        /// Gets or sets the primary email address of the group.
        /// </summary>
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

    }
}
