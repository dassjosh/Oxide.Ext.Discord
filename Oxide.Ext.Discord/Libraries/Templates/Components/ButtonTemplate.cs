using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Template for Button Components
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ButtonTemplate : BaseComponentTemplate
    {
        /// <summary>
        /// Display label for the button
        /// </summary>
        [JsonProperty("Button Label")]
        public string Label { get; set; } = "Button Label";

        /// <summary>
        /// Emoji for the button
        /// </summary>
        [JsonProperty("Button Emoji")]
        public EmojiTemplate Emoji { get; set; } = new();

        /// <summary>
        /// <see cref="ButtonStyle"/> for the button
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("Button Style")]
        public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

        /// <summary>
        /// Command for the button. If <see cref="ButtonStyle.Link"/> then this will set the Url field; Else the CustomId field
        /// </summary>
        [JsonProperty("Button Command")]
        public string Command { get; set; } = "My Command";

        /// <summary>
        /// Should the button be on the same or new row
        /// </summary>
        [JsonProperty("Keep Button On Same Row")]
        public bool Inline { get; set; } = true;
        
        /// <summary>
        /// If the Button is enabled
        /// </summary>
        [JsonProperty("Button Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [JsonConstructor]
        public ButtonTemplate() : base(MessageComponentType.Button) { }

        /// <summary>
        /// Constructor without emoji
        /// </summary>
        /// <param name="label">Button Label</param>
        /// <param name="style"><see cref="ButtonStyle"/></param>
        /// <param name="command">Button Command</param>
        /// <param name="enabled">Is button enabled?</param>
        /// <param name="inline">Should the button be on the same row or a new row?</param>
        public ButtonTemplate(string label, ButtonStyle style, string command, bool enabled = true, bool inline = true) : this(label, style, command, null, enabled, inline) { }

        /// <summary>
        /// Constructor with emoji
        /// </summary>
        /// <param name="label">Button Label</param>
        /// <param name="style"><see cref="ButtonStyle"/></param>
        /// <param name="command">Button Command</param>
        /// <param name="emoji">Emoji for the button</param>
        /// <param name="enabled">Is button enabled?</param>
        /// <param name="inline">Should the button be on the same row or a new row?</param>
        public ButtonTemplate(string label, ButtonStyle style, string command, string emoji, bool enabled = true, bool inline = true) : this()
        {
            Label = label;
            Style = style;
            Command = command;
            Emoji = new EmojiTemplate
            {
                Emoji = emoji
            };
            Enabled = enabled;
            Inline = inline;
        }

        /// <summary>
        /// Converts the template to a <see cref="ButtonComponent"/>
        /// </summary>
        /// <returns></returns>
        public override BaseComponent ToComponent(PlaceholderData data)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            string command = placeholders.ProcessPlaceholders(Command, data);
            if (string.IsNullOrEmpty(command))
            {
                return null;
            }

            data?.IncrementDepth();
            ButtonComponent button = new()
            {
                Label = placeholders.ProcessPlaceholders(Label, data),
                Style = Style,
                Disabled = !Enabled,
                Emoji = Emoji?.ToEmoji()
            };

            if (Style == ButtonStyle.Link)
            {
                button.Url = command;
            }
            else
            {
                button.CustomId = command;
            }
            
            data?.DecrementDepth();
            data?.AutoDispose();

            return button;
        }
    }
}