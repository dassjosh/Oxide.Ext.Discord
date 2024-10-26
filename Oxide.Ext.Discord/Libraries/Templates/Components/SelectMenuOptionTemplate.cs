using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Template for Select Menu Options
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SelectMenuOptionTemplate
    {
        /// <summary>
        /// The user-facing name of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("Label")]
        public string Label { get; set; } = string.Empty;
        
        /// <summary>
        /// The dev-define value of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("Value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// An additional description of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Emoji in the option
        /// </summary>
        [JsonProperty("Emoji")]
        public EmojiTemplate Emoji { get; set; }

        /// <summary>
        /// Will render this option as selected by default
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public SelectMenuOptionTemplate()
        {
            Emoji = new EmojiTemplate();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="emoji"></param>
        /// <param name="default"></param>
        public SelectMenuOptionTemplate(string label, string value, string description = "", EmojiTemplate emoji = null, bool @default = false)
        {
            Label = label;
            Value = value;
            Description = description;
            Emoji = emoji ?? new EmojiTemplate();
            Default = @default;
        }

        /// <summary>
        /// Converts the template to <see cref="SelectMenuOption"/>
        /// </summary>
        /// <param name="data"><see cref="PlaceholderData"/> to use</param>
        /// <returns><see cref="SelectMenuOption"/></returns>
        public SelectMenuOption ToOption(PlaceholderData data)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            data?.IncrementDepth();
            SelectMenuOption option = new()
            {
                Label = placeholders.ProcessPlaceholders(Label, data),
                Value = placeholders.ProcessPlaceholders(Value, data),
                Description = placeholders.ProcessPlaceholders(Description, data),
                Emoji = Emoji.ToEmoji(),
                Default = Default
            };
            data?.DecrementDepth();
            data?.AutoDispose();
            return option;
        }
    }
}