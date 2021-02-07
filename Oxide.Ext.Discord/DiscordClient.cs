using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;
using uMod.Ext.Discord.Attributes;
using uMod.Ext.Discord.DiscordEvents;
using uMod.Ext.Discord.DiscordObjects;
using uMod.Ext.Discord.Exceptions;
using uMod.Ext.Discord.Gateway;
using uMod.Ext.Discord.Logging;
using uMod.Ext.Discord.REST;
using uMod.Ext.Discord.WebSockets;
using uMod.Plugins;
using Timer = System.Timers.Timer;

namespace uMod.Ext.Discord
{
    public class DiscordClient
    {
        public List<Plugin> Plugins { get; private set; } = new List<Plugin>();

        public RestHandler REST { get; private set; }

        public DiscordSettings Settings { get; set; } = new DiscordSettings();

        public List<Guild> DiscordServers { get; set; } = new List<Guild>();
        public List<Channel> DMs { get; } = new List<Channel>();
        
        public Guild DiscordServer
        {
            get
            {
                return this.DiscordServers.FirstOrDefault();
            }
        }

        public int Sequence;

        public string SessionID;
        
        internal bool Initialized;

        private Socket _webSocket;

        private Timer _timer;

        public bool HeartbeatAcknowledged = false;

        private ILogger _logger;

        public void Initialize(Plugin plugin, DiscordSettings settings)
        {
            if (plugin == null)
            {
                throw new PluginNullException();
            }

            if (settings == null)
            {
                throw new SettingsNullException();
            }

            if (string.IsNullOrEmpty(settings.ApiToken))
            {
                throw new APIKeyException();
            }
            
            _logger = new Logger(settings.LogLevel);
            
            if (!string.IsNullOrEmpty(DiscordExtension.TestVersion))
            {
                _logger.Warning($"Using Discord Test Version: {DiscordExtension.GetExtensionVersion}");
            }

            /*if(Discord.PendingTokens.Contains(settings.ApiToken)) // Not efficient, will re-do later
            {
                _logger.LogWarning($"[Discord Extension] Connection with same token in short period.. Connection delayed for {plugin.Name}");
                Timer t = new Timer() { AutoReset = false, Interval = 5000f, Enabled = true};
                t.Elapsed += (object sender, ElapsedEventArgs e) =>
                {
                    // TODO: Check if the connection still persists or cancelled
                    _logger.LogWarning($"[Discord Extension] Delayed connection for {plugin.Name} is being resumed..");
                    Initialize(plugin, settings);
                };
                return;
            }*/

            Initialized = true;
            RegisterPlugin(plugin);
            UpdatePluginReference(plugin);
            CallHook("DiscordSocket_Initialized");

            Settings = settings;

            REST = new RestHandler(this, Settings.ApiToken);
            _webSocket = new Socket(this);
            
            ConnectWebSocket();

            /*Discord.PendingTokens.Add(settings.ApiToken); // Not efficient, will re-do later
            Timer t2 = new Timer() { AutoReset = false, Interval = 5000f, Enabled = true };
            t2.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                if (Discord.PendingTokens.Contains(settings.ApiToken))
                    Discord.PendingTokens.Remove(settings.ApiToken);
            };*/
        }
        
        public void ConnectWebSocket()
        {
            if (Initialized)
            {
                _webSocket.Connect();
            }
        }

        public void DisconnectWebsocket(bool attemptReconnect = false, bool attemptResume = false)
        {
            if (Initialized)
            {
                _webSocket.Disconnect(attemptReconnect, attemptResume);
            }
        }

        public void Disconnect()
        {
            Initialized = false;
            DestroyHeartbeat();
            _webSocket?.Shutdown();
            _webSocket = null;
            REST?.Disconnect();
            REST = null;
        }

        public void UpdatePluginReference(Plugin plugin = null)
        {
            List<Plugin> affectedPlugins = (plugin == null) ? Plugins : new List<Plugin>() { plugin };

            foreach (var pluginItem in affectedPlugins)
            {
                foreach (var field in pluginItem.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    if (field.GetCustomAttributes(typeof(DiscordClientAttribute), true).Any())
                    {
                        field.SetValue(pluginItem, this);
                    }
                }
            }
        }

        public void RegisterPlugin(Plugin plugin)
        {
            var search = Plugins.Where(x => x.Title == plugin.Title);
            search.ToList().ForEach(x => Plugins.Remove(x));

            Plugins.Add(plugin);
        }

        public void CallHook(string hookName, params object[] args)
        {
            //Run from next tick so we can be sure it's ran on the main thread.
            Interface.uMod.NextTick(() =>
            {
                Plugins.RemoveAll(p => p == null || !p.IsLoaded);
                foreach (Plugin plugin in Plugins)
                {
                    plugin.CallHook(hookName, args);
                }
            });
        }

        public string GetPluginNames(string delimiter = ", ") => string.Join(delimiter, Plugins.Select(x => x.Name).ToArray());

        #region Heartbeat
        public void CreateHeartbeat(float heartbeatInterval)
        {
            if (_timer != null)
            {
                _logger.Debug($"{nameof(DiscordClient)}.{nameof(CreateHeartbeat)} Previous heartbeat timer exists.");
                DestroyHeartbeat();
            }

            HeartbeatAcknowledged = true;
            _timer = new Timer(heartbeatInterval);
            _timer.Elapsed += HeartbeatElapsed;
            _timer.Start();
            _logger.Debug($"{nameof(DiscordClient)}.{nameof(CreateHeartbeat)} Creating heartbeat with interval {heartbeatInterval}ms.");
        }

        public void DestroyHeartbeat()
        {
            if(_timer != null)
            {
                _logger.Debug($"{nameof(DiscordClient)}.{nameof(DestroyHeartbeat)} Destroy Heartbeat");
                _timer.Dispose();
                _timer = null;
            }
        }

        private void HeartbeatElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} heartbeat Elapsed");
            if (!_webSocket.IsAlive() && !_webSocket.IsConnecting())
            {
                if (!_webSocket.IsReconnectTimerActive())
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Websocket is offline and is NOT connecting. Start reconnect timer.");
                    _webSocket.StartReconnectTimer(1f, () => UpdateGatewayUrl(ConnectWebSocket));
                }
                else
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Websocket is offline and is waiting to connect.");
                }

                return;
            }

            SendHeartbeat();
        }
        
        public void SendHeartbeat()
        {
            if(!HeartbeatAcknowledged)
            {
                //Discord did not acknowledge our last sent heartbeat. This is a zombie connection we should reconnect.
                if (_webSocket.IsAlive())
                {
                    _webSocket.Disconnect(true, true, true);
                }
                else if (!_webSocket.IsReconnectTimerActive())
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online or connecting.");
                    _webSocket.StartReconnectTimer(1f, ConnectWebSocket);
                }
                else
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online but is waiting to connect.");
                }
                
                return;
            }
            
            HeartbeatAcknowledged = false;
            _webSocket.Send(SendOpCode.Heartbeat, Sequence);
            CallHook("DiscordSocket_HeartbeatSent");
            _logger.Debug($"Heartbeat sent - {_timer.Interval}ms interval.");
        }
        #endregion

        internal void UpdateGatewayUrl(Action callback)
        {
            DiscordObjects.Gateway.GetGateway(this, gateway =>
            {
                // Example: wss://gateway.discord.gg/?v=6&encoding=json
                DiscordObjects.Gateway.WebSocketUrl = $"{gateway.URL}/?{Connect.Serialize()}";
                _logger.Debug($"{nameof(DiscordClient)}.{nameof(UpdateGatewayUrl)} Got Gateway url: {gateway.URL}");
                callback.Invoke();
            });
        }

        #region Discord Events
        
        public void Identify()
        {
            // Sent immediately after connecting. Opcode 2: Identify
            // Ref: https://discordapp.com/developers/docs/topics/gateway#identifying

            if (!Initialized)
            {
                return;
            }
            
            Identify identify = new Identify()
            {
                Token = Settings.ApiToken,
                Properties = new Properties()
                {
                    OS = "Oxide.Ext.Discord",
                    Browser = "Oxide.Ext.Discord",
                    Device = "Oxide.Ext.Discord"
                },
                Compress = false,
                LargeThreshold = 50,
                Shard = new List<int>() { 0, 1 }
            };
            
            _webSocket.Send(SendOpCode.Identify, identify);
        }
        
        public void Resume()
        {
            if (!Initialized)
            {
                return;
            }
            
            var resume = new Resume()
            {
                Sequence = this.Sequence,
                SessionID = this.SessionID,
                Token = Settings.ApiToken
            };

            _webSocket.Send(SendOpCode.Resume, resume);
        }

        public void RequestGuildMembers(string guildId, string query = "", int limit = 0, bool? presences = null, List<string> userIds = null, string nonce = null)
        {
            if (!Initialized)
            {
                return;
            }
            
            var requestGuildMembers = new GuildMembersRequest
            {
                GuildID = guildId,
                Query = query,
                Limit = limit,
                Presences = presences,
                UserIds = userIds,
                Nonce = nonce
            };

            _webSocket.Send(SendOpCode.RequestGuildMembers, requestGuildMembers);
        }

        public void RequestGuildMembers(Guild guild, string query = "", int limit = 0)
        {
            if (!Initialized)
            {
                return;
            }
            
            RequestGuildMembers(guild.id, query, limit);
        }

        public void UpdateVoiceState(string guildID, string channelId, bool selfDeaf, bool selfMute)
        {
            if (!Initialized)
            {
                return;
            }
            
            var voiceState = new VoiceStateUpdate()
            {
                ChannelID = channelId,
                GuildID = guildID,
                SelfDeaf = selfDeaf,
                SelfMute = selfMute
            };
            
            _webSocket.Send(SendOpCode.VoiceStateUpdate, voiceState);
        }

        public void UpdateStatus(Presence presence)
        {
            if (!Initialized)
            {
                return;
            }
            
            _webSocket.Send(SendOpCode.StatusUpdate, presence);
        }

        public Guild GetGuild(string id)
        {
            return this.DiscordServers.FirstOrDefault(x => x.id == id);
        }

        public void UpdateGuild(string g_id, Guild newguild)
        {
            Guild g = this.GetGuild(g_id);
            if (g == null) return;
            int idx = DiscordServers.IndexOf(g);
            if (idx == -1) return;
            this.DiscordServers[idx] = newguild;
        }

        internal void RemoveGuild(string guildId)
        {
            DiscordServers.RemoveAll(g => g.id == guildId);
        }

        #endregion
    }
}
