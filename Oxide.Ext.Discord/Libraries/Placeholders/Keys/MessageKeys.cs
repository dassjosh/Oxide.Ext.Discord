using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordMessage"/>
    /// </summary>
    public class MessageKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordMessage.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordMessage.ChannelId"/>
        /// </summary>
        public readonly PlaceholderKey ChannelId;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordMessage.Content"/>
        /// </summary>
        public readonly PlaceholderKey Content;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public MessageKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            ChannelId = new PlaceholderKey(prefix, "channel.id");
            Content = new PlaceholderKey(prefix, "content");
        }
    }
}