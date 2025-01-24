using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-call-object">Application Command Interaction Metadata</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageComponentInteractionMetadata : BaseInteractionMetadata
    {
        /// <summary>
        /// ID of the message that contained the interactive component
        /// </summary>
        [JsonProperty("interacted_message_id")]
        public Snowflake? InteractedMessageId { get; set; }
    }
}