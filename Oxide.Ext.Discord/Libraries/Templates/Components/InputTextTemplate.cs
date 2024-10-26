using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Input Text Message Component Template
    /// </summary>
    public class InputTextTemplate : BaseComponentTemplate
    {
        /// <summary>
        /// Custom ID of the input text
        /// </summary>
        [JsonProperty("Input Text ID")]
        public string CustomId { get; set; } = string.Empty;
        
        /// <summary>
        /// The style of the input text
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("Input Text Style")]
        public InputTextStyles Style { get; set; } = InputTextStyles.Short;
        
        /// <summary>
        /// Text that appears on top of the input text field, max 80 characters
        /// </summary>
        [JsonProperty("Input Text Label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The minimum length of the text input
        /// </summary>
        [JsonProperty("Input Text Min Length")]
        public int MinLength { get; set; }
        
        /// <summary>
        /// The maximum length of the text input
        /// </summary>
        [JsonProperty("Input Text Max Length")]
        public int MaxLength { get; set; } = 4000;
        
        /// <summary>
        /// The placeholder for the text input field
        /// </summary>
        [JsonProperty("Input Text Placeholder")]
        public string Placeholder { get; set; } = string.Empty;

        /// <summary>
        /// The pre-filled value for text input
        /// </summary>
        [JsonProperty("Input Text Value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Is the Input Text Required to be filled out
        /// </summary>
        [JsonProperty("Input Text Required")]
        public bool Required { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public InputTextTemplate() : base(MessageComponentType.InputText) { }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label"></param>
        /// <param name="customId"></param>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="required"></param>
        /// <param name="placeholder"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        public InputTextTemplate(string label, string customId, string value = "", InputTextStyles style = InputTextStyles.Short, bool required = false, string placeholder = "", int minLength = 0, int maxLength = 4000) : this()
        {
            Label = label;
            CustomId = customId;
            Value = value;
            Style = style;
            Required = required;
            Placeholder = placeholder;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        /// <summary>
        /// Converts the template to a <see cref="InputTextComponent"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override BaseComponent ToComponent(PlaceholderData data)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            data?.IncrementDepth();
            InputTextComponent text = new()
            {
                Label = placeholders.ProcessPlaceholders(Label, data),
                Placeholder = placeholders.ProcessPlaceholders(Placeholder, data),
                Value = placeholders.ProcessPlaceholders(Value, data),
                Required = Required,
                Style = Style,
                MinLength = MinLength,
                MaxLength = MaxLength,
                CustomId = CustomId
            };
            data?.DecrementDepth();
            data?.AutoDispose();
            return text;
        }
    }
}