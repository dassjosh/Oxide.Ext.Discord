using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordGuild"/>
    /// </summary>
    public class GuildKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.Description"/>
        /// </summary>
        public readonly PlaceholderKey Description;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.Icon"/>
        /// </summary>
        public readonly PlaceholderKey Icon;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.Banner"/>
        /// </summary>
        public readonly PlaceholderKey Banner;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordGuild.MemberCount"/>
        /// </summary>
        public readonly PlaceholderKey MemberCount;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public GuildKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            Description = new PlaceholderKey(prefix, "description");
            Icon = new PlaceholderKey(prefix, "icon");
            Banner = new PlaceholderKey(prefix, "banner");
            MemberCount = new PlaceholderKey(prefix, "members.count");
        }
    }
}