namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-event-types">Auto Mod Event Type</a>
    /// </summary>
    public enum AutoModEventType : byte
    {
        /// <summary>
        /// When a member sends or edits a message in the guild
        /// </summary>
        MessageSend = 1,
        
        /// <summary>
        /// When a member edits their profile
        /// </summary>
        MemberUpdate = 1
    }
}