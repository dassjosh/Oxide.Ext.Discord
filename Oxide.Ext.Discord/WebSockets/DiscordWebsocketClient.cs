using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.WebSockets
{
    internal class DiscordWebsocketClient : IDisposable
    {
        public readonly Snowflake WebsocketId;
        public SocketState SocketState { get; private set; }
        
        public CancellationToken Token => _source.Token;
        public WebSocketState WebSocketState => _socket.State;
        public bool IsCancelRequested => _source.IsCancellationRequested;
        public WebSocketCloseStatus? CloseStatus => _socket.CloseStatus;
        public string CloseStatusDescription => _socket.CloseStatusDescription;

        private readonly ClientWebSocket _socket = new();
        private readonly CancellationTokenSource _source = new();
        private readonly ILogger _logger;
        
        private bool _isDisposed;
        private bool _socketClosed;

        public DiscordWebsocketClient(ILogger logger)
        {
            _logger = logger;
            WebsocketId = SnowflakeIdFactory.Instance.Generate();
            SocketState = SocketState.Connecting;
            _socket.Options.KeepAliveInterval = TimeSpan.Zero;
        }

        private void SetSocketState(SocketState state)
        {
            if (SocketState > state)
            {
                throw new Exception($"Trying to set SocketState to a lower state {state} < {SocketState}");
            }

            SocketState = state;
        }

        public async ValueTask ConnectAsync(Uri uri)
        {
            await _socket.ConnectAsync(uri, Token).ConfigureAwait(false);
            SetSocketState(SocketState.Connected);
        }

        public ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer) => _socket.ReceiveAsync(buffer, Token);

        public ValueTask SendAsync(Memory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage) => _socket.SendAsync(buffer, messageType, endOfMessage, Token);

        public async ValueTask CloseSocket(WebSocketCloseStatus status, string reason)
        {
            SetSocketState(SocketState.Disconnecting);

            if (_socket.State == WebSocketState.CloseReceived)
            {
                _logger.Debug("Closing Socket Output for ID: {0}", WebsocketId);
                await _socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, string.Empty, Token).ConfigureAwait(false);
            }
            else
            {
                _logger.Debug("Closing Socket for ID: {0}", WebsocketId);
                await _socket.CloseAsync(status, reason, Token).ConfigureAwait(false);
            }

            _socketClosed = true;
            _logger.Debug("{0} Socket Closed Successfully", WebsocketId);
        }

        public void Dispose()
        {
            _logger.Debug("Disposing Client {0}", WebsocketId);
            if (_isDisposed)
            {
                _logger.Debug("{0} already disposed", WebsocketId);
                return;
            }

            _isDisposed = true;
            
            SetSocketState(SocketState.Disconnected);
            if (Token.CanBeCanceled)
            {
                _source.Cancel();
            }
            
            if (!_socketClosed)
            {
                _socket.Dispose();
            }
            
            _logger.Debug("{0} Dispose Complete", WebsocketId);
        }
    }
}