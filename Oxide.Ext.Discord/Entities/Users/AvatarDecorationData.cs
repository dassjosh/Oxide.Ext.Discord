using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/user#avatar-decoration-data-object-avatar-decoration-data-structure">Avatar Decoration Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AvatarDecorationData
    {
        /// <summary>
        /// The avatar decoration hash
        /// </summary>
        [JsonProperty("asset")]
        public string Asset { get; set; }
        
        /// <summary>
        /// Id of the avatar decoration's SKU
        /// </summary>
        [JsonProperty("sku_id")]
        public Snowflake SkuId { get; set; }
    }
}