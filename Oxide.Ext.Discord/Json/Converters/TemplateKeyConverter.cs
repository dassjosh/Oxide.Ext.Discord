using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// JSON Template Key Converter
    /// </summary>
    public class TemplateKeyConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TemplateKey key = (TemplateKey)value;
            writer.WriteValue(key.Name);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new TemplateKey(reader.Value.ToString());
            }
                
            throw new JsonException($"Unexpected token {reader.TokenType} when parsing TemplateKey.");
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => typeof(TemplateKey) == objectType;
    }
}