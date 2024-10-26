using Oxide.Ext.Discord.Clients;

namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Represents the completed status for the request
    /// </summary>
    public enum RequestCompletedStatus : byte
    {
        /// <summary>
        /// The request completed successfully
        /// </summary>
        Success,
        
        /// <summary>
        /// The request encountered a fatal error
        /// </summary>
        ErrorFatal,
        
        /// <summary>
        /// The error attempt multiple times to complete the request and was unsuccessful
        /// </summary>
        ErrorRetry,
        
        /// <summary>
        /// The request was canceled. The <see cref="DiscordClient"/> was disconnected while making the request
        /// </summary>
        Cancelled
    }
}