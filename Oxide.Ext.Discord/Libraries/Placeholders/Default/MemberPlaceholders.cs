using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="GuildMember"/> placeholders
    /// </summary>
    public static class MemberPlaceholders
    {
        /// <summary>
        /// <see cref="GuildMember.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(GuildMember member) =>  member.Id;
        
        /// <summary>
        /// <see cref="GuildMember.Id"/> placeholder
        /// </summary>
        public static string Name(GuildMember member) => member.DisplayName;
        
        /// <summary>
        /// <see cref="GuildMember.Id"/> placeholder
        /// </summary>
        public static string Mention(GuildMember member) => member.User.Mention;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Member, new PlaceholderDataKey(nameof(GuildMember)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, MemberKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<GuildMember, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<GuildMember, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<GuildMember, string>(plugin, keys.Mention, dataKey, Mention);
        }
    }
}