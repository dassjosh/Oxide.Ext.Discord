using System;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/stage-instance#stage-instance-object-privacy-level">Stage Privacy Level</a> within Discord.
    /// </summary>
    public enum PrivacyLevel : byte
    {
        /// <summary>
        /// The Stage instance is visible publicly. (deprecated)
        /// </summary>
        [Obsolete("Deprecated by Discord")]
        [DiscordEnum("PUBLIC")]
        Public = 1,
        
        /// <summary>
        /// The Stage instance is visible to only guild members.
        /// </summary>
        [DiscordEnum("GUILD_ONLY")]
        GuildOnly = 2
    }
}