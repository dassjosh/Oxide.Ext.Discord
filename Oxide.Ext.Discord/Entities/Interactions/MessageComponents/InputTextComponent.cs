using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#input-text">Input Text Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputTextComponent : BaseInteractableComponent
    {
        /// <summary>
        /// Style of the input text
        /// </summary>
        [JsonProperty("style")]
        public InputTextStyles Style { get; set; }
        
        /// <summary>
        /// Text that appears on top of the input text field, max 80 characters
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }
        
        /// <summary>
        /// Minimum length of the text input
        /// </summary>
        [JsonProperty("min_length")]
        public int? MinLength { get; set; }
        
        /// <summary>
        /// Maximum length of the text input
        /// </summary>
        [JsonProperty("max_length")]
        public int? MaxLength { get; set; }

        /// <summary>
        /// Whether this component is required to be filled
        /// defaults to true
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }
        
        /// <summary>
        /// Pre-filled value for text input
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        
        /// <summary>
        /// Custom placeholder text if the input is empty
        /// Max 100 characters
        /// </summary>
        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }

        /// <summary>
        /// Input Text Constructor
        /// </summary>
        public InputTextComponent()
        {
            Type = MessageComponentType.InputText;
        }

        ///<inheritdoc />
        public override void Validate()
        {
            base.Validate();
            InvalidMessageComponentException.ThrowIfInvalidTextInputLabel(Label);
            InvalidMessageComponentException.ThrowIfInvalidTextInputValue(Value);
            InvalidMessageComponentException.ThrowIfInvalidTextInputLength(MinLength, MaxLength);
        }
    }
}