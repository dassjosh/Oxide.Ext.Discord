using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordMessage"/> placeholders
    /// </summary>
    public static class MessagePlaceholders
    {
        /// <summary>
        /// <see cref="DiscordMessage.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(PlaceholderState state, DiscordMessage message) => message.Id;
        
        /// <summary>
        /// <see cref="DiscordMessage.ChannelId"/> placeholder
        /// </summary>
        public static Snowflake ChannelId(PlaceholderState state, DiscordMessage message) => message.ChannelId;
        
        /// <summary>
        /// <see cref="DiscordMessage.Content"/> placeholder
        /// </summary>
        public static string Content(PlaceholderState state, DiscordMessage message) => message.Content;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Message, new PlaceholderDataKey(nameof(DiscordMessage)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, MessageKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordMessage, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordMessage, Snowflake>(plugin, keys.ChannelId, dataKey, ChannelId);
            placeholders.RegisterPlaceholder<DiscordMessage, string>(plugin, keys.Content, dataKey, Content);
        }
    }
}