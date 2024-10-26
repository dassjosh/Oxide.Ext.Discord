using System.Collections.Concurrent;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a WebSocket Rate Limit
    /// </summary>
    public class WebsocketRateLimit : BaseRateLimit
    {
        private readonly ConcurrentDictionary<PluginId, int> _pluginRequests = new();
        internal const int MaxRequestPerPlugin = 60;
        internal const long RateLimitInterval = 60 * 1000L;

        /// <summary>
        /// Constructor for WebsocketRateLimit
        /// </summary>
        public WebsocketRateLimit(ILogger logger) : base(110, RateLimitInterval, logger) { }
        
        /// <summary>
        /// Called when an API request is fired
        /// </summary>
        public void FiredRequest(WebSocketCommand command)
        {
            _pluginRequests.TryGetValue(command.Client.PluginId, out int numRequest);
            _pluginRequests[command.Client.PluginId] = numRequest + 1;
            Logger.Debug($"{nameof(WebsocketRateLimit)}.{nameof(FiredRequest)} For {{0}} Num Requests {{1}}", command.Client.PluginId, numRequest + 1);
            FiredRequestInternal();
        }

        /// <summary>
        /// Returns if the client can return the given command.
        /// This is used to limit plugins to a certain number of websocket commands per rate limit tick
        /// </summary>
        /// <param name="command">Command that is to be ran</param>
        /// <returns>True if the command can run; False otherwise</returns>
        public bool CanFireRequest(WebSocketCommand command) => !_pluginRequests.TryGetValue(command.Client.PluginId, out int numRequest) || numRequest < MaxRequestPerPlugin;

        ///<inheritdoc/>
        protected override void OnRateLimitReset()
        {
            _pluginRequests.Clear();
            if (NumRequests > 0)
            {
                Logger.Debug($"{nameof(RestRateLimit)}.{nameof(OnRateLimitReset)} Num Requests: {{0}} Reached Rate Limit: {{1}}", NumRequests, HasReachedRateLimit);
            }
        }
    }
}