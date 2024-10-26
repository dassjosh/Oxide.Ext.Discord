using System.Collections.Generic;

namespace Oxide.Ext.Discord.Plugins
{
    internal static class LangKeys
    {
        public const string Chat = nameof(Chat);
        public const string Version = nameof(Version);
        public const string Enabled = nameof(Enabled);
        public const string Disabled = nameof(Disabled);
        public const string Help = nameof(Help);

        internal static class Websocket
        {
            private const string Base = nameof(Websocket) + ".";
            
            public const string Reconnect = Base + nameof(Reconnect);
            public const string Reset = Base + nameof(Reset);
        }

        internal static class RestApi
        {
            private const string Base = nameof(RestApi) + ".";
            
            public const string Reset = Base + nameof(Reset);
        }        
       
        internal static class Pool
        {
            private const string Base = nameof(Pool) + ".";
            
            public const string ClearEntities = Base + nameof(ClearEntities);
            public const string Remove = Base + nameof(Remove);
        }
        
        internal static class Placeholders
        {
            private const string Base = nameof(Placeholders) + ".";
            
            public const string List = Base + nameof(List);
        }

        internal static class Log
        {
            private const string Base = nameof(Log) + ".";
            
            public const string Show = Base + nameof(Show);
            public const string Set = Base + nameof(Set);
            public const string InvalidEnum = Base + nameof(InvalidEnum);
        }
        
        internal static class Validation
        {
            private const string Base = nameof(Validation) + ".";

            public const string Show = Base + nameof(Show);
            public const string Set = Base + nameof(Set);
            public const string InvalidEnum = Base + nameof(InvalidEnum);
        }

        internal static class Search
        {
            private const string Base = nameof(Search) + ".";
            
            internal static class HighPerformance
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                private const string Base = Search.Base + nameof(HighPerformance) + ".";
                
                public const string Show = Base + nameof(Show);
                public const string Set = Base + nameof(Set);
                public const string Invalid = Base + nameof(Invalid);
            }
        }

        internal static class TimeSpan
        {
            private const string Base = nameof(TimeSpan) + ".";

            public const string Infinity = Base + nameof(Infinity);
            
            public const string Days = Base + nameof(Days);
            public const string Day = Base + nameof(Day);
            
            public const string Hours = Base + nameof(Hours);
            public const string Hour = Base + nameof(Hour);
            
            public const string Minutes = Base + nameof(Minutes);
            public const string Minute = Base + nameof(Minute);
            
            public const string Seconds = Base + nameof(Seconds);
            public const string Second = Base + nameof(Second);
        }
    }
    
    internal static class Localization
    {
        internal static readonly Dictionary<string, Dictionary<string, string>> Languages = new()
        {
            ["en"] = new Dictionary<string, string>
            {
                [LangKeys.Chat] = "[Discord Extension] {0}",
                [LangKeys.Version] = "Server is running Discord Extension v{0}",
                [LangKeys.Websocket.Reconnect] = "Requested reconnect for all web sockets",
                [LangKeys.Websocket.Reset] = "All websockets have been reset",
                [LangKeys.RestApi.Reset] = "All REST API's have been reset",
                [LangKeys.Pool.ClearEntities] = "All Discord Pool Entities have been cleared",
                [LangKeys.Pool.Remove] = "All Discord Pools have been removed",
                [LangKeys.Placeholders.List] = "Placeholders:\n{0}",
                [LangKeys.Log.Show] = "{0} log is currently set to {1}",
                [LangKeys.Log.Set] = "{0} log has been set to {1}",
                [LangKeys.Log.InvalidEnum] = "'{0}' is not a valid DiscordLogLevel enum. Valid values are Off, Error, Warning, Info, Debug, Verbose",
                [LangKeys.Validation.Show] = "Discord Validation is currently set to {0}",
                [LangKeys.Validation.Set] = "Discord Validation has been set to {0}",
                [LangKeys.Validation.InvalidEnum] = "'{0}' is not a valid boolean value. Valid values are false, true, 0, or 1",
                [LangKeys.Search.HighPerformance.Show] = "Discord Search High Performance is currently set to {0}",
                [LangKeys.Search.HighPerformance.Set] = "Discord Search High Performance has been set to {0}",
                [LangKeys.Search.HighPerformance.Invalid] = "'{0}' is not a valid boolean value. Valid values are false, true, 0, or 1",
                [LangKeys.Enabled] = "Enabled",
                [LangKeys.Disabled] = "Disabled",
                [LangKeys.TimeSpan.Infinity] = "\u221E",
                [LangKeys.TimeSpan.Day] = "Day",
                [LangKeys.TimeSpan.Days] = "Days",
                [LangKeys.TimeSpan.Hour] = "Hour",
                [LangKeys.TimeSpan.Hours] = "Hours",
                [LangKeys.TimeSpan.Minute] = "Minute",
                [LangKeys.TimeSpan.Minutes] = "Minutes",
                [LangKeys.TimeSpan.Second] = "Second",
                [LangKeys.TimeSpan.Seconds] = "Seconds",
                [LangKeys.Help] = "Discord Extension v{0} Commands:\n" +
                                  " * de.version - displays the current Discord Extension version\n" +
                                  " * de.reset.reset - resets all rest handlers\n" +
                                  " * de.websocket.reset - resets all websockets\n" +
                                  " * de.websocket.reconnect - reconnects all websockets\n" +
                                  " * de.log.console - sets the console log level. Options (Verbose, Debug, Info, Warning, Error, Exception, Off)\n" +
                                  " * de.log.file - sets the file log level. Options (Verbose, Debug, Info, Warning, Error, Exception, Off)\n" +
                                  " * de.validation.enabled - sets if request validation is enabled\n" +
                                  " * de.search.trie.enable - sets if player name search should use high performance trie mode\n" +
                                  " * de.debug - prints debug information about the state of the Discord Extension"
            },
            ["ru"] = new Dictionary<string, string>
            {
                [LangKeys.TimeSpan.Infinity] = "\u221E",
                [LangKeys.TimeSpan.Day] = "день ",
                [LangKeys.TimeSpan.Days] = "дней ",
                [LangKeys.TimeSpan.Hour] = "час ",
                [LangKeys.TimeSpan.Hours] = "часов ",
                [LangKeys.TimeSpan.Minute] = "минуту ",
                [LangKeys.TimeSpan.Minutes] = "минут ",
                [LangKeys.TimeSpan.Second] = "секунду",
                [LangKeys.TimeSpan.Seconds] = "секунд",
            }
        };
    }
}