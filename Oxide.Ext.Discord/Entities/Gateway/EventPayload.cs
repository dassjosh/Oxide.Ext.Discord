using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Types;
using Oxide.Ext.Discord.WebSockets;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#payloads">Gateway Payload Structure</a>
    /// </summary>
    [JsonConverter(typeof(EventPayloadConverter))]
    public class EventPayload : BasePoolable
    {
        /// <summary>
        /// Op Code for the payload
        /// </summary>
        public GatewayEventCode OpCode { get; internal set; }

        /// <summary>
        /// The event name for this payload
        /// </summary>
        public DiscordDispatchCode DispatchCode { get; internal set; }

        /// <summary>
        /// Event data
        /// </summary>
        public object Data { get; private set; }

        /// <summary>
        /// Sequence number, used for resuming sessions and heartbeats
        /// </summary>
        public int? Sequence { get; internal set; }

        /// <summary>
        /// If the websocket should resume on reconnect.
        /// </summary>
        public bool ShouldResume { get; internal set; }

        internal JToken JsonData { get; set; }
        
        /// <summary>
        /// Returns the Data as {T}
        /// </summary>
        /// <typeparam name="T">Type to convert Data to</typeparam>
        /// <returns>Data converted to {T}</returns>
        public T GetData<T>(BotClient client)
        {
            return JsonData.ToObject<T>(client.JsonSerializer);
        }
        
        /// <inheritdoc/>
        protected override void EnterPool()
        {
            OpCode = default;
            DispatchCode = default;
            Data = null;
            Sequence = null;
        }
    }
}