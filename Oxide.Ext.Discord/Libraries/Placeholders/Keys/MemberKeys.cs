using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="GuildMember"/>
    /// </summary>
    public class MemberKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="GuildMember.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="GuildMember.DisplayName"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordUser.Mention"/>
        /// </summary>
        public readonly PlaceholderKey Mention;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public MemberKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            Mention = new PlaceholderKey(prefix, "mention");
        }
    }
}