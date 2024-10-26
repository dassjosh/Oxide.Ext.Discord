using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a Base Interaction Response with generic data {T}
    /// </summary>
    /// <typeparam name="T">{T} data type</typeparam>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class BaseInteractionResponse<T> : BaseInteractionResponse
    {
        /// <summary>
        /// Response to the Interaction
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseInteractionResponse() { }

        /// <summary>
        /// Constructor with Data and response type
        /// </summary>
        /// <param name="type">Response type for the interaction</param>
        /// <param name="data">Data for the interaction</param>
        protected BaseInteractionResponse(InteractionResponseType type, T data) : base(type)
        {
            Data = data;
        }
    }
}