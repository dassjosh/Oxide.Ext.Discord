using System;

namespace uMod.Ext.Discord.Logging
{
    public class Logger : ILogger
    {
        private readonly LogLevel _logLevel;
        
        public Logger(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public void Verbose(string message)
        {
            Log(LogLevel.Verbose, message);
        }

        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }
        
        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }
        
        public void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }
        
        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }
        
        public void Exception(string message, Exception ex)
        {
            Log(LogLevel.Exception, message, ex);
        }

        private void Log(LogLevel level, string message, object data = null)
        {
            if (level < _logLevel)
            {
                return;
            }

            string log= $"[Discord Extension] [{level}]: {message}";
            switch (level)
            {
                case LogLevel.Debug:
                case LogLevel.Warning:
                    Interface.uMod.LogWarning(log);
                    break;
                case LogLevel.Error:
                    Interface.uMod.LogError(log);
                    break;
                case LogLevel.Exception:
                    Interface.uMod.LogException(log, (Exception)data);
                    break;
                default:
                    Interface.uMod.LogInfo(log);
                    break;
            }
        }
    }
}