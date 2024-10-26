using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-verification-level">Verification Level</a>
    /// </summary>
    public enum GuildVerificationLevel : byte
    {
        /// <summary>
        /// Unrestricted
        /// </summary>
        [DiscordEnum("NONE")]
        None = 0,
        
        /// <summary>
        /// Must have verified email on account
        /// </summary>
        [DiscordEnum("LOW")]
        Low = 1,
        
        /// <summary>
        /// Must be registered on Discord for longer than 5 minutes
        /// </summary>
        [DiscordEnum("MEDIUM")]
        Medium = 2,
        
        /// <summary>
        /// Must be a member of the server for longer than 10 minutes
        /// </summary>
        [DiscordEnum("HIGH")]
        High = 3,
        
        /// <summary>
        /// Must have a verified phone number
        /// </summary>
        [DiscordEnum("VERY_HIGH")]
        VeryHigh = 4
    }
}