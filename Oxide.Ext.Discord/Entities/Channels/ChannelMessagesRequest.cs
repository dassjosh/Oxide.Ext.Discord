using Newtonsoft.Json;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/channel#get-channel-messages">Get Channel Messages Request</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class ChannelMessagesRequest : IDiscordQueryString
{
    /// <summary>
    /// Get messages around this message ID
    /// Before, after, and around keys are mutually exclusive, only one may be passed at a time
    /// </summary>
    public Snowflake? Around { get; set; }
        
    /// <summary>
    /// Get messages before this message ID
    /// Before, after, and around keys are mutually exclusive, only one may be passed at a time
    /// </summary>
    public Snowflake? Before { get; set; }
        
    /// <summary>
    /// Get messages after this message ID
    /// Before, after, and around keys are mutually exclusive, only one may be passed at a time
    /// </summary>
    public Snowflake? After { get; set; }
        
    /// <summary>
    /// Max number of messages to return (1-100)
    /// </summary>
    public int? Limit { get; set; }

    /// <inheritdoc/>
    public string ToQueryString()
    {
        QueryStringBuilder builder = QueryStringBuilder.Create(DiscordPool.Internal);

        //Per Documentation "The before, after, and around keys are mutually exclusive, only one may be passed at a time."
        if (Around.HasValue)
        {
            builder.Add("around", Around.Value.ToString());
        }
        else if (Before.HasValue)
        {
            builder.Add("before", Before.Value.ToString());
        }
        else if (After.HasValue)
        {
            builder.Add("after", After.Value.ToString());
        }
            
        if (Limit.HasValue)
        {
            builder.Add("limit", Limit.Value.ToString());
        }

        return builder.ToStringAndFree();
    }
}