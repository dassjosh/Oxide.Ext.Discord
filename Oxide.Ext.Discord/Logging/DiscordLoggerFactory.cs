using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Logging
{
    /// <summary>
    /// Factory for creating DiscordLoggers
    /// </summary>
    public sealed class DiscordLoggerFactory : Singleton<DiscordLoggerFactory>
    {
        private readonly Hash<string, DiscordLogHandler> _handlers = new();

        private DiscordLoggerFactory() {}
        
        /// <summary>
        /// Returns a newly created <see cref="DiscordLogger"/> for a given plugin
        /// </summary>
        /// <param name="plugin">Plugin the logger is for</param>
        /// <param name="logLevel">The current LogLevel for the logger</param>
        /// <param name="config">The config for the logger</param>
        /// <returns><see cref="DiscordLogger"/></returns>
        public DiscordLogger CreateLogger(Plugin plugin, DiscordLogLevel logLevel, IDiscordLoggingConfig config)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            return GetLoggerInternal(plugin.Name, logLevel, config, false);
        }

        internal DiscordLogLevel GetLogLevel()
        {
            return DiscordConfig.Instance.Logging.ConsoleLogLevel <= DiscordConfig.Instance.Logging.FileLogLevel ? DiscordConfig.Instance.Logging.ConsoleLogLevel : DiscordConfig.Instance.Logging.FileLogLevel;
        }
        
        internal DiscordLogLevel GetLogLevel(DiscordLogLevel level)
        {
            DiscordLogLevel globalLevel = GetLogLevel();
            return level < globalLevel ? level : globalLevel;
        }

        internal DiscordLogger CreateExtensionLogger() => CreateExtensionLogger(GetLogLevel());
        internal DiscordLogger CreateExtensionLogger(DiscordLogLevel logLevel) => GetLoggerInternal(nameof(DiscordExtension), GetLogLevel(logLevel), DiscordConfig.Instance.Logging, true);

        private DiscordLogger GetLoggerInternal(string pluginName, DiscordLogLevel logLevel, IDiscordLoggingConfig config, bool isExtension)
        {
            DiscordLogHandler handler = _handlers[pluginName];
            if (handler == null)
            {
                handler = new DiscordLogHandler(pluginName, config, isExtension);
                _handlers[pluginName] = handler;
            }

            return new DiscordLogger(logLevel, config, handler);
        }

        internal void OnPluginUnloaded(Plugin plugin)
        {
            string name = plugin.Name;
            _handlers[name]?.Shutdown();
            _handlers.Remove(name);
        }
        
        internal void OnServerShutdown()
        {
            foreach (DiscordLogHandler handler in _handlers.Values)
            {
                handler.Shutdown();
            }
            
            _handlers.Clear();
            DiscordFileLoggerFactory.Instance.OnServerShutdown();
        }
    }
}