using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Callbacks.Data;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Data;
using Oxide.Ext.Discord.Data.Ip;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore : BaseDiscordPlugin
    {
        #region Fields
        public readonly PluginId PluginId;
        public static DiscordExtensionCore Instance;
        private ILogger _logger;

        internal bool IsServerLoaded;

        private readonly Hash<string, Action<Plugin>> _pluginReferences;
        #endregion
        
        #region Setup & Loading
        public DiscordExtensionCore()
        {
            Name = "DiscordExtension";
            Title = "Discord Extension";
            PluginId = new PluginId(this);
            _pluginReferences = new Hash<string, Action<Plugin>>
            {
                ["PlaceholderAPI"] = HandlePlaceholderApi,
                ["Clans"] = plugin => _clans = plugin,
            };
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(Init))]
        private void Init()
        {
            Instance = this;
            _logger = DiscordLoggerFactory.Instance.CreateExtensionLogger(DiscordLogLevel.Info);
            DiscordPool.Instance.CreateInternal(this);
            DataHandler.Instance.LoadAll();
            AddCovalenceCommand(new[] {"de.version"}, nameof(VersionCommand), "de.version");
            AddCovalenceCommand(new[] {"de.websocket.reset"}, nameof(ResetWebSocketCommand), "de.websocket.reset");
            AddCovalenceCommand(new[] {"de.websocket.reconnect"}, nameof(ReconnectWebSocketCommand), "de.websocket.reconnect");
            AddCovalenceCommand(new[] {"de.rest.reset"}, nameof(ResetRestApiCommand), "de.rest.reset");
            AddCovalenceCommand(new[] {"de.search.highperformance.enable"}, nameof(SearchHighPerformanceEnabled), "de.search.highperformance.enable");
            AddCovalenceCommand(new[] {"de.placeholders.list"}, nameof(PlaceholdersList), "de.placeholders.list");
            AddCovalenceCommand(new[] {"de.pool.clearentities"}, nameof(ClearEntitiesDiscordPool), "de.pool.clearentities");
            AddCovalenceCommand(new[] {"de.pool.remove"}, nameof(RemoveDiscordPool), "de.pool.remove");
            AddCovalenceCommand(new[] {"de.log.console"}, nameof(ConsoleLogCommand), "de.log.console");
            AddCovalenceCommand(new[] {"de.log.file"}, nameof(FileLogCommand), "de.log.file");
            AddCovalenceCommand(new[] {"de.validation.enable"}, nameof(ValidationEnableCommand), "de.validation.enable");
            AddCovalenceCommand(new[] {"de.debug"}, nameof(DiscordDebugCommand), "de.debug");
            AddCovalenceCommand(new[] {"de.help"}, nameof(DiscordHelpCommand), "de.help");
            
            foreach (KeyValuePair<string, Dictionary<string, string>> language in Localization.Languages)
            {
                Lang.RegisterMessages(language.Value, this, language.Key);
            }
            
            DiscordPlaceholders.Instance.RegisterPlaceholders();
            ServerPlayerCache.Instance.SetSearchService();
            
            CreateTemplates();
            RegisterApplicationCommands();
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnServerInitialized))]
        private void OnServerInitialized()
        {
            IsServerLoaded = true;
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnServerSave))]
        private void OnServerSave()
        {
            DataHandler.Instance.OnServerSave();
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnServerShutdown))]
        private void OnServerShutdown()
        {
            DiscordExtension.IsShuttingDown = true;
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(Unload))]
        private void Unload()
        {
            Instance = null;
        }
        #endregion

        #region Commands
        [HookMethod(nameof(VersionCommand))]
        private void VersionCommand(IPlayer player)
        {
            Chat(player, LangKeys.Version, DiscordExtension.FullExtensionVersion);
        }

        [HookMethod(nameof(ResetWebSocketCommand))]
        private void ResetWebSocketCommand(IPlayer player)
        {
            BotClientFactory.Instance.ResetAllWebSockets();
            Chat(player, LangKeys.Websocket.Reset);
        }
        
        [HookMethod(nameof(ReconnectWebSocketCommand))]
        private void ReconnectWebSocketCommand(IPlayer player)
        {
            BotClientFactory.Instance.ReconnectAllWebSockets();
            Chat(player, LangKeys.Websocket.Reconnect);
        }
        
        [HookMethod(nameof(ResetRestApiCommand))]
        private void ResetRestApiCommand(IPlayer player)
        {
            BotClientFactory.Instance.ResetAllRestApis();
            Chat(player, LangKeys.RestApi.Reset);
        }
        
        [HookMethod(nameof(SearchHighPerformanceEnabled))]
        // ReSharper disable once UnusedParameter.Local
        private void SearchHighPerformanceEnabled(IPlayer player, string cmd, string[] args)
        {
            DiscordSearchConfig config = DiscordConfig.Instance.Search;
            if (args.Length == 0)
            {
                Chat(player, LangKeys.Search.HighPerformance.Show, GetLang(config.EnablePlayerNameSearchTrie ? LangKeys.Enabled : LangKeys.Disabled));
                return;
            }

            if (!args[0].ParseBool(out bool state))
            {
                Chat(player, LangKeys.Search.HighPerformance.Invalid, args[0]);
                return;
            }
            
            Chat(player, LangKeys.Search.HighPerformance.Set, GetLang(state ? LangKeys.Enabled : LangKeys.Disabled));
            
            if (config.EnablePlayerNameSearchTrie != state)
            {
                config.EnablePlayerNameSearchTrie = state;
                ServerPlayerCache.Instance.SetSearchService();
                DiscordConfig.Instance.Save();
            }
        }

        [HookMethod(nameof(PlaceholdersList))]
        private void PlaceholdersList(IPlayer player)
        {
            ValueStringBuilder sb = new();
            string extensionName = this.PluginName();
            foreach (KeyValuePair<PlaceholderKey, IPlaceholder> placeholder in DiscordPlaceholders.Instance.GetPlaceholders().OrderBy(p => p.Key))
            {
                sb.Append('{');
                sb.Append(placeholder.Key.Placeholder);
                sb.Append("} - Return Type: ");
                sb.Append(placeholder.Value.GetReturnType().Name);
                sb.Append(" Plugin: ");
                sb.Append(placeholder.Value.IsExtensionPlaceholder ? extensionName : placeholder.Value.PluginName);
                sb.AppendLine();
            }
            
            Chat(player, LangKeys.Placeholders.List, sb.ToString());
        }
        
        [HookMethod(nameof(ClearEntitiesDiscordPool))]
        private void ClearEntitiesDiscordPool(IPlayer player)
        {
            Chat(player, LangKeys.Pool.ClearEntities);
            DiscordPool.Instance.Clear();
        }
        
        [HookMethod(nameof(RemoveDiscordPool))]
        private void RemoveDiscordPool(IPlayer player)
        {
            Chat(player, LangKeys.Pool.Remove);
            DiscordPool.Instance.Wipe();
        }
        
        [HookMethod(nameof(ConsoleLogCommand))]
        // ReSharper disable once UnusedParameter.Local
        private void ConsoleLogCommand(IPlayer player, string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Chat(player, LangKeys.Log.Show, "Console", DiscordConfig.Instance.Logging.ConsoleLogLevel);
                return;
            }

            try
            {
                DiscordLogLevel log = (DiscordLogLevel)Enum.Parse(typeof(DiscordLogLevel), args[0], true);
                DiscordConfig.Instance.Logging.ConsoleLogLevel = log;
                DiscordConfig.Instance.Save();

                Chat(player, LangKeys.Log.Set, "Console", log);
                
                BotClientFactory.Instance.UpdateLogLevel();
                WebhookClientFactory.Instance.UpdateLogLevel();
            }
            catch
            {
                Chat(player, LangKeys.Log.InvalidEnum, args[0]);
            }
        }
        
        [HookMethod(nameof(FileLogCommand))]
        // ReSharper disable once UnusedParameter.Local
        private void FileLogCommand(IPlayer player, string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Chat(player, LangKeys.Log.Show, "File", DiscordConfig.Instance.Logging.FileLogLevel);
                return;
            }
            
            try
            {
                DiscordLogLevel log = (DiscordLogLevel)Enum.Parse(typeof(DiscordLogLevel), args[0], true);
                DiscordConfig.Instance.Logging.FileLogLevel = log;
                DiscordConfig.Instance.Save();

                Chat(player, LangKeys.Log.Set, "File", log);
                
                BotClientFactory.Instance.UpdateLogLevel();
                WebhookClientFactory.Instance.UpdateLogLevel();
                DiscordClientFactory.Instance.UpdateLogLevel();
            }
            catch
            {
                Chat(player, LangKeys.Log.InvalidEnum, args[0]);
            }
        }

        [HookMethod(nameof(ValidationEnableCommand))]
        // ReSharper disable once UnusedParameter.Local
        private void ValidationEnableCommand(IPlayer player, string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Chat(player, LangKeys.Validation.Show, GetLang(DiscordConfig.Instance.Validation.EnableValidation ? LangKeys.Enabled : LangKeys.Disabled));
                return;
            }

            if (!args[0].ParseBool(out bool state))
            {
                Chat(player, LangKeys.Validation.InvalidEnum, args[0]);
                return;
            }
            
            DiscordConfig.Instance.Validation.EnableValidation = state;
            Chat(player, LangKeys.Validation.Set, GetLang(state ? LangKeys.Enabled : LangKeys.Disabled));
            DiscordConfig.Instance.Save();
        }

        [HookMethod(nameof(DiscordDebugCommand))]
        // ReSharper disable once UnusedParameter.Local
        private void DiscordDebugCommand(IPlayer player, string cmd, string[] args)
        {
            DebugLogger logger = new();
            
            ThreadPool.GetAvailableThreads(out int worker, out int port);
            ThreadPool.GetMaxThreads(out int maxWorker, out int maxPort);
            
            logger.AppendLine($"Discord Extension Version: {DiscordExtension.FullExtensionVersion}");
            logger.AppendList("Bot Clients", BotClientFactory.Instance.Clients);
            logger.AppendList("Webhook Clients", WebhookClientFactory.Instance.Clients);
            logger.AppendObject("Global Rest", RestHandler.Global);
            logger.StartObject("Threads");
            logger.AppendFieldOutOf("Worker", worker, maxWorker);
            logger.AppendFieldOutOf("Port", port, maxPort);
            logger.EndObject();
            logger.StartObject("Libraries");
            logger.AppendObject("Discord Application Command", DiscordAppCommand.Instance);
            logger.AppendObject("Discord Command", DiscordCommand.Instance);
            logger.AppendObject("Discord Subscriptions", DiscordSubscriptions.Instance);
            DiscordAppCommand.Instance.LogDebug(logger);
            DiscordCommand.Instance.LogDebug(logger);
            DiscordSubscriptions.Instance.LogDebug(logger);
            logger.AppendObject("Discord Pool", DiscordPool.Instance);
            logger.EndObject();
            
            string message = logger.ToString();

            if (args.Length != 0 && args[0].Equals("file", StringComparison.OrdinalIgnoreCase))
            {
                string path = Path.Combine(Interface.Oxide.LogDirectory, "DiscordExtension");
                string filePath = Path.Combine(path, $"DEBUG-{DateTime.Now:yyyy-MM-dd_h-mm-ss-tt}.txt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                File.WriteAllText(filePath, message);
                player.Message($"Debug Saved to File. Path: {filePath.Replace(Interface.Oxide.RootDirectory, "").Substring(1)}");
            }
            else
            {
                player.Message(message);
                _logger.Info(message);
            }
        }

        [HookMethod(nameof(DiscordHelpCommand))]
        private void DiscordHelpCommand(IPlayer player)
        {
            Chat(player, LangKeys.Help, DiscordExtension.FullExtensionVersion);
        }
        #endregion

        #region Hooks
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnPluginLoaded))]
        private void OnPluginLoaded(Plugin plugin)
        {
            _pluginReferences[plugin.Name]?.Invoke(plugin);
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnPluginUnloaded))]
        private void OnPluginUnloaded(Plugin plugin)
        {
            _pluginReferences[plugin.Name]?.Invoke(null);
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnUserApproved))]
        // ReSharper disable twice UnusedParameter.Local
        private void OnUserApproved(string name, string id, string ipAddress)
        {
            if (!DiscordIpData.Instance.HasData(ipAddress))
            {
                _logger.Verbose($"{nameof(DiscordExtensionCore)}.{nameof(OnUserConnected)} No data found for IP: {{0}}. Requesting Data.", ipAddress);
                GetIpDataCallback.Start(ipAddress);
            }
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnUserConnected))]
        private void OnUserConnected(IPlayer player)
        {
            ServerPlayerCache.Instance.OnUserConnected(player);
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnUserDisconnected))]
        private void OnUserDisconnected(IPlayer player)
        {
            try
            {
                ServerPlayerCache.Instance.OnUserDisconnected(player);
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("An error occured", ex);
            }
        }
        
        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnUserNameUpdated))]
        private void OnUserNameUpdated(IPlayer player, string oldName, string newName)
        {
            ServerPlayerCache.Instance.OnUserNameUpdated(player, oldName, newName);
        }
        #endregion
    }
}