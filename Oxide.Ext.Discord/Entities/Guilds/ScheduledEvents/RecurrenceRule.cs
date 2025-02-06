using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object">Guild Scheduled Event Recurrence Rule Object</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RecurrenceRule
    {
        /// <summary>
        /// Starting time of the recurrence interval
        /// </summary>
        [JsonProperty("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Ending time of the recurrence interval
        /// </summary>
        [JsonProperty("end")]
        public DateTime? End { get; set; }

        /// <summary>
        /// Ending time of the recurrence interval
        /// </summary>
        [JsonProperty("frequency")]
        public RecurrenceRuleFrequency Frequency { get; set; }

        /// <summary>
        /// The spacing between the events, defined by frequency.
        /// For example, frequency of WEEKLY and an interval of 2 would be "every-other week"
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// Set of specific days within a week for the event to recur on
        /// </summary>
        [JsonProperty("by_weekday")]
        public List<RecurrenceRuleWeekday> ByWeekday { get; set; }

        /// <summary>
        /// List of specific days within a specific week (1-5) to recur on
        /// </summary>
        [JsonProperty("by_n_weekday")]
        public List<RecurrenceRuleNWeekday> ByNWeekday { get; set; }

        /// <summary>
        /// Set of specific months to recur on
        /// </summary>
        [JsonProperty("by_month")]
        public List<RecurrenceRuleMonth> ByMonth { get; set; }

        /// <summary>
        /// Set of specific dates within a month to recur on
        /// </summary>
        [JsonProperty("by_month_day")]
        public List<int> ByMonthDay { get; set; }

        /// <summary>
        /// Set of days within a year to recur on (1-364)
        /// </summary>
        [JsonProperty("by_year_day")]
        public List<int> ByYearDay { get; set; }

        /// <summary>
        /// The total amount of times that the event is allowed to recur before stopping
        /// </summary>
        [JsonProperty("count")]
        public int? Count { get; set; }
    }
}