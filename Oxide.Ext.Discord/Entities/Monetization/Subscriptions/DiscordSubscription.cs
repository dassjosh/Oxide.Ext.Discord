using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/subscription#subscription-resource">Subscription</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordSubscription
    {
        /// <summary>
        /// ID of the subscription
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
    
        /// <summary>
        /// ID of the user who is subscribed
        /// </summary>
        [JsonProperty("user_id")]
        public Snowflake UserId { get; set; }
    
        /// <summary>
        /// List of SKUs subscribed to
        /// </summary>
        [JsonProperty("sku_ids")]
        public List<Snowflake> SkuIds { get; set; }
    
        /// <summary>
        /// List of entitlements granted for this subscription
        /// </summary>
        [JsonProperty("entitlement_ids")]
        public List<Snowflake> EntitlementIds { get; set; }
    
        /// <summary>
        /// Start of the current subscription period
        /// </summary>
        [JsonProperty("current_period_start")]
        public DateTimeOffset CurrentPeriodStart { get; set; }
    
        /// <summary>
        /// End of the current subscription period
        /// </summary>
        [JsonProperty("current_period_end")]
        public DateTimeOffset CurrentPeriodEnd { get; set; }
    
        /// <summary>
        /// Current status of the subscription
        /// </summary>
        [JsonProperty("status")]
        public SubscriptionStatus Status { get; set; }
    
        /// <summary>
        /// When the subscription was canceled
        /// </summary>
        [JsonProperty("canceled_at")]
        public DateTimeOffset? CanceledAt { get; set; }
    
        /// <summary>
        /// ISO3166-1 alpha-2 country code of the payment source used to purchase the subscription.
        /// Missing unless queried with a private OAuth scope.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}