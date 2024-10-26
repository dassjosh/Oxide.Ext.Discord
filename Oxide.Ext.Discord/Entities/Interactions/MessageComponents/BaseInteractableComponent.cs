using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represent a MessageComponent that can be interacted with
    /// </summary>
    public abstract class BaseInteractableComponent : BaseComponent
    {
        /// <summary>
        /// Developer-defined identifier for the interactable component
        /// Max 100 characters
        /// </summary>
        [JsonProperty("custom_id")]
        public string CustomId { get; set; }

        ///<inheritdoc />
        public override void Validate()
        {
            InvalidMessageComponentException.ThrowIfInvalidCustomId(CustomId);
        }
    }
}