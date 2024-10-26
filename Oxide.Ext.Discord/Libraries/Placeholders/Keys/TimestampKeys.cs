using Oxide.Ext.Discord.Helpers;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="long"/>
    /// </summary>
    public class TimestampKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/>
        /// </summary>
        public readonly PlaceholderKey Time;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.ShortTime"/>
        /// </summary>
        public readonly PlaceholderKey ShortTime;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.LongTime"/>
        /// </summary>
        public readonly PlaceholderKey LongTime;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.ShortDate"/>
        /// </summary>
        public readonly PlaceholderKey ShortDate;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.LongDate"/>
        /// </summary>
        public readonly PlaceholderKey LongDate;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.ShortDateTime"/>
        /// </summary>
        public readonly PlaceholderKey ShortDateTime;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.LongDateTime"/>
        /// </summary>
        public readonly PlaceholderKey LongDateTime;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordFormatting.UnixTimestamp(System.Int64,Oxide.Ext.Discord.Helpers.TimestampStyles)"/> formatted as <see cref="TimestampStyles.RelativeTime"/>
        /// </summary>
        public readonly PlaceholderKey RelativeTime;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public TimestampKeys(string prefix)
        {
            Time = new PlaceholderKey(prefix);
            ShortTime = new PlaceholderKey(prefix, "shorttime");
            LongTime = new PlaceholderKey(prefix, "longtime");
            ShortDate = new PlaceholderKey(prefix, "shortdate");
            LongDate = new PlaceholderKey(prefix, "longdate");
            ShortDateTime = new PlaceholderKey(prefix, "shortdatetime");
            LongDateTime = new PlaceholderKey(prefix, "longdatetime");
            RelativeTime = new PlaceholderKey(prefix, "relativetime");
        }
    }
}