using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params">Scheduled Event Lookup Structure</a> within Discord.
    /// </summary>
    public class ScheduledEventLookup : IDiscordQueryString
    {
        /// <summary>
        /// Include number of users subscribed to each event
        /// </summary>
        public bool? WithUserCount { get; set; }
        
        /// <inheritdoc/>
        public string ToQueryString()
        {
            QueryStringBuilder builder = new();
            if (WithUserCount.HasValue)
            {
                builder.Add("with_user_count", WithUserCount.Value.ToString());
            }

            return builder.ToString();
        }
    }
}