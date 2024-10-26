using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a Base Interaction response
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class BaseInteractionResponse
    {
        /// <summary>
        /// The type of response
        /// </summary>
        [JsonProperty("type")]
        public InteractionResponseType Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseInteractionResponse() {}

        /// <summary>
        /// Constructor with <see cref="InteractionResponseType"/>
        /// </summary>
        /// <param name="type"></param>
        protected BaseInteractionResponse(InteractionResponseType type)
        {
            Type = type;
        }
    }
}