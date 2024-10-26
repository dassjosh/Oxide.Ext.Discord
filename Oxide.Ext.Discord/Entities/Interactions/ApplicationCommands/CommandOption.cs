using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-structure">ApplicationCommandOption</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandOption
    {
        /// <summary>
        /// Type of option
        /// See <see cref="CommandOptionType"/>
        /// </summary>
        [JsonProperty("type")]
        public CommandOptionType Type { get; set; }
        
        /// <summary>
        /// Name of the command option (1-32 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Localization dictionary for the name field. Values follow the same restrictions as name
        /// </summary>
        [JsonProperty("name_localizations")]
        public Hash<string, string> NameLocalizations { get; set; }
        
        /// <summary>
        /// Description the command option (1-100 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Localization dictionary for the description field. Values follow the same restrictions as description
        /// </summary>
        [JsonProperty("description_localizations")]
        public Hash<string, string> DescriptionLocalizations { get; set; }

        /// <summary>
        /// If the parameter is required or optional
        /// Defaults to false
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }

        /// <summary>
        /// Choices for STRING, INTEGER, and NUMBER types for the user to pick from, max 25
        /// See <see cref="CommandOptionChoice"/>
        /// </summary>
        [JsonProperty("choices")]
        public List<CommandOptionChoice> Choices { get; set; }
        
        /// <summary>
        /// If the option is a subcommand or subcommand group type, these nested options will be the parameters
        /// See <see cref="CommandOption"/>
        /// </summary>
        [JsonProperty("options")]
        public List<CommandOption> Options { get; set; }
        
        /// <summary>
        /// If the option is a channel type, the channels shown will be restricted to these types
        /// See <see cref="ChannelType"/>
        /// </summary>
        [JsonProperty("channel_types")]
        public List<ChannelType> ChannelTypes { get; set; }
        
        /// <summary>
        /// If the option is an INTEGER or NUMBER type, the minimum value permitted
        /// </summary>
        [JsonProperty("min_value")]
        public double? MinValue { get; set; }
        
        /// <summary>
        /// If the option is an INTEGER or NUMBER type, the maximum value permitted
        /// </summary>
        [JsonProperty("max_value")]
        public double? MaxValue { get; set; }
        
        /// <summary>
        /// For option type STRING, the minimum allowed length (minimum of 0)
        /// </summary>
        [JsonProperty("min_length")]
        public int? MinLength { get; set; }
        
        /// <summary>
        /// For option type STRING, the maximum allowed length (minimum of 1)
        /// </summary>
        [JsonProperty("max_length")]
        public int? MaxLength { get; set; }
        
        /// <summary>
        /// If autocomplete interactions are enabled for this `STRING`, `INTEGER`, or `NUMBER` type option
        /// </summary>
        [JsonProperty("autocomplete")]
        public bool? Autocomplete { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public CommandOption() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public CommandOption(string name, string description, CommandOptionType type, List<CommandOption> options = null)
        {
            Name = name;
            Description = description;
            Type = type;
            Options = options;
            NameLocalizations = new Hash<string, string>();
            DescriptionLocalizations = new Hash<string, string>();
        }
    }
}