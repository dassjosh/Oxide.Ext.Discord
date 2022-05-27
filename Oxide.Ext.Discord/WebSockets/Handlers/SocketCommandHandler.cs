using System;
using System.Collections.Generic;
using System.Timers;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Gatway;
using Oxide.Ext.Discord.Entities.Gatway.Commands;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.RateLimits;

namespace Oxide.Ext.Discord.WebSockets.Handlers
{
    /// <summary>
    /// Handles command queueing when the websocket is down
    /// </summary>
    public class SocketCommandHandler
    {
        private readonly BotClient _client;
        private readonly Socket _webSocket;
        private readonly ILogger _logger;
        private readonly List<CommandPayload> _pendingCommands = new List<CommandPayload>();
        private readonly WebsocketRateLimit _rateLimit = new WebsocketRateLimit();
        private Timer _rateLimitTimer;
        private readonly object _syncRoot = new object();
        private bool _socketCanSendCommands;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Bot Client for socket commands</param>
        /// <param name="webSocket">Websocket to handle commands for</param>
        /// <param name="logger">Logger for this handler</param>
        public SocketCommandHandler(BotClient client, Socket webSocket, ILogger logger)
        {
            _client = client;
            _webSocket = webSocket;
            _logger = logger;
            
            _rateLimitTimer = new Timer(1000);
            _rateLimitTimer.AutoReset = false;
            _rateLimitTimer.Elapsed += RateLimitElapsed;
        }

        /// <summary>
        /// Enqueue a payload to be sent over the websocket
        /// If the websocket is connected it will be sent immediately
        /// If the websocket is not connected it will be queued until it is back online
        /// </summary>
        /// <param name="command">Command to send over the websocket</param>
        public void Enqueue(CommandPayload command)
        {
            _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(Enqueue)} Queuing command {{0}}", command.OpCode);

            //If websocket has connect and we need to identify or resume send those payloads right away
            if (_webSocket.IsConnected() && (command.OpCode == GatewayCommandCode.Identify || command.OpCode == GatewayCommandCode.Resume))
            {
                _webSocket.Send(command);
                return;
            }
            
            //If the websocket isn't fully connect enqueue the command until it is ready
            if (!_socketCanSendCommands)
            {
                if (command.OpCode == GatewayCommandCode.PresenceUpdate)
                {
                    RemoveByType(GatewayCommandCode.PresenceUpdate);
                }
                else if (command.OpCode == GatewayCommandCode.VoiceStateUpdate)
                {
                    RemoveByType(GatewayCommandCode.VoiceStateUpdate);
                }

                AddCommand(command);
                return;
            }
            
            AddCommand(command);
            SendCommands();
        }

        internal void OnSocketConnected()
        {
            _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(OnSocketConnected)} Socket Connected. Sending queued commands.");
            _socketCanSendCommands = true;
            SendCommands();
        }

        internal void OnSocketDisconnected()
        {
            _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(OnSocketConnected)} Socket Disconnected. Queuing Commands.");
            _socketCanSendCommands = false;
        }

        private void RateLimitElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(RateLimitElapsed)} Rate Limit has elapsed. Send Queued Commands");
            _rateLimitTimer.Stop();
            if (!_socketCanSendCommands)
            {
                _rateLimitTimer.Interval = 1000;
                _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(RateLimitElapsed)} Can't send commands right now. Trying again in 1 second");
                _rateLimitTimer.Start();
                return;
            }

            SendCommands();
        }
        
        private void SendCommands()
        {
            while (GetCommandCount() != 0)
            {
                CommandPayload payload = GetNextCommand();
                if (!SendCommand(payload))
                {
                    return;
                }
            }
        }
        
        private bool SendCommand(CommandPayload payload)
        {
            if (_rateLimit.HasReachedRateLimit)
            {
                if (!_rateLimitTimer.Enabled)
                {
                    DateTimeOffset nextReset = _rateLimit.NextReset();
                    _rateLimitTimer.Interval = nextReset.SecondsUntilTime();
                    _rateLimitTimer.Stop();
                    _rateLimitTimer.Start();
                    _logger.Warning($"{nameof(SocketCommandHandler)}.{nameof(SendCommands)} Rate Limit Hit! Retrying in {{0}} seconds\nOpcode: {{1}}\nPayload: {{2}}", nextReset, payload.OpCode, JsonConvert.SerializeObject(payload.Payload, _client.ClientSerializerSettings));
                }

                return false;
            }

            _logger.Debug($"{nameof(SocketCommandHandler)}.{nameof(SendCommands)} Sending Command {{0}}", payload.OpCode);

            if (!_webSocket.Send(payload))
            {
                return false;
            }

            RemoveCommand();
            _rateLimit.FiredRequest();
            return true;
        }

        private void AddCommand(CommandPayload command)
        {
            lock (_syncRoot)
            {
                if (command.OpCode == GatewayCommandCode.Identify || command.OpCode == GatewayCommandCode.Resume)
                {
                    _pendingCommands.Insert(0, command);
                    return;
                }
                _pendingCommands.Add(command);
            }
        }
        
        private void RemoveByType(GatewayCommandCode code)
        {
            lock (_syncRoot)
            {
                for (int index = _pendingCommands.Count - 1; index >= 0; index--)
                {
                    CommandPayload command = _pendingCommands[index];
                    if (command.OpCode == code)
                    {
                        _pendingCommands.RemoveAt(index);
                        command.Dispose();
                    }
                }
            }
        }

        private int GetCommandCount()
        {
            lock (_syncRoot)
            {
                return _pendingCommands.Count;
            }
        }

        private CommandPayload GetNextCommand()
        {
            lock (_syncRoot)
            {
                return _pendingCommands[0];
            }
        }

        private void RemoveCommand()
        {
            lock (_syncRoot)
            {
                CommandPayload command = GetNextCommand();
                _pendingCommands.RemoveAt(0);
                command.Dispose();
            }
        }

        internal void OnSocketShutdown()
        {
            _rateLimitTimer?.Dispose();
            _rateLimitTimer = null;
        }
    }
}