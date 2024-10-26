using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="MessageCreate"/>
    /// </summary>
    public class DiscordMessageBuilder : BaseChannelMessageBuilder<MessageCreate, DiscordMessageBuilder>
    {
        /// <summary>
        /// Constructor creating a new message
        /// </summary>
        public DiscordMessageBuilder() : this(new MessageCreate()) { }
        
        /// <summary>
        /// Constructor to use an existing message
        /// </summary>
        /// <param name="message">Message to use</param>
        public DiscordMessageBuilder(MessageCreate message) : base(message) { }
    }
}