using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Localization for Application Command Arguments
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ArgumentLocalization
    {
        /// <summary>
        /// Localization for <see cref="CommandOption.Name"/>
        /// </summary>
        [JsonProperty("Argument Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Localization for <see cref="CommandOption.Description"/>
        /// </summary>
        [JsonProperty("Argument Description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Localization for Select Menu Choices
        /// </summary>
        [JsonProperty("Argument Choices", NullValueHandling = NullValueHandling.Ignore)]
        public Hash<string, ChoicesLocalization> Choices { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        private ArgumentLocalization() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="option">Option to create the localization for</param>
        /// <param name="locale">The oxide lang for the localization</param>
        public ArgumentLocalization(CommandOption option, DiscordLocale locale)
        {
            Name = option.NameLocalizations[locale.Id];
            Description = option.DescriptionLocalizations[locale.Id];
            if (option.Choices != null)
            {
                Choices = new Hash<string, ChoicesLocalization>();
                for (int index = 0; index < option.Choices.Count; index++)
                {
                    CommandOptionChoice choice = option.Choices[index];
                    Choices[choice.Name] = new ChoicesLocalization(choice.Name);
                }
            }
        }

        /// <summary>
        /// Apply localizations to the command option
        /// </summary>
        /// <param name="option"></param>
        /// <param name="locale"></param>
        public void ApplyArgumentLocalization(CommandOption option, DiscordLocale locale)
        {
            option.NameLocalizations[locale.Id] = Name;
            option.DescriptionLocalizations[locale.Id] = Description;

            if (option.Choices != null)
            {
                for (int index = 0; index < option.Choices.Count; index++)
                {
                    CommandOptionChoice choice = option.Choices[index];
                    Choices?[choice.Name]?.ApplyChoiceLocalization(choice, locale);
                }
            }
        }
    }
}