using System;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DateTime"/>
    /// </summary>
    public class DateTimeKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Date"/>
        /// </summary>
        public readonly PlaceholderKey Date;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Year"/>
        /// </summary>
        public readonly PlaceholderKey Year;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Month"/>
        /// </summary>
        public readonly PlaceholderKey Month;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Day"/>
        /// </summary>
        public readonly PlaceholderKey Day;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Hour"/>
        /// </summary>
        public readonly PlaceholderKey Hour;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Minute"/>
        /// </summary>
        public readonly PlaceholderKey Minute;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Second"/>
        /// </summary>
        public readonly PlaceholderKey Second;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DateTime.Millisecond"/>
        /// </summary>
        public readonly PlaceholderKey Millisecond;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public DateTimeKeys(string prefix)
        {
            Date = new PlaceholderKey(prefix, "date");
            Year = new PlaceholderKey(prefix, "year");
            Month = new PlaceholderKey(prefix, "month");
            Day = new PlaceholderKey(prefix, "day");
            Hour = new PlaceholderKey(prefix, "hour");
            Minute = new PlaceholderKey(prefix, "minute");
            Second = new PlaceholderKey(prefix, "second");
            Millisecond = new PlaceholderKey(prefix, "millisecond");
        }
    }
}