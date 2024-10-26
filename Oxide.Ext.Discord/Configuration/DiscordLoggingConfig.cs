using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// Represents Discord Extension Logging Config
    /// </summary>
    internal class DiscordLoggingConfig : IDiscordLoggingConfig
    {
        /// <summary>
        /// Server Console Log Level
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("Server Console Log Level")]
        public DiscordLogLevel ConsoleLogLevel { get; set; }
        
        /// <summary>
        /// File Log Level
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("File Log Level")]
        public DiscordLogLevel FileLogLevel { get; set; }

        /// <summary>
        /// Discord Response Error codes that will not be logged
        /// </summary>
        [JsonProperty("Hide Discord Error Codes")]
        public HashSet<int> HideDiscordErrorCodes { get; set; }
        
        /// <summary>
        /// DateTime format for file logging
        /// </summary>
        [JsonProperty("File DateTime Format")]
        public string FileDateTimeFormat { get; set; }
    }
}