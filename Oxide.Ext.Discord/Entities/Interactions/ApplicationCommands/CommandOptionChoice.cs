using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-choice-structure">ApplicationCommandOptionChoice</a>
    /// If you specify choices for an option, they are the only valid values for a user to pick
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandOptionChoice
    {
        /// <summary>
        /// Choice name (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Localization dictionary for the name field. Values follow the same restrictions as name
        /// </summary>
        [JsonProperty("name_localizations")]
        public Hash<string, string> NameLocalizations { get; set; }
        
        /// <summary>
        /// Type can be string, integer, double or boolean
        /// Value of the choice, up to 100 characters if string
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        [JsonConstructor]
        public CommandOptionChoice() { }

        /// <summary>
        /// Creates a Command Option Choice
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <param name="nameLocalizations">Name localizations for the choice</param>
        public CommandOptionChoice(string name, object value, Hash<string, string> nameLocalizations = null)
        {
            Name = name;
            Value = value;
            NameLocalizations = nameLocalizations;
        }
    }
}