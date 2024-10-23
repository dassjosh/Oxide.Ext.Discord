using System.Timers;
using Oxide.Core;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Handles the heartbeating for the websocket connection
    /// </summary>
    public class DiscordHeartbeatHandler
    {
        /// <summary>
        /// Discord Acknowledged our heartbeat successfully 
        /// </summary>
        private bool _heartbeatAcknowledged;
        
        private readonly BotClient _client;
        private readonly DiscordWebSocket _socket;
        private readonly ILogger _logger;
        private Timer _timer;
        private float _interval;
        private bool _initial;

        /// <summary>
        /// Constructor for Heartbeat Handler
        /// </summary>
        /// <param name="client">Client for the handler</param>
        /// <param name="socket">Socket for the heartbeat</param>
        /// <param name="logger">Logger for the bot</param>
        public DiscordHeartbeatHandler(BotClient client, DiscordWebSocket socket, ILogger logger)
        {
            _client = client;
            _socket = socket;
            _logger = logger;
            _timer = new Timer();
            _timer.Elapsed += HeartbeatElapsed;
        }
        
        #region Heartbeat
        /// <summary>
        /// Setup a heartbeat for this bot with the given interval
        /// </summary>
        /// <param name="interval"></param>
        internal void SetupHeartbeat(float interval)
        {
            _timer.Stop();
            _heartbeatAcknowledged = true;
            _interval = interval;
            _initial = true;
            _timer.Interval = _interval * Random.Range(0f, 1f);
            _timer.Start();
            _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(SetupHeartbeat)} Creating heartbeat with interval {{0}}ms.", interval);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordSetupHeartbeat, interval);
        }

        internal void OnHeartbeatAcknowledge()
        {
            _heartbeatAcknowledged = true;
        }

        /// <summary>
        /// Destroy the heartbeat timer on this bot
        /// </summary>
        public void OnSocketShutdown()
        {
            if(_timer != null)
            {
                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(OnSocketShutdown)} Destroy Heartbeat");
                _timer.Dispose();
                _timer = null;
            }
        }

        private void HeartbeatElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Verbose($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed");

            if (_initial)
            {
                _timer.Interval = _interval;
                _initial = false;
            }

            if (!_socket.SocketHasConnected)
            {
                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Websocket has not yet connected successfully. Skipping Heartbeat.");
                return;
            }
            
            if (_socket.IsPendingReconnect())
            {
                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Websocket is offline and is waiting to connect.");
                return;
            }

            if (_socket.IsDisconnected())
            {
                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Websocket is offline and is NOT connecting. Attempt Reconnect.");
                _socket.ShouldReconnect = true;
                _socket.ReconnectIfRequested();
                return;
            }

            if (_socket.IsDisconnecting())
            {
                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Websocket is currently in the process of disconnecting");
                return;
            }
            
            if(!_heartbeatAcknowledged)
            {
                //Discord did not acknowledge our last sent heartbeat. This is a zombie connection we should reconnect.
                if (_socket.IsConnected())
                {
                    _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and WebSocket is connected. Forcing reconnect.");
                    _socket.Disconnect(true, true, true);
                    return;
                }

                //Websocket isn't connected or waiting to reconnect. We should reconnect.
                if (!_socket.IsConnecting() && !_socket.IsPendingReconnect())
                {
                    _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online or connecting.");
                    _socket.ShouldReconnect = true;
                    _socket.ReconnectIfRequested();
                    return;
                }

                _logger.Debug($"{nameof(DiscordHeartbeatHandler)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online but is waiting to connecting or waiting to reconnect.");
                return;
            }
            
            SendHeartbeat();
        }
        
        /// <summary>
        /// Sends a heartbeat to discord.
        /// If the previous heartbeat wasn't acknowledged, then we will attempt to reconnect
        /// </summary>
        private void SendHeartbeat()
        {
            _heartbeatAcknowledged = false;
            _socket.SendHeartbeat();
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordHeartbeatSent);
            _logger.Verbose("Heartbeat sent - {0}ms interval.", _timer.Interval);
        }
        #endregion
    }
}