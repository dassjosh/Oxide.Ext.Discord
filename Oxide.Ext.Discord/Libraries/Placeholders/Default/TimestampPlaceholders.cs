using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Timestamp placeholders
    /// </summary>
    public static class TimestampPlaceholders
    {
        internal static readonly PlaceholderDataKey TimestampKey = new("Timestamp");
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string Timestamp(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string ShortTime(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.ShortTime);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string Longtime(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.LongTime);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string ShortDate(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.ShortDate);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string LongDate(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.LongDate);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string ShortDateTime(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string LongDateTime(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.LongDateTime);
        
        /// <summary>
        /// <see cref="DiscordFormatting.UnixTimestamp(long,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> placeholder
        /// </summary>
        public static string RelativeTime(long timestamp) => DiscordFormatting.UnixTimestamp(timestamp, TimestampStyles.RelativeTime);

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Timestamp, TimestampKey);
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.TimestampNow);
        }

        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, TimestampKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.Time, dataKey, Timestamp);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.ShortTime, dataKey, ShortTime);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.LongTime, dataKey, Longtime);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.ShortDate, dataKey, ShortDate);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.LongDate, dataKey, LongDate);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.ShortDateTime, dataKey, ShortDateTime);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.LongDateTime, dataKey, LongDateTime);
            placeholders.RegisterPlaceholder<long, string>(plugin, keys.RelativeTime, dataKey, RelativeTime);
        }

        private static void RegisterPlaceholders(Plugin plugin, TimestampKeys keys)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder(plugin, keys.Time, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow));
            placeholders.RegisterPlaceholder(plugin, keys.ShortTime, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.ShortTime));
            placeholders.RegisterPlaceholder(plugin, keys.LongTime, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.LongTime));
            placeholders.RegisterPlaceholder(plugin, keys.ShortDate, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.ShortDate));
            placeholders.RegisterPlaceholder(plugin, keys.LongDate, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.LongDate));
            placeholders.RegisterPlaceholder(plugin, keys.ShortDateTime, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.ShortDateTime));
            placeholders.RegisterPlaceholder(plugin, keys.LongDateTime, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.LongDateTime));
            placeholders.RegisterPlaceholder(plugin, keys.RelativeTime, () => DiscordFormatting.UnixTimestamp(DateTimeOffset.UtcNow, TimestampStyles.RelativeTime));
        }
    }
}