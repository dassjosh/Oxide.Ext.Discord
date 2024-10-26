using System;
using Newtonsoft.Json;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Data;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;
using Oxide.Ext.Discord.WebSockets;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Clients
{
    /// <summary>
    /// Represents a bot connected to discord
    /// </summary>
    public class BotClient : BaseClient, IDebugLoggable
    {
        /// <summary>
        /// All the servers that this bot is in
        /// </summary>
        public readonly Hash<Snowflake, DiscordGuild> Servers = new();

        /// <summary>
        /// All the direct messages that we have seen by channel ID
        /// </summary>
        public readonly Hash<Snowflake, DiscordChannel> DirectMessagesByChannelId = new();

        /// <summary>
        /// All the direct messages that we have seen by User ID
        /// </summary>
        public readonly Hash<Snowflake, DiscordChannel> DirectMessagesByUserId = new();

        /// <summary>
        /// Application reference for this bot
        /// </summary>
        public DiscordApplication Application { get; private set; }

        /// <summary>
        /// Bot User
        /// </summary>
        public DiscordUser BotUser { get; private set; }
        
        /// <summary>
        /// Returns if the bot has fully loaded.
        /// All guilds are loaded and if <see cref="GatewayIntents.GuildMembers"/> is specified all guild members have been loaded
        /// </summary>
        public bool IsFullyLoaded { get; private set; }
        
        /// <summary>
        /// Returns if ReadyData is set
        /// </summary>
        public bool IsReady => _readyData != null;
        
        internal readonly BotConnection Connection;
        internal DiscordWebSocket WebSocket;
        internal readonly DiscordHook Hooks;
        internal readonly JsonSerializerSettings JsonSettings;
        internal readonly JsonSerializer JsonSerializer;

        private GatewayReadyEvent _readyData;

        /// <summary>
        /// Connection settings to use for the bot
        /// </summary>
        /// <param name="connection"></param>
        public BotClient(BotConnection connection)
        {
            Connection = new BotConnection(connection);
            Rest = new RestHandler(this, Logger);
            WebSocket = new DiscordWebSocket(this, Logger);
            Hooks = new DiscordHook(Logger);
        
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None
            };

            JsonSerializer = JsonSerializer.Create(JsonSettings);
            Initialized = true;
        }

        /// <summary>
        /// Connects the websocket to discord. Should only be called if the websocket is disconnected
        /// </summary>
        internal override void HandleConnect()
        {
            if (Initialized)
            {
                Logger.Debug($"{nameof(BotClient)}.{nameof(HandleConnect)} Connecting to websocket");
                WebSocket.Connect();
            }
        }

        /// <summary>
        /// Close the websocket with discord
        /// </summary>
        /// <param name="reconnect">Should we attempt to reconnect to discord after closing</param>
        /// <param name="resume">Should we attempt to resume the previous session</param>
        public void DisconnectWebsocket(bool reconnect = false, bool resume = false)
        {
            if (Initialized)
            {
                WebSocket.Disconnect(reconnect, resume);
            }
        }

        internal void ResetWebSocket()
        {
            try
            {
                WebSocket?.Shutdown();
            }
            finally
            {
                WebSocket = new DiscordWebSocket(this, Logger);
                WebSocket.Connect();
            }
        }
        
        internal void ResetRestApi()
        {
            try
            {
                Rest?.Shutdown();
            }
            finally
            {
                Rest = new RestHandler(this, Logger);
            }
        }

        /// <summary>
        /// Called when the bot client is no longer used by any client and can be shutdown.
        /// </summary>
        internal override void HandleShutdown()
        {
            Logger.Debug($"{nameof(BotClient)}.{nameof(HandleShutdown)} Shutting down the bot");
            BotClientFactory.Instance.RemoveBot(this);

            try
            {
                WebSocket?.Shutdown();
            }
            catch (Exception ex)
            {
                Logger.Exception($"{nameof(BotClient)}.{nameof(HandleShutdown)} An error occured shutting down the bot websocket.", ex);
            }
            finally
            {
                WebSocket = null;
            }

            ShutdownRest();
                
            _readyData = null;
            Initialized = false;
        }
        
        ///<inheritdoc/>
        public override void AddClient(DiscordClient client)
        {
            TokenMismatchException.ThrowIfMismatchedToken(client, Connection);

            if (_clients.Contains(client))
            {
                throw new Exception("This client is already in the list of clients");
            }

            base.AddClient(client);
            Hooks.AddPlugin(client);
        }

        internal override void HandleAlreadyConnected(DiscordClient client)
        {
            GatewayIntents intents = Connection.Intents | client.Connection.Intents;
                
            //Our intents have changed. Disconnect websocket and reconnect with new intents.
            if (intents != Connection.Intents)
            {
                Connection.Intents = intents;
                if (WebSocket.Intents != Connection.Intents && WebSocket.IsConnected())
                {
                    Logger.Debug("New intents have been requested for the a connected bot. Reconnecting with updated intents.");
                    DisconnectWebsocket(true);
                }
            }

            if (_readyData != null)
            {
                _readyData.Guilds = Servers;
                DiscordHook.CallPluginHook(client.Plugin, DiscordExtHooks.OnDiscordGatewayReady, _readyData);

                foreach (DiscordGuild guild in Servers.Values)
                {
                    if (guild.IsAvailable)
                    {
                        DiscordHook.CallPluginHook(client.Plugin, DiscordExtHooks.OnDiscordGuildCreated, guild);
                    }

                    if (guild.HasLoadedAllMembers)
                    {
                        DiscordHook.CallPluginHook(client.Plugin, DiscordExtHooks.OnDiscordGuildMembersLoaded, guild);
                    }
                }

                if (IsFullyLoaded)
                {
                    DiscordHook.CallPluginHook(client.Plugin, DiscordExtHooks.OnDiscordBotFullyLoaded);
                }
            }
        }

        ///<inheritdoc/>
        public override bool RemoveClient(DiscordClient client)
        {
            if (base.RemoveClient(client))
            {
                return true;
            }
        
            Hooks.RemovePlugin(client.Plugin);
            
            GatewayIntents intents = GatewayIntents.None;
            for (int index = 0; index < _clients.Count; index++)
            {
                DiscordClient exitingClients = _clients[index];
                intents |= exitingClients.Connection.Intents;
            }

            //Update Intents so the next reconnect we supply the correct GatewayIntents for connected plugins
            Connection.Intents = intents;
            return false;
        }

        internal void OnClientReady(GatewayReadyEvent ready)
        {
            Application = ready.Application;
            BotUser = ready.User;

            bool isFirst = _readyData == null;
            if (isFirst)
            {
                Hooks.CallHook(DiscordExtHooks.OnDiscordGatewayReady, ready);
                if (DiscordUserData.Instance.TryGetBotData(ready.User.Id, out BotData botData))
                {
                    foreach (UserData userData in botData.Users.Values)
                    {
                        DiscordChannel channel = userData.CreateDmChannel();
                        DirectMessagesByChannelId[channel.Id] = channel;
                        DirectMessagesByUserId[userData.UserId] = channel;
                        channel.UserData = userData;
                        userData.ClearBlockIfExpired();
                    }
                }
            }
            else
            {
                Hooks.CallHook(DiscordExtHooks.OnDiscordGatewayReconnected);
            }
            
            _readyData = ready;
            _readyData.Guilds = Servers;

            if (isFirst)
            {
                DiscordExtensionCore.Instance.ApplyApplicationCommands(this);
            }

            if (Connection.Intents != WebSocket.Intents)
            {
                DisconnectWebsocket(true);
            }
        }

        internal void OnBotFullyLoaded()
        {
            if (!IsFullyLoaded)
            {
                IsFullyLoaded = true;
                Hooks.CallHook(DiscordExtHooks.OnDiscordBotFullyLoaded);
            }
        }
        
        /// <summary>
        /// Returns the first client connected to this bot.
        /// Only use for Gateway API call
        /// </summary>
        /// <returns></returns>
        internal DiscordClient GetFirstClient()
        {
            return _clients.Count != 0 ? _clients[0] : null;
        }

        /// <summary>
        /// Sends a websocket command
        /// </summary>
        /// <param name="client">Client sending the command</param>
        /// <param name="opCode"><see cref="GatewayCommandCode"/> OP Code for the command</param>
        /// <param name="data">Command Payload</param>
        public void SendWebSocketCommand(DiscordClient client, GatewayCommandCode opCode, object data)
        {
            if (Initialized)
            {
                WebSocket.Send(client, opCode, data);
            }
        }

        #region Entity Helpers
        /// <summary>
        /// Returns a guild for the specific ID
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <returns>Guild with the specified ID</returns>
        public DiscordGuild GetGuild(Snowflake? guildId)
        {
            if (guildId.HasValue && guildId.Value.IsValid())
            {
                return Servers[guildId.Value];
            }

            return null;
        }

        /// <summary>
        /// Returns the channel for the given channel ID.
        /// If guild ID is null, it will search for a direct message channel
        /// If guild ID is not null, it will search for a guild channel
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="guildId"></param>
        /// <returns></returns>
        public DiscordChannel GetChannel(Snowflake channelId, Snowflake? guildId)
        {
            if (guildId.HasValue)
            {
                DiscordGuild guild = GetGuild(guildId);
                if (guild != null)
                {
                    return guild.Channels?[channelId] ?? guild.Threads?[channelId];
                }

                return null;
            }

            return DirectMessagesByChannelId[channelId];
        }

        /// <summary>
        /// Adds a guild to the list of servers a bot is in
        /// </summary>
        /// <param name="guild"></param>
        public void AddGuild(DiscordGuild guild)
        {
            Servers[guild.Id] = guild;
        }

        /// <summary>
        /// Adds a guild if it does not exist or updates the guild with
        /// </summary>
        /// <param name="guild"></param>
        public void AddGuildOrUpdate(DiscordGuild guild)
        {
            DiscordGuild existing = Servers[guild.Id];
            if (existing != null)
            {
                Logger.Verbose($"{nameof(BotClient)}.{nameof(AddGuildOrUpdate)} Updating Existing Guild {{0}}", guild.Id);
                existing.Edit(guild);
            }
            else
            {
                Logger.Verbose($"{nameof(BotClient)}.{nameof(AddGuildOrUpdate)} Adding new Guild {{0}}", guild.Id);
                Servers[guild.Id] = guild;
            }
        }

        /// <summary>
        /// Removes guild from the list of servers a bot is in
        /// </summary>
        /// <param name="guildId">Guild to remove from bot</param>
        internal void RemoveGuild(Snowflake guildId)
        {
            Servers.Remove(guildId);
        }

        /// <summary>
        /// Adds a Direct Message Channel to the bot cache
        /// </summary>
        /// <param name="channel">Channel to be added</param>
        public void AddDirectChannel(DiscordChannel channel)
        {
            if (channel.Type != ChannelType.Dm)
            {
                Logger.Warning($"{nameof(BotClient)}.{nameof(AddDirectChannel)} Tried to add a non DM channel");
                return;
            }
            
            Logger.Verbose($"{nameof(BotClient)}.{nameof(AddDirectChannel)} Adding New Channel {{0}}", channel.Id);
            DirectMessagesByChannelId[channel.Id] = channel;

            BotData data = DiscordUserData.Instance.GetBotData(BotUser.Id);

            foreach (DiscordUser recipient in channel.Recipients.Values)
            {
                if (!recipient.Bot.HasValue || !recipient.Bot.Value)
                {
                    DirectMessagesByUserId[recipient.Id] = channel;

                    UserData userData = data.GetUserData(recipient.Id);
                    channel.UserData = userData;
                    if (userData.DmChannelId != channel.Id)
                    {
                        userData.DmChannelId = channel.Id;
                        DiscordUserData.Instance.OnDataChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Removes a direct message channel if it exists
        /// </summary>
        /// <param name="id">ID of the channel to remove</param>
        public void RemoveDirectMessageChannel(Snowflake id)
        {
            DiscordChannel existing = DirectMessagesByChannelId[id];
            if (existing != null)
            {
                DirectMessagesByChannelId.Remove(id);
                DirectMessagesByUserId.RemoveAll(c => c.Id == id);
            }
        }
        #endregion

        #region Discord Command Helpers
        internal bool IsPluginRegistered(Plugin plugin)
        {
            for (int index = 0; index < _clients.Count; index++)
            {
                DiscordClient client = _clients[index];
                if (client.Plugin == plugin)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Client", Connection.HiddenToken);
            logger.AppendField("Initialized", Initialized);
            logger.AppendFieldEnum("Log Level", Logger.LogLevel);
            logger.AppendFieldEnum("Intents", Connection.Intents);
            logger.AppendField("Plugins", GetClientPluginList());
            
            logger.AppendObject("Bot", BotUser);
            logger.AppendObject("Application", Application);
            logger.AppendObject("Websocket", WebSocket);
            logger.AppendObject("REST API", Rest);
        }
    }
}