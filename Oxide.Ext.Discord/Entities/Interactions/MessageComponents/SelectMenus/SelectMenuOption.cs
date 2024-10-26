using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-option-structure">Select Menu Option Structure</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SelectMenuOption : IDiscordValidation
    {
        /// <summary>
        /// User-facing name of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }
        
        /// <summary>
        /// Dev-define value of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        
        /// <summary>
        /// Additional description of the option,
        /// Max 100 characters
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Emoji in the option
        /// </summary>
        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }
        
        /// <summary>
        /// Will show this option as selected by default
        /// </summary>
        [JsonProperty("default")]
        public bool? Default { get; set; }

        ///<inheritdoc />
        public void Validate()
        {
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuOptionLabel(Label);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuOptionValue(Value);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuOptionDescription(Description);
        }
    }
}