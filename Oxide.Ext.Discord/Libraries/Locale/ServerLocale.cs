using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a Server Locale
    /// </summary>
    [JsonConverter(typeof(ServerLocaleConverter))]
    public readonly struct ServerLocale : IEquatable<ServerLocale>
    {
        /// <summary>
        /// ID of the Locale
        /// </summary>
        public readonly string Id;
        
        /// <summary>
        /// Returns if the Locale is valid
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Id);
        
        /// <summary>
        /// Returns if the Locale is the default server language "en"
        /// </summary>
        public bool IsDefault => IsValid && Equals(Default);
        
        /// <summary>
        /// Returns the <see cref="DiscordLocale"/> for this server locale
        /// </summary>
        /// <returns></returns>
        public DiscordLocale GetDiscordLocale() => DiscordLocales.Instance.GetDiscordLocale(this);
        
        /// <summary>
        /// The default locale for servers
        /// </summary>
        public static readonly ServerLocale Default = new(DiscordLocales.DefaultServerLanguage);

        private static DateTime _lastError;
        private static readonly List<string> LocaleError = new();
        
        private ServerLocale(string id) 
        {
            Id = id;
        }
        
        /// <summary>
        /// Parses a locale returning a <see cref="ServerLocale"/>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ServerLocale Parse(string locale)
        {
            ServerLocale serverLocale = new(locale);
            if (!DiscordLocales.Instance.Contains(serverLocale))
            {
                if (!LocaleError.Contains(locale) || _lastError + TimeSpan.FromMinutes(5) < DateTime.UtcNow)
                {
                    LocaleError.Remove(locale);
                    LocaleError.Add(locale);
                    _lastError = DateTime.UtcNow;
                    DiscordExtension.GlobalLogger.Warning("Parsed ServerLocale '{0}' which does not exist in DiscordLang. " +
                                                          "Please give this message to the Discord Extension Authors", locale);
                }

            }

            return serverLocale;
        }

        internal static ServerLocale Create(string locale) => new(locale);

        /// <summary>
        /// Returns the ID of the ServerLocale
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;

        /// <inheritdoc />
        public bool Equals(ServerLocale other) => Id == other.Id;
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ServerLocale other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => (Id != null ? Id.GetHashCode() : 0);
    }
}