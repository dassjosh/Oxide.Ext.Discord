using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordApplicationCommand"/> placeholders
    /// </summary>
    public static class ApplicationCommandPlaceholders
    {
        /// <summary>
        /// <see cref="DiscordApplicationCommand.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(DiscordApplicationCommand command) => command.Id;

        /// <summary>
        /// <see cref="DiscordApplicationCommand.Name"/> placeholder
        /// </summary>
        public static string Name(DiscordApplicationCommand command) => command.Name;
        
        /// <summary>
        /// <see cref="DiscordApplicationCommand.Mention"/> placeholder
        /// </summary>
        public static string Mention(DiscordApplicationCommand command) => command.Mention;
        
        /// <summary>
        /// <see cref="DiscordApplicationCommand.MentionCustom"/> placeholder
        /// </summary>
        public static string MentionCustom(PlaceholderState state, DiscordApplicationCommand command) => command.MentionCustom(state.Format);
        
        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.AppCommand, new PlaceholderDataKey(nameof(DiscordApplicationCommand)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, AppCommandKeys keys , PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordApplicationCommand, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordApplicationCommand, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<DiscordApplicationCommand, string>(plugin, keys.Mention, dataKey, Mention);
            placeholders.RegisterPlaceholder<DiscordApplicationCommand, string>(plugin, keys.MentionCustom, dataKey, MentionCustom);
        }
    }
}