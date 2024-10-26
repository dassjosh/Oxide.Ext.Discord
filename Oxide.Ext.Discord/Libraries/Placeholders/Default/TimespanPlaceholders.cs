using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="TimeSpan"/> placeholders
    /// </summary>
    public static class TimeSpanPlaceholders
    {
        internal static readonly PlaceholderDataKey TimeSpanKey = new("timespan");
        
        /// <summary>
        /// <see cref="TimeSpan.Days"/> placeholder
        /// </summary>
        public static int Days(TimeSpan time) => time.Days;

        /// <summary>
        /// Formats Timespan into a text string placeholder
        /// Text is localized if used with DiscordInteraction or IPlayer
        /// Ex: 1 days 2 hours 3 minutes 4 seconds
        /// Ex: 2 hour 0 minutes 53 seconds
        /// </summary>
        public static string Formatted(PlaceholderState state, TimeSpan time)
        {
            DiscordInteraction interaction = state.Data.Get<DiscordInteraction>();
            if (time < TimeSpan.Zero)
            {
                return interaction?.GetLangMessage(DiscordExtensionCore.Instance, LangKeys.TimeSpan.Infinity) ?? DiscordLocales.Instance.GetLangMessage(DiscordExtensionCore.Instance, null, LangKeys.TimeSpan.Infinity);
            }

            ValueStringBuilder sb = new();
            
            AppendTime(interaction, sb, time.TotalDays, time.Days, LangKeys.TimeSpan.Day, LangKeys.TimeSpan.Days);
            AppendTime(interaction, sb, time.TotalHours, time.Hours, LangKeys.TimeSpan.Hour, LangKeys.TimeSpan.Hours);
            AppendTime(interaction, sb, time.TotalMinutes, time.Minutes, LangKeys.TimeSpan.Minute, LangKeys.TimeSpan.Minutes);
            AppendTime(interaction, sb, time.TotalSeconds, time.Seconds, LangKeys.TimeSpan.Second, LangKeys.TimeSpan.Seconds);

            return sb.ToString();
        }

        private static void AppendTime(DiscordInteraction interaction, ValueStringBuilder sb, double total, int value, string singular, string plural)
        {
            if (total >= 1)
            {
                if (sb.Length != 0)
                {
                    sb.Append(' ');
                }

                string langKey = value == 1 ? singular : plural;
                
                sb.Append(value.ToString());
                sb.Append(' ');
                sb.Append(interaction?.GetLangMessage(DiscordExtensionCore.Instance, langKey) ?? DiscordLocales.Instance.GetLangMessage(DiscordExtensionCore.Instance, null, langKey));
            }
        }
        
        /// <summary>
        /// <see cref="TimeSpan.Hours"/> placeholder
        /// </summary>
        public static int Hours(TimeSpan time) => time.Hours;
        
        /// <summary>
        /// <see cref="TimeSpan.Minutes"/> placeholder
        /// </summary>
        public static int Minutes(TimeSpan time) => time.Minutes;
        
        /// <summary>
        /// <see cref="TimeSpan.Seconds"/> placeholder
        /// </summary>
        public static int Seconds(TimeSpan time) => time.Seconds;

        /// <summary>
        /// <see cref="TimeSpan.Milliseconds"/> placeholder
        /// </summary>
        public static int Milliseconds(TimeSpan time) => time.Milliseconds;
        
        /// <summary>
        /// <see cref="TimeSpan.TotalDays"/> placeholder
        /// </summary>
        public static double TotalDays(TimeSpan time) => time.TotalDays;
        
        /// <summary>
        /// <see cref="TimeSpan.TotalHours"/> placeholder
        /// </summary>
        public static double TotalHours(TimeSpan time) => time.TotalHours;
        
        /// <summary>
        /// <see cref="TimeSpan.TotalMinutes"/> placeholder
        /// </summary>
        public static double TotalMinutes(TimeSpan time) => time.TotalMinutes;
        
        /// <summary>
        /// <see cref="TimeSpan.TotalSeconds"/> placeholder
        /// </summary>
        public static double TotalSeconds(TimeSpan time) => time.TotalSeconds;
        
        /// <summary>
        /// <see cref="TimeSpan.TotalMilliseconds"/> placeholder
        /// </summary>
        public static double TotalMilliseconds(TimeSpan time) => time.TotalMilliseconds;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Timespan, TimeSpanKey);
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, TimespanKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<TimeSpan>(plugin, keys.Time, dataKey);
            placeholders.RegisterPlaceholder<TimeSpan, string>(plugin, keys.Formatted, dataKey, Formatted);
            placeholders.RegisterPlaceholder<TimeSpan, int>(plugin, keys.Days, dataKey, Days);
            placeholders.RegisterPlaceholder<TimeSpan, int>(plugin, keys.Hours, dataKey, Hours);
            placeholders.RegisterPlaceholder<TimeSpan, int>(plugin, keys.Minutes, dataKey, Minutes);
            placeholders.RegisterPlaceholder<TimeSpan, int>(plugin, keys.Seconds, dataKey, Seconds);
            placeholders.RegisterPlaceholder<TimeSpan, int>(plugin, keys.Milliseconds, dataKey, Milliseconds);
            placeholders.RegisterPlaceholder<TimeSpan, double>(plugin, keys.TotalDays, dataKey, TotalDays);
            placeholders.RegisterPlaceholder<TimeSpan, double>(plugin, keys.TotalHours, dataKey, TotalHours);
            placeholders.RegisterPlaceholder<TimeSpan, double>(plugin, keys.TotalMinutes, dataKey, TotalMinutes);
            placeholders.RegisterPlaceholder<TimeSpan, double>(plugin, keys.TotalSeconds, dataKey, TotalSeconds);
            placeholders.RegisterPlaceholder<TimeSpan, double>(plugin, keys.TotalMilliseconds, dataKey, TotalMilliseconds);
        }
    }
}