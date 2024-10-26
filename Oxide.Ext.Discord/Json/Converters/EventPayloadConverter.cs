using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.WebSockets;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// JSON converter for <see cref="EventPayload"/>
    /// </summary>
    public class EventPayloadConverter : JsonConverter
    {
        private const string EventCode = "op";
        private const string Sequence = "s";
        private const string DiscordCode = "t";
        private const string Data = "d";
        
        /// <summary>
        /// We do not write with this converter
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// We do nto write with this converter
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();

        /// <summary>
        /// Reads the JSON into a pooled <see cref="EventPayload"/>
        /// Populates the Data field with the correct type during deserialization
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            EventPayload payload = DiscordPool.Internal.Get<EventPayload>();
            payload.OpCode = obj[EventCode].ToObject<GatewayEventCode>(serializer);
            payload.Sequence = obj[Sequence]?.ToObject<int?>(serializer);

            switch (payload.OpCode)
            {
                case GatewayEventCode.Dispatch:
                    payload.DispatchCode = obj[DiscordCode].ToObject<DiscordDispatchCode>(serializer);
                    payload.JsonData = obj[Data];
                    break;
                case GatewayEventCode.InvalidSession:
                    payload.ShouldResume = obj[Data]?.ToObject<bool?>(serializer) ?? false;
                    break;
                case GatewayEventCode.Hello:
                    payload.JsonData = obj[Data];
                    break;
            }

            return payload;
        }

        /// <summary>
        /// Returns if this converter can convert the given type
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType) => typeof(EventPayload) == objectType;
    }
}