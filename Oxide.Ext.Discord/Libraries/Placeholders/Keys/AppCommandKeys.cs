using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordApplicationCommand"/>
    /// </summary>
    public class AppCommandKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordApplicationCommand.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordApplicationCommand.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordApplicationCommand.Mention"/>
        /// </summary>
        public readonly PlaceholderKey Mention;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordApplicationCommand.MentionCustom"/>
        /// </summary>
        public readonly PlaceholderKey MentionCustom;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public AppCommandKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            Mention = new PlaceholderKey(prefix, "mention");
            MentionCustom = new PlaceholderKey(prefix, "custom");
        }
    }
}