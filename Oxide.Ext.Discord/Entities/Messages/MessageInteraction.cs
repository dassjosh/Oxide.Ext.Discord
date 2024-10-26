using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#message-interaction-object">Message Interaction Structure</a> within Discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageInteraction
    {
        /// <summary>
        /// ID of the interaction
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Type of interaction
        /// </summary>
        [JsonProperty("type")]
        public InteractionType Type { get; set; }
        
        /// <summary>
        /// Name of the <see cref="DiscordApplicationCommand"/>, including subcommands and subcommand groups 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The user who invoked the interaction
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// Member who invoked the interaction in the guild
        /// </summary>
        [JsonProperty("member")]
        public GuildMember Member { get; set; }
    }
}