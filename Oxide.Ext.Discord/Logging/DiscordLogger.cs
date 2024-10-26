using System;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Logging
{
    /// <summary>
    /// Represents a discord extension logger
    /// </summary>
    public class DiscordLogger : ILogger
    {
        ///<inheritdoc/>
        public DiscordLogLevel LogLevel { get; private set; }
        private readonly IDiscordLoggingConfig _config;
        private readonly DiscordLogHandler _handler;

        /// <summary>
        /// Creates a new logger with the given log level
        /// </summary>
        /// <param name="logLevel">Log level of the logger</param>
        /// <param name="config">Configuration for the logger</param>
        /// <param name="handler">Handler for the logger</param>
        internal DiscordLogger(DiscordLogLevel logLevel, IDiscordLoggingConfig config, DiscordLogHandler handler)
        {
            LogLevel = logLevel;
            _config = config;
            _handler = handler;
        }

        /// <inheritdoc/>
        public void Log(DiscordLogLevel level, string log, object[] args, Exception exception = null)
        {
            DiscordLoggerException.ThrowIfShutdown(_handler);
            if (IsConsoleLogging(level))
            {
                _handler.LogConsole(level, log, args,  exception);
            }

            if (IsFileLogging(level))
            {
                _handler.LogFile(level, log, args, exception);
            }
        }

        /// <inheritdoc/>
        public void UpdateLogLevel(DiscordLogLevel level)
        {
            LogLevel = level;
        }

        /// <inheritdoc/>
        public bool IsLogging(DiscordLogLevel level)
        {
            return level >= LogLevel && (level >= _config.ConsoleLogLevel || level >= _config.FileLogLevel);
        }
        
        /// <inheritdoc/>
        public bool IsConsoleLogging(DiscordLogLevel level)
        {
            return level >= LogLevel && level >= _config.ConsoleLogLevel;
        }
        
        /// <inheritdoc/>
        public bool IsFileLogging(DiscordLogLevel level)
        {
            return level >= LogLevel && level >= _config.FileLogLevel;
        }
        
        /// <inheritdoc/>
        public void Shutdown()
        {
            _handler.Shutdown();
        }
    }
}