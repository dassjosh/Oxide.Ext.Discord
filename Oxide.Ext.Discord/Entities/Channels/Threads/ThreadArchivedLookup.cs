using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents a <a href="https://discord.com/developers/docs/resources/channel#list-public-archived-threads-query-string-params">Thread Archive Lookup Structure</a> within Discord.
/// Represents a <a href="https://discord.com/developers/docs/resources/channel#list-private-archived-threads-query-string-params">Thread Archive Lookup Structure</a> within Discord.
/// Represents a <a href="https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads-query-string-params">Thread Archive Lookup Structure</a> within Discord.
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class ThreadArchivedLookup : IDiscordQueryString
{
    /// <summary>
    /// Returns threads before this timestamp
    /// </summary>
    [JsonProperty("before")]
    public DateTime? Before { get; set; } 
        
    /// <summary>
    /// Optional maximum number of threads to return
    /// </summary>
    [JsonProperty("limit")]
    public int? Limit { get; set; } 
        
    /// <inheritdoc/>
    public string ToQueryString()
    {
        QueryStringBuilder builder = new();
        if (Before.HasValue)
        {
            builder.Add("before", Before.Value.ToString("o"));
        }
            
        if (Limit.HasValue)
        {
            builder.Add("limit", Limit.Value.ToString());
        }

        return builder.ToString();
    }
}