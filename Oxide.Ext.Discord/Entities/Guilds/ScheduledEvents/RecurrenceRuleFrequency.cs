namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-frequency">Guild Scheduled Event Recurrence Rule Frequency</a>
    /// </summary>
    public enum RecurrenceRuleFrequency
    {
        /// <summary>
        /// Yearly Recurrence Rule Frequency
        /// </summary>
        Yearly = 0,
        
        /// <summary>
        /// Monthy Recurrence Rule Frequency
        /// </summary>
        Monthly = 1,
        
        /// <summary>
        /// Weekly Recurrence Rule Frequency
        /// </summary>
        Weekly = 2,
        
        /// <summary>
        /// Daily Recurrence Rule Frequency
        /// </summary>
        Daily = 3
    }
}