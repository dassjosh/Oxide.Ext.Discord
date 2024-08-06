using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents a <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params">Scheduled Event Lookup Structure</a> within Discord.
///
/// Provide a user id to before and after for pagination.
/// Users will always be returned in ascending order by user_id.
/// If both before and after are provided, only before is respected.
/// Fetching users in-between before and after is not supported.
/// </summary>
public class ScheduledEventUsersLookup : IDiscordQueryString, IDiscordValidation
{
    /// <summary>
    /// Number of users to return (up to maximum 100)
    /// </summary>
    public int? Limit { get; set; }
        
    /// <summary>
    /// Include guild member data if it exists
    /// Default false
    /// </summary>
    public bool? WithMember { get; set; }
        
    /// <summary>
    /// Consider only users before given user id
    /// Default null
    /// </summary>
    public Snowflake? Before { get; set; }
        
    /// <summary>
    /// Consider only users after given user id
    /// Default null
    /// </summary>
    public Snowflake? After { get; set; }
        
    /// <inheritdoc/>
    public string ToQueryString()
    {
        Validate();
        QueryStringBuilder builder = QueryStringBuilder.Create(DiscordPool.Internal);
        if (Limit.HasValue)
        {
            builder.Add("limit", Limit.Value.ToString());
        }
            
        if (WithMember.HasValue)
        {
            builder.Add("with_member", WithMember.Value.ToString());
        }
            
        if (Before.HasValue)
        {
            builder.Add("before", Before.Value.ToString());
        }
            
        if (After.HasValue)
        {
            builder.Add("after", After.Value.ToString());
        }

        return builder.ToStringAndFree();
    }

    /// <inheritdoc/>
    public void Validate()
    {
        InvalidGuildScheduledEventLookupException.ThrowIfInvalidLimit(Limit);
    }
}