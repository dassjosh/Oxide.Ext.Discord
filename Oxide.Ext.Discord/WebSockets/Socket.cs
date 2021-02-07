using System;
using System.Timers;
using Newtonsoft.Json;
using uMod.Ext.Discord.Exceptions;
using uMod.Ext.Discord.Gateway;
using uMod.Ext.Discord.Logging;
using WebSocketSharp;

namespace uMod.Ext.Discord.WebSockets
{
    public class Socket
    {
        public bool RequestReconnect;
        
        public bool ShouldAttemptResume;
        
        internal Timer ReconnectTimer;
        
        private readonly DiscordClient _client;

        private WebSocket _socket;

        private SocketListener _listener;

        private readonly ILogger _logger;

        public Socket(DiscordClient client)
        {
            _client = client;
            _logger = new Logging.Logger(client.Settings.LogLevel);
        }

        public void Connect()
        {
            string url = DiscordObjects.Gateway.WebSocketUrl;
            if (string.IsNullOrEmpty(url))
            {
                _client.UpdateGatewayUrl(Connect);
                return;
            }

            if (_socket != null)
            {
                throw new SocketRunningException(_client);
                // Assume force-reconnect
                //Disconnect(false);
            }

            _socket = new WebSocket($"{url}/?v=6&encoding=json");

            if (_listener == null)
            {
                _listener = new SocketListener(_client, this, _logger);
            }

            _socket.OnOpen += _listener.SocketOpened;
            _socket.OnClose += _listener.SocketClosed;
            _socket.OnError += _listener.SocketErrored;
            _socket.OnMessage += _listener.SocketMessage;
            _socket.ConnectAsync();
        }
        

        public void Disconnect(bool attemptReconnect, bool shouldResume, bool requested = false)
        {
            RequestReconnect = attemptReconnect;
            ShouldAttemptResume = shouldResume;
            
            if (ReconnectTimer != null)
            {
                ReconnectTimer.Stop();
                ReconnectTimer.Dispose();
                ReconnectTimer = null;
            }
            
            if (IsClosingOrClosed())
            {
                return;
            }

            if (requested)
            {
                _socket.CloseAsync(4199, "Discord server requested reconnect");
            }
            else
            {
                _socket.CloseAsync(CloseStatusCode.Normal);
            }

            DisposeSocket();
        }

        public void Shutdown()
        {
            if (ReconnectTimer != null)
            {
                ReconnectTimer.Stop();
                ReconnectTimer.Dispose();
                ReconnectTimer = null;
            }
            
            Disconnect(false, false);
            _listener = null;
            _socket = null;
        }

        public void DisposeSocket()
        {
            if (_socket != null)
            {
                _socket.OnOpen -= _listener.SocketOpened;
                _socket.OnError -= _listener.SocketErrored;
                _socket.OnMessage -= _listener.SocketMessage;
                _socket = null;
            }
        }

        public void Send(SendOpCode opCode, object data, Action<bool> completed = null)
        {
            if (!IsAlive())
            {
                return;
            }
            
            SPayload opcode = new SPayload
            {
                OpCode = opCode,
                Payload = data
            };
            
            _socket.SendAsync(JsonConvert.SerializeObject(opcode), completed);
        }

        public void Send(string message, Action<bool> completed = null)
        {
            if (IsAlive())
            {
                _socket.SendAsync(message, completed);
            }
        }

        public bool IsAlive()
        {
            if (_socket == null)
            {
                return false;
            }
            
            return _socket.ReadyState == WebSocketState.Open;
        }
        
        public bool IsConnecting()
        {
            if (_socket == null)
            {
                return false;
            }
            
            return _socket.ReadyState == WebSocketState.Connecting;
        }

        public bool IsClosingOrClosed()
        {
            if (_socket == null)
            {
                return true;
            }

            return _socket.ReadyState == WebSocketState.Closing || _socket.ReadyState == WebSocketState.Closed;
        }
        
        public bool IsReconnectTimerActive()
        {
            return ReconnectTimer != null && ReconnectTimer.Enabled;
        }

        public void StartReconnectTimer(float seconds, Action callback)
        {
            if (IsReconnectTimerActive())
            {
                return;
            }
            
            ReconnectTimer = new Timer
            {
                Interval = seconds * 1000,
                AutoReset = false
            };
            ReconnectTimer.Elapsed += (_, __) =>
            {
                callback.Invoke();
            };
            
            ReconnectTimer.Start();
        }
    }
}
