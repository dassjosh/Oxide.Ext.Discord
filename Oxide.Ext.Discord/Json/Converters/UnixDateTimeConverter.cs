using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Converts a <see cref="DateTimeOffset"/> to and from a json long
    /// </summary>
    public class UnixDateTimeConverter : JsonConverter
    {
        /// <summary>
        /// Write <see cref="DateTimeOffset"/> to UnixTimeMilliseconds 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTimeOffset dateTime = (DateTimeOffset)value;
            writer.WriteValue(dateTime.ToUnixTimeMilliseconds());
        }

        /// <summary>
        /// Convert to <see cref="DateTimeOffset"/> from UnixTimeMilliseconds
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long value = JToken.ReadFrom(reader).ToObject<long>(serializer);
            return DateTimeOffset.FromUnixTimeMilliseconds(value);
        }

        /// <summary>
        /// Can the type be converted
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTimeOffset) == objectType;
        }
    }
}