using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-mfa-level">MFA Level</a>
    /// </summary>
    public enum GuildMfaLevel : byte
    {
        /// <summary>
        /// Guild does not require MFA
        /// </summary>
        [DiscordEnum("NONE")]
        None = 0,
        
        /// <summary>
        /// Guild requires elevated MFA
        /// </summary>
        [DiscordEnum("ELEVATED")]
        Elevated = 1
    }
}