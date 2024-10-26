namespace Oxide.Ext.Discord.Constants
{
    /// <summary>
    /// Discord API endpoint settings
    /// </summary>
    public static class DiscordEndpoints
    {
        /// <summary>
        /// Represents Discord Rest API endpoints
        /// </summary>
        public static class Rest
        {
            /// <summary>
            /// Base URL for Discord
            /// </summary>
            public const string DiscordBaseUrl = "https://discord.com/api";

            /// <summary>
            /// API Version for Rest requests
            /// </summary>
            public const string ApiVersion = "v10";
        
            /// <summary>
            /// Discord API Url
            /// </summary>
            public const string ApiUrl = DiscordBaseUrl + "/" + ApiVersion + "/";
        }

        /// <summary>
        /// Represents Discord Websocket Connection Args
        /// </summary>
        public static class Websocket
        {
            /// <summary>
            /// Which websocket version to use
            /// </summary>
            public const string Version = "10";

            /// <summary>
            /// How the data sent / received will be encoded
            /// </summary>
            public const string Encoding = "json";

            /// <summary>
            /// Generated connection string for the websocket
            /// </summary>
            /// <returns></returns>
            public static readonly string WebsocketArgs = $"v={Version}&encoding={Encoding}";
        }
    }
}