using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities;

public class GetSkuSubscriptionsQueryString : IDiscordQueryString
{
    /// <summary>
    /// List subscriptions before this ID
    /// </summary>
    public Snowflake? Before { get; set; }
    
    /// <summary>
    /// List subscriptions after this ID
    /// </summary>
    public Snowflake? After { get; set; }
    
    /// <summary>
    /// Number of results to return (1-100)
    /// </summary>
    public int? Limit { get; set; }
    
    /// <summary>
    /// User ID for which to return subscriptions.
    /// Required except for OAuth queries.
    /// </summary>
    public Snowflake? UserId { get; set; }
    
    public string ToQueryString()
    {
        Validate();
        QueryStringBuilder builder = new();
        
        if (Before.HasValue)
        {
            builder.Add("before", Before.Value.ToString());
        }
        
        if (After.HasValue)
        {
            builder.Add("after", After.Value.ToString());
        }
        
        if (Limit.HasValue)
        {
            builder.Add("limit", Limit.Value.ToString());
        }

        if (UserId.HasValue)
        {
            builder.Add("user_id", UserId.Value.ToString());
        }

        return builder.ToString();
    }

    private void Validate()
    {
        InvalidGetSkuSubscriptionsException.ThrowIfInvalidLimit(Limit);
    }
}