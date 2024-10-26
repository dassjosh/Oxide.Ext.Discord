using Newtonsoft.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a command payload
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandPayload : BasePoolable
    {
        /// <summary>
        /// Command Code for the payload
        /// </summary>
        [JsonProperty("op")]
        public GatewayCommandCode OpCode;

        /// <summary>
        /// Payload data
        /// </summary>
        [JsonProperty("d")]
        public object Payload;

        /// <summary>
        /// Creates a <see cref="CommandPayload"/> for the web socket
        /// </summary>
        /// <param name="code">OP Code for the command</param>
        /// <param name="payload">Payload for the command</param>
        /// <returns></returns>
        public static CommandPayload CreatePayload(GatewayCommandCode code, object payload)
        {
            CommandPayload command = DiscordPool.Internal.Get<CommandPayload>();
            command.Init(code, payload);
            return command;
        }
        
        /// <summary>
        /// Initializes the pooled command payload
        /// </summary>
        /// <param name="code">OP Code for the command</param>
        /// <param name="payload">Payload for the command</param>
        private void Init(GatewayCommandCode code, object payload)
        {
            OpCode = code;
            Payload = payload;
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            OpCode = default;
            Payload = null;
        }
    }
}