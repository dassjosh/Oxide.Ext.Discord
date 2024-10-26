using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using Oxide.Core;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Logging
{
    /// <summary>
    /// Represents a File Logger for Discord
    /// </summary>
    internal class DiscordFileLogger : IOutputLogger
    {
        private readonly ConcurrentQueue<string> _messages = new();
        private readonly string _logFileName;
        private readonly string _dateTimeFormat;
        private readonly AutoResetEvent _reset;
        
        private static readonly ThreadLocal<StringBuilder> Builder = new(() => new StringBuilder());

        internal DiscordFileLogger(string pluginName, string dateTimeFormat, AutoResetEvent reset)
        {
            _dateTimeFormat = dateTimeFormat;
            _reset = reset;
            string logPath = Path.Combine(Interface.Oxide.LogDirectory, pluginName);
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            
            _logFileName = Path.Combine(logPath, $"{pluginName}-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");
        }

        public void AddMessage(DiscordLogLevel level, string log, object[] args, Exception ex)
        {
            StringBuilder sb = Builder.Value;
            sb.Clear();
            Span<char> span = stackalloc char[_dateTimeFormat.Length];
            DateTime.Now.TryFormat(span, out int written, _dateTimeFormat);
            sb.Append(span.Slice(0, written));
            sb.Append(" [");
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
            
            _messages.Enqueue(sb.ToString());
            if (ex != null)
            {
                _messages.Enqueue(ex.ToString());
            }
            _reset.Set();
        }
        
        internal void WriteLog()
        {
            if (_messages.IsEmpty)
            {
                return;
            }

            using StreamWriter fileWriter = File.AppendText(_logFileName);
            while (_messages.TryDequeue(out string message))
            {
                fileWriter.WriteLine(message);
            }
        }

        public void OnShutdown()
        {
            WriteLog();
            DiscordFileLoggerFactory.Instance.RemoveLogger(this);
        }
    }
}