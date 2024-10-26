using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/topics/gateway#integration-create-integration-create-event-additional-fields">Integration Create Structure</a> 
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class IntegrationCreatedEvent : Integration
    {
        /// <summary>
        /// Guild Id the Integration was created in
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
    }
}