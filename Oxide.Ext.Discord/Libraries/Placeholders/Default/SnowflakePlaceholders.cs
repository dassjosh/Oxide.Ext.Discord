using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="Snowflake"/> placeholders
    /// </summary>
    public static class SnowflakePlaceholders
    {
        /// <summary>
        /// <see cref="Snowflake.GetCreationDate"/> placeholder
        /// </summary>
        public static DateTimeOffset Created(Snowflake id) => id.GetCreationDate();

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Snowflake, new PlaceholderDataKey(nameof(Snowflake)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, SnowflakeKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<Snowflake>(plugin, keys.Id, dataKey);
            placeholders.RegisterPlaceholder<Snowflake, DateTimeOffset>(plugin, keys.Created, dataKey, Created);
        }
    }
}