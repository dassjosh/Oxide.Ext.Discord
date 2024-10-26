using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-verification-level">Verification Level</a>
    /// </summary>
    public enum GuildPremiumTier : byte
    {
        /// <summary>
        /// Guild does not have any premium tier
        /// </summary>
        [DiscordEnum("NONE")]
        None = 0,
        
        /// <summary>
        /// Guild is premium tier 1
        /// </summary>
        [DiscordEnum("TIER_1")]
        Tier1 = 1,
        
        /// <summary>
        /// Guild is premium tier 2
        /// </summary>
        [DiscordEnum("TIER_2")]
        Tier2 = 2,
        
        /// <summary>
        /// Guild is premium tier 3
        /// </summary>
        [DiscordEnum("TIER_3")]
        Tier3 = 3
    }
}