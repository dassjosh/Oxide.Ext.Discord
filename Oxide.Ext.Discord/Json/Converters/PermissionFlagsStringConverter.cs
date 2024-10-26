using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Converts Permission Flags to and from a JSON string
    /// </summary>
    public class PermissionFlagsStringConverter : JsonConverter
    {
        /// <summary>
        /// Writes Permission Flags as a JSON string
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("0");
                return;
            }
            
            writer.WriteValue(EnumCache<PermissionFlags>.Instance.ToNumber((PermissionFlags)value));
        }

        /// <summary>
        /// Converts the ulong JSON string to Permission Flags
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
                return PermissionFlags.None;
            }
            
            ulong value = ulong.Parse(reader.Value.ToString());
            return (PermissionFlags)value;
        }

        /// <summary>
        /// Returns if the type equals PermissionFlags
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(PermissionFlags) == objectType;
        }
    }
}