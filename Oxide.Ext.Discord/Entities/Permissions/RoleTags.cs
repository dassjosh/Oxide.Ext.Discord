using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/permissions#role-object-role-tags-structure">Role Tags Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(RoleTagsConverter))]
    public class RoleTags
    {
        /// <summary>
        /// The id of the bot this role belongs to
        /// </summary>
        [JsonProperty("bot_id")]
        public Snowflake? BotId { get; set; }
        
        /// <summary>
        /// The id of the integration this role belongs to
        /// </summary>
        [JsonProperty("integration_id")]
        public Snowflake? IntegrationId { get; set; }
        
        /// <summary>
        /// Whether this is the guild's premium subscriber role
        /// </summary>
        [JsonProperty("premium_subscriber")]
        public bool PremiumSubscriber { get; set; }
        
        /// <summary>
        /// The id of this role's subscription sku and listing
        /// </summary>
        [JsonProperty("subscription_listing_id")]
        public Snowflake? SubscriptionListingId { get; set; }
        
        /// <summary>
        /// whether this role is available for purchase
        /// </summary>
        [JsonProperty("available_for_purchase")]
        public bool AvailableForPurchase { get; set; }
        
        /// <summary>
        /// Whether this role is a guild's linked role
        /// </summary>
        [JsonProperty("guild_connections")]
        public bool GuildConnections { get; set; }
    }
}