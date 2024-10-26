using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-interaction-metadata-object-message-interaction-metadata-structure">Message Interaction Metadata Structure</a> within Discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageInteractionMetadata
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
        /// IUser who triggered the interaction
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// IDs for installation context(s) related to an interaction.
        /// </summary>
        [JsonProperty("authorizing_integration_owners")]
        public Hash<ApplicationIntegrationType, Snowflake> AuthorizingIntegrationOwners { get; set; }
        
        /// <summary>
        /// ID of the original response message, present only on follow-up messages
        /// </summary>
        [JsonProperty("original_response_message_id")]
        public Snowflake? OriginalResponseMessageId { get; set; }
        
        /// <summary>
        /// ID of the message that contained interactive component, present only on messages created from component interactions
        /// </summary>
        [JsonProperty("interacted_message_id")]
        public Snowflake? InteractedMessageId { get; set; }
        
        /// <summary>
        /// Metadata for the interaction that was used to open the modal, present only on modal submit interactions
        /// </summary>
        [JsonProperty("triggering_interaction_metadata")]
        public MessageInteractionMetadata TriggeringInteractionMetadata { get; set; }
    }
}