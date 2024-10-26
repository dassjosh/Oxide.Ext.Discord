using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Represents a websocket that connects to discord
    /// </summary>
    public class DiscordWebSocket : IDebugLoggable
    {
        /// <summary>
        /// The current session ID for the connected bot
        /// </summary>
        private string _sessionId;

        /// <summary>
        /// The URL to use when resuming a session
        /// </summary>
        private string _resumeSessionUrl;
        
        /// <summary>
        /// If we should attempt to reconnect to discord on disconnect
        /// </summary>
        public bool ShouldReconnect;
        
        /// <summary>
        /// If we should attempt to resume our previous session after connecting
        /// </summary>
        public bool ShouldResume;

        /// <summary>
        /// The current sequence number for the websocket
        /// </summary>
        private int _sequence;

        /// <summary>
        /// If the bot has successfully connected to the websocket at least once
        /// </summary>
        public bool SocketHasConnected { get; private set; }

        internal GatewayIntents Intents { get; private set; }

        private readonly BotClient _client;
        internal readonly WebSocketHandler Handler;
        private readonly WebSocketEventHandler _listener;
        private readonly WebSocketCommandHandler _commands;
        private readonly DiscordHeartbeatHandler _heartbeat;
        private readonly WebSocketReconnectHandler _reconnect;
        private readonly ILogger _logger;

        private bool _isShutdown;

        /// <summary>
        /// Socket used by the BotClient
        /// </summary>
        /// <param name="client">Client using the socket</param>
        /// <param name="logger">Logger for the bot client</param>
        public DiscordWebSocket(BotClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;

            _reconnect = new WebSocketReconnectHandler(client, this, logger);
            _commands = new WebSocketCommandHandler(client, this, logger);
            _heartbeat = new DiscordHeartbeatHandler(client, this, logger);
            _listener = new WebSocketEventHandler(client, this, logger);
            Handler = new WebSocketHandler(_listener, client, logger);
        }

        /// <summary>
        /// Connect to the websocket
        /// </summary>
        /// <exception cref="Exception">Thrown if the socket still exists. Must call disconnect before trying to connect</exception>
        public void Connect()
        {
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Connect)} Start websocket connection");
            string url = Gateway.WebsocketUrl;
            if (ShouldResume && !string.IsNullOrEmpty(_resumeSessionUrl))
            {
                url = _resumeSessionUrl;
            }
            
            //We haven't gotten the websocket url. Get url then attempt to connect.
            //There has been more than 3 tries to reconnect. Discord suggests trying to update gateway url.
            if (string.IsNullOrEmpty(url) || (_reconnect.AttemptGatewayUpdate && Gateway.LastUpdate + TimeSpan.FromMinutes(5) <= DateTime.UtcNow))
            {
                Gateway.UpdateGatewayUrl(_client)
                    .Then(_ => Connect())
                    .Catch<ResponseError>(OnGatewayUrlUpdateFailed);
                return;
            }

            ShouldReconnect = false;
            ShouldResume = false;

            Intents = _client.Connection.Intents;
            
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Connect)} Bot: {{0}} Websocket connecting to: {{1}} with intents: {{2}}", _client.Connection.HiddenToken, url, Intents);
            Handler.Connect(url);
        }

        private void OnGatewayUrlUpdateFailed(ResponseError error)
        {
            _logger.Warning("Failed to update gateway url. Attempting reconnect.");
            WebsocketReconnectCallback.Start(_reconnect);
        }

        /// <summary>
        /// Disconnects the websocket from discord
        /// </summary>
        /// <param name="reconnect">Should we attempt to reconnect to discord after disconnecting</param>
        /// <param name="resume">Should we attempt to resume our previous session</param>
        /// <param name="requested">If discord requested that we reconnect to discord</param>
        public async void Disconnect(bool reconnect, bool resume, bool requested = false)
        {
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Disconnect)} Disconnecting Web Socket. Socket State: {{0}} Reconnect: {{1}} Resume: {{2}} Requested {{3}}", Handler.SocketState, reconnect, resume, requested);
            ShouldReconnect = reconnect;
            ShouldResume = resume;
            _reconnect.CancelReconnect();

            if (!IsDisconnected() && !IsDisconnecting())
            {
                OnSocketDisconnected();

                if (requested)
                {
                    await Handler.Disconnect((int)DiscordWebsocketCloseCode.DiscordExtensionReconnect, "Discord Requested Reconnect").ConfigureAwait(false);
                }
                else
                {
                    await Handler.Disconnect(WebSocketCloseStatus.NormalClosure, "Normal Websocket Disconnect Requested").ConfigureAwait(false);
                }
            }

            ReconnectIfRequested();
        }

        /// <summary>
        /// Returns if the given websocket matches our current websocket.
        /// If socket is null we return false
        /// </summary>
        /// <param name="webSocketId">ID of the socket</param>
        /// <returns>True if current socket is not null and socket matches current socket; False otherwise.</returns>
        internal bool IsCurrentSocket(Snowflake webSocketId) => !Handler.WebsocketId.IsValid() || Handler.WebsocketId == webSocketId;

        /// <summary>
        /// Shutdowns the websocket completely. Used when bot is being shutdown
        /// </summary>
        public void Shutdown()
        {
            _isShutdown = true;
            Disconnect(false, false);
            _reconnect.OnSocketShutdown();
            _heartbeat.OnSocketShutdown();
            _commands.OnSocketShutdown();
        }

        /// <summary>
        /// Send a command to discord over the websocket
        /// </summary>
        /// <param name="client">Client sending the command</param>
        /// <param name="opCode">Command code to send</param>
        /// <param name="data">Data to send</param>
        public void Send(DiscordClient client, GatewayCommandCode opCode, object data)
        {
            WebSocketCommand command = WebSocketCommand.CreateCommand(client, opCode, data);
            _commands.Enqueue(command);
        }
        
        /// <summary>
        /// Send a command to discord over the websocket
        /// </summary>
        /// <param name="opCode">Command code to send</param>
        /// <param name="data">Data to send</param>
        private async ValueTask SendImmediatelyAsync(GatewayCommandCode opCode, object data)
        {
            CommandPayload payload = CommandPayload.CreatePayload(opCode, data);
            if (!await SendAsync(payload).ConfigureAwait(false))
            {
                _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(SendImmediatelyAsync)} Failed to send command! {{0}}", opCode);
            }
            payload.Dispose();
        }
        
        internal ValueTask<bool> SendAsync(CommandPayload payload)
        {
            if (Handler == null)
            {
                return new ValueTask<bool>(false);
            }

            using DiscordJsonWriter writer = DiscordJsonWriter.Get(DiscordPool.Internal);
            writer.Write(_client.JsonSerializer, payload);
            writer.Stream.Position = 0;

            if (_client.Logger.IsLogging(DiscordLogLevel.Verbose))
            {
                string json = writer.ReadAsString();
                if (payload.OpCode == GatewayCommandCode.Identify)
                {
                    json = json.Replace(_client.Connection.ApiToken, _client.Connection.HiddenToken);
                }

                _logger.Verbose($"{nameof(DiscordWebSocket)}.{nameof(SendAsync)} Sending Payload {{0}} Body: {{1}}", payload.OpCode, json);
            }

            return Handler.SendAsync(writer.Stream);
        }

        /// <summary>
        /// Reconnected to the websocket is a reconnect is requested and we are not shutting down
        /// </summary>
        public void ReconnectIfRequested()
        {
            if (ShouldReconnect && !_isShutdown)
            {
                _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Disconnect)} Attempting Reconnect");
                ShouldReconnect = false;
                WebsocketReconnectCallback.Start(_reconnect);
            }
        }

        internal void OnSocketConnected()
        {
            _reconnect.CancelReconnect();
        }
        
        internal void OnSocketReady(GatewayReadyEvent ready)
        {
            _sessionId = ready.SessionId;
            _resumeSessionUrl = ready.ResumeSessionUrl;
            SocketHasConnected = true;
            ShouldResume = true;
            _reconnect.OnWebsocketReady();
            _commands.OnWebSocketReady();
        }

        internal void OnSocketDisconnected()
        {
            _commands.OnSocketDisconnected();
        }

        internal void OnSequenceUpdate(int? sequence)
        {
            if (sequence.HasValue)
            {
                _sequence = sequence.Value;
            }
        }

        internal async ValueTask OnDiscordHello(GatewayHelloEvent hello)
        {
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(OnDiscordHello)}");

            // Client should now perform identification
            if (ShouldResume && !string.IsNullOrEmpty(_sessionId))
            {
                await Resume().ConfigureAwait(false);
            }
            else
            {
                await Identify().ConfigureAwait(false);
            }
            
            _heartbeat.SetupHeartbeat(hello.HeartbeatInterval);
        }

        /// <summary>
        /// Used to Identify the bot with discord
        /// </summary>
        internal ValueTask Identify()
        {
            // Sent immediately after connecting. Opcode 2: Identify
            // Ref: https://discord.com/developers/docs/topics/gateway#identifying
            if (!_client.Initialized)
            {
                return new ValueTask();
            }
            
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Identify)} Identifying bot with discord.");

            IdentifyCommand identify = new()
            {
                Token = _client.Connection.ApiToken,
                Properties = Gateway.Properties,
                Intents = _client.Connection.Intents,
                Compress = false,
                LargeThreshold = 50,
                Shard = Gateway.Shard
            };

            return SendImmediatelyAsync(GatewayCommandCode.Identify, identify);
        }
        
        /// <summary>
        /// Used to resume the current session with discord
        /// </summary>
        private ValueTask Resume()
        {
            if (!_client.Initialized)
            {
                return new ValueTask();
            }

            ResumeSessionCommand resume = new()
            {
                Sequence = _sequence,
                SessionId = _sessionId,
                Token = _client.Connection.ApiToken
            };

            _sessionId = null;
            
            _logger.Debug($"{nameof(DiscordWebSocket)}.{nameof(Resume)} Attempting to resume session with ID: {{0}} Sequence: {{1}}", _sessionId, _sequence);
            return SendImmediatelyAsync(GatewayCommandCode.Resume, resume);
        }
        
        internal void OnHeartbeatAcknowledge()
        {
            _heartbeat.OnHeartbeatAcknowledge();
        }
        
        /// <summary>
        /// Sends a heartbeat to Discord
        /// </summary>
        internal ValueTask SendHeartbeat()
        {
            if (IsConnected())
            {
                return SendImmediatelyAsync(GatewayCommandCode.Heartbeat, _sequence);
            }
            
            return new ValueTask();
        }

        internal void OnInvalidSession(bool resume)
        {
            bool shouldResume = !string.IsNullOrEmpty(_sessionId) && resume;
            _logger.Warning("Invalid Session ID opcode received! Attempting to reconnect. Should Resume? {0}", shouldResume);
            if (!resume)
            {
                _sessionId = null;
            }
            Disconnect(true, shouldResume);
        }

        internal void OnReconnectRequested()
        {
            _logger.Debug("Discord has requested a reconnect. Reconnecting...");
            //If we disconnect normally, our session becomes invalid per: https://discord.com/developers/docs/topics/gateway#resuming
            Disconnect(true, true, true);
        }
        
        /// <summary>
        /// Returns if the websocket is in the connecting state
        /// </summary>
        /// <returns>Returns if the websocket is in connecting state</returns>
        public bool IsConnecting() => Handler.SocketState == SocketState.Connecting;

        /// <summary>
        /// Returns if the websocket is in the open state
        /// </summary>
        /// <returns>Returns if the websocket is in open state</returns>
        public bool IsConnected() => Handler.SocketState == SocketState.Connected;

        /// <summary>
        /// Returns if the socket is waiting to reconnect
        /// </summary>
        /// <returns>Returns if the socket is waiting to reconnect</returns>
        public bool IsPendingReconnect() => _reconnect.IsPendingReconnect;

        /// <summary>
        /// Returns if the websocket is null or is currently closing / closed
        /// </summary>
        /// <returns>Returns if the websocket is null or is currently closing / closed</returns>
        public bool IsDisconnecting() => Handler.SocketState == SocketState.Disconnecting;

        /// <summary>
        /// Returns if the websocket is null or is currently closing / closed
        /// </summary>
        /// <returns>Returns if the websocket is null or is currently closing / closed</returns>
        public bool IsDisconnected() => Handler.SocketState == SocketState.Disconnected;

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendFieldEnum("State", Handler.SocketState);
            logger.AppendList("Pending Commands", _commands.GetPendingCommands());
        }
    }
}