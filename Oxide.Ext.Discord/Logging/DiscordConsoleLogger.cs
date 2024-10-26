using System;
using System.Text;
using System.Threading;
using Oxide.Core;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Logging
{
    /// <summary>
    /// Represents a Console Logger for Discord
    /// </summary>
    internal class DiscordConsoleLogger : IOutputLogger
    {
        private readonly string _pluginName;

        private static readonly ThreadLocal<StringBuilder> Builder = new(() => new StringBuilder());

        public DiscordConsoleLogger(string pluginName)
        {
            _pluginName = $"[{pluginName}] ";
        }

        /// <summary>
        /// Adds a message to the server console
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        /// <param name="args"></param>
        /// <param name="ex"></param>
        public void AddMessage(DiscordLogLevel level, string log, object[] args, Exception ex)
        {
            StringBuilder sb = Builder.Value;
            sb.Clear();
            sb.Append(_pluginName);
            sb.Append('[');
            sb.Append(EnumCache<DiscordLogLevel>.Instance.ToString(level));
            sb.Append("]: ");
            if (args.Length != 0)
            {
                sb.AppendFormat(log, args);
            }
            else
            {
                sb.Append(log);
            }

            string message = sb.ToString();

            switch (level)
            {
                case DiscordLogLevel.Debug:
                case DiscordLogLevel.Warning:
                    Interface.Oxide.LogWarning(message, Array.Empty<object>());
                    break;
                case DiscordLogLevel.Error:
                    Interface.Oxide.LogError(message, Array.Empty<object>());
                    break;
                case DiscordLogLevel.Exception:
                    Interface.Oxide.LogException(message, ex);
                    break;
                default:
                    Interface.Oxide.LogInfo(message, Array.Empty<object>());
                    break;
            }
        }

        public void OnShutdown() {}
    }
}