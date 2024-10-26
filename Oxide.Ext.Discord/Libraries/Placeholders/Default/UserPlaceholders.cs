using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordUser"/> placeholders
    /// </summary>
    public static class UserPlaceholders
    {
        internal static readonly PlaceholderDataKey TargetUserKey = new("TargetUser");
        internal static readonly PlaceholderDataKey BotUserKey = new("BotUser");
        
        /// <summary>
        /// <see cref="DiscordUser.Id"/> placeholder
        /// </summary>
        public static Snowflake Id(DiscordUser user) => user.Id;
        
        /// <summary>
        /// <see cref="DiscordUser.Username"/> placeholder
        /// </summary>
        public static string UserName(DiscordUser user) => user.Username;
        
        /// <summary>
        /// <see cref="DiscordUser.Discriminator"/> placeholder
        /// </summary>
        public static string Discriminator(DiscordUser user) => user.Discriminator;
        
        /// <summary>
        /// <see cref="DiscordUser.FullUserName"/> placeholder
        /// </summary>
        public static string FullName(DiscordUser user) => user.FullUserName;
        
        /// <summary>
        /// <see cref="DiscordUser.GetAvatarUrl"/> placeholder
        /// </summary>
        public static string AvatarUrl(DiscordUser user) => user.GetAvatarUrl;
        
        /// <summary>
        /// <see cref="DiscordUser.GetBannerUrl"/> placeholder
        /// </summary>
        public static string BannerUrl(DiscordUser user) => user.GetBannerUrl;
        
        /// <summary>
        /// <see cref="DiscordUser.Mention"/> placeholder
        /// </summary>
        public static string Mention(DiscordUser user) => user.Mention;
        
        /// <summary>
        /// <see cref="DiscordUserExt.IsLinked"/> placeholder
        /// </summary>
        public static bool IsLinked(DiscordUser user) => user.IsLinked();

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.User, new PlaceholderDataKey(nameof(DiscordUser)));
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.UserTarget, TargetUserKey);
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Bot, BotUserKey);
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, UserKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordUser, Snowflake>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.Username, dataKey, UserName);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.Discriminator, dataKey, Discriminator);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.Fullname, dataKey, FullName);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.AvatarUrl, dataKey, AvatarUrl);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.BannerUrl, dataKey, BannerUrl);
            placeholders.RegisterPlaceholder<DiscordUser, string>(plugin, keys.Mention, dataKey, Mention);
            placeholders.RegisterPlaceholder<DiscordUser, bool>(plugin, keys.IsLinked, dataKey, IsLinked);
        }
    }
}