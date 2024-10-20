﻿using System;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Logging;

internal class DiscordLogHandler
{
    private readonly DiscordConsoleLogger _consoleLogger;
    private readonly DiscordFileLogger _fileLogger;
    public bool IsShutdown { get; private set; }

    public DiscordLogHandler(string pluginName, IDiscordLoggingConfig config, bool isExtension)
    {
        _consoleLogger = isExtension || config.ConsoleLogLevel != DiscordLogLevel.Off ? new DiscordConsoleLogger(pluginName) : null;
        _fileLogger = isExtension || config.FileLogLevel != DiscordLogLevel.Off ? DiscordFileLoggerFactory.Instance.CreateLogger(pluginName, config.FileDateTimeFormat) : null;
    }

    public void LogConsole(DiscordLogLevel level, string log, object[] args, Exception exception = null)
    {
        _consoleLogger?.AddMessage(level, log, args, exception);
    }

    public void LogFile(DiscordLogLevel level, string log, object[] args, Exception exception = null)
    {
        _fileLogger?.AddMessage(level, log, args, exception);
    }

    public void Shutdown()
    {
        _consoleLogger?.OnShutdown();
        _fileLogger?.OnShutdown();
        IsShutdown = true;
    }
}