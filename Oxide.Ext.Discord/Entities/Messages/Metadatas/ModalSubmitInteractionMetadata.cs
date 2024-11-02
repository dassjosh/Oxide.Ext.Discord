using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-call-object">Message Component Interaction Metadata</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ModalSubmitInteractionMetadata : BaseInteractionMetadata
    {
        /// <summary>
        /// The ID of the message the command was run on, present only on message command interactions. The original response message will also have message_reference and referenced_message pointing to this message.
        /// </summary>
        [JsonConverter(typeof(InteractionMetadataConverter))]
        [JsonProperty("triggering_interaction_metadata")]
        public BaseInteractionMetadata TriggeringInteractionMetadata { get; set; }
    }
}