using System;
using uMod.Ext.Discord.Logging;

namespace uMod.Ext.Discord
{
    public class DiscordSettings
    {
        public string ApiToken;

        [Obsolete]
        public bool Debugging
        {
            get => LogLevel < LogLevel.Warning;
            set => LogLevel = value ? LogLevel.Debug : LogLevel.Info;
        }

        public LogLevel LogLevel = LogLevel.Info;
    }
}