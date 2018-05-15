// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Graph.RBAC.Version1_6.Models
{
    using Azure;
    using Graph;
    using RBAC;
    using Version1_6;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Request parameters for IsMemberOf API call.
    /// </summary>
    public partial class CheckGroupMembershipParameters
    {
        /// <summary>
        /// Initializes a new instance of the CheckGroupMembershipParameters
        /// class.
        /// </summary>
        public CheckGroupMembershipParameters()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CheckGroupMembershipParameters
        /// class.
        /// </summary>
        /// <param name="groupId">The object ID of the group to check.</param>
        /// <param name="memberId">The object ID of the contact, group, user,
        /// or service principal to check for membership in the specified
        /// group.</param>
        public CheckGroupMembershipParameters(string groupId, string memberId)
        {
            GroupId = groupId;
            MemberId = memberId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the object ID of the group to check.
        /// </summary>
        [JsonProperty(PropertyName = "groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the object ID of the contact, group, user, or service
        /// principal to check for membership in the specified group.
        /// </summary>
        [JsonProperty(PropertyName = "memberId")]
        public string MemberId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (GroupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "GroupId");
            }
            if (MemberId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "MemberId");
            }
        }
    }
}
