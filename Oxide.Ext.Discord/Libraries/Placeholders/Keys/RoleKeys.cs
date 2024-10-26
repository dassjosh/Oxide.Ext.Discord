using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordRole"/>
    /// </summary>
    public class RoleKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordRole.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordRole.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordRole.Mention"/>
        /// </summary>
        public readonly PlaceholderKey Mention;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordRole.Icon"/>
        /// </summary>
        public readonly PlaceholderKey Icon;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public RoleKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            Mention = new PlaceholderKey(prefix, "mention");
            Icon = new PlaceholderKey(prefix, "icon");
        }
    }
}