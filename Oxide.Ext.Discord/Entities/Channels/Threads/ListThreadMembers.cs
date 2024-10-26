using System;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#list-thread-members-query-string-params">List Thread Member Query String Params</a>
    /// </summary>
    public class ListThreadMembers : IDiscordQueryString
    {
        /// <summary>
        /// Whether to include a guild member object for the thread member
        /// </summary>
        public bool WithMember { get; set; }
        
        /// <summary>
        /// Get thread members after this user ID
        /// </summary>
        public Snowflake? After { get; set; }
        
        /// <summary>
        /// Max number of thread members to return (1-100). Defaults to 100.
        /// </summary>
        public int? Limit { get; set; }
        
        ///<inheritdoc/>
        public string ToQueryString()
        {
            QueryStringBuilder builder = new();

            if (WithMember)
            {
                builder.Add("with_member", StringCache<bool>.Instance.ToString(WithMember));
            }

            if (After.HasValue)
            {
                builder.Add("after", After.Value.ToString());
            }

            if (Limit.HasValue)
            {
                builder.Add("limit", StringCache<int>.Instance.ToString(Math.Clamp(Limit.Value, 1, 100)));
            }
            
            return builder.ToString();
        }
    }
}