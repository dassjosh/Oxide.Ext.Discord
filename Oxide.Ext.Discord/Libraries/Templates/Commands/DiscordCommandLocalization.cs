using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Command Localizations for Application Commands
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordCommandLocalization
    {
        /// <summary>
        /// Localized Command
        /// </summary>
        [JsonProperty("Command Localization")]
        public CommandLocalization Command { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        [JsonConstructor]
        private DiscordCommandLocalization() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command to create the localization for</param>
        /// <param name="locale">Oxide Lang for the command</param>
        public DiscordCommandLocalization(CommandCreate command, ServerLocale locale)
        {
            Command = new CommandLocalization(command, locale.GetDiscordLocale());
        }

        /// <summary>
        /// Apply localizations to <see cref="CommandCreate"/> for language
        /// </summary>
        /// <param name="create"></param>
        /// <param name="locale"></param>
        public void ApplyCommandLocalization(CommandCreate create, DiscordLocale locale)
        {
            Command.ApplyCommandLocalization(create, locale);
        }
    }
}