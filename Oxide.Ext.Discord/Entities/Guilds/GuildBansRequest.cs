using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild#get-guild-bans-query-string-params">Get Guild Bans Query String Params</a>
    /// </summary>
    public class GuildBansRequest : IDiscordQueryString
    {
        /// <summary>
        /// Number of users to return (up to maximum 1000)  
        /// </summary>
        public int? Limit { get; set; } = 1000;
        
        /// <summary>
        /// Get bans before this user ID
        /// </summary>
        public Snowflake? Before { get; set; }
        
        /// <summary>
        /// Get bans after this user ID
        /// </summary>
        public Snowflake? After { get; set; }
        
        /// <inheritdoc/>
        public string ToQueryString()
        {
            QueryStringBuilder builder = new();
            
            if (Limit.HasValue)
            {
                builder.Add("limit", Limit.Value.ToString());
            }

            if (Before.HasValue)
            {
                builder.Add("before", Before.Value.ToString());
            }
            else if (After.HasValue)
            {
                builder.Add("after", After.Value.ToString());
            }

            return builder.ToString();
        }
    }
}