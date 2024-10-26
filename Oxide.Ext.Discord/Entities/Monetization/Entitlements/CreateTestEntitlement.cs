using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/entitlements#create-test-entitlement-json-params">Create Test Entitlement Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CreateTestEntitlement
    {
        /// <summary>
        /// ID of the SKU to grant the entitlement to
        /// </summary>
        [JsonProperty("sku_id")]
        public Snowflake SkuId { get; set; }
        
        /// <summary>
        /// ID of the guild or user to grant the entitlement to
        /// </summary>
        [JsonProperty("owner_id")]
        public Snowflake OwnerId { get; set; }
        
        /// <summary>
        /// ID of the guild or user to grant the entitlement to
        /// </summary>
        [JsonProperty("owner_type")]
        public EntitlementOwnerType OwnerType { get; set; }
    }
}