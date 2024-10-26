using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Builders;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#begin-guild-prune">Guild Prune Begin</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildPruneBegin : GuildPruneGet
    {
        /// <summary>
        /// Whether 'pruned' is returned, discouraged for large guilds
        /// </summary>
        [JsonProperty("compute_prune_count")]
        public bool ComputePruneCount { get; set; }
        
        /// <summary>
        /// Reason for the prune (Deprecated)
        /// </summary>
        [Obsolete("This field is deprecated and may be removed in a future update")]
        [JsonProperty("reason")]
        public string Reason { get; set; }
        
        /// <summary>
        /// Returns Guild Prune Begin query string for the API Endpoint
        /// </summary>
        /// <returns>Guild Prune Begin Query String</returns>
        public override string ToQueryString()
        {
            Validate();
            QueryStringBuilder builder = new();
            
            builder.Add("days", Days.ToString());
            builder.Add("compute_prune_count", ComputePruneCount.ToString());

            if (IncludeRoles != null)
            {
                builder.AddList("include_roles", IncludeRoles, ",");
            }
            
#pragma warning disable CS0618
            if (!string.IsNullOrEmpty(Reason))
            {
                builder.Add("reason", Reason);
            }
#pragma warning restore CS0618

            return builder.ToString();
        }
    }
}