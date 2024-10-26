using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a command to be sent over the web socket
    /// </summary>
    public class WebSocketCommand : BasePoolable, IDebugLoggable
    {
        /// <summary>
        /// Client requesting the command
        /// </summary>
        public DiscordClient Client;
        
        /// <summary>
        /// Payload for the command
        /// </summary>
        public CommandPayload Payload;

        /// <summary>
        /// Creates a new <see cref="WebSocketCommand"/>
        /// </summary>
        /// <param name="client">Client for the command</param>
        /// <param name="code"><see cref="GatewayCommandCode"/> For the command</param>
        /// <param name="payload">Payload for the command</param>
        /// <returns></returns>
        internal static WebSocketCommand CreateCommand(DiscordClient client, GatewayCommandCode code, object payload)
        {
            WebSocketCommand command = DiscordPool.Internal.Get<WebSocketCommand>();
            command.Init(client, code, payload);
            return command;
        }

        private void Init(DiscordClient client, GatewayCommandCode code, object payload)
        {
            Client = client;
            Payload = CommandPayload.CreatePayload(code, payload);
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            Payload?.Dispose();
            Client = null;
            Payload = null;
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Plugin", Client.PluginName);
            logger.AppendFieldEnum("Code", Payload.OpCode);
        }
    }
}