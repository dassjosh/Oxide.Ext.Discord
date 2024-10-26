using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordUser"/>
    /// </summary>
    public class UserKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.Username"/>
        /// </summary>
        public readonly PlaceholderKey Username;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.Discriminator"/>
        /// </summary>
        public readonly PlaceholderKey Discriminator;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.FullUserName"/>
        /// </summary>
        public readonly PlaceholderKey Fullname;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.GetAvatarUrl"/>
        /// </summary>
        public readonly PlaceholderKey AvatarUrl;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.GetBannerUrl"/>
        /// </summary>
        public readonly PlaceholderKey BannerUrl;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.Mention"/>
        /// </summary>
        public readonly PlaceholderKey Mention;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUserExt.IsLinked"/>
        /// </summary>
        public readonly PlaceholderKey IsLinked;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public UserKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Username = new PlaceholderKey(prefix, "username");
            Discriminator = new PlaceholderKey(prefix, "discriminator");
            Fullname = new PlaceholderKey(prefix, "fullname");
            AvatarUrl = new PlaceholderKey(prefix, "avatar.url");
            BannerUrl = new PlaceholderKey(prefix, "banner.url");
            Mention = new PlaceholderKey(prefix, "mention");
            IsLinked = new PlaceholderKey(prefix, "islinked");
        }
    }
}