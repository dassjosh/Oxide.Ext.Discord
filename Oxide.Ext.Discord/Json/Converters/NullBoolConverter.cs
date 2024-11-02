using System;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Json
{
    internal class NullBoolConverter : JsonConverter
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => true;

        public override bool CanConvert(Type objectType) => objectType == typeof(bool);
    }
}