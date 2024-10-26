using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Handles deserializing JSON values as strings. If the value doesn't exist, return the default value.
    /// </summary>
    public class DiscordEnumConverter : JsonConverter
    {
        /// <summary>
        /// Write Enum value to Discord Enum String
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            Enum enumValue = (Enum) value;
            string enumText = enumValue.ToString("G");
            if (char.IsNumber(enumText[0]) || enumText[0] == '-')
            {
                writer.WriteValue(value);
                return;
            }

            string enumName = JsonEnumUtils.ToEnumName(enumValue.GetType(), enumText);
            if (!string.IsNullOrEmpty(enumName))
            {
                writer.WriteValue(enumName);
            }
        }

        /// <summary>
        /// Read enum value from Discord Enum String
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
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

            string value = reader.Value.ToString();
            if (reader.TokenType == JsonToken.Integer)
            {
                return Enum.IsDefined(objectType, value) ? Enum.Parse(objectType, value) : JsonEnumUtils.GetDefault(objectType);
            }

            if (reader.TokenType == JsonToken.String)
            {
                string enumName = JsonEnumUtils.FromEnumName(objectType, value) ?? value;
                return Enum.IsDefined(objectType, enumName) ? Enum.Parse(objectType, enumName) : JsonEnumUtils.GetDefault(objectType);
            }

            throw new JsonException($"Unexpected token {reader.TokenType} when parsing enum. Path: {reader.Path}");
        }
        
        /// <summary>
        /// Checks if this type is enum or nullable enum
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType != null && ((objectType.IsNullable() ? Nullable.GetUnderlyingType(objectType) : objectType)?.IsEnum ?? false);
        }
    }
}