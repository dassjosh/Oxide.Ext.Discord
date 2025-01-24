using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-resolved-data-structure">Application Command Interaction Data Option</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionDataResolved
    {
        /// <summary>
        /// IDs and User objects
        /// </summary>
        [JsonProperty("users")]
        public Hash<Snowflake, DiscordUser> Users { get; set; }

        /// <summary>
        /// IDs and partial Member objects
        /// </summary>
        [JsonProperty("members")]
        public Hash<Snowflake, GuildMember> Members { get; set; }

        /// <summary>
        /// IDs and Role objects
        /// </summary>
        [JsonProperty("roles")]
        public Hash<Snowflake, DiscordRole> Roles { get; set; }

        /// <summary>
        /// IDs and partial Channel objects
        /// </summary>
        [JsonProperty("channels")]
        public Hash<Snowflake, DiscordChannel> Channels { get; set; }

        /// <summary>
        /// IDs and partial Message objects
        /// </summary>
        [JsonProperty("messages")]
        public Hash<Snowflake, DiscordMessage> Messages { get; set; }

        /// <summary>
        /// IDs and attachment objects
        /// </summary>
        [JsonProperty("attachments")]
        public Hash<Snowflake, MessageAttachment> Attachments { get; set; }
    }
}