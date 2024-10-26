using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Handles the JSON Serialization / Deserialization for DiscordColor
    /// </summary>
    public class DiscordColorConverter : JsonConverter
    {
        /// <summary>
        /// Writes to JSON
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DiscordColor color = (DiscordColor) value;
            writer.WriteValue(color.Color);
        }

        /// <summary>
        /// Reads from JSON
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (!objectType.IsNullable())
                {
                    throw new JsonException($"Cannot convert null value to {objectType}. Path: {reader.Path}");
                }

                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                return new DiscordColor(uint.Parse(reader.Value.ToString()));
            }
            
            if (reader.TokenType == JsonToken.String)
            {
                return new DiscordColor(reader.Value.ToString());
            }
            
            throw new JsonException($"Unexpected token {reader.TokenType} when parsing discord color. Path: {reader.Path}");
        }

        /// <summary>
        /// Check if it can convert
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType != null && (objectType.IsNullable() ? Nullable.GetUnderlyingType(objectType) : objectType) == typeof(DiscordColor);
        }
    }
}