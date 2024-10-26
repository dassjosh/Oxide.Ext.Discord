using System;
using System.Collections.Generic;
using System.Threading;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Logging
{
    internal sealed class DiscordFileLoggerFactory : Singleton<DiscordFileLoggerFactory>
    {
        private readonly Thread _writerThread;
        private readonly List<DiscordFileLogger> _loggers = new();
        private readonly AutoResetEvent _reset = new(false);
        private bool _exit;

        private DiscordFileLoggerFactory()
        {
            _writerThread = new Thread(WriteLogThread)
            {
                IsBackground = true,
                Name = nameof(DiscordFileLogger)
            };
            _writerThread.Start();
        }

        public DiscordFileLogger CreateLogger(string pluginName, string dateTimeFormat)
        {
            DiscordFileLogger logger = new(pluginName, dateTimeFormat, _reset);
            _loggers.Add(logger);
            return logger;
        }
        
        private void WriteLogThread()
        {
            try
            {
                while (!_exit)
                {
                    _reset.WaitOne();
                    for (int index = 0; index < _loggers.Count; index++)
                    {
                        _loggers[index].WriteLog();
                    }
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("An exception occured writing log file.", ex);
                WriteLogThread();
            }
        }
        
        internal void OnServerShutdown()
        {
            _exit = true;
            _reset.Set();
            _writerThread.Join(TimeSpan.FromSeconds(5));
        }

        internal void RemoveLogger(DiscordFileLogger logger)
        {
            _loggers.Remove(logger);
        }
    }
}