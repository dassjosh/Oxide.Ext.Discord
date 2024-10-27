using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Represents the <see cref="JsonConverter"/> for <see cref="DiscordSoundData"/>
    /// </summary>
    public class DiscordSoundDataConverter : JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DiscordSoundData sound = (DiscordSoundData)value;
            writer.WriteValue(sound.GetBase64Sound());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    if (Nullable.GetUnderlyingType(objectType) != null)
                    {
                        return null;
                    }

                    DiscordExtension.GlobalLogger.Warning($"{nameof(DiscordSoundData)} tried to parse null to non nullable field: {{0}}. Please give this message to the discord extension authors.", reader.Path);
                    return default(DiscordSoundData);

                case JsonToken.String:
                    string value = reader.Value.ToString();
                    return new DiscordSoundData(value);

                default:
                    throw new JsonException($"Token type {reader.TokenType} does not match {nameof(DiscordSoundData)} valid types of string or null. Path: {reader.Path}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DiscordSoundData);
        }
    }
}