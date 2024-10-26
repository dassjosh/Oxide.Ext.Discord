using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Json
{
    internal class ServerLocaleConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    string value = reader.Value.ToString();
                    return !string.IsNullOrEmpty(value) ? ServerLocale.Parse(value) : default;

                case JsonToken.Null:
                    return Nullable.GetUnderlyingType(objectType) != null ? null : default(ServerLocale);

                default:
                    throw new JsonException($"Token type {reader.TokenType} does not match ServerLocale valid types of string or null. Path: {reader.Path}");
            }
        }

        public override bool CanConvert(Type objectType) => typeof(ServerLocale) == objectType;
    }
}