using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/skus#sku-object-sku-structure">SKU Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordSku
    {
        /// <summary>
        /// ID of SKU
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Type of SKU
        /// </summary>
        [JsonProperty("type")]
        public DiscordSkuType Type { get; set; }
        
        /// <summary>
        /// ID of the parent application
        /// </summary>
        [JsonProperty("application_id")]
        public Snowflake ApplicationId { get; set; }
        
        /// <summary>
        /// Customer-facing name of your premium offering
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// System-generated URL slug based on the SKU's name
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        /// <summary>
        /// SKU flags combined as a bitfield
        /// </summary>
        [JsonProperty("flags")]
        public SkuFlags Flags { get; set; }

        /// <summary>
        /// Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. 
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="applicationId">Application ID to get SKU's for</param>
        public static IPromise<List<DiscordSku>> GetSkus(DiscordClient client, Snowflake applicationId)
        {
            return client.Bot.Rest.Get<List<DiscordSku>>(client, $"applications/{applicationId}/skus");
        }
    }

    /// <summary>
    /// Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. 
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="query">Query for the request</param>
    public IPromise<List<DiscordSubscription>> GetSkuSubscriptions(DiscordClient client, GetSkuSubscriptionsQueryString query = null)
    {
        return client.Bot.Rest.Get<List<DiscordSubscription>>(client, $"skus/{Id}/subscriptions{query?.ToQueryString()}");
    }
    
    /// <summary>
    /// Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. 
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="subscriptionId">ID of the subscription</param>
    public IPromise<DiscordSubscription> GetSkuSubscription(DiscordClient client, Snowflake subscriptionId)
    {
        return client.Bot.Rest.Get<DiscordSubscription>(client, $"skus/{Id}/subscriptions/{subscriptionId}");
    }
}