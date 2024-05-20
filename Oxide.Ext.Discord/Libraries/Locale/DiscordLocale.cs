﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a Locale in Discord
    /// </summary>
    [JsonConverter(typeof(DiscordLocaleConverter))]
    public struct DiscordLocale : IEquatable<DiscordLocale>
    {
        /// <summary>
        /// ID of the locale
        /// </summary>
        public readonly string Id;
        
        /// <summary>
        /// Is the Locale Valid
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Id);

        /// <summary>
        /// Returns the Server Locale for this Discord Locale
        /// </summary>
        /// <returns></returns>
        public ServerLocale GetServerLocale() => DiscordLocales.Instance.GetServerLanguage(this);
        
        private static DateTime _lastError;
        private static readonly List<string> LocaleError = new List<string>();
        
        private DiscordLocale(string id) 
        {
            Id = id;
        }

        /// <summary>
        /// Parses a Discord Locale
        /// </summary>
        /// <param name="locale">Locale to Parse</param>
        /// <returns>Parsed Discord Locale</returns>
        public static DiscordLocale Parse(string locale)
        {
            DiscordLocale discordLocale = new DiscordLocale(locale);
            if (!DiscordLocales.Instance.Contains(discordLocale))
            {
                if (!LocaleError.Contains(locale) || _lastError + TimeSpan.FromMinutes(5) < DateTime.UtcNow)
                {
                    LocaleError.Remove(locale);
                    LocaleError.Add(locale);
                    _lastError = DateTime.UtcNow;
                    DiscordExtension.GlobalLogger.Warning("Parsed DiscordLocale '{0}' which does not exist in DiscordLang. " +
                                                          "Please give this message to the Discord Extension Authors", locale);
                }
            }

            return discordLocale;
        }

        internal static DiscordLocale Create(string locale) => new DiscordLocale(locale);
        
        ///<inheritdoc/>
        public bool Equals(DiscordLocale other) => Id == other.Id;

        ///<inheritdoc/>
        public override bool Equals(object obj) => obj is DiscordLocale other && Equals(other);

        ///<inheritdoc/>
        public override int GetHashCode() => Id != null ? Id.GetHashCode() : 0;

        /// <summary>
        /// Returns if two Discord Locales are equal to each other
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator == (DiscordLocale left, DiscordLocale right) => left.Equals(right);
        
        /// <summary>
        /// Returns if two Discord Locales are not equal to each other
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator != (DiscordLocale left, DiscordLocale right) => !(left == right);
        
        /// <summary>
        /// Returns the ID of the Locale
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Id;
    }
}