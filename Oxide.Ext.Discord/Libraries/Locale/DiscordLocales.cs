using System;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Converts discord locale codes into oxide locale codes
    /// </summary>
    public class DiscordLocales : BaseDiscordLibrary<DiscordLocales>
    {
        /// <summary>
        /// Default Oxide Lang (English)
        /// </summary>
        public const string DefaultServerLanguage = "en";

        /// <summary>
        /// Returns the Oxide Server language
        /// </summary>
        public ServerLocale ServerLanguage => ServerLocale.Create(OxideLibrary.Instance.Lang.GetServerLanguage());
        
        private readonly Hash<PluginLocale, Hash<string, string>> _pluginLangCache = new();
        
        private readonly ILogger _logger;

        private readonly BidirectionalDictionary<ServerLocale, DiscordLocale> _locales = new()
        {
            [ServerLocale.Create("en")] = DiscordLocale.Create("en-US"),
            [ServerLocale.Create("bg")] = DiscordLocale.Create("bg"),
            [ServerLocale.Create("zh")] = DiscordLocale.Create("zh-CN"),
            [ServerLocale.Create("hr")] = DiscordLocale.Create("hr"),
            [ServerLocale.Create("cs")] = DiscordLocale.Create("cs"),
            [ServerLocale.Create("da")] = DiscordLocale.Create("da"),
            [ServerLocale.Create("id")] = DiscordLocale.Create("id-Id"),
            [ServerLocale.Create("nl")] = DiscordLocale.Create("nl"),
            [ServerLocale.Create("fi")] = DiscordLocale.Create("fi"),
            [ServerLocale.Create("fr")] = DiscordLocale.Create("fr"),
            [ServerLocale.Create("de")] = DiscordLocale.Create("de"),
            [ServerLocale.Create("el")] = DiscordLocale.Create("el"),
            [ServerLocale.Create("hi")] = DiscordLocale.Create("hi"),
            [ServerLocale.Create("hu")] = DiscordLocale.Create("hu"),
            [ServerLocale.Create("it")] = DiscordLocale.Create("it"),
            [ServerLocale.Create("ja")] = DiscordLocale.Create("ja"),
            [ServerLocale.Create("ko")] = DiscordLocale.Create("ko"),
            [ServerLocale.Create("lt")] = DiscordLocale.Create("lt"),
            [ServerLocale.Create("no")] = DiscordLocale.Create("no"),
            [ServerLocale.Create("pl")] = DiscordLocale.Create("pl"),
            [ServerLocale.Create("pt")] = DiscordLocale.Create("pt-BR"),
            [ServerLocale.Create("ro")] = DiscordLocale.Create("ro"),
            [ServerLocale.Create("ru")] = DiscordLocale.Create("ru"),
            [ServerLocale.Create("es")] = DiscordLocale.Create("es-ES"),
            [ServerLocale.Create("sv")] = DiscordLocale.Create("sv-SE"),
            [ServerLocale.Create("th")] = DiscordLocale.Create("th"),
            [ServerLocale.Create("tr")] = DiscordLocale.Create("tr"),
            [ServerLocale.Create("uk")] = DiscordLocale.Create("uk"),
            [ServerLocale.Create("vi")] = DiscordLocale.Create("vi"),
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordLocales(ILogger logger)
        {
            _logger = logger;

            AddOxideLocale(ServerLocale.Create("pt-BR"), DiscordLocale.Create("pt-BR"));
            AddOxideLocale(ServerLocale.Create("es-ES"), DiscordLocale.Create("es-ES"));
            AddOxideLocale(ServerLocale.Create("zh-CN"), DiscordLocale.Create("zh-CN"));
            AddDiscordLocale(DiscordLocale.Create("en-GB"), ServerLocale.Create("en"));
            AddDiscordLocale(DiscordLocale.Create("zh-TW"), ServerLocale.Create("zh"));
            AddDiscordLocale(DiscordLocale.Create("es-419"), ServerLocale.Create("es"));
        }

        /// <summary>
        /// Adds a one way <see cref="ServerLocale"/> -> <see cref="DiscordLocale"/> mapping
        /// </summary>
        /// <param name="serverLang"></param>
        /// <param name="discordLang"></param>
        public void AddOxideLocale(ServerLocale serverLang, DiscordLocale discordLang) => _locales.AddKey(serverLang, discordLang);
        
        /// <summary>
        /// Adds a one way <see cref="DiscordLocale"/> -> <see cref="ServerLocale"/> mapping
        /// </summary>
        /// <param name="discordLang"></param>
        /// <param name="serverLang"></param>
        public void AddDiscordLocale(DiscordLocale discordLang, ServerLocale serverLang) => _locales.AddValue(discordLang, serverLang);

        /// <summary>
        /// Returns if the <see cref="ServerLocale"/> mapping exists
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public bool Contains(ServerLocale locale) => _locales.ContainsKey(locale);
        
        /// <summary>
        /// Returns if the <see cref="DiscordLocale"/> mapping exists
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public bool Contains(DiscordLocale locale) => _locales.ContainsKey(locale);

        /// <summary>
        /// Returns the oxide locale for a given discord locale
        /// </summary>
        /// <param name="discordLocale">Discord locale to get oxide locale for</param>
        /// <returns>Oxide locale if it exists; null otherwise</returns>
        public ServerLocale GetServerLanguage(DiscordLocale discordLocale) => _locales.TryGetValue(discordLocale, out ServerLocale serverLocale) ? serverLocale : default;

        /// <summary>
        /// Returns the discord locale for a given oxide locale
        /// </summary>
        /// <param name="serverLocale">oxide locale to get discord locale for</param>
        /// <returns>Discord locale if it exists; null otherwise</returns>
        public DiscordLocale GetDiscordLocale(ServerLocale serverLocale) => _locales.TryGetValue(serverLocale, out DiscordLocale discordLocale) ? discordLocale : default;

        /// <summary>
        /// Returns the oxide locale for the given IPlayer
        /// </summary>
        /// <param name="player"><see cref="IPlayer"/> to get the locale for</param>
        /// <returns>Locale for the given IPlayer</returns>
        public ServerLocale GetPlayerLanguage(IPlayer player) => GetPlayerLanguage(player?.Id);

        /// <summary>
        /// Returns the oxide locale for the given playerId
        /// </summary>
        /// <param name="playerId">PlayerId to get the locale for</param>
        /// <returns>Locale for the given playerId</returns>
        public ServerLocale GetPlayerLanguage(string playerId) => ServerLocale.Parse(OxideLibrary.Instance.Lang.GetLanguage(playerId));

        /// <summary>
        /// Returns all the discord localizations for a specific lang key in a plugin
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public Hash<string, string> GetDiscordLocalizations(Plugin plugin, string langKey)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (langKey == null) throw new ArgumentNullException(nameof(langKey));
            
            Hash<string, string> localization = new();
            string[] languages = OxideLibrary.Instance.Lang.GetLanguages(plugin);
            for (int index = 0; index < languages.Length; index++)
            {
                ServerLocale serverLocale = ServerLocale.Parse(languages[index]);
                DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
                if (!discordLocale.IsValid)
                {
                    _logger.Warning("Discord Extension failed to find discord locale for oxide language '{0}' for '{1}'. Please give this message to the Discord Extension Authors", serverLocale, plugin.FullName());
                    continue;
                }

                Hash<string, string> messages = GetLanguageMessages(plugin, serverLocale);
                if (!messages.TryGetValue(langKey, out string message))
                {
                    //DiscordExtension.GlobalLogger.Warning("Failed to add localized message for lang key '{0}' for plugin '{1} because lang key doesn't exist for language {2}", langKey, plugin.FullName(), language);
                    continue;
                }
                
                localization[discordLocale.Id] = message;
            }

            return localization;
        }

        /// <summary>
        /// Retrieves the lang message for a Discord Interaction
        /// </summary>
        /// <param name="plugin">Plugin the lang is from</param>
        /// <param name="interaction">The interaction to be localized</param>
        /// <param name="langKey">The lang key to lookup</param>
        /// <returns>Localized message if found; Empty string otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the input arguments are null</exception>
        public string GetDiscordInteractionLangMessage(Plugin plugin, DiscordInteraction interaction, string langKey)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (interaction == null) throw new ArgumentNullException(nameof(interaction));
            if (langKey == null) throw new ArgumentNullException(nameof(langKey));

            IPlayer player = interaction.User.Player;
            
            //Retrieves the plugin lang messages. If the messages are not found for a language then it will check in the following order
            // 1. Interaction.Locale - Discord User's Locale
            // 2. Oxide IPlayer Locale
            // 3. Interaction.GuildLocale - Application Command Guild Locale
            // 4. Oxide Lang Language
            // 5. English
            string message = GetLanguageMessages(plugin, interaction.Locale.GetServerLocale())?[langKey]
                             ?? (player != null ? GetLanguageMessages(plugin, GetPlayerLanguage(player))?[langKey] : null)
                             ?? (interaction.GuildLocale.HasValue ? GetLanguageMessages(plugin, interaction.GuildLocale.Value.GetServerLocale())?[langKey] : null)
                             ?? GetLanguageMessages(plugin, ServerLanguage)?[langKey]
                             ?? GetLanguageMessages(plugin, ServerLocale.Default)?[langKey];

            return !string.IsNullOrEmpty(message) ? message : langKey;
        }

        internal string GetLangMessage(Plugin plugin, IPlayer player, string langKey)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (langKey == null) throw new ArgumentNullException(nameof(langKey));
            
            string message = (player != null ? GetLanguageMessages(plugin, GetPlayerLanguage(player))?[langKey] : null)
                             ?? GetLanguageMessages(plugin, ServerLanguage)?[langKey]
                             ?? GetLanguageMessages(plugin, ServerLocale.Default)?[langKey];
            
            return !string.IsNullOrEmpty(message) ? message : langKey;
        }

        /// <summary>
        /// Retrieves the lang message for a Discord Interaction
        /// </summary>
        /// <param name="plugin">Plugin the lang is from</param>
        /// <param name="interaction">The interaction to be localized</param>
        /// <param name="langKey">The lang key to lookup</param>
        /// <param name="args">Localization formatting args</param>
        /// <returns>Localized message if found; Empty string otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the input arguments are null</exception>
        public string GetDiscordInteractionLangMessage(Plugin plugin, DiscordInteraction interaction, string langKey, params object[] args)
        {
            string message = GetDiscordInteractionLangMessage(plugin, interaction, langKey);
            if (string.IsNullOrEmpty(message))
            {
                return langKey;
            }

            try
            {
                return string.Format(message, args);
            }
            catch(Exception ex)
            {
                _logger.Exception("Plugin {0} Lang Key '{1}'\nMessage:{2}\nArgs:{3}", plugin, langKey, message, string.Join(", ", args.Select(a => a.ToString()).ToArray()), ex);
                return message;
            }
        }

        private Hash<string, string> GetLanguageMessages(Plugin plugin, ServerLocale language)
        {
            if (!language.IsValid)
            {
                return null;
            }
            
            PluginLocale id = new(plugin, language);
            Hash<string, string> langCache = _pluginLangCache[id];
            
            if (langCache == null)
            {
                langCache = new Hash<string, string>();
                _pluginLangCache[id] = langCache;
                Dictionary<string, string> messages = OxideLibrary.Instance.Lang.GetMessages(language.Id, plugin);
                if (messages != null)
                {
                    foreach (KeyValuePair<string, string> lang in messages)
                    {
                        langCache[lang.Key] = lang.Value;
                    }
                }
            }

            return langCache;
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            PluginId pluginId = plugin.Id();
            _pluginLangCache.RemoveAll(p => pluginId == p.Key.PluginId);
        }
    }
}