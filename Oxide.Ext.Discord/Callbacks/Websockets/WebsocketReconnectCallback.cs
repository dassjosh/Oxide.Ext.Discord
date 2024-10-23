﻿using System.Threading.Tasks;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.WebSockets;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class WebsocketReconnectCallback : BaseAsyncCallback
    {
        private WebSocketReconnectHandler _reconnect;

        public static void Start(WebSocketReconnectHandler reconnect)
        {
            WebsocketReconnectCallback callback = DiscordPool.Internal.Get<WebsocketReconnectCallback>();
            callback.Init(reconnect);
            callback.Run();
        }

        private void Init(WebSocketReconnectHandler reconnect)
        {
            _reconnect = reconnect;
        }
        
        protected override ValueTask HandleCallback()
        {
            return _reconnect.StartReconnect();
        }

        protected override string GetExceptionMessage()
        {
            return $"Websocket: {_reconnect.WebSocket.Handler.WebsocketId}";
        }

        protected override void EnterPool()
        {
            _reconnect = null;
        }
    }
}