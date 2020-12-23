﻿using System;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.DiscordObjects;

namespace Oxide.Ext.Discord
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

        public LogLevel LogLevel;
        
        public BotIntents Intents = BotIntents.All;
    }
}