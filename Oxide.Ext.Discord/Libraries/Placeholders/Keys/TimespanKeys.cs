using System;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="TimeSpan"/>
    /// </summary>
    public class TimespanKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan"/>
        /// </summary>
        public readonly PlaceholderKey Time;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan"/>
        /// </summary>
        public readonly PlaceholderKey Formatted;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.Days"/>
        /// </summary>
        public readonly PlaceholderKey Days;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.Hours"/>
        /// </summary>
        public readonly PlaceholderKey Hours;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.Minutes"/>
        /// </summary>
        public readonly PlaceholderKey Minutes;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.Seconds"/>
        /// </summary>
        public readonly PlaceholderKey Seconds;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.Milliseconds"/>
        /// </summary>
        public readonly PlaceholderKey Milliseconds;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.TotalDays"/>
        /// </summary>
        public readonly PlaceholderKey TotalDays;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.TotalHours"/>
        /// </summary>
        public readonly PlaceholderKey TotalHours;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.TotalMinutes"/>
        /// </summary>
        public readonly PlaceholderKey TotalMinutes;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.TotalSeconds"/>
        /// </summary>
        public readonly PlaceholderKey TotalSeconds;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="TimeSpan.TotalMilliseconds"/>
        /// </summary>
        public readonly PlaceholderKey TotalMilliseconds;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public TimespanKeys(string prefix)
        {
            Time = new PlaceholderKey(prefix, "time");
            Formatted = new PlaceholderKey(prefix, "formatted");
            Days = new PlaceholderKey(prefix, "days");
            Hours = new PlaceholderKey(prefix, "hours");
            Minutes = new PlaceholderKey(prefix, "minutes");
            Seconds = new PlaceholderKey(prefix, "seconds");
            Milliseconds = new PlaceholderKey(prefix, "milliseconds");
            TotalDays = new PlaceholderKey(prefix, "total.days");
            TotalHours = new PlaceholderKey(prefix, "total.hours");
            TotalMinutes = new PlaceholderKey(prefix, "total.minutes");
            TotalSeconds = new PlaceholderKey(prefix, "total.seconds");
            TotalMilliseconds = new PlaceholderKey(prefix, "total.milliseconds");
        }
    }
}