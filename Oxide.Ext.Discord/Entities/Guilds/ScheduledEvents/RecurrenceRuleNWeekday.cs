using System;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-nweekday-structure">Guild Scheduled Event Recurrence Rule N Weekday Object</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class RecurrenceRuleNWeekday
{
    /// <summary>
    /// The week to reoccur on. 1 - 5
    /// </summary>
    [JsonProperty("n")]
    public int N { get; set; }
    
    /// <summary>
    /// The day within the week to reoccur on
    /// </summary>
    [JsonProperty("day")]
    public RecurrenceRuleWeekday Day { get; set; }
}