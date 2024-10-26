using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-response-object">Interaction Callback Response</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionCallbackResponse
    {
        /// <summary>
        /// The interaction object associated with the response
        /// </summary>
        [JsonProperty("interaction")]
        public InteractionCallback interaction { get; set; }
    
        /// <summary>
        /// The resource that was created by the interaction response.
        /// </summary>
        [JsonProperty("resource")]
        public InteractionResource resource { get; set; }
    }
}