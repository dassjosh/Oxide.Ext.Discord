using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Handles converting <see cref="RoleTags"/>
    /// This type contains special deserialization types
    /// </summary>
    public class RoleTagsConverter : JsonConverter
    {
        /// <summary>
        /// Cannot write
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Cannot Write
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="JsonSerializationException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new JsonSerializationException($"{nameof(RoleTagsConverter)} does not support writing.");
        }

        /// <summary>
        /// Converts the JSON to a <see cref="RoleTags"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            RoleTags tags = new()
            {
                BotId = obj["bot_id"]?.ToObject<Snowflake?>(serializer),
                IntegrationId = obj["integration_id"]?.ToObject<Snowflake?>(serializer),
                SubscriptionListingId = obj["subscription_listing_id"]?.ToObject<Snowflake?>(serializer),
                PremiumSubscriber = obj["premium_subscriber"] != null,
                AvailableForPurchase = obj["available_for_purchase"] != null,
                GuildConnections = obj["guild_connections"] != null
            };

            return tags;
        }

        /// <summary>
        /// Returns if the type can be converter
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType) => typeof(RoleTags) == objectType;
    }
}