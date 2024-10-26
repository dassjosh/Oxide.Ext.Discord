namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-trigger-types">Auto Mod Trigger Types</a>
    /// </summary>
    public enum AutoModTriggerType : byte
    {
        /// <summary>
        /// Check if content contains words from a user defined list of keywords
        /// </summary>
        Keyword = 1,

        /// <summary>
        /// Check if content represents generic spam
        /// </summary>
        Spam = 3,
        
        /// <summary>
        /// Check if content contains words from internal pre-defined wordsets
        /// </summary>
        KeywordPreset = 4,
        
        /// <summary>
        /// Check if content contains more unique mentions than allowed
        /// </summary>
        MentionSpam = 5,
        
        /// <summary>
        /// Check if member profile contains words from a user defined list of keywords
        /// </summary>
        MemberProfile = 6,
    }
}