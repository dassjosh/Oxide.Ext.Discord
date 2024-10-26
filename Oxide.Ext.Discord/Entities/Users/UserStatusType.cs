using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents Discord User <a href="https://discord.com/developers/docs/topics/gateway#update-status-status-types">Status Types</a> 
    /// </summary>
    public enum UserStatusType : byte
    {
        /// <summary>
        /// User is online
        /// </summary>
        [DiscordEnum("online")] Online,
        
        /// <summary>
        /// User has Do Not Disturb
        /// </summary>
        [DiscordEnum("dnd")] Dnd,
        
        /// <summary>
        /// User is idle
        /// </summary>
        [DiscordEnum("idle")] Idle,
        
        /// <summary>
        /// User is invisible
        /// </summary>
        [DiscordEnum("invisible")] Invisible,
        
        /// <summary>
        /// User is offline
        /// </summary>
        [DiscordEnum("offline")] Offline
    }
}