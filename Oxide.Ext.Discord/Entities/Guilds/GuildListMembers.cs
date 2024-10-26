using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild#list-guild-members-query-string-params">List Guild Members</a> Stucture
    /// </summary>
    public class GuildListMembers : IDiscordQueryString, IDiscordValidation
    {
        /// <summary>
        /// Max number of members to return (1-1000)
        /// Default is 1
        /// </summary>
        public int? Limit { get; set; }
        
        /// <summary>
        /// The highest user id in the previous page
        /// </summary>
        public Snowflake? After { get; set; }
        
        ///<inheritdoc/>
        public string ToQueryString()
        {
            Validate();
            QueryStringBuilder builder = new();
            if (Limit.HasValue)
            {
                builder.Add("limit", Limit.Value.ToString());
            }

            if (After.HasValue)
            {
                builder.Add("after", After.Value.ToString());
            }

            return builder.ToString();
        }

        /// <inheritdoc/>
        public void Validate()
        {
            InvalidGuildListMembersException.ThrowIfInvalidLimit(Limit);
        }
    }
}