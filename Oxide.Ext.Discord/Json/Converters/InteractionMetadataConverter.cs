using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Converter for a list of message components
    /// </summary>
    public class InteractionMetadataConverter : JsonConverter
    {
        /// <summary>
        /// Ignored as we don't write JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotSupportedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Populate the correct types in components instead of just the BaseComponent
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            InteractionType type = (InteractionType)obj["type"].ToObject<byte>();
            return type switch
            {
                InteractionType.ApplicationCommand => obj.ToObject<ApplicationCommandInteractionMetadata>(serializer),
                InteractionType.MessageComponent => obj.ToObject<MessageComponentInteractionMetadata>(serializer),
                InteractionType.ModalSubmit => obj.ToObject<ModalSubmitInteractionMetadata>(serializer),
                _ => null
            };
        }

        /// <summary>
        /// Returns if this can convert the value
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BaseInteractionMetadata);
        }

        /// <summary>
        /// Message Component Convert does not write JSON
        /// </summary>
        public override bool CanWrite => false;
    }
}