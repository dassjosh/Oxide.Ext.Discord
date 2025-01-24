using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-call-object">Message Call Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BaseInteractionMetadata
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
        /// User who triggered the interaction
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// IDs for installation context(s) related to an interaction. Details in Authorizing Integration Owners Object
        /// </summary>
        [JsonProperty("authorizing_integration_owners")]
        public Hash<ApplicationIntegrationType, Snowflake> AuthorizingIntegrationOwners { get; set; }
        
        /// <summary>
        /// ID of the original response message, present only on follow-up messages
        /// </summary>
        [JsonProperty("original_response_message_id")]
        public Snowflake? OriginalResponseMessageId { get; set; }
    }
}