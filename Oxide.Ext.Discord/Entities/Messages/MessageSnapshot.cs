using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-snapshot-object">Message Snapshot</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageSnapshot
    {
        /// <summary>
        /// Subset of fields in the message object
        /// </summary>
        [JsonProperty("message")]
        public DiscordMessage Message  { get; set; }
        
        /// <summary>
        /// ID of the origin message's guild
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId  { get; set; }
    }
}