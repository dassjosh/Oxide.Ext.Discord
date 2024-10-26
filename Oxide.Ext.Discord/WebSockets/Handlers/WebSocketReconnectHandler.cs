using System;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Handles reconnecting to the web socket
    /// </summary>
    internal class WebSocketReconnectHandler
    {
        internal readonly DiscordWebSocket WebSocket;
        private readonly BotClient _client;
        private readonly ILogger _logger;
        private int _reconnectRetries;
        private CancellationTokenSource _source;

        public bool IsPendingReconnect { get; private set; }
        
        internal bool AttemptGatewayUpdate => _reconnectRetries >= 3;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="webSocket"></param>
        /// <param name="logger"></param>
        public WebSocketReconnectHandler(BotClient client, DiscordWebSocket webSocket, ILogger logger)
        {
            _client = client;
            WebSocket = webSocket;
            _logger = logger;
        }

        /// <summary>
        /// Starts the reconnect process
        /// </summary>
        public async ValueTask StartReconnect()
        {
            if (!_client.Initialized)
            {
                _logger.Debug("Skipping reconnect. BotClient is not Initialized");
                return;
            }

            if (!WebSocket.IsDisconnected() && !WebSocket.IsDisconnecting())
            {
                _logger.Debug("Skipping reconnect. Websocket is not Disconnected or Disconnecting");
                return;
            }

            if (IsPendingReconnect)
            {
                _logger.Debug("Skipping reconnect. Reconnect is already in progress.");
                return;
            }

            try
            {
                IsPendingReconnect = true;
                CancelReconnect();
                _source = new CancellationTokenSource();

                int delay = GetReconnectDelay();

                if (_reconnectRetries == 0)
                {
                    _logger.Info("Reconnecting to Discord.");
                }
                else
                {
                    _logger.Info("Reconnecting to Discord. Retry: #{0} Delay: {1}ms", _reconnectRetries, delay);
                }

                _reconnectRetries++;
                await Task.Delay(delay, _source.Token).ConfigureAwait(false);
                Connect();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.Exception("An error occured during websocket reconnect", ex);
            }
            finally
            {
                IsPendingReconnect = false;
            }
        }

        private void Connect()
        {
            if (WebSocket.IsConnected() || WebSocket.IsConnecting())
            {
                _logger.Debug("Skipping Connect. Socket is: {0}", WebSocket.Handler.SocketState);
                return;
            }
            
            WebSocket.Connect();
        }
        
        /// <summary>
        /// Cancels the reconnect timer
        /// </summary>
        public void CancelReconnect()
        {
            if (_source is {IsCancellationRequested: false})
            {
                _source.Cancel();
            }
        }

        /// <summary>
        /// Called when the websocket received a ready event from discord
        /// </summary>
        public void OnWebsocketReady() => _reconnectRetries = 0;

        /// <summary>
        /// Called when the bot is shutting down
        /// </summary>
        public void OnSocketShutdown() => CancelReconnect();

        private int GetReconnectDelay()
        {
            return _reconnectRetries switch
            {
                0 => 1000 / 60,
                <= 3 => 1 * 1000 + Core.Random.Range(100, 250),
                <= 25 => 15 * 1000 + Core.Random.Range(250, 500),
                _ => 60 * 1000 + Core.Random.Range(500, 1000)
            };
        }
    }
}