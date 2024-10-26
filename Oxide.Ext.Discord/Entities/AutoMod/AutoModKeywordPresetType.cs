namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-keyword-preset-types">Auto Mod Keyword Preset Types</a>
    /// </summary>
    public enum AutoModKeywordPresetType : byte
    {
        /// <summary>
        /// Words that may be considered forms of swearing or cursing
        /// </summary>
        Profanity = 1,
        
        /// <summary>
        /// Words that refer to sexually explicit behavior or activity
        /// </summary>
        SexualContent = 2,
        
        /// <summary>
        /// Personal insults or words that may be considered hate speech
        /// </summary>
        Slurs = 3,
    }
}