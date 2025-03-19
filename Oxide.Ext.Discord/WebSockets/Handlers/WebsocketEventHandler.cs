using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Handles websocket events
    /// </summary>
    public class WebSocketEventHandler : IWebSocketEventHandler
    {
        private readonly BotClient _client;
        private readonly DiscordWebSocket _webSocket;
        private readonly ILogger _logger;
        
        /// <summary>
        /// Creates a new socket listener
        /// </summary>
        /// <param name="client">Client this listener is for</param>
        /// <param name="socket">Socket this listener is for</param>
        /// <param name="logger">Logger for the client</param>
        public WebSocketEventHandler(BotClient client, DiscordWebSocket socket, ILogger logger)
        {
            _client = client;
            _webSocket = socket;
            _logger = logger;
        }

        #region Socket Events
        /// <summary>
        /// Called when a socket is open
        /// </summary>
        public ValueTask SocketOpened(Snowflake webSocketId)
        {
            _logger.Info("Discord socket connected!");
            _webSocket.OnSocketConnected();
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordWebsocketOpened);
            return new ValueTask();
        }

        /// <summary>
        /// Called when a socket is closed
        /// </summary>
        /// <param name="webSocketId">ID of the web socket</param>
        /// <param name="status"><see cref="WebSocketCloseStatus"/> for the web socket</param>
        /// <param name="message">Close message from the web socket</param>
        public ValueTask SocketClosed(Snowflake webSocketId, WebSocketCloseStatus status, string message)
        {
            //If the socket close came from the extension, then this will be true
            if (!_webSocket.IsCurrentSocket(webSocketId))
            {
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(SocketClosed)} Socket closed event for non matching socket. Code: {{0}}, reason: {{1}}", status, message);
                return new ValueTask();
            }

            int code = (int)status;
            if(code is >= 1000 and < 2000)
            {
                if (status != WebSocketCloseStatus.NormalClosure)
                {
                    _logger.Warning($"{nameof(WebSocketEventHandler)}.{nameof(SocketClosed)} Discord WebSocket closed. Code: {{1}}, reason: {{2}}", status, code, message);
                }
                else
                {
                    _webSocket.ShouldReconnect = true;
                }
            }
            else if (code is >= 4000 and < 5000)
            {
                HandleDiscordClosedSocket(code, message);
            }
            else
            {
                _logger.Warning("Discord WebSocket closed with abnormal close code. Code: {0}, reason: {1}", code, message);
                _webSocket.ShouldReconnect = true;
                _logger.Debug($"{nameof(WebSocketEventHandler)}.{nameof(SocketClosed)} Discord WebSocket closed. Code: {{0}}, reason: {{1}}", code, message);
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordWebsocketClosed, message, code);
            _webSocket.OnSocketDisconnected();

            if (_client.Initialized)
            {
                _webSocket.ReconnectIfRequested();
            }

            return new ValueTask();
        }

        /// <summary>
        /// Parse out the closing reason if discord closed the socket
        /// </summary>
        /// <param name="code">Socket close code</param>
        /// <param name="reason">Socket close reason</param>
        /// <returns>True if discord closed the socket with one of it's close codes</returns>
        private void HandleDiscordClosedSocket(int code, string reason)
        {
            DiscordWebsocketCloseCode closeCode;
            if (Enum.IsDefined(typeof(DiscordWebsocketCloseCode), code))
            {
                closeCode = (DiscordWebsocketCloseCode)code;
            }
            else
            {
                closeCode = DiscordWebsocketCloseCode.UnknownCloseCode;
            }

            bool shouldResume = false;
            bool shouldReconnect = true;
            switch (closeCode)
            {
                case DiscordWebsocketCloseCode.UnknownError: 
                    _logger.Error("Unknown Discord error {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.UnknownOpcode: 
                    _logger.Error("Unknown gateway opcode sent: {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.DecodeError: 
                    _logger.Error("Invalid gateway payload sent: {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.NotAuthenticated: 
                    _logger.Error("Tried to send a payload before identifying: {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.AuthenticationFailed: 
                    _logger.Error("The given bot token is invalid. Please enter a valid token. Token: {0} Plugins: {1} Reason: {2}", _client.Connection.HiddenToken, _client.GetClientPluginList(), reason);
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.AlreadyAuthenticated: 
                    _logger.Error("The bot has already authenticated. Please don't identify more than once. Reason: {0} Plugins: {1}", reason, _client.GetClientPluginList());
                    break;
                
                case DiscordWebsocketCloseCode.InvalidSequence: 
                    _logger.Error("Invalid resume sequence. Doing full reconnect. Reason {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.RateLimited: 
                    _logger.Error("You're being rate limited. Please slow down how quickly you're sending requests. Reason: {0} Plugins: {1}", reason, _client.GetClientPluginList());
                    shouldResume = true;
                    break;
                
                case DiscordWebsocketCloseCode.SessionTimedOut: 
                    _logger.Error("Session has timed out. Starting a new one: {0}", reason);
                    break;
                
                case DiscordWebsocketCloseCode.InvalidShard: 
                    _logger.Error("Invalid shared has been specified: {0}", reason);
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.ShardingRequired: 
                    _logger.Error("Bot is in too many guilds. You must shard your bot: {0}", reason);
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.InvalidApiVersion: 
                    _logger.Error("Gateway is using invalid API version: {0}. Please contact Discord Extension Devs immediately!", Gateway.WebsocketUrl);
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.InvalidIntents: 
                    _logger.Error("Invalid intent(s) specified for the gateway. Please check that you're using valid intents in the connect. Plugins: {0}", _client.GetClientPluginList(), reason);
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.DisallowedIntent:
                    DiscordClient client = _client.GetFirstClient();
                    _logger.Warning("A plugin is asking for an intent you have not granted your bot. Attempting to update intents. Plugins: {0}", _client.GetClientPluginList());
                    DiscordApplication.Get(client).Then(app =>
                    {
                        ProcessGatewayIntents(app)?
                            .Then(updatedApp =>
                            {
                                _client.Application.Flags = updatedApp.Flags;
                                _webSocket.Connect();
                            })
                            .Catch(err => _logger.Exception("An error occurred trying to update disallowed intents. Plugins: {0} Reason: {1}", _client.GetClientPluginList(), reason, err));
                    }).Catch(err => _logger.Exception("An error occurred trying to correct disallowed intents. Plugins: {0} Reason: {1}", _client.GetClientPluginList(), reason, err));
                    shouldReconnect = false;
                    break;
                
                case DiscordWebsocketCloseCode.UnknownCloseCode:
                    _logger.Error("Discord has closed the gateway with a code we do not recognize. Please Contact Discord Extension Authors. Code: {0}. Reason: {1}.", code, reason);
                    break;
            }

            _webSocket.ShouldResume = shouldResume;
            _webSocket.ShouldReconnect = shouldReconnect;
        }

        /// <summary>
        /// Called when an error occurs on a socket
        /// </summary>
        /// <param name="webSocketId">ID of the web socket</param>
        /// <param name="ex">Exception throw</param>
        public ValueTask SocketErrored(Snowflake webSocketId, Exception ex)
        {
            if (!_webSocket.IsCurrentSocket(webSocketId))
            {
                return new ValueTask();
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordWebsocketErrored, ex, ex.Message);
            _logger.Exception("An error has occured in the websocket {0}. Attempting to reconnect to discord.", webSocketId, ex);
            _webSocket.Disconnect(true, false);
            return new ValueTask();
        }

        /// <summary>
        /// Called when a socket receives a message
        /// </summary>
        /// <param name="webSocketId">ID of the web socket</param>
        /// <param name="reader">JSON Reader containing the message</param>
        public async ValueTask SocketMessage(Snowflake webSocketId, DiscordJsonReader reader)
        {
            EventPayload payload = reader.Deserialize<EventPayload>(_client.JsonSerializer);
            _webSocket.OnSequenceUpdate(payload.Sequence);

            if (_logger.IsLogging(DiscordLogLevel.Verbose))
            {
                _logger.Verbose("Received socket message, Bot: {0} OpCode: {1} Payload: {2}", _client.BotUser?.Username ?? _client.Connection.HiddenToken, payload.OpCode, reader.ReadAsString());
            }
            else
            {
                _logger.Debug("Received socket message, Bot: {0} OpCode: {1} ", _client.BotUser?.Username ?? _client.Connection.HiddenToken, payload.OpCode);
            }
            
            try
            {
                switch (payload.OpCode)
                {
                    // Dispatch (dispatches an event)
                    case GatewayEventCode.Dispatch:
                        HandleDispatch(payload);
                        break;

                    // Heartbeat
                    // https://discord.com/developers/docs/topics/gateway#gateway-heartbeat
                    case GatewayEventCode.Heartbeat:
                        await HandleHeartbeat().ConfigureAwait(false);
                        break;

                    // Reconnect (used to tell clients to reconnect to the gateway)
                    // we should immediately reconnect here
                    case GatewayEventCode.Reconnect:
                        HandleReconnect();
                        break;

                    // Invalid Session (used to notify the client they have an invalid session ID)
                    case GatewayEventCode.InvalidSession:
                        HandleInvalidSession(payload.ShouldResume);
                        break;

                    // Hello (sent immediately after connecting, contains heartbeat and server debug information)
                    case GatewayEventCode.Hello:
                        await HandleHello(payload).ConfigureAwait(false);
                        break;

                    // Heartbeat ACK (sent immediately following a client heartbeat
                    // that was received)
                    // (See 'zombied or failed connections')
                    case GatewayEventCode.HeartbeatAcknowledge:
                        HandleHeartbeatAcknowledge();
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.Exception($"{nameof(WebSocketEventHandler)}.{nameof(SocketMessage)} Please give error message below to Discord Extension Authors. An error occured for: {{0}}.\nBody{{1}}", payload.DispatchCode, reader.ReadAsString(), ex);
            }
            finally
            {
                payload.Dispose();
            }
        }
        #endregion

        #region Discord Events
        private void HandleDispatch(EventPayload payload)
        {
            _logger.Debug("Received OpCode: Dispatch, event: {0}", payload.DispatchCode);

            // Listed here: https://discord.com/developers/docs/topics/gateway#commands-and-events-gateway-events
            switch (payload.DispatchCode)
            {
                case DiscordDispatchCode.Ready:
                    HandleDispatchReady(payload.GetData<GatewayReadyEvent>(_client));
                    break;

                case DiscordDispatchCode.Resumed:
                    HandleDispatchResumed(payload.GetData<GatewayResumedEvent>(_client));
                    break;

                case DiscordDispatchCode.ChannelCreated:
                    HandleDispatchChannelCreate(payload.GetData<DiscordChannel>(_client));
                    break;

                case DiscordDispatchCode.ChannelUpdated:
                    HandleDispatchChannelUpdate(payload.GetData<DiscordChannel>(_client));
                    break;

                case DiscordDispatchCode.ChannelDeleted:
                    HandleDispatchChannelDelete(payload.GetData<DiscordChannel>(_client));
                    break;

                case DiscordDispatchCode.ChannelPinsUpdate:
                    HandleDispatchChannelPinUpdate(payload.GetData<ChannelPinsUpdatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.EntitlementCreate:
                    HandleDispatchEntitlementCreate(payload.GetData<DiscordEntitlement>(_client));
                    break;
                
                case DiscordDispatchCode.EntitlementUpdate:
                    HandleDispatchEntitlementUpdate(payload.GetData<DiscordEntitlement>(_client));
                    break;
                
                case DiscordDispatchCode.EntitlementDelete:
                    HandleDispatchEntitlementDelete(payload.GetData<DiscordEntitlement>(_client));
                    break;

                case DiscordDispatchCode.GuildCreated:
                    HandleDispatchGuildCreate(payload.GetData<DiscordGuild>(_client));
                    break;

                case DiscordDispatchCode.GuildUpdated:
                    HandleDispatchGuildUpdate(payload.GetData<DiscordGuild>(_client));
                    break;

                case DiscordDispatchCode.GuildDeleted:
                    HandleDispatchGuildDelete(payload.GetData<DiscordGuild>(_client));
                    break;

                case DiscordDispatchCode.GuildBanAdded:
                    HandleDispatchGuildBanAdd(payload.GetData<GuildMemberBannedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildBanRemoved:
                    HandleDispatchGuildBanRemove(payload.GetData<GuildMemberBannedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildEmojisUpdated:
                    HandleDispatchGuildEmojisUpdate(payload.GetData<GuildEmojisUpdatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildStickersUpdate:
                    HandleDispatchGuildStickersUpdate(payload.GetData<GuildStickersUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildIntegrationsUpdated:
                    HandleDispatchGuildIntegrationsUpdate(payload.GetData<GuildIntegrationsUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildMemberAdded:
                    HandleDispatchGuildMemberAdd(payload.GetData<GuildMemberAddedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildMemberRemoved:
                    HandleDispatchGuildMemberRemove(payload.GetData<GuildMemberRemovedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildMemberUpdated:
                    HandleDispatchGuildMemberUpdate(payload.GetData<GuildMemberUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildMembersChunk:
                    HandleDispatchGuildMembersChunk(payload.GetData<GuildMembersChunkEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildRoleCreated:
                    HandleDispatchGuildRoleCreate(payload.GetData<GuildRoleCreatedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildRoleUpdated:
                    HandleDispatchGuildRoleUpdate(payload.GetData<GuildRoleUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.GuildRoleDeleted:
                    HandleDispatchGuildRoleDelete(payload.GetData<GuildRoleDeletedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildScheduledEventCreate:
                    HandleDispatchGuildScheduledEventCreate(payload.GetData<GuildScheduledEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildScheduledEventUpdate:
                    HandleDispatchGuildScheduledEventUpdate(payload.GetData<GuildScheduledEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildScheduledEventDelete:
                    HandleDispatchGuildScheduledEventDelete(payload.GetData<GuildScheduledEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildScheduledEventUserAdd:
                    HandleDispatchGuildScheduledEventUserAdd(payload.GetData<GuildScheduleEventUserAddedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildScheduledEventUserRemove:
                    HandleDispatchGuildScheduledEventUserRemove(payload.GetData<GuildScheduleEventUserRemovedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.IntegrationCreated:
                    HandleDispatchIntegrationCreate(payload.GetData<IntegrationCreatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.IntegrationUpdated:
                    HandleDispatchIntegrationUpdate(payload.GetData<IntegrationUpdatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.IntegrationDeleted:
                    HandleDispatchIntegrationDelete(payload.GetData<IntegrationDeletedEvent>(_client));
                    break;    

                case DiscordDispatchCode.MessageCreated:
                    HandleDispatchMessageCreate(payload.GetData<DiscordMessage>(_client));
                    break;

                case DiscordDispatchCode.MessageUpdated:
                    HandleDispatchMessageUpdate(payload.GetData<DiscordMessage>(_client));
                    break;

                case DiscordDispatchCode.MessageDeleted:
                    HandleDispatchMessageDelete(payload.GetData<MessageDeletedEvent>(_client));
                    break;

                case DiscordDispatchCode.MessageBulkDeleted:
                    HandleDispatchMessageDeleteBulk(payload.GetData<MessageBulkDeletedEvent>(_client));
                    break;

                case DiscordDispatchCode.MessageReactionAdded:
                    HandleDispatchMessageReactionAdd(payload.GetData<MessageReactionAddedEvent>(_client));
                    break;

                case DiscordDispatchCode.MessageReactionRemoved:
                    HandleDispatchMessageReactionRemove(payload.GetData<MessageReactionRemovedEvent>(_client));
                    break;

                case DiscordDispatchCode.MessageReactionAllRemoved:
                    HandleDispatchMessageReactionRemoveAll(payload.GetData<MessageReactionRemovedAllEvent>(_client));
                    break;
                
                case DiscordDispatchCode.MessageReactionEmojiRemoved:
                    HandleDispatchMessageReactionRemoveEmoji(payload.GetData<MessageReactionRemovedAllEmojiEvent>(_client));
                    break;

                case DiscordDispatchCode.PresenceUpdated:
                    HandleDispatchPresenceUpdate(payload.GetData<PresenceUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.TypingStarted:
                    HandleDispatchTypingStart(payload.GetData<TypingStartedEvent>(_client));
                    break;

                case DiscordDispatchCode.UserUpdated:
                    HandleDispatchUserUpdate(payload.GetData<DiscordUser>(_client));
                    break;

                case DiscordDispatchCode.VoiceStateUpdated:
                    HandleDispatchVoiceStateUpdate(payload.GetData<VoiceState>(_client));
                    break;
                
                case DiscordDispatchCode.VoiceChannelEffectSend:
                    HandleDispatchVoiceChannelEffect(payload.GetData<VoiceChannelEffectEvent>(_client));
                    break;

                case DiscordDispatchCode.VoiceServerUpdated:
                    HandleDispatchVoiceServerUpdate(payload.GetData<VoiceServerUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.WebhooksUpdated:
                    HandleDispatchWebhooksUpdate(payload.GetData<WebhooksUpdatedEvent>(_client));
                    break;

                case DiscordDispatchCode.InviteCreated:
                    HandleDispatchInviteCreate(payload.GetData<InviteCreatedEvent>(_client));
                    break;

                case DiscordDispatchCode.InviteDeleted:
                    HandleDispatchInviteDelete(payload.GetData<InviteDeletedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.ApplicationCommandsPermissionsUpdate:
                    HandleApplicationCommandsPermissionsUpdate(payload.GetData<CommandPermissions>(_client));
                    break;
                
                case DiscordDispatchCode.InteractionCreated:
                    HandleDispatchInteractionCreate(payload.GetData<DiscordInteraction>(_client));
                    break;

                case DiscordDispatchCode.ThreadCreated:
                    HandleDispatchThreadCreated(payload.GetData<DiscordChannel>(_client));
                    break;
                
                case DiscordDispatchCode.ThreadUpdated:
                    HandleDispatchThreadUpdated(payload.GetData<DiscordChannel>(_client));
                    break;
                
                case DiscordDispatchCode.ThreadDeleted:
                    HandleDispatchThreadDeleted(payload.GetData<DiscordChannel>(_client));
                    break;
                
                case DiscordDispatchCode.ThreadListSync:
                    HandleDispatchThreadListSync(payload.GetData<ThreadListSyncEvent>(_client));
                    break;
                
                case DiscordDispatchCode.ThreadMemberUpdated:
                    HandleDispatchThreadMemberUpdated(payload.GetData<ThreadMemberUpdateEvent>(_client));
                    break;
                
                case DiscordDispatchCode.ThreadMembersUpdated:
                    HandleDispatchThreadMembersUpdated(payload.GetData<ThreadMembersUpdatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.StageInstanceCreated:
                    HandleDispatchStageInstanceCreated(payload.GetData<StageInstance>(_client));
                    break;
                
                case DiscordDispatchCode.StageInstanceUpdated:
                    HandleDispatchStageInstanceUpdated(payload.GetData<StageInstance>(_client));
                    break;
                
                case DiscordDispatchCode.StageInstanceDeleted:
                    HandleDispatchStageInstanceDeleted(payload.GetData<StageInstance>(_client));
                    break;
                
                case DiscordDispatchCode.SubscriptionCreate:
                    HandleDispatchSubscriptionCreated(payload.GetData<DiscordSubscription>(_client));
                    break;
                    
                case DiscordDispatchCode.SubscriptionUpdate:
                    HandleDispatchSubscriptionUpdated(payload.GetData<DiscordSubscription>(_client));
                    break;
                    
                case DiscordDispatchCode.SubscriptionDelete:
                    HandleDispatchSubscriptionDeleted(payload.GetData<DiscordSubscription>(_client));
                    break;
                
                case DiscordDispatchCode.GuildSoundboardSoundCreate:
                    HandleDispatchSoundboardSoundCreated(payload.GetData<DiscordSoundboardSound>(_client));
                    break;
                
                case DiscordDispatchCode.GuildSoundboardSoundUpdate:
                    HandleDispatchSoundboardSoundUpdated(payload.GetData<DiscordSoundboardSound>(_client));
                    break;
                
                case DiscordDispatchCode.GuildSoundboardSoundDelete:
                    HandleDispatchSoundboardSoundDeleted(payload.GetData<SoundboardDeletedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.GuildSoundboardSoundsUpdate:
                    HandleDispatchSoundboardSoundsUpdated(payload.GetData<SoundboardSoundsUpdatedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.SoundboardSounds:
                    HandleDispatchGetSoundboardSoundsResponse(payload.GetData<GetGuildSoundboardSoundsEvent>(_client));
                    break;
                
                case DiscordDispatchCode.AutoModerationRuleCreate:
                    HandleDispatchAutoModRuleCreated(payload.GetData<AutoModRule>(_client));
                    break;
                
                case DiscordDispatchCode.AutoModerationRuleUpdate:
                    HandleDispatchAutoModRuleUpdated(payload.GetData<AutoModRule>(_client));
                    break;
                
                case DiscordDispatchCode.AutoModerationRuleDelete:
                    HandleDispatchAutoModRuleDeleted(payload.GetData<AutoModRule>(_client));
                    break;
                
                case DiscordDispatchCode.AutoModerationActionExecution:
                    HandleDispatchAutoModActionExecuted(payload.GetData<AutoModActionExecutionEvent>(_client));
                    break;
                
                case DiscordDispatchCode.MessagePollVoteAdded:
                    HandleDispatchMessagePollVoteAdded(payload.GetData<MessagePollVoteAddedEvent>(_client));
                    break;
                
                case DiscordDispatchCode.MessagePollVoteRemoved:
                    HandleDispatchMessagePollVoteRemoved(payload.GetData<MessagePollVoteRemovedEvent>(_client));
                    break;
                
                // Bots should ignore this
                case DiscordDispatchCode.PresenceReplace:
                    break;
                
                default:
                    HandleDispatchUnhandledEvent(payload);
                    break;
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#ready
        private void HandleDispatchReady(GatewayReadyEvent ready)
        {
            foreach (DiscordGuild guild in ready.Guilds.Values)
            {
                _client.AddGuildOrUpdate(guild);
            }
            
            _webSocket.OnSocketReady(ready);
            _client.OnClientReady(ready);

            _logger.Info("Your bot {0} was found in {1} Guilds!", ready.User.Username, ready.Guilds.Count);
        }

        private IPromise<DiscordApplication> ProcessGatewayIntents(DiscordApplication app)
        {
            if (!DiscordConfig.Instance.Bot.AutomaticallyApplyGatewayIntents)
            {
                return null;
            }
            
            ApplicationFlags flags = app.Flags ?? ApplicationFlags.None;
            if (_client.Connection.HasIntents(GatewayIntents.GuildMessages) && !app.HasAnyApplicationFlags(ApplicationFlags.GatewayMessageContentLimited | ApplicationFlags.GatewayMessageContent))
            {
                _logger.Info("Applying GatewayMessageContent App Flag since it is currently disabled");
                flags |= ApplicationFlags.GatewayMessageContentLimited;
            }

            if (!app.HasAnyApplicationFlags(ApplicationFlags.GatewayGuildMembersLimited | ApplicationFlags.GatewayGuildMembers))
            {
                _logger.Info("Applying GatewayGuildMembers App Flag since it is currently disabled");
                flags |= ApplicationFlags.GatewayGuildMembersLimited;
            }

            if (flags != app.Flags)
            {
                IPromise<DiscordApplication> promise = app.Edit(_client.GetFirstClient(), new ApplicationUpdate { Flags = flags });
                promise.Then(_ =>
                {
                    _logger.Info("Successfully Applied Application Flags: {0}", EnumCache<ApplicationFlags>.Instance.ToString(flags));
                }).Catch<ResponseError>(error =>
                {
                    _logger.Error("An error occurred applying application flags: {0}\n{1}", EnumCache<ApplicationFlags>.Instance.ToString(flags), error.ResponseMessage);
                });
                return promise;
            }

            return null;
        }

        //https://discord.com/developers/docs/topics/gateway-events#resumed`
        private void HandleDispatchResumed(GatewayResumedEvent resumed)
        {
            _logger.Debug("Session resumed successfully!");
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGatewayResumed, resumed);
        }

        //https://discord.com/developers/docs/topics/gateway-events#channel-create
        private void HandleDispatchChannelCreate(DiscordChannel channel)
        {
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchChannelCreate)}: ID: {{0}} Type: {{1}}. Guild ID: {{2}}", channel.Id, channel.Type, channel.GuildId);
            
            if (channel.IsDmChannel())
            {
                _client.AddDirectChannel(channel);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectChannelCreated, channel);
            }
            else
            {
                DiscordGuild guild = _client.GetGuild(channel.GuildId);
                if (guild is {IsAvailable: true})
                {
                    if (channel.IsThreadChannel())
                    {
                        guild.Threads[channel.Id] = channel;
                    }
                    else
                    {
                        guild.Channels[channel.Id] = channel;
                    }

                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildChannelCreated, channel, guild);
                }
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#channel-update
        private void HandleDispatchChannelUpdate(DiscordChannel update)
        {
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchChannelUpdate)} ID: {{0}} Type: {{1}} Guild ID: {{2}}", update.Id, update.Type, update.GuildId);

            if (update.IsDmChannel())
            {
                DiscordChannel channel = _client.GetChannel(update.Id, null);
                if (channel == null)
                {
                    _client.AddDirectChannel(update);
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectChannelUpdated, update, (DiscordChannel)null);
                }
                else
                {
                    DiscordChannel previous = channel.Update(update);
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectChannelUpdated, channel, previous);
                }
            }
            else
            {
                DiscordGuild guild = _client.GetGuild(update.GuildId);
                if (guild is {IsAvailable: true})
                {
                    DiscordChannel channel = guild.GetChannel(update.Id);
                    if (channel != null)
                    {
                        DiscordChannel previous = channel.Update(update);
                        _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildChannelUpdated, channel, previous, guild);
                    }
                    else
                    {
                        if (update.IsThreadChannel())
                        {
                            guild.Threads[update.Id] = update;
                        }
                        else
                        {
                            guild.Channels[update.Id] = update;
                        }
                        
                        _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildChannelUpdated, update, update, guild);
                    }
                }
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#channel-delete
        private void HandleDispatchChannelDelete(DiscordChannel channel)
        {
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchChannelDelete)} ID: {{0}} Type: {{1}} Guild ID: {{2}}", channel.Id, channel.Type, channel.GuildId);
            DiscordGuild guild = _client.GetGuild(channel.GuildId);
            if (channel.IsDmChannel())
            {
                _client.RemoveDirectMessageChannel(channel.Id);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectChannelDeleted, channel);
            }
            else
            {
                guild.Channels.Remove(channel.Id);
                guild.Threads.Remove(channel.Id);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildChannelDeleted, channel, guild);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#channel-pins-update
        private void HandleDispatchChannelPinUpdate(ChannelPinsUpdatedEvent pins)
        {
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchChannelPinUpdate)} Channel ID: {{0}} Guild ID: {{1}}", pins.GuildId, pins.GuildId);
            
            DiscordChannel channel = _client.GetChannel(pins.ChannelId, pins.GuildId);
            if (pins.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(pins.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildChannelPinsUpdated, pins, channel, guild);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectChannelPinsUpdated, pins, channel);
            }
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#entitlement-create
        private void HandleDispatchEntitlementCreate(DiscordEntitlement entitlement)
        {
            DiscordGuild guild = _client.GetGuild(entitlement.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordEntitlementCreated, entitlement, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#entitlement-update
        private void HandleDispatchEntitlementUpdate(DiscordEntitlement entitlement)
        {
            DiscordGuild guild = _client.GetGuild(entitlement.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordEntitlementUpdated, entitlement, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#entitlement-delete
        private void HandleDispatchEntitlementDelete(DiscordEntitlement entitlement)
        {
            DiscordGuild guild = _client.GetGuild(entitlement.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordEntitlementDeleted, entitlement, guild);
        }

        // NOTE: Some elements of Guild object is only sent with GUILD_CREATE
        //https://discord.com/developers/docs/topics/gateway-events#guild-create
        private void HandleDispatchGuildCreate(DiscordGuild guild)
        {
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildCreate)} Guild ID: {{0}} Name: {{1}}", guild.Id, guild.Name);
            
            DiscordGuild existing = _client.GetGuild(guild.Id);
            if (existing == null || !existing.IsAvailable && guild.IsAvailable)
            {
                _client.AddGuildOrUpdate(guild);
                existing = _client.GetGuild(guild.Id);
                existing.HasLoadedAllMembers = false;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildCreated, existing);
            }

            if (_client.Connection.HasIntents(GatewayIntents.GuildMembers))
            {
                if (!existing.HasLoadedAllMembers)
                {
                    _client.GetFirstClient().RequestGuildMembers(new GuildMembersRequestCommand
                    {
                        Nonce = "DiscordExtension",
                        GuildId = guild.Id,
                    });
                    
                    _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildCreate)} Guild is now requesting all guild members.");
                }
            }
            else
            {
                if (_client.Servers.Values.All(value => value.IsAvailable))
                {
                    _client.OnBotFullyLoaded();
                }
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-update
        private void HandleDispatchGuildUpdate(DiscordGuild guild)
        {
            DiscordGuild previous =_client.GetGuild(guild.Id)?.Edit(guild);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildUpdated, guild, previous);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildUpdate)} Guild ID: {{0}}", guild.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-delete
        private void HandleDispatchGuildDelete(DiscordGuild guild)
        {
            DiscordGuild existing = _client.GetGuild(guild.Id);
            if (!guild.IsAvailable) // There is an outage with Discord
            {
                if (existing != null)
                {
                    existing.Unavailable = guild.Unavailable;
                }

                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildUnavailable, existing ?? guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildDelete)} There is an outage with the guild. Guild ID: {{0}}", guild.Id);
            }
            else
            {
                _client.RemoveGuild(guild.Id);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildDeleted, existing ?? guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildDelete)} Guild deleted or user removed from guild. Guild ID: {{0}} Name: {{1}}", guild.Id, existing?.Name ?? guild.Name);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-ban-add
        private void HandleDispatchGuildBanAdd(GuildMemberBannedEvent ban)
        {
            DiscordGuild guild = _client.GetGuild(ban.GuildId);
            
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildBanAdd)} User was banned from the guild. Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}} User Name: {{3}}", ban.GuildId, guild.Name, ban.User.Id, ban.User.FullUserName);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberBanned, ban, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-ban-remove
        private void HandleDispatchGuildBanRemove(GuildMemberBannedEvent ban)
        {
            DiscordGuild guild = _client.GetGuild(ban.GuildId);
            
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberUnbanned, ban.User, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildBanRemove)} User was unbanned from the guild. Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}} User Name: {{3}}", ban.GuildId, guild.Name, ban.User.Id, ban.User.FullUserName);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-emojis-update
        private void HandleDispatchGuildEmojisUpdate(GuildEmojisUpdatedEvent emojis)
        {
            DiscordGuild guild = _client.GetGuild(emojis.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            Hash<Snowflake, DiscordEmoji> previous = guild.Emojis.Clone();

            List<Snowflake> removedEmojis = DiscordPool.Internal.GetList<Snowflake>();

            foreach (Snowflake id in guild.Emojis.Keys)
            {
                if (!emojis.Emojis.ContainsKey(id))
                {
                    removedEmojis.Add(id);
                }
            }

            for (int index = 0; index < removedEmojis.Count; index++)
            {
                Snowflake id = removedEmojis[index];
                guild.Emojis.Remove(id);
            }
            
            DiscordPool.Internal.FreeList(removedEmojis);

            guild.Emojis.RemoveAll(e => e.EmojiId.HasValue && !emojis.Emojis.ContainsKey(e.EmojiId.Value));
                    
            foreach (DiscordEmoji emoji in emojis.Emojis.Values)
            {
                DiscordEmoji existing = guild.Emojis[emoji.Id];
                if (existing != null)
                {
                    existing.Update(emoji);
                }
                else
                {
                    guild.Emojis[emoji.Id] = emoji;
                }
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildEmojisUpdated, emojis, previous, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildEmojisUpdate)} Guild ID: {{0}} Guild Name: {{1}}", emojis.GuildId, guild.Name);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-stickers-update
        private void HandleDispatchGuildStickersUpdate(GuildStickersUpdatedEvent stickers)
        { 
            DiscordGuild guild = _client.GetGuild(stickers.GuildId);

            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            Hash<Snowflake, DiscordSticker> previous = guild.Stickers.Clone();

            List<Snowflake> removedStickers = DiscordPool.Internal.GetList<Snowflake>();

            foreach (Snowflake id in guild.Stickers.Keys)
            {
                if (!stickers.Stickers.ContainsKey(id))
                {
                    removedStickers.Add(id);
                }
            }

            for (int index = 0; index < removedStickers.Count; index++)
            {
                Snowflake id = removedStickers[index];
                guild.Emojis.Remove(id);
            }
            
            DiscordPool.Internal.FreeList(removedStickers);

            guild.Emojis.RemoveAll(e => e.EmojiId.HasValue && !stickers.Stickers.ContainsKey(e.EmojiId.Value));
                    
            foreach (DiscordSticker sticker in stickers.Stickers.Values)
            {
                DiscordSticker existing = guild.Stickers[sticker.Id];
                if (existing != null)
                {
                    existing.Update(sticker);
                }
                else
                {
                    guild.Stickers[sticker.Id] = sticker;
                }
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildStickersUpdated, stickers, previous, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildEmojisUpdate)} Guild ID: {{0}} Guild Name: {{1}}", stickers.GuildId, guild.Name);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-integrations-update
        private void HandleDispatchGuildIntegrationsUpdate(GuildIntegrationsUpdatedEvent integration)
        {
            DiscordGuild guild = _client.GetGuild(integration.GuildId);
            
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildIntegrationsUpdated, integration, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildIntegrationsUpdate)} Guild ID: {{0}} Guild Name: {{1}}", integration.GuildId, guild.Name);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-member-add
        private void HandleDispatchGuildMemberAdd(GuildMemberAddedEvent member)
        {
            DiscordGuild guild = _client.GetGuild(member.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }

            guild.LeftMembers.Remove(member.User.Id);
            guild.Members[member.User.Id] = member;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberAdded, member, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildMemberAdd)} Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}} User Name: {{3}}", member.GuildId, guild.Name, member.User.Id, member.User.FullUserName);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-member-remove
        private void HandleDispatchGuildMemberRemove(GuildMemberRemovedEvent remove)
        {
            DiscordGuild guild = _client.GetGuild(remove.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            GuildMember member = guild.Members[remove.User.Id];
            if (member == null)
            {
                return;
            }

            member.HasLeftGuild = true;
            guild.LeftMembers[remove.User.Id] = member;
            guild.Members.Remove(remove.User.Id);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberRemoved, member, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildMemberRemove)} Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}} User Name: {{3}}", remove.GuildId, guild.Name, member.User.Id, member.User.FullUserName);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-member-update
        private void HandleDispatchGuildMemberUpdate(GuildMemberUpdatedEvent update)
        {
            DiscordGuild guild = _client.GetGuild(update.GuildId);
            if (guild is not {IsAvailable: true})
            {
                return;
            }
            
            GuildMember current = guild.Members[update.Id];
            if (current == null)
            {
                current = update;
                guild.Members[update.Id] = current;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberUpdated, update, current, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildMemberUpdate)} GUILD_MEMBER_UPDATE: Guild ID: {{0}} User ID: {{1}}", update.GuildId, update.User.Id);

            if (current.Nickname != update.Nickname)
            {
                string oldNickname = current.Nickname;
                current.Nickname = update.Nickname;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberNicknameUpdated, current, oldNickname, update.Nickname, current.NickNameLastUpdated, guild);
                current.NickNameLastUpdated = DateTime.UtcNow;
            }

            if (current.Avatar != update.Avatar)
            {
                current.Avatar = update.Avatar;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberAvatarUpdated, current, current.Avatar, update.Avatar, guild);
            }

            if (current.Deaf != update.Deaf)
            {
                current.Deaf = update.Deaf;
                _client.Hooks.CallHook(update.Deaf ? DiscordExtHooks.OnDiscordGuildMemberDeafened : DiscordExtHooks.OnDiscordGuildMemberUndeafened, current, guild);
            }

            if (current.Mute != update.Mute)
            {
                current.Mute = update.Mute;
                _client.Hooks.CallHook(update.Mute ? DiscordExtHooks.OnDiscordGuildMemberMuted : DiscordExtHooks.OnDiscordGuildMemberUnmuted, current, guild);
            }

            if (current.CommunicationDisabledUntil != update.CommunicationDisabledUntil)
            {
                DateTime? previous = current.CommunicationDisabledUntil;
                current.CommunicationDisabledUntil = update.CommunicationDisabledUntil;
                if (previous.HasValue && !update.CommunicationDisabledUntil.HasValue)
                {
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberTimeoutEnded, current, guild);
                }
                else if(!previous.HasValue && update.CommunicationDisabledUntil.HasValue)
                {
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberTimeout, current, guild);
                }
            }

            if (current.PremiumSince != update.PremiumSince)
            {
                DateTime? previous = current.PremiumSince;
                current.PremiumSince = update.PremiumSince;
                if (!previous.HasValue && update.PremiumSince.HasValue)
                {
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberBoosted, current, guild);
                }
                else if (previous.HasValue && current.PremiumSince.HasValue && current.PremiumSince.Value > DateTime.UtcNow)
                {
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberBoostExtended, current, guild);
                }
                else if (previous.HasValue && !current.PremiumSince.HasValue)
                {
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberBoostEnded, current, guild);
                }
            }

            for (int index = current.Roles.Count - 1; index >= 0; index--)
            {
                Snowflake role = current.Roles[index];
                if (!update.Roles.Contains(role))
                {
                    current.Roles.RemoveAt(index);
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberRoleRemoved, current, role, guild);
                }
            }
            
            for (int index = update.Roles.Count - 1; index >= 0; index--)
            {
                Snowflake role = update.Roles[index];
                if (!current.Roles.Contains(role))
                {
                    current.Roles.Add(role);
                    _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberRoleAdded, current, role, guild);
                }
            }

            current.Flags = update.Flags;
            current.Banner = update.Banner;
            current.Pending = update.Pending;
            if (update.AvatarDecoration != null) current.AvatarDecoration = update.AvatarDecoration;
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-members-chunk
        private void HandleDispatchGuildMembersChunk(GuildMembersChunkEvent chunk)
        {
            DiscordGuild guild = _client.GetGuild(chunk.GuildId);

            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildMembersChunk)}: Guild ID: {{0}} Guild Name: {{1}} Nonce: {{2}}", chunk.GuildId, guild?.Name, chunk.Nonce);
            //Used to load all members in the discord server
            if (chunk.Nonce == "DiscordExtension")
            {
                if (guild is not {IsAvailable: true})
                {
                    return;
                }
                
                for (int index = 0; index < chunk.Members.Count; index++)
                {
                    GuildMember member = chunk.Members[index];
                    guild.Members.TryAdd(member.User.Id, member);
                }
                    
                //Once we've loaded all guild members call hook
                if (chunk.ChunkIndex + 1 < chunk.ChunkCount)
                {
                    return;
                }
                
                guild.HasLoadedAllMembers = true;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMembersLoaded, guild);
                if (_client.Servers.Values.All(s => s.HasLoadedAllMembers))
                {
                    _client.OnBotFullyLoaded();
                }
                return;
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMembersChunk, chunk, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-role-create
        private void HandleDispatchGuildRoleCreate(GuildRoleCreatedEvent role)
        {
            DiscordGuild guild = _client.GetGuild(role.GuildId);

            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            guild.Roles[role.Role.Id] = role.Role;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildRoleCreated, role.Role, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildRoleCreate)} Guild ID: {{0}} Guild Name: {{1}} Role ID: {{2}} Role Name: {{3}}", role.GuildId, guild.Name, role.Role.Id, role.Role);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-role-update
        private void HandleDispatchGuildRoleUpdate(GuildRoleUpdatedEvent update)
        {
            DiscordRole updatedRole = update.Role;
            DiscordGuild guild = _client.GetGuild(update.GuildId);
            
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            DiscordRole existing = guild.Roles[updatedRole.Id];
            if (existing == null)
            {
                return;
            }
            
            DiscordRole previous = existing.UpdateRole(updatedRole);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildRoleUpdated, updatedRole, previous, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildRoleUpdate)} Existing Guild ID: {{0}} Guild Name: {{1}} Role ID: {{2}} Role Name: {{3}}", update.GuildId, guild.Name, update.Role.Id, update.Role.Name);
        }

        //https://discord.com/developers/docs/topics/gateway-events#guild-role-delete
        private void HandleDispatchGuildRoleDelete(GuildRoleDeletedEvent delete)
        {
            DiscordGuild guild = _client.GetGuild(delete.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            DiscordRole role = guild.Roles[delete.RoleId];
            if (role == null)
            {
                return;
            }
            
            guild.Roles.Remove(delete.RoleId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildRoleDeleted, role, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildRoleDelete)} Guild ID: {{0}} Guild Name: {{1}} Role ID: {{2}}", delete.GuildId, guild.Name, delete.RoleId);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-scheduled-event-create
        private void HandleDispatchGuildScheduledEventCreate(GuildScheduledEvent guildEvent)
        {
            DiscordGuild guild = _client.GetGuild(guildEvent.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            guild.ScheduledEvents[guild.Id] = guildEvent;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildScheduledEventCreated, guildEvent, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildScheduledEventCreate)} Guild ID: {{0}} Guild Name: {{1}} Scheduled Event ID: {{2}}", guildEvent.GuildId, guild.Name, guildEvent.Id);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-scheduled-event-update
        private void HandleDispatchGuildScheduledEventUpdate(GuildScheduledEvent guildEvent)
        {
            DiscordGuild guild = _client.GetGuild(guildEvent.GuildId);

            GuildScheduledEvent existing = guild?.ScheduledEvents[guildEvent.Id];
            if (existing == null)
            {
                return;
            }
            
            existing.Update(guildEvent);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildScheduledEventUpdated, guildEvent, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildScheduledEventUpdate)} Guild ID: {{0}} Guild Name: {{1}} Scheduled Event ID: {{2}}", guildEvent.GuildId, guild.Name, guildEvent.Id);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-scheduled-event-delete
        private void HandleDispatchGuildScheduledEventDelete(GuildScheduledEvent guildEvent)
        {
            DiscordGuild guild = _client.GetGuild(guildEvent.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            guild.ScheduledEvents.Remove(guildEvent.Id);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildScheduledEventDeleted, guildEvent, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildScheduledEventDelete)} Guild ID: {{0}} Guild Name: {{1}} Scheduled Event ID: {{2}}", guildEvent.GuildId, guild.Name, guildEvent.Id);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-scheduled-event-user-add
        private void HandleDispatchGuildScheduledEventUserAdd(GuildScheduleEventUserAddedEvent added)
        {
            DiscordGuild guild = _client.GetGuild(added.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            GuildScheduledEvent scheduledEvent = guild.ScheduledEvents[added.GuildScheduledEventId];
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildScheduledEventUserAdded, added, scheduledEvent, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildScheduledEventUserAdd)} Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}}", added.GuildId, guild.Name, added.UserId);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#guild-scheduled-event-user-remove
        private void HandleDispatchGuildScheduledEventUserRemove(GuildScheduleEventUserRemovedEvent removed)
        {
            DiscordGuild guild = _client.GetGuild(removed.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            GuildScheduledEvent scheduledEvent = guild.ScheduledEvents[removed.GuildScheduledEventId];
            guild.ScheduledEvents.Remove(removed.GuildScheduledEventId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildScheduledEventUserRemoved, removed, scheduledEvent, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchGuildScheduledEventUserRemove)} Guild ID: {{0}} Guild Name: {{1}} User ID: {{2}}", removed.GuildId, guild.Name, removed.UserId);
        }

        //https://discord.com/developers/docs/topics/gateway-events#integration-create
        private void HandleDispatchIntegrationCreate(IntegrationCreatedEvent integration)
        {
            DiscordGuild guild = _client.GetGuild(integration.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildIntegrationCreated, integration, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchIntegrationCreate)} Guild ID: {{0}} Guild Name: {{1}} Integration ID: {{2}}", integration.GuildId, guild.Name, integration.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#integration-update
        private void HandleDispatchIntegrationUpdate(IntegrationUpdatedEvent integration)
        {
            DiscordGuild guild = _client.GetGuild(integration.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildIntegrationUpdated, integration, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchIntegrationUpdate)} Guild ID: {{0}} Guild Name: {{1}} Integration ID: {{2}}", integration.GuildId, guild.Name, integration.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#integration-delete
        private void HandleDispatchIntegrationDelete(IntegrationDeletedEvent integration)
        {
            DiscordGuild guild = _client.GetGuild(integration.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildIntegrationDeleted, integration, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchIntegrationDelete)} Guild ID: {{0}} Guild Name: {{1}} Integration ID: {{2}}", integration.GuildId, guild.Name, integration.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-create
        private void HandleDispatchMessageCreate(DiscordMessage message)
        {
            DiscordGuild guild = _client.GetGuild(message.GuildId);
            DiscordChannel channel = _client.GetChannel(message.ChannelId, message.GuildId);
            
            if (channel != null)
            {
                channel.LastMessageId = message.Id;
                if (channel.Type == ChannelType.GuildPublicThread || channel.Type == ChannelType.GuildPrivateThread)
                {
                    channel.MessageCount = channel.MessageCount++ ?? 1;
                    channel.TotalMessageSent = channel.TotalMessageSent++ ?? 1;
                }
            }

            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageCreate)} Guild ID: {{0}} Channel ID: {{1}} Message ID: {{2}}", message.GuildId, message.ChannelId, message.Id);

            if (!message.Author.Bot.HasValue || !message.Author.Bot.Value)
            {
                if(!string.IsNullOrEmpty(message.Content) && DiscordCommand.Instance.HasCommands() && DiscordConfig.Instance.Commands.CommandPrefixes.Contains(message.Content[0]))
                {
                    message.Content.TrimStart(DiscordConfig.Instance.Commands.CommandPrefixes).ParseCommand(out string command, out string[] args);
                    _logger.Debug($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageCreate)} Cmd: {{0}}", message.Content);

                    if (message.GuildId.HasValue && message.GuildId.Value.IsValid() && DiscordCommand.Instance.HandleGuildCommand(_client, message, channel, command, args))
                    {
                        _logger.Debug($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageCreate)} Guild Handled Cmd: {{0}}", command);
                        return;
                    }

                    if (!message.GuildId.HasValue && DiscordCommand.Instance.HandleDirectMessageCommand(_client, message, channel, command, args))
                    {
                        _logger.Debug($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageCreate)} Direct Handled Cmd: {{0}}", command);
                        return;
                    }
                }

                if (DiscordSubscriptions.Instance.HasSubscriptions() && channel != null && message.GuildId.HasValue)
                {
                    DiscordSubscriptions.Instance.HandleMessage(message, channel, _client);
                }
            }

            if (message.GuildId.HasValue)
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageCreated, message, channel, guild);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageCreated, message, channel);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-update
        private void HandleDispatchMessageUpdate(DiscordMessage message)
        {
            DiscordChannel channel = _client.GetChannel(message.ChannelId, message.GuildId);
            
            if (message.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(message.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageUpdated, message, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageUpdate)} GuildMessage Guild ID: {{0}} Guild Name: {{1}} Channel ID: {{2}} Channel Name: {{3}} Message ID: {{4}}", message.GuildId, guild.Name, message.ChannelId, channel?.Name, message.Id);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageUpdated, message, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageUpdate)} DirectMessage Message ID: {{0}} Channel ID: {{1}}", message.Id, message.ChannelId);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-delete
        private void HandleDispatchMessageDelete(MessageDeletedEvent message)
        {
            DiscordChannel channel = _client.GetChannel(message.ChannelId, message.GuildId);

            if (channel != null && (channel.Type == ChannelType.GuildPublicThread || channel.Type == ChannelType.GuildPrivateThread))
            {
                channel.MessageCount = channel.MessageCount-- ?? 0;
            }

            if (message.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(message.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageDeleted, message, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageDelete)} GuildMessage Message ID: {{0}} Channel ID: {{1}} Channel Name: {{2}} Guild Id: {{3}} Guild Name: {{4}}", message.Id, message.ChannelId, channel?.Name, message.GuildId, guild.Name);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageDeleted, message, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageDelete)} DirectMessage Message ID: {{0}} Channel ID: {{1}}", message.Id, message.ChannelId);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-delete-bulk
        private void HandleDispatchMessageDeleteBulk(MessageBulkDeletedEvent bulkDelete)
        {
            DiscordChannel channel = _client.GetChannel(bulkDelete.ChannelId, bulkDelete.GuildId);
            
            if (channel != null && (channel.Type == ChannelType.GuildPublicThread || channel.Type == ChannelType.GuildPrivateThread))
            {
                channel.MessageCount = channel.MessageCount - bulkDelete.Ids.Count ?? 0;
            }
            
            if (bulkDelete.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(bulkDelete.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessagesBulkDeleted, bulkDelete.Ids, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageDeleteBulk)} Channel ID: {{0}} Channel Name: {{1}} Guild ID: {{2}} Guild Name: {{3}}", bulkDelete.ChannelId.Id, channel?.Name, bulkDelete.GuildId, guild.Name);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessagesBulkDeleted, bulkDelete.Ids, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageDeleteBulk)} Channel ID: {{0}}", bulkDelete.ChannelId);
            }
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#message-reaction-add
        private void HandleDispatchMessageReactionAdd(MessageReactionAddedEvent reaction)
        {
            DiscordChannel channel = _client.GetChannel(reaction.ChannelId, reaction.GuildId);

            if (reaction.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(reaction.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageReactionAdded, reaction, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionAdd)} GuildMessage Emoji: {{0}} Channel ID: {{1}} Channel Name: {{2}} Message ID: {{3}} User ID: {{4}} Guild ID: {{5}} Guild Name: {{6}}", reaction.Emoji.Name, reaction.ChannelId, channel.Name, reaction.MessageId, reaction.UserId, reaction.GuildId, guild.Name);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageReactionAdded, reaction, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionAdd)} DirectMessage Emoji: {{0}} Channel ID: {{1}} Message ID: {{2}} User ID: {{3}}", reaction.Emoji.Name, reaction.ChannelId, reaction.MessageId, reaction.UserId);
            } 
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-reaction-remove
        private void HandleDispatchMessageReactionRemove(MessageReactionRemovedEvent reaction)
        {
            DiscordChannel channel = _client.GetChannel(reaction.ChannelId, reaction.GuildId);

            if (reaction.GuildId.HasValue)
            { 
                DiscordGuild guild = _client.GetGuild(reaction.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageReactionRemoved, reaction, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemove)} GuildMessage Emoji: {{0}} Channel ID: {{1}} Channel Name: {{2}} Message ID: {{3}} User ID: {{4}} Guild ID: {{5}} Guild Name: {{6}}", reaction.Emoji.Name, reaction.ChannelId, channel.Name, reaction.MessageId, reaction.UserId, reaction.GuildId, guild?.Name);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageReactionRemoved, reaction, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemove)} DirectMessage Emoji: {{0}} Channel ID: {{1}} Message ID: {{2}} User ID: {{3}}", reaction.Emoji.Name, reaction.ChannelId, reaction.MessageId, reaction.UserId);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#message-reaction-remove-all
        private void HandleDispatchMessageReactionRemoveAll(MessageReactionRemovedAllEvent reaction)
        {
            DiscordChannel channel = _client.GetChannel(reaction.ChannelId, reaction.GuildId);

            if (reaction.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(reaction.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageReactionRemovedAll, reaction, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemoveAll)} GuildMessage Channel ID: {{0}} Channel Name: {{1}} Message ID: {{2}} Guild ID: {{3}} Guild Name: {{4}}", reaction.ChannelId, channel.Name, reaction.MessageId, reaction.GuildId, guild?.Name);
            }
            else
            {
                
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageReactionRemovedAll, reaction, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemoveAll)} DirectMessage Channel ID: {{0}} Message ID: {{1}}", reaction.ChannelId, reaction.MessageId);
            }
        }        
        
        //https://discord.com/developers/docs/topics/gateway-events#message-reaction-remove-emoji
        private void HandleDispatchMessageReactionRemoveEmoji(MessageReactionRemovedAllEmojiEvent reaction)
        {
            DiscordChannel channel = _client.GetChannel(reaction.ChannelId, reaction.GuildId);

            if (reaction.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(reaction.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMessageReactionEmojiRemoved, reaction, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemoveAll)} GuildMessage Emoji: {{0}} Channel ID: {{1}} Channel Name: {{2}} Message ID: {{3}} Guild ID: {{4}} Guild Name: {{5}}", reaction.Emoji.Name, reaction.ChannelId, channel.Name, reaction.MessageId, reaction.GuildId, guild.Name);
            }
            else
            {
                
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectMessageReactionEmojiRemoved, reaction, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchMessageReactionRemoveAll)} DirectMessage Emoji: {{0}} Channel ID: {{1}}  Message ID: {{2}}", reaction.Emoji.Name, reaction.ChannelId, reaction.MessageId);
            }
        }

        /// <summary>
        ///  * From Discord API docs:
        ///  * The user object within this event can be partial, the only field which must be sent is the id field, everything else is optional.
        ///  * Along with this limitation, no fields are required, and the types of the fields are not validated.
        ///  * Your client should expect any combination of fields and types within this event
        /// </summary>
        /// <param name="update"></param>
        /// https://discord.com/developers/docs/topics/gateway#presence-update
        private void HandleDispatchPresenceUpdate(PresenceUpdatedEvent update)
        {
            DiscordUser updateUser = update.User;
            
            DiscordGuild guild = _client.GetGuild(update.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            GuildMember member = guild.Members[updateUser.Id];
            if (member == null)
            {
                return;
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildMemberPresenceUpdated, update, member, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchPresenceUpdate)} Guild ID: {{0}} User ID: {{1}} Status: {{2}}", update.GuildId, update.User.Id, update.Status);
        }

        //https://discord.com/developers/docs/topics/gateway-events#typing-start
        private void HandleDispatchTypingStart(TypingStartedEvent typing)
        {
            DiscordChannel channel = _client.GetChannel(typing.ChannelId, typing.GuildId);

            if (typing.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(typing.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildTypingStarted, typing, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchTypingStart)} GuildChannel Channel ID: {{0}} Channel Name: {{1}} User ID: {{2}} Guild ID: {{3}} Guild Name: {{4}}", typing.ChannelId, channel.Name, typing.UserId, typing.GuildId, guild.Name);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectTypingStarted, typing, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchTypingStart)} DirectChannel Channel ID: {{0}} User ID: {{1}}", typing.ChannelId, typing.UserId);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#user-update
        private void HandleDispatchUserUpdate(DiscordUser user)
        {
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordUserUpdated, user);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchUserUpdate)} User ID: {{0}}", user.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#voice-state-update
        private void HandleDispatchVoiceStateUpdate(VoiceState voice)
        {
            DiscordGuild guild = _client.GetGuild(voice.GuildId);
            VoiceState existing = guild.VoiceStates[voice.UserId];
            DiscordChannel channel = voice.ChannelId.HasValue ? _client.GetChannel(voice.ChannelId.Value, voice.GuildId) : null;

            if (existing != null)
            {
                existing.Update(voice);
                voice = existing;
            }
            else
            {
                guild.VoiceStates[voice.UserId] = voice;
            }
            
            if (voice.GuildId.HasValue)
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildVoiceStateUpdated, voice, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchVoiceStateUpdate)} GuildChannel Guild ID: {{0}} Guild Name: {{1}} Channel ID: {{2}} Channel Name: {{3}} User ID: {{4}}", voice.GuildId, guild.Name, voice.ChannelId, channel?.Name, voice.UserId);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectVoiceStateUpdated, voice, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchVoiceStateUpdate)} DirectChannel Channel ID: {{0}} User ID: {{1}}", voice.ChannelId, voice.UserId);
            }
        }
        
        // https://discord.com/developers/docs/topics/gateway-events#voice-channel-effect-send
        private void HandleDispatchVoiceChannelEffect(VoiceChannelEffectEvent effect)
        {
            DiscordGuild guild = _client.GetGuild(effect.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordVoiceChannelEffect, effect, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#voice-server-update
        private void HandleDispatchVoiceServerUpdate(VoiceServerUpdatedEvent voice)
        {
            DiscordGuild guild = _client.GetGuild(voice.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildVoiceServerUpdated, voice, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchVoiceServerUpdate)} Guild ID: {{0}} Guild Name: {{1}}", voice.GuildId, guild.Name);
        }

        //https://discord.com/developers/docs/topics/gateway-events#webhooks-update
        private void HandleDispatchWebhooksUpdate(WebhooksUpdatedEvent webhook)
        {
            DiscordGuild guild = _client.GetGuild(webhook.GuildId);
            DiscordChannel channel = guild?.Channels[webhook.ChannelId];

            if (channel == null)
            {
                return;
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildWebhookUpdated, webhook, channel, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchWebhooksUpdate)} Guild ID: {{0}} Guild Name {{1}} Channel ID: {{2}} Channel Name: {{3}}", webhook.GuildId, guild.Name, webhook.ChannelId, channel.Name);
        }

        //https://discord.com/developers/docs/topics/gateway-events#invite-create
        private void HandleDispatchInviteCreate(InviteCreatedEvent invite)
        {
            DiscordChannel channel = _client.GetChannel(invite.ChannelId, invite.GuildId);
            
            if (invite.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(invite.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildInviteCreated, invite, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInviteCreate)} Guild Invite Guild ID: {{0}} Guild Name: {{1}} Channel ID: {{2}} Channel Name: {{3}} Code: {{4}}", invite.GuildId, guild?.Name, invite.ChannelId, channel?.Name, invite.Code);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectInviteCreated, invite, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInviteCreate)} Direct Invite Channel ID: {{0}} Code: {{1}}", invite.ChannelId, invite.Code);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#invite-delete
        private void HandleDispatchInviteDelete(InviteDeletedEvent invite)
        {
            DiscordChannel channel = _client.GetChannel(invite.ChannelId, invite.GuildId);
            
            if (invite.GuildId.HasValue)
            {
                DiscordGuild guild = _client.GetGuild(invite.GuildId);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildInviteDeleted, invite, channel, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInviteDelete)} Guild ID: {{0}} Guild Name: {{1}} Channel ID: {{2}} Channel Name: {{3}} Code: {{4}}", invite.GuildId, guild.Name, invite.ChannelId,channel.Name, invite.Code);
            }
            else
            {
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordDirectInviteDeleted, invite, channel);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInviteDelete)} Channel ID: {{0}} Code: {{1}}", invite.ChannelId, invite.Code);
            }
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#application-command-permissions-update
        private void HandleApplicationCommandsPermissionsUpdate(CommandPermissions permissions)
        {
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordApplicationCommandPermissionsUpdated, permissions);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleApplicationCommandsPermissionsUpdate)} Permission ID: {{0}}", permissions.Id);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#interaction-create
        private void HandleDispatchInteractionCreate(DiscordInteraction interaction)
        {
            if (DiscordAppCommand.Instance.HandleInteraction(interaction))
            {
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInteractionCreate)} Handled. Guild ID: {{0}} Channel ID: {{1}} Interaction ID: {{2}}", interaction.GuildId, interaction.ChannelId, interaction.Id);
                return;
            }
            
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchInteractionCreate)} Unhandled.  Guild ID: {{0}} Channel ID: {{1}} Interaction ID: {{2}}", interaction.GuildId, interaction.ChannelId, interaction.Id);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordInteractionCreated, interaction);
        }

        //https://discord.com/developers/docs/topics/gateway-events#thread-create
        private void HandleDispatchThreadCreated(DiscordChannel thread)
        {
            if (!thread.GuildId.HasValue)
            {
                return;
            }
            
            DiscordGuild guild = _client.GetGuild(thread.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            guild.Threads[thread.Id] = thread;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadCreated, thread, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchThreadCreated)} Guild: {{0}}({{1}}) Thread: {{2}}({{3}})", guild.Name, guild.Id, thread.Name, thread.Id);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#thread-update
        private void HandleDispatchThreadUpdated(DiscordChannel thread)
        {
            if (!thread.GuildId.HasValue)
            {
                return;
            }
            
            DiscordGuild guild = _client.GetGuild(thread.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            DiscordChannel existing = guild.Threads[thread.Id];
            if (existing != null)
            {
                DiscordChannel previous = existing.Update(thread);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadUpdated, thread, previous, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchThreadUpdated)} Existing Thread: {{0}}({{1}}) Thread: {{2}}({{3}})", guild.Name, guild.Id, thread.Name, thread.Id);
            }
            else
            {
                guild.Threads[thread.Id] = thread;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadUpdated, thread, thread, guild);
                _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchThreadUpdated)} New Thread: {{0}}({{1}}) Thread: {{2}}({{3}})", guild.Name, guild.Id, thread.Name, thread.Id);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#thread-delete
        private void HandleDispatchThreadDeleted(DiscordChannel thread )
        {
            if (!thread.GuildId.HasValue)
            {
                return;
            }
            
            DiscordGuild guild = _client.GetGuild(thread.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            thread = guild.Threads[thread.Id] ?? thread;
            guild.Threads.Remove(thread.Id);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadDeleted, thread, guild);
            _logger.Verbose($"{nameof(WebSocketEventHandler)}.{nameof(HandleDispatchThreadDeleted)} Guild: {{0}}({{1}}) Thread: {{2}}({{3}})", guild.Name, guild.Id, thread.Name, thread.Id);
        }

        //https://discord.com/developers/docs/topics/gateway-events#thread-list-sync
        private void HandleDispatchThreadListSync(ThreadListSyncEvent sync)
        {
            DiscordGuild guild = _client.GetGuild(sync.GuildId);

            //We clear all threads from the guild if ChannelIds is null or the ChannelId exists in ChannelIds
            List<Snowflake> deleteThreadIds = DiscordPool.Internal.GetList<Snowflake>();
            foreach (DiscordChannel thread in guild.Threads.Values)
            {
                if (thread.ParentId.HasValue 
                    && (sync.ChannelIds == null || sync.ChannelIds.Contains(thread.ParentId.Value))
                    && !sync.Threads.ContainsKey(thread.Id))
                {
                    deleteThreadIds.Add(thread.Id);
                }
            }

            //Remove all threads who were in synced channels
            foreach (Snowflake threadId in deleteThreadIds)
            {
                guild.Threads.Remove(threadId);
            }
            
            DiscordPool.Internal.FreeList(deleteThreadIds);
            
            //Add threads to the guild
            foreach (DiscordChannel thread in sync.Threads.Values)
            {
                DiscordChannel existing = guild.Threads[thread.Id];
                if (existing != null)
                {
                    existing.Update(thread);
                    existing.ThreadMembers.Clear();
                }
                else
                {
                    guild.Threads[thread.Id] = thread;
                }
            }

            foreach (ThreadMember member in sync.Members)
            {
                if (member.Id.HasValue && member.UserId.HasValue)
                {
                    DiscordChannel thread = guild.Threads[member.Id.Value];
                    if (thread != null)
                    {
                        thread.ThreadMembers[member.UserId.Value] = member;
                    }
                }
            }
            
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadListSynced, sync, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#thread-member-update
        private void HandleDispatchThreadMemberUpdated(ThreadMemberUpdateEvent member)
        {
            DiscordGuild guild = _client.GetGuild(member.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }

            if (!member.Id.HasValue || !member.UserId.HasValue)
            {
                return;
            }
            
            DiscordChannel thread = guild.Threads[member.Id.Value];
            if (thread == null)
            {
                return;
            }
            
            ThreadMember existing = thread.ThreadMembers[member.UserId.Value];
            if (existing != null)
            {
                existing.Update(member);
            }
            else
            {
                thread.ThreadMembers[member.UserId.Value] = member;
            }
                    
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadMemberUpdated, member, thread, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#thread-members-update
        private void HandleDispatchThreadMembersUpdated(ThreadMembersUpdatedEvent members)
        {
            DiscordGuild guild = _client.GetGuild(members.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            DiscordChannel thread = guild.Threads[members.Id];
            if (thread == null)
            {
                return;
            }
            
            if (members.AddedMembers != null)
            {
                for (int index = 0; index < members.AddedMembers.Count; index++)
                {
                    ThreadMember member = members.AddedMembers[index];
                    if (member.UserId.HasValue)
                    {
                        thread.ThreadMembers[member.UserId.Value] = member;
                    }
                }
            }

            if (members.RemovedMemberIds != null)
            {
                for (int index = 0; index < members.RemovedMemberIds.Count; index++)
                {
                    Snowflake memberId = members.RemovedMemberIds[index];
                    thread.ThreadMembers.Remove(memberId);
                }
            }

            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildThreadMembersUpdated, members, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#stage-instance-create
        private void HandleDispatchStageInstanceCreated(StageInstance stage)
        {
            DiscordGuild guild = _client.GetGuild(stage.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            guild.StageInstances[stage.Id] = stage;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordStageInstanceCreated, stage, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#stage-instance-update
        private void HandleDispatchStageInstanceUpdated(StageInstance stage)
        {
            DiscordGuild guild = _client.GetGuild(stage.GuildId);
            if (guild == null || !guild.IsAvailable)
            {
                return;
            }
            
            StageInstance existing = guild.StageInstances[stage.Id];
            if (existing == null)
            {
                guild.StageInstances[stage.Id] = stage;
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordStageInstanceUpdated, stage, stage, guild);
            }
            else
            {
                StageInstance previous = existing.Edit(stage);
                _client.Hooks.CallHook(DiscordExtHooks.OnDiscordStageInstanceUpdated, stage, previous, guild);
            }
        }

        //https://discord.com/developers/docs/topics/gateway-events#stage-instance-delete
        private void HandleDispatchStageInstanceDeleted(StageInstance stage)
        {
            DiscordGuild guild = _client.GetGuild(stage.GuildId);
            if (guild is not {IsAvailable: true})
            {
                return;
            }
            
            StageInstance existing = guild.StageInstances[stage.Id];
            guild.StageInstances.Remove(stage.Id);
            guild.StageInstances[stage.Id] = stage;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordStageInstanceDeleted, existing ?? stage, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#subscription-create
        private void HandleDispatchSubscriptionCreated(DiscordSubscription subscription)
        {
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordSubscriptionCreated, subscription);
        }

        //https://discord.com/developers/docs/topics/gateway-events#subscription-update
        private void HandleDispatchSubscriptionUpdated(DiscordSubscription subscription)
        {
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordSubscriptionUpdated, subscription);
        }

        //https://discord.com/developers/docs/topics/gateway-events#subscription-delete
        private void HandleDispatchSubscriptionDeleted(DiscordSubscription subscription)
        {
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordSubscriptionDeleted, subscription);
        }
        
        //https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-create
        private void HandleDispatchSoundboardSoundCreated(DiscordSoundboardSound sound)
        {
            DiscordGuild guild = _client.GetGuild(sound.GuildId);
            guild.SoundboardSounds[sound.Id] = sound;
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildSoundboardCreated, sound, guild);
        }

        //https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-update
        private void HandleDispatchSoundboardSoundUpdated(DiscordSoundboardSound sound)
        {
            DiscordGuild guild = _client.GetGuild(sound.GuildId);
            DiscordSoundboardSound existing = guild.SoundboardSounds[sound.Id];
            if (existing == null)
            {
                guild.SoundboardSounds[sound.Id] = sound;
            }
            else
            {
                existing.Update(sound);
            }
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildSoundboardUpdated, existing ?? sound, guild);
        }

        //https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-delete
        private void HandleDispatchSoundboardSoundDeleted(SoundboardDeletedEvent sounds)
        {
            DiscordGuild guild = _client.GetGuild(sounds.GuildId);
            DiscordSoundboardSound sound = guild.SoundboardSounds[sounds.SoundId] ?? new DiscordSoundboardSound { SoundId = sounds.SoundId };
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGuildSoundboardDeleted, sound, guild);
        }

        //https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sounds-update
        private void HandleDispatchSoundboardSoundsUpdated(SoundboardSoundsUpdatedEvent sounds)
        {
            for (int index = 0; index < sounds.SoundboardSounds.Count; index++)
            {
                DiscordSoundboardSound sound = sounds.SoundboardSounds[index];
                HandleDispatchSoundboardSoundUpdated(sound);
            }
        }
        
        //https://discord.com/developers/docs/events/gateway-events#soundboard-sounds
        private void HandleDispatchGetSoundboardSoundsResponse(GetGuildSoundboardSoundsEvent sounds)
        {
            DiscordGuild guild = _client.GetGuild(sounds.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordGetGuildSoundboardSounds, sounds.SoundboardSounds, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#auto-moderation-rule-create
        private void HandleDispatchAutoModRuleCreated(AutoModRule rule)
        {
            DiscordGuild guild = _client.GetGuild(rule.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordAutoModRuleCreated, rule, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#auto-moderation-rule-update
        private void HandleDispatchAutoModRuleUpdated(AutoModRule rule)
        {
            DiscordGuild guild = _client.GetGuild(rule.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordAutoModRuleUpdated, rule, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#auto-moderation-rule-delete
        private void HandleDispatchAutoModRuleDeleted(AutoModRule rule)
        {
            DiscordGuild guild = _client.GetGuild(rule.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordAutoModRuleDeleted, rule, guild);
        }

        //https://discord.com/developers/docs/topics/gateway-events#auto-moderation-action-execution
        private void HandleDispatchAutoModActionExecuted(AutoModActionExecutionEvent action)
        {
            DiscordGuild guild = _client.GetGuild(action.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordAutoModActionExecuted, action, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-add
        private void HandleDispatchMessagePollVoteAdded(MessagePollVoteAddedEvent data)
        {
            DiscordGuild guild = _client.GetGuild(data.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordPollVoteAdded, data, guild);
        }
        
        //https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-remove
        private void HandleDispatchMessagePollVoteRemoved(MessagePollVoteRemovedEvent data)
        {
            DiscordGuild guild = _client.GetGuild(data.GuildId);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordPollVoteRemoved, data, guild);
        }

        private void HandleDispatchUnhandledEvent(EventPayload payload)
        {
            _logger.Verbose("Unhandled Dispatch Event: {0}.\n{1}", payload.DispatchCode, payload.Data);
            _client.Hooks.CallHook(DiscordExtHooks.OnDiscordUnhandledCommand, payload);
        }

        //https://discord.com/developers/docs/topics/gateway-events#heartbeat
        private ValueTask HandleHeartbeat()
        {
            _logger.Debug("Manually sent heartbeat (received opcode 1)");
            return _webSocket.SendHeartbeat();
        }

        //https://discord.com/developers/docs/topics/gateway-events#reconnect
        private void HandleReconnect()
        {
            _webSocket.OnReconnectRequested();
        }

        //https://discord.com/developers/docs/topics/gateway-events#invalid-session
        private void HandleInvalidSession(bool resume)
        {
            _webSocket.OnInvalidSession(resume);
        }

        //https://discord.com/developers/docs/topics/gateway-events#hello
        private ValueTask HandleHello(EventPayload payload)
        {
            GatewayHelloEvent hello = payload.GetData<GatewayHelloEvent>(_client);
            return _webSocket.OnDiscordHello(hello);
        }

        //https://discord.com/developers/docs/topics/gateway-events#heartbeating
        private void HandleHeartbeatAcknowledge()
        {
            _webSocket.OnHeartbeatAcknowledge();
        }
        #endregion
    }
}