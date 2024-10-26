using System.Collections.Generic;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Get Entitlements Query String Builder
    /// </summary>
    public class GetEntitlements : IDiscordQueryString, IDiscordValidation
    {
        /// <summary>
        /// User ID to look up entitlements for
        /// </summary>
        public Snowflake? UserId { get; set; }
        
        /// <summary>
        /// Optional list of SKU IDs to check entitlements for
        /// </summary>
        public List<Snowflake> SkuIds { get; set; }
        
        /// <summary>
        /// Retrieve entitlements before this entitlement ID
        /// </summary>
        public Snowflake? Before { get; set; }
        
        /// <summary>
        /// Retrieve entitlements after this entitlement ID
        /// </summary>
        public Snowflake? After { get; set; }
        
        /// <summary>
        /// Number of entitlements to return, 1-100, default 100
        /// </summary>
        public int? Limit { get; set; }
        
        /// <summary>
        /// Guild ID to look up entitlements for
        /// </summary>
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// Whether expired entitlements should be omitted
        /// </summary>
        public bool? ExcludeEnded { get; set; }
        
        ///<inheritdoc/>
        public string ToQueryString()
        {
            Validate();
            QueryStringBuilder builder = new();
            
            if(UserId.HasValue) builder.Add("user_id", UserId.Value);
            if(SkuIds != null) builder.AddList("sku_ids", SkuIds, ",");
            if(Before.HasValue) builder.Add("before", Before.Value);
            if(After.HasValue) builder.Add("after", After.Value);
            if(Limit.HasValue) builder.Add("limit", Limit.Value.ToString());
            if(GuildId.HasValue) builder.Add("guild_id", GuildId.Value.ToString());
            if(ExcludeEnded.HasValue) builder.Add("exclude_ended", StringCache<bool>.Instance.ToString(ExcludeEnded.Value));
            
            return builder.ToString();
        }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidGetEntitlementException.ThrowIfInvalidLimit(Limit);
        }
    }
}