using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordChannel"/>
    /// </summary>
    public class ChannelKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordChannel.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordChannel.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordChannel.Icon"/>
        /// </summary>
        public readonly PlaceholderKey Icon;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordChannel.Topic"/>
        /// </summary>
        public readonly PlaceholderKey Topic;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordChannel.Mention"/>
        /// </summary>
        public readonly PlaceholderKey Mention;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public ChannelKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            Icon = new PlaceholderKey(prefix, "icon");
            Topic = new PlaceholderKey(prefix, "topic");
            Mention = new PlaceholderKey(prefix, "mention");
        }
    }
}