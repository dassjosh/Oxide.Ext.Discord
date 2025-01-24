using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-call-object">Application Command Interaction Metadata</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationCommandInteractionMetadata : BaseInteractionMetadata
    {
        /// <summary>
        /// The user the command was run on, present only on user command interactions
        /// </summary>
        [JsonProperty("target_user")]
        public DiscordUser TargetUser { get; set; }
        
        /// <summary>
        ///  The ID of the message the command was run on, present only on message command interactions. The original response message will also have message_reference and referenced_message pointing to this message.
        /// </summary>
        [JsonProperty("target_message_id")]
        public Snowflake? TargetMessageId { get; set; }
    }
}