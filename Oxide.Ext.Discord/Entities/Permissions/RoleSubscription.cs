using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#role-subscription-data-object-role-subscription-data-object-structure">Role Subscription Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RoleSubscription
    {
        /// <summary>
        /// The id of the sku and listing that the user is subscribed to
        /// </summary>
        [JsonProperty("role_subscription_listing_id")]
        public Snowflake RoleSubscriptionListingId { get; set; }
        
        /// <summary>
        /// The name of the tier that the user is subscribed to
        /// </summary>
        [JsonProperty("tier_name")]
        public string TierName { get; set; }
        
        /// <summary>
        /// The cumulative number of months that the user has been subscribed for
        /// </summary>
        [JsonProperty("total_months_subscribed")]
        public int TotalMonthsSubscribed { get; set; }
        
        /// <summary>
        /// Whether this notification is for a renewal rather than a new purchase
        /// </summary>
        [JsonProperty("is_renewal")]
        public bool IsRenewal { get; set; }
    }
}