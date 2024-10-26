using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Interface for Discord Logging Configuration
    /// </summary>
    public interface IDiscordLoggingConfig
    {
        /// <summary>
        /// Log Level for the Console
        /// </summary>
        DiscordLogLevel ConsoleLogLevel { get; }
        
        /// <summary>
        /// Log Level for file Logging
        /// </summary>
        DiscordLogLevel FileLogLevel { get; }
        
        /// <summary>
        /// File Logging DateTime format
        /// </summary>
        string FileDateTimeFormat { get; }
    }
}