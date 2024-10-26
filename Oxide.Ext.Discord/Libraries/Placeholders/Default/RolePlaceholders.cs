using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordRole"/> placeholders
    /// </summary>
    public static class RolePlaceholders
    {
        /// <summary>
        /// <see cref="DiscordRole.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(DiscordRole role) => role.Id;
        
        /// <summary>
        /// <see cref="DiscordRole.Name"/> placeholder
        /// </summary>
        public static string Name(DiscordRole role) => role.Name;
        
        /// <summary>
        /// <see cref="DiscordRole.Mention"/> placeholder
        /// </summary>
        public static string Mention(DiscordRole role) => role.Mention;
        
        /// <summary>
        /// <see cref="DiscordRole.Icon"/> placeholder
        /// </summary>
        public static string Icon(DiscordRole role) => role.Icon;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Role, new PlaceholderDataKey(nameof(DiscordRole)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, RoleKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordRole, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordRole, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<DiscordRole, string>(plugin, keys.Mention, dataKey, Mention);
            placeholders.RegisterPlaceholder<DiscordRole, string>(plugin, keys.Icon, dataKey, Icon);
        }
    }
}