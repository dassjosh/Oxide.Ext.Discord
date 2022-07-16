namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Represents our current state for the websocket
    /// </summary>
    public enum SocketState : byte
    {
        /// <summary>
        /// Websocket is currently disconnect and not waiting to connect
        /// </summary>
        Disconnected,
        
        /// <summary>
        /// Socket is connect and functioning normally
        /// </summary>
        Connected,
        
        /// <summary>
        /// Socket is in the process of connecting
        /// </summary>
        Connecting,
        
        /// <summary>
        /// Websocket is currently disconnecting from a connected web socket
        /// </summary>
        Disconnecting,
        
        /// <summary>
        /// Socket is waiting to reconnect to the websocket
        /// </summary>
        PendingReconnect
    }
}