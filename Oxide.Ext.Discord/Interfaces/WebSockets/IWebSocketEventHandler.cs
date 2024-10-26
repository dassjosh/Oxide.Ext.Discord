using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents a Handler for Websocket Events
    /// </summary>
    public interface IWebSocketEventHandler
    {
        /// <summary>
        /// Called when the web socket is opened
        /// </summary>
        /// <param name="webSocketId">ID of the web socket</param>
        /// <returns></returns>
        ValueTask SocketOpened(Snowflake webSocketId);

        /// <summary>
        /// Called when the web socket is closed
        /// </summary>
        /// <param name="webSocketId">ID of the websocket</param>
        /// <param name="status">Web socket close code</param>
        /// <param name="message">Web socket close message</param>
        /// <returns></returns>
        ValueTask SocketClosed(Snowflake webSocketId, WebSocketCloseStatus status, string message);

        /// <summary>
        /// Called when an error occurs on the web socket
        /// </summary>
        /// <param name="webSocketId">ID of the websocket</param>
        /// <param name="ex">Exception that was thrown</param>
        /// <returns></returns>
        ValueTask SocketErrored(Snowflake webSocketId, Exception ex);

        /// <summary>
        /// Called when a message is received from the websocket
        /// </summary>
        /// <param name="webSocketId">ID of the message</param>
        /// <param name="stream">Stream containing the message</param>
        /// <returns></returns>
        ValueTask SocketMessage(Snowflake webSocketId, DiscordJsonReader stream);
    }
}