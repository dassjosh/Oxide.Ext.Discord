using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-object-message-activity-types">Message Activity Types</a>
    /// </summary>
    public enum MessageActivityType : byte
    {
        /// <summary>
        /// Message Activity Join
        /// </summary>
        [DiscordEnum("JOIN")]
        Join = 1,
        
        /// <summary>
        /// Message Activity Spectate
        /// </summary>
        [DiscordEnum("SPECTATE")]
        Spectate = 2,
        
        /// <summary>
        /// Message Activity Listen
        /// </summary>
        [DiscordEnum("LISTEN")]
        Listen = 3,
        
        /// <summary>
        /// Message Activity JoinRequest
        /// </summary>
        [DiscordEnum("JOIN_REQUEST")]
        JoinRequest = 5,
    }
}