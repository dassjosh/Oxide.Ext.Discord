using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-resource-object">Interaction Callback Resource</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionResource
    {
        /// <summary>
        /// The resource that was created by the interaction response.
        /// </summary>
        [JsonProperty("type")]
        public InteractionResponseType Type { get; set; }
    
        /// <summary>
        /// Represents the Activity launched by this interaction.
        /// </summary>
        [JsonProperty("activity_instance")]
        public InteractionCallbackActivityInstanceResource ActivityInstance { get; set; }
    
        /// <summary>
        /// Message created by the interaction.
        /// </summary>
        [JsonProperty("message")]
        public DiscordMessage Message { get; set; }
    }
}