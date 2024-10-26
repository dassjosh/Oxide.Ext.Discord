using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordChannel"/> Placeholders
    /// </summary>
    public static class ChannelPlaceholders
    {
        /// <summary>
        /// <see cref="DiscordChannel.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(DiscordChannel channel) => channel.Id;
        
        /// <summary>
        /// <see cref="DiscordChannel.Name"/> placeholder
        /// </summary>
        public static string Name(DiscordChannel channel) => channel.Name;
        
        /// <summary>
        /// <see cref="DiscordChannel.IconUrl"/> placeholder
        /// </summary>
        public static string Icon(DiscordChannel channel) => channel.IconUrl;
        
        /// <summary>
        /// <see cref="DiscordChannel.Topic"/> placeholder
        /// </summary>
        public static string Topic(DiscordChannel channel) => channel.Topic;
        
        /// <summary>
        /// <see cref="DiscordChannel.Mention"/> placeholder
        /// </summary>
        public static string Mention(DiscordChannel channel) => channel.Mention;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Channel, new PlaceholderDataKey(nameof(DiscordChannel)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, ChannelKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordChannel, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordChannel, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<DiscordChannel, string>(plugin, keys.Icon, dataKey, Icon);
            placeholders.RegisterPlaceholder<DiscordChannel, string>(plugin, keys.Topic, dataKey, Topic);
            placeholders.RegisterPlaceholder<DiscordChannel, string>(plugin, keys.Mention, dataKey, Mention);
        }
    }
}