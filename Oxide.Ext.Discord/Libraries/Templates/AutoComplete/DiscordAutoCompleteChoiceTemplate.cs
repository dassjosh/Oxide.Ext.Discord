using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Template for Discord Auto Completes
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordAutoCompleteChoiceTemplate
    {
        /// <summary>
        /// Choice Text (1-100 characters)
        /// </summary>
        [JsonProperty("Choice Text")]
        public string Name { get; set; }

        /// <summary>
        /// Apply localizations to the auto complete choice
        /// </summary>
        /// <param name="locale">DiscordLocale being applied</param>
        /// <param name="choice">Choice to apply the template to</param>
        /// <param name="data">Placeholders for be applied</param>
        public void ApplyLocalization(DiscordLocale locale, CommandOptionChoice choice, PlaceholderData data = null)
        {
            string name = DiscordPlaceholders.Instance.ProcessPlaceholders(Name, data);
            choice.NameLocalizations[locale.Id] = name.TrimIfLargerThan(100);
        }
        
        /// <summary>
        /// Apply the name to the auto complete choice
        /// </summary>
        /// <param name="choice">Choice to apply the template to</param>
        /// <param name="data">Placeholders for be applied</param>
        public void ApplyName(CommandOptionChoice choice, PlaceholderData data = null)
        {
            string name = DiscordPlaceholders.Instance.ProcessPlaceholders(Name, data);
            choice.Name = name.TrimIfLargerThan(100);
        }
    }
}