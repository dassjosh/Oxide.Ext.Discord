namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object-action-types">Auto Mod Action Types</a>
    /// </summary>
    public enum AutoModActionType : byte
    {
        /// <summary>
        /// Blocks the content of a message according to the rule
        /// </summary>
        BlockMessage = 1,
        
        /// <summary>
        /// Logs user content to a specified channel
        /// </summary>
        SendAlertMessage = 2,
        
        /// <summary>
        /// Timeout user for a specified duration
        /// A TIMEOUT action can only be setup for KEYWORD rules.
        /// MODERATE_MEMBERS permission is required to use the TIMEOUT action type.
        /// </summary>
        Timeout = 3,
        
        /// <summary>
        /// Prevents a member from using text, voice, or other interactions
        /// </summary>
        BlockMemberInteraction = 4,
    }
}