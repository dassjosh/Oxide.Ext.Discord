using System;

namespace Oxide.Ext.Discord.Entities.Channels
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#channel-object-channel-flags">Channel Flags</a>
    /// </summary>
    [Flags]
    public enum ChannelFlags
    {
        /// <summary>
        /// This thread is pinned to the top of its parent GUILD_FORUM channel
        /// </summary>
        Pinned = 1 << 1,
        
        /// <summary>
        /// Whether a tag is required to be specified when creating a thread in a GUILD_FORUM channel. Tags are specified in the applied_tags field.
        /// </summary>
        RequireTag = 1 << 4,
    }
}