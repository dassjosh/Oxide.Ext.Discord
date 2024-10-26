using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Configuration;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// Represents Discord Extension Config
    /// </summary>
    internal class DiscordConfig : ConfigFile
    {
        internal static DiscordConfig Instance;
        
        /// <summary>
        /// Discord Command Options
        /// </summary>
        [JsonProperty("Commands")]
        public DiscordCommandsConfig Commands { get; set; }
        
        /// <summary>
        /// Discord Rest Options
        /// </summary>
        [JsonProperty("Rest")]
        public DiscordRestConfig Rest { get; set; }
        
        /// <summary>
        /// Discord Logging Options
        /// </summary>
        [JsonProperty("Logging")]
        public DiscordLoggingConfig Logging { get; set; }
        
        /// <summary>
        /// Discord Users Options
        /// </summary>
        [JsonProperty("Users")]
        public DiscordUsersConfig Users { get; set; }
        
        /// <summary>
        /// Discord Search Options
        /// </summary>
        [JsonProperty("Search")]
        public DiscordSearchConfig Search { get; set; }
        
        /// <summary>
        /// Discord Validation Options
        /// </summary>
        [JsonProperty("Validation")]
        public DiscordValidationConfig Validation { get; set; }
        
        /// <summary>
        /// Discord Bot Options
        /// </summary>
        [JsonProperty("Bot")]
        public DiscordBotConfig Bot { get; set; }
        
        /// <summary>
        /// Discord Bot Options
        /// </summary>
        [JsonProperty("Ip")]
        public DiscordIpConfig Ip { get; set; }

        /// <summary>
        /// Constructor for discord config
        /// </summary>
        /// <param name="filename">Filename to use</param>
        public DiscordConfig(string filename) : base(filename)
        {
            if (Instance != null)
            {
                throw new Exception("Duplicate DiscordConfig Instances");
            }
            
            Instance = this;
            ApplyDefaults();
        }

        public static void LoadConfig()
        {
            string configPath = Path.Combine(Interface.Oxide.InstanceDirectory, "discord.config.json");
            DiscordConfig config = File.Exists(configPath) ? ConfigFile.Load<DiscordConfig>(configPath) : new DiscordConfig(configPath);
            config.Save();
        }
        
        /// <summary>
        /// Load the config file and populate it.
        /// </summary>
        /// <param name="filename"></param>
        public override void Load(string filename = null)
        {
            try
            {
                base.Load(filename);
                ApplyDefaults();
            }
            catch (Exception ex)
            {
                Interface.Oxide.LogException($"[Discord Extension] Failed to load config file. Using default config. {ex}", ex);
                ApplyDefaults();
            }
        }

        private void ApplyDefaults()
        {
            Commands = new DiscordCommandsConfig
            {
                CommandPrefixes = Commands?.CommandPrefixes ?? new[] {'/', '!'}
            };
            Rest = new DiscordRestConfig
            {
                ApiErrorRetries = Rest?.ApiErrorRetries ?? 3,
                ApiRateLimitRetries = Rest?.ApiRateLimitRetries ?? 6
            };
            Logging = new DiscordLoggingConfig
            {
                HideDiscordErrorCodes = Logging?.HideDiscordErrorCodes ?? new HashSet<int>(),
                ConsoleLogLevel = Logging?.ConsoleLogLevel ?? DiscordLogLevel.Info,
                FileLogLevel = Logging?.FileLogLevel ?? DiscordLogLevel.Off,
                FileDateTimeFormat = "HH:mm:ss.ff"
            };
            Users = new DiscordUsersConfig
            {
                DmBlockedDuration = Users?.DmBlockedDuration ?? 24f
            };
            Search = new DiscordSearchConfig
            {
                EnablePlayerNameSearchTrie = true
            };
            Validation = new DiscordValidationConfig
            {
                EnableValidation = Validation?.EnableValidation ?? true
            };
            Bot = new DiscordBotConfig
            {
                AutomaticallyApplyGatewayIntents = Bot?.AutomaticallyApplyGatewayIntents ?? true
            };
            Ip = new DiscordIpConfig
            {
                StoreIpDuration = Ip?.StoreIpDuration ?? 30f,
                UnknownCountryEmoji = Ip?.UnknownCountryEmoji ?? ":signal_strength:"
            };
        }
    }
}