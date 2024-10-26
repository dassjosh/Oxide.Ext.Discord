using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordGuild"/> placeholders
    /// </summary>
    public static class GuildPlaceholders
    {
        /// <summary>
        /// <see cref="DiscordGuild.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(DiscordGuild guild) => guild.Id;
        
        /// <summary>
        /// <see cref="DiscordGuild.Name"/> placeholder
        /// </summary>
        public static string Name(DiscordGuild guild) => guild.Name;
        
        /// <summary>
        /// <see cref="DiscordGuild.Description"/> placeholder
        /// </summary>
        public static string Description(DiscordGuild guild) => guild.Description;
        
        /// <summary>
        /// <see cref="DiscordGuild.IconUrl"/> placeholder
        /// </summary>
        public static string Icon(DiscordGuild guild) => guild.IconUrl;
        
        /// <summary>
        /// <see cref="DiscordGuild.BannerUrl"/> placeholder
        /// </summary>
        public static string Banner(DiscordGuild guild) => guild.BannerUrl;
        
        /// <summary>
        /// <see cref="DiscordGuild.Members"/> count placeholder
        /// </summary>
        public static int MemberCount(DiscordGuild guild) => guild.Members.Count;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Guild, new PlaceholderDataKey(nameof(DiscordGuild)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, GuildKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordGuild, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordGuild, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<DiscordGuild, string>(plugin, keys.Description, dataKey, Description);
            placeholders.RegisterPlaceholder<DiscordGuild, string>(plugin, keys.Icon, dataKey, Icon);
            placeholders.RegisterPlaceholder<DiscordGuild, string>(plugin, keys.Banner, dataKey, Banner);
            placeholders.RegisterPlaceholder<DiscordGuild, int>(plugin, keys.MemberCount, dataKey, MemberCount);
        }
    }
}