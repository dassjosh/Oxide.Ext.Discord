using System;
using System.Collections.Generic;
using System.Reflection;
using Oxide.Ext.Discord.Entities;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Constants;

/// <summary>
/// Represents all hooks available in the discord extension
/// </summary>
public static class DiscordExtHooks
{
    /// <summary>
    /// Hooks that are called on Discord Plugins
    /// </summary>
    private static readonly HashSet<string> AllHooks = [];

    /// <summary>
    /// Hooks that are called on Discord Plugins
    /// </summary>
    private static readonly HashSet<string> PluginHooks = [];

    /// <summary>
    /// Hooks that are call globally
    /// </summary>
    private static readonly HashSet<string> GlobalHooks =
    [
        OnDiscordPlayerLinked,
        OnDiscordPlayerUnlink,
        OnDiscordPlayerUnlinked
    ];

    /// <summary>
    /// A mapping of Gateway Intent to Hooks
    /// </summary>
    private static readonly Hash<GatewayIntents, List<string>> GatewayIntentHooks = new()
    {
        [GatewayIntents.Guilds] =
        [
            OnDiscordGuildCreated,
            OnDiscordGuildUpdated,
            OnDiscordGuildDeleted,
            OnDiscordGuildUnavailable,
            OnDiscordGuildRoleCreated,
            OnDiscordGuildRoleUpdated,
            OnDiscordGuildRoleDeleted,
            OnDiscordGuildChannelCreated,
            OnDiscordGuildChannelUpdated,
            OnDiscordGuildChannelDeleted,
            OnDiscordGuildChannelPinsUpdated,
            OnDiscordGuildThreadCreated,
            OnDiscordGuildThreadUpdated,
            OnDiscordGuildThreadListSynced,
            OnDiscordGuildThreadMemberUpdated,
            OnDiscordGuildThreadMembersUpdated,
            OnDiscordStageInstanceCreated,
            OnDiscordStageInstanceUpdated,
            OnDiscordStageInstanceDeleted
        ],
        [GatewayIntents.GuildMembers] =
        [
            OnDiscordGuildMemberAdded,
            OnDiscordGuildMemberUpdated,
            OnDiscordGuildMemberRemoved,
            OnDiscordGuildMemberRoleAdded,
            OnDiscordGuildMemberRoleRemoved,
            OnDiscordGuildMemberBoosted,
            OnDiscordGuildMemberBoostExtended,
            OnDiscordGuildMemberBoostEnded,
            OnDiscordGuildMemberNicknameUpdated,
            OnDiscordGuildMemberAvatarUpdated,
            OnDiscordGuildMemberDeafened,
            OnDiscordGuildMemberUndeafened,
            OnDiscordGuildMemberMuted,
            OnDiscordGuildMemberUnmuted,
            OnDiscordGuildMemberTimeout,
            OnDiscordGuildMemberTimeoutEnded,
            OnDiscordGuildThreadMembersUpdated
        ],
        [GatewayIntents.GuildModeration] =
        [
            OnDiscordGuildMemberBanned,
            OnDiscordGuildMemberUnbanned
        ],
        [GatewayIntents.GuildEmojisAndStickers] =
        [
            OnDiscordGuildEmojisUpdated,
            OnDiscordGuildStickersUpdated
        ],
        [GatewayIntents.GuildIntegrations] =
        [
            OnDiscordGuildIntegrationsUpdated,
            OnDiscordGuildIntegrationCreated,
            OnDiscordGuildIntegrationUpdated,
            OnDiscordGuildIntegrationDeleted
        ],
        [GatewayIntents.GuildWebhooks] =
        [
            OnDiscordGuildWebhookUpdated
        ],
        [GatewayIntents.GuildInvites] =
        [
            OnDiscordGuildInviteCreated,
            OnDiscordGuildIntegrationDeleted
        ],
        [GatewayIntents.GuildVoiceStates] = [OnDiscordGuildVoiceStateUpdated],
        [GatewayIntents.GuildPresences] = [OnDiscordGuildMemberPresenceUpdated],
        [GatewayIntents.GuildMessages] =
        [
            OnDiscordGuildMessageCreated,
            OnDiscordGuildMessageUpdated,
            OnDiscordGuildMessageDeleted,
            OnDiscordGuildMessagesBulkDeleted
        ],
        [GatewayIntents.GuildMessageReactions] =
        [
            OnDiscordGuildMessageReactionAdded,
            OnDiscordGuildMessageReactionRemoved,
            OnDiscordGuildMessageReactionRemovedAll,
            OnDiscordGuildMessageReactionEmojiRemoved
        ],
        [GatewayIntents.GuildMessageTyping] = [OnDiscordGuildTypingStarted],
        [GatewayIntents.DirectMessages] =
        [
            OnDiscordDirectMessageCreated,
            OnDiscordDirectMessageUpdated,
            OnDiscordDirectMessageDeleted,
            OnDiscordDirectMessagesBulkDeleted
        ],
        [GatewayIntents.DirectMessageReactions] =
        [
            OnDiscordDirectMessageReactionAdded,
            OnDiscordDirectMessageReactionRemoved,
            OnDiscordDirectMessageReactionRemovedAll,
            OnDiscordDirectMessageReactionEmojiRemoved
        ],
        [GatewayIntents.DirectMessageTyping] = [OnDiscordDirectTypingStarted],
        [GatewayIntents.GuildScheduledEvents] =
        [
            OnDiscordGuildScheduledEventCreated,
            OnDiscordGuildScheduledEventUpdated,
            OnDiscordGuildScheduledEventDeleted,
            OnDiscordGuildScheduledEventUserAdded,
            OnDiscordGuildScheduledEventUserRemoved
        ],
        [GatewayIntents.AutoModerationConfiguration] =
        [
            OnDiscordAutoModRuleCreated,
            OnDiscordAutoModRuleUpdated,
            OnDiscordAutoModRuleDeleted
        ],
        [GatewayIntents.AutoModerationExecution] = [OnDiscordAutoModActionExecuted],
    };

    /// <summary>
    /// A mapping of Hooks required Gateway Intent
    /// </summary>
    public static readonly Hash<string, GatewayIntents> HookGatewayIntent = new();

    static DiscordExtHooks()
    {
        Type stringType = typeof(string);
        foreach (FieldInfo field in typeof(DiscordExtHooks).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
        {
            if (field.IsLiteral && !field.IsInitOnly && field.FieldType == stringType)
            {
                string hook = (string)field.GetRawConstantValue();
                AllHooks.Add(hook);
                if (!GlobalHooks.Contains(hook))
                {
                    PluginHooks.Add(hook);
                }
            }
        }

        foreach (KeyValuePair<GatewayIntents, List<string>> intentHooks in GatewayIntentHooks)
        {
            foreach (string hook in intentHooks.Value)
            {
                HookGatewayIntent[hook] |= intentHooks.Key;
            }
        }
    }

    /// <summary>
    /// Returns true if the hook is a Discord Extension Global Hook
    /// </summary>
    /// <param name="hook">Name of the hook</param>
    /// <returns></returns>
    public static bool IsGlobalHook(string hook) => GlobalHooks.Contains(hook);

    /// <summary>
    /// Returns true if the hook is a Discord Extension Plugin Hook
    /// </summary>
    /// <param name="hook">Name of the hook</param>
    /// <returns></returns>
    public static bool IsPluginHook(string hook) => PluginHooks.Contains(hook);

    /// <summary>
    /// Returns true if the hook is a Discord Extension Hook
    /// </summary>
    /// <param name="hook">Name of the hook</param>
    /// <returns></returns>
    public static bool IsDiscordHook(string hook) => AllHooks.Contains(hook);

    #region Bot Client Hooks
    /// <summary>
    /// Called when the DiscordClient is created on the bot and is ready to use.
    /// This is called after the Loaded() hook on the plugin.
    /// <code>
    /// void OnDiscordClientCreated()
    /// {
    ///     Puts("OnDiscordClientCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordClientCreated = nameof(OnDiscordClientCreated);

    /// <summary>
    /// Called when the bot has fully loaded all discord guilds
    /// If GatewayIntent.GuildMembers is specified then this hook is delayed until all guild members have been loaded 
    /// <code>
    /// void OnDiscordBotFullyLoaded()
    /// {
    ///     Puts("OnDiscordBotFullyLoaded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordBotFullyLoaded = nameof(OnDiscordBotFullyLoaded);
    #endregion

    #region Socket Hooks
    /// <summary>
    /// Called when the discord socket connects.
    /// <code>
    /// void OnDiscordWebsocketOpened()
    /// {
    ///     Puts("OnDiscordWebsocketOpened Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordWebsocketOpened = nameof(OnDiscordWebsocketOpened);

    /// <summary>
    /// Called when the web socket is closed for any reason. 
    /// <code>
    /// void OnDiscordWebsocketClosed(string reason, ushort code)
    /// {
    ///     Puts("OnDiscordWebsocketClosed Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordWebsocketClosed = nameof(OnDiscordWebsocketClosed);

    /// <summary>
    /// Called when the web socket has an error.
    /// <code>
    /// void OnDiscordWebsocketErrored(Exception ex, string message)
    /// {
    ///     Puts("OnDiscordWebsocketErrored Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordWebsocketErrored = nameof(OnDiscordWebsocketErrored);

    /// <summary>
    /// Called when we receive the heartbeat interval from the websocket
    /// <code>
    /// void OnDiscordSetupHeartbeat(float heartbeat)
    /// {
    ///     Puts("OnDiscordHeartbeatSent Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordSetupHeartbeat = nameof(OnDiscordSetupHeartbeat);

    /// <summary>
    /// Called when a heartbeat is sent over the websocket to discord to keep the connection open
    /// <code>
    /// void OnDiscordHeartbeatSent()
    /// {
    ///     Puts("OnDiscordHeartbeatSent Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordHeartbeatSent = nameof(OnDiscordHeartbeatSent);
    #endregion

    #region Link Hooks
    /// <summary>
    /// These hooks are called when a player is linked or unlinked using discord link.
    /// It will be called for every plugins registered to receive hooks.  
    /// **Note:** If your plugin supports discord link you should not supply any other hooks as the extension provides them for you.  
    /// **Note:** Discord Link hooks are considered global hooks and will be called on all plugins regardless of bot 
    /// <code>
    /// void OnDiscordPlayerLinked(IPlayer player, DiscordUser discord)
    /// {
    ///     Puts("OnDiscordPlayerLinked Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordPlayerLinked = nameof(OnDiscordPlayerLinked);

    /// <summary>
    /// Called when a player is being unlinked from DiscordLink Library
    /// This is called before the unlink occurs
    /// <code>
    /// void OnDiscordPlayerUnlink(IPlayer player, DiscordUser discord)
    /// {
    ///     Puts("OnDiscordPlayerUnlink Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordPlayerUnlink = nameof(OnDiscordPlayerUnlink);

    /// <summary>
    /// Called when a player has unlinked their discord and player together using the DiscordLink library
    /// <code>
    /// void OnDiscordPlayerUnlinked(IPlayer player, DiscordUser discord)
    /// {
    ///     Puts("OnDiscordPlayerUnlinked Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordPlayerUnlinked = nameof(OnDiscordPlayerUnlinked);
    #endregion

    #region Discord Event Hooks
    /// <summary>
    /// - Called when the Discord Bot has successfully connected to the gateway and identified successfully.
    /// **Note:** Only partial guild information is available at this point. 
    /// If you need full guild listen for [OnDiscordGuildCreated](#OnDiscordGuildCreated) hook
    /// If you need full guild member list listen for [OnDiscordGuildMembersLoaded](#OnDiscordGuildMembersLoaded)
    /// <code>
    /// void OnDiscordGatewayReady(GatewayReadyEvent ready)
    /// {
    ///     Puts("OnDiscordGatewayReady Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGatewayReady = nameof(OnDiscordGatewayReady);

    /// <summary>
    /// Called when the websocket has reconnected to the websocket and resumed the previous session
    /// <code>
    /// void OnDiscordGatewayResumed(GatewayResumedEvent resume)
    /// {
    ///     Puts("OnDiscordGatewayResumed Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGatewayResumed = nameof(OnDiscordGatewayResumed);

    /// <summary>
    /// Called when the websocket has reconnected
    /// <code>
    /// void OnDiscordGatewayReconnected()
    /// {
    ///     Puts("OnDiscordGatewayReconnected Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGatewayReconnected = nameof(OnDiscordGatewayReconnected);

    /// <summary>
    /// Called when a direct message (DM) channel has been created.
    /// <code>
    /// void OnDiscordDirectChannelCreated(DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectChannelCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectChannelCreated = nameof(OnDiscordDirectChannelCreated);

    /// <summary>
    /// Called when a channel has been created in a guild.
    /// <code>
    /// void OnDiscordGuildChannelCreated(DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildChannelCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildChannelCreated = nameof(OnDiscordGuildChannelCreated);

    /// <summary>
    /// Called when a direct message (DM) channel has been updated. 
    /// <code>
    /// Note: previous will be null if previous channel not found
    /// void OnDiscordDirectChannelUpdated(DiscordChannel channel, DiscordChannel previous)
    /// {
    ///     Puts("OnDiscordDirectChannelUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectChannelUpdated = nameof(OnDiscordDirectChannelUpdated);

    /// <summary>
    /// Called when a channel has been updated in a guild.
    /// <code>
    /// void OnDiscordGuildChannelUpdated(DiscordChannel channel, DiscordChannel previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildChannelUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildChannelUpdated = nameof(OnDiscordGuildChannelUpdated);

    /// <summary>
    /// Called when a direct message (DM) channel has been deleted.
    /// Not sure if this is possible for DM channels
    /// <code>
    /// Note: Not sure if this will ever happen but we handle it if it does
    /// void OnDiscordDirectChannelDeleted(DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectChannelDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectChannelDeleted = nameof(OnDiscordDirectChannelDeleted);

    /// <summary>
    /// Called when a channel has been deleted in a guild.
    /// <code>
    /// void OnDiscordGuildChannelDeleted(DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildChannelDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildChannelDeleted = nameof(OnDiscordGuildChannelDeleted);

    /// <summary>
    /// Called when a direct message (DM) channel has it's pinned messages updated.
    /// Channel may be null if we haven't seen it before.
    /// <code>
    /// void OnDiscordDirectChannelPinsUpdated(ChannelPinsUpdatedEvent update, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectChannelPinsUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectChannelPinsUpdated = nameof(OnDiscordDirectChannelPinsUpdated);

    /// <summary>
    /// Called when an entitlement has been created 
    /// <code>
    /// void OnDiscordEntitlementCreated(DiscordEntitlement entitlement, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordEntitlementCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordEntitlementCreated = nameof(OnDiscordEntitlementCreated);

    /// <summary>
    /// Called when an entitlement has been update
    /// <code>
    /// void OnDiscordEntitlementUpdated(DiscordEntitlement entitlement, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordEntitlementUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordEntitlementUpdated = nameof(OnDiscordEntitlementUpdated);

    /// <summary>
    /// Called when an entitlement has been deleted
    /// <code>
    /// void OnDiscordEntitlementDeleted(DiscordEntitlement entitlement, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordEntitlementDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordEntitlementDeleted = nameof(OnDiscordEntitlementDeleted);

    /// <summary>
    /// Called when a guild channel has it's pinned messages updated
    /// <code>
    /// void OnDiscordGuildChannelPinsUpdated(ChannelPinsUpdatedEvent update, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildChannelPinsUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildChannelPinsUpdated = nameof(OnDiscordGuildChannelPinsUpdated);

    /// <summary>
    /// Called when a discord server is fully loaded while connecting or the bot has joined a new discord server
    /// <code>
    /// void OnDiscordGuildCreated(GuildDiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildCreated = nameof(OnDiscordGuildCreated);

    /// <summary>
    /// Called when any updates are made to a guild
    /// Note: previous will be null if guild previously not loaded
    /// <code>
    /// void OnDiscordGuildUpdated(DiscordGuild guild, DiscordGuild previous)
    /// {
    ///     Puts("OnDiscordGuildUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildUpdated = nameof(OnDiscordGuildUpdated);

    /// <summary>
    /// Called when a guild become unavailable due to a network outage
    /// <code>
    /// void OnDiscordGuildUnavailable(DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildUnavailable Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildUnavailable = nameof(OnDiscordGuildUnavailable);

    /// <summary>
    /// Called when a bot is removed from a discord server or that discord server was deleted 
    /// <code>
    /// void OnDiscordGuildDeleted(DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildDeleted = nameof(OnDiscordGuildDeleted);

    /// <summary>
    /// Called when a guild member is banned
    /// <code>
    /// void OnDiscordGuildMemberBanned(GuildMemberBannedEvent ban, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberBanned Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberBanned = nameof(OnDiscordGuildMemberBanned);

    /// <summary>
    /// Called when a guild member is unbanned
    /// <code>
    /// void OnDiscordGuildMemberUnbanned(GuildMemberBannedEvent ban, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildBanRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberUnbanned = nameof(OnDiscordGuildMemberUnbanned);

    /// <summary>
    /// Called when the custom emojis for a guild are created/updated/deleted
    /// <code>
    /// void OnDiscordGuildEmojisUpdated(GuildEmojisUpdatedEvent emojis, Hash&lt;Snowflake, DiscordEmoji&gt; previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildEmojisUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildEmojisUpdated = nameof(OnDiscordGuildEmojisUpdated);

    /// <summary>
    /// Called when the guild stickers are updated
    /// <code>
    /// void OnDiscordGuildStickersUpdated(GuildStickersUpdatedEvent stickers, Hash&lt;Snowflake, DiscordSticker&gt; previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildStickersUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildStickersUpdated = nameof(OnDiscordGuildStickersUpdated);

    /// <summary>
    /// Called when a guild integration is updated 
    /// <code>
    /// void OnDiscordGuildIntegrationsUpdated(GuildIntegrationsUpdatedEvent integration, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildIntegrationsUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildIntegrationsUpdated = nameof(OnDiscordGuildIntegrationsUpdated);

    /// <summary>
    /// Called when a guild member has been added to the guild 
    /// <code>
    /// void OnDiscordGuildMemberAdded(GuildMemberAddedEvent member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberAdded = nameof(OnDiscordGuildMemberAdded);

    /// <summary>
    /// Called when a guild member has been removed from the guild
    /// <code>
    /// void OnDiscordGuildMemberRemoved(GuildMemberRemovedEvent member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberRemoved = nameof(OnDiscordGuildMemberRemoved);

    /// <summary>
    /// Called when a guild member has been updated
    /// This also include when the DiscordUser is updated as well
    /// <code>
    /// void OnDiscordGuildMemberUpdated(GuildMemberUpdatedEvent member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberUpdated = nameof(OnDiscordGuildMemberUpdated);

    /// <summary>
    /// Called when a guild member nickname has been updated
    /// <code>
    /// void OnDiscordGuildMemberNicknameUpdated(GuildMember member, string oldNickname, string newNickname, DateTime? lastNicknameUpdate, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberNicknameUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberNicknameUpdated = nameof(OnDiscordGuildMemberNicknameUpdated);

    /// <summary>
    /// Called when a guild member avatar has been updated
    /// <code>
    /// void OnDiscordGuildMemberAvatarUpdated(GuildMember member, string oldAvatar, string newAvatar, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberAvatarUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberAvatarUpdated = nameof(OnDiscordGuildMemberAvatarUpdated);

    /// <summary>
    /// Called when a guild member is deafened
    /// <code>
    /// void OnDiscordGuildMemberDeafened(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberDeafened Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberDeafened = nameof(OnDiscordGuildMemberDeafened);

    /// <summary>
    /// Called when a guild member is undeafened 
    /// <code>
    /// void OnDiscordGuildMemberUndeafened(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberUndeafened Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberUndeafened = nameof(OnDiscordGuildMemberUndeafened);

    /// <summary>
    /// Called when a guild member is muted
    /// <code>
    /// void OnDiscordGuildMemberMuted(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberMuted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberMuted = nameof(OnDiscordGuildMemberMuted);

    /// <summary>
    /// Called when a guild member is unmuted
    /// <code>
    /// void OnDiscordGuildMemberUnmuted(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberUnmuted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberUnmuted = nameof(OnDiscordGuildMemberUnmuted);

    /// <summary>
    /// Called when a guild member is placed in [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ)
    /// <code>
    /// void OnDiscordGuildMemberTimeout(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberTimeout Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberTimeout = nameof(OnDiscordGuildMemberTimeout);

    /// <summary>
    /// Called when a guild members [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ) ends
    /// <code>
    /// void OnDiscordGuildMemberTimeoutEnded(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberTimeoutEnded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberTimeoutEnded = nameof(OnDiscordGuildMemberTimeoutEnded);

    /// <summary>
    /// Called when a guild member boosts the server 
    /// <code>
    /// void OnDiscordGuildMemberBoosted(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberBoosted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberBoosted = nameof(OnDiscordGuildMemberBoosted);

    /// <summary>
    /// Called when a guild member extends their boost
    /// <code>
    /// void OnDiscordGuildMemberBoostExtended(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberBoostExtended Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberBoostExtended = nameof(OnDiscordGuildMemberBoostExtended);

    /// <summary>
    /// Called when a guild member boost ends
    /// <code>
    /// void OnDiscordGuildMemberBoostEnded(GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberBoostEnded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberBoostEnded = nameof(OnDiscordGuildMemberBoostEnded);

    /// <summary>
    /// Called when a role is added to a guild member 
    /// <code>
    /// void OnDiscordGuildMemberRoleAdded(GuildMember member, Snowflake roleId, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberRoleAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberRoleAdded = nameof(OnDiscordGuildMemberRoleAdded);

    /// <summary>
    /// Called when a role is removed from a guild member
    /// <code>
    /// void OnDiscordGuildMemberRoleRemoved(GuildMember member, Snowflake roleId, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberRoleRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberRoleRemoved = nameof(OnDiscordGuildMemberRoleRemoved);

    /// <summary>
    /// Called when a guild has finished loading all guild members
    /// This Discord Extension requests all guild members in the [OnDiscordGuildCreated](#ondiscordguildcreated) Hook
    /// <code>
    /// void OnDiscordGuildMembersLoaded(DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMembersLoaded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMembersLoaded = nameof(OnDiscordGuildMembersLoaded);

    /// <summary>
    /// Called in a response to a request for guild member chunks 
    /// <code>
    /// void OnDiscordGuildMembersChunk(GuildMembersChunkEvent chunk, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMembersChunk Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMembersChunk = nameof(OnDiscordGuildMembersChunk);

    /// <summary>
    /// Called when a discord guild role is created
    /// <code>
    /// void OnDiscordGuildRoleCreated(DiscordRole role, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildRoleCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildRoleCreated = nameof(OnDiscordGuildRoleCreated);

    /// <summary>
    /// Called when a discord guild role is updated
    /// <code>
    /// void OnDiscordGuildRoleUpdated(DiscordRole role, DiscordRole previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildRoleUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildRoleUpdated = nameof(OnDiscordGuildRoleUpdated);

    /// <summary>
    /// Called when a discord guild role is deleted 
    /// <code>
    /// void OnDiscordGuildRoleDeleted(DiscordRole role, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildRoleDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildRoleDeleted = nameof(OnDiscordGuildRoleDeleted);

    /// <summary>
    /// Called when a discord guild scheduled event is created
    /// <code>
    /// void OnDiscordGuildScheduledEventCreated(GuildScheduledEvent guildEvent, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildScheduledEventCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildScheduledEventCreated = nameof(OnDiscordGuildScheduledEventCreated);

    /// <summary>
    /// Called when a discord guild scheduled event is updated 
    /// <code>
    /// void OnDiscordGuildScheduledEventUpdated(GuildScheduledEvent guildEvent, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildScheduledEventUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildScheduledEventUpdated = nameof(OnDiscordGuildScheduledEventUpdated);

    /// <summary>
    /// Called when a discord guild scheduled event is deleted
    /// <code>
    /// void OnDiscordGuildScheduledEventDeleted(GuildScheduledEvent guildEvent, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildScheduledEventDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildScheduledEventDeleted = nameof(OnDiscordGuildScheduledEventDeleted);

    /// <summary>
    ///  Called when a discord user is added to a guild scheduled event
    /// <code>
    /// void OnDiscordGuildScheduledEventUserAdded(GuildScheduleEventUserAddedEvent added, GuildScheduledEvent, scheduledEvent, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildScheduledEventUserAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildScheduledEventUserAdded = nameof(OnDiscordGuildScheduledEventUserAdded);

    /// <summary>
    /// Called when a discord user is removed from a guild scheduled event
    /// <code>
    /// void OnDiscordGuildScheduledEventUserRemoved(GuildScheduleEventUserRemovedEvent removed, GuildScheduledEvent, scheduledEvent, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildScheduledEventUserRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildScheduledEventUserRemoved = nameof(OnDiscordGuildScheduledEventUserRemoved);

    /// <summary>
    /// Called when a message is created in a direct message channel
    /// `channel` may be null if we haven't seen it yet 
    /// <code>
    /// void OnDiscordDirectMessageCreated(DiscordMessage message, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageCreated = nameof(OnDiscordDirectMessageCreated);

    /// <summary>
    /// Called when a message is created in a guild channel
    /// <code>
    /// void OnDiscordGuildMessageCreated(DiscordMessage message, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageCreated = nameof(OnDiscordGuildMessageCreated);

    /// <summary>
    /// Called when a message is updated in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessageUpdated(DiscordMessage message, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageUpdated = nameof(OnDiscordDirectMessageUpdated);

    /// <summary>
    /// Called when a message is updated in a guild channel
    /// <code>
    /// void OnDiscordDirectMessageUpdated(DiscordMessage message, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageUpdated = nameof(OnDiscordGuildMessageUpdated);

    /// <summary>
    /// Called when a message is deleted in a direct message channel
    /// `channel` may be null if we haven't seen it yet 
    /// <code>
    /// void OnDiscordDirectMessageDeleted(DiscordMessage message, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageDeleted = nameof(OnDiscordDirectMessageDeleted);

    /// <summary>
    /// Called when a message is deleted in a guild channel
    /// <code>
    /// void OnDiscordGuildMessageDeleted(DiscordMessage message, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageDeleted = nameof(OnDiscordGuildMessageDeleted);

    /// <summary>
    /// Called when a message is deleted in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessagesBulkDeleted(List&lt;Snowflake&gt; messageIds, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessagesBulkDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessagesBulkDeleted = nameof(OnDiscordDirectMessagesBulkDeleted);

    /// <summary>
    /// Called when a message is deleted in a guild channel 
    /// <code>
    /// void OnDiscordGuildMessagesBulkDeleted(List&lt;Snowflake&gt; messageIds, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessagesBulkDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessagesBulkDeleted = nameof(OnDiscordDirectMessagesBulkDeleted);

    /// <summary>
    /// Called when a reaction is added to a message in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessageReactionAdded(MessageReactionAddedEvent reaction, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageReactionAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageReactionAdded = nameof(OnDiscordDirectMessageReactionAdded);

    /// <summary>
    /// Called when a reaction is added to a message in a guild channel 
    /// <code>
    /// void OnDiscordGuildMessageReactionAdded(MessageReactionAddedEvent reaction, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageReactionAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageReactionAdded = nameof(OnDiscordGuildMessageReactionAdded);

    /// <summary>
    /// Called when a reaction is removed from a message in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessageReactionRemoved(MessageReactionRemovedEvent reaction, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageReactionRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageReactionRemoved = nameof(OnDiscordDirectMessageReactionRemoved);

    /// <summary>
    /// Called when a reaction is removed from a message in a guild channel
    /// <code>
    /// void OnDiscordGuildMessageReactionRemoved(MessageReactionRemovedEvent reaction, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageReactionRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageReactionRemoved = nameof(OnDiscordGuildMessageReactionRemoved);

    /// <summary>
    /// Called when all reactions are removed from a message in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessageReactionRemovedAll(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageReactionRemovedAll Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageReactionRemovedAll = nameof(OnDiscordDirectMessageReactionRemoved);

    /// <summary>
    /// Called when all reactions are removed from a message in a guild channel
    /// <code>
    /// void OnDiscordGuildMessageReactionRemovedAll(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageReactionRemovedAll Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageReactionRemovedAll = nameof(OnDiscordGuildMessageReactionRemoved);

    /// <summary>
    /// Called when all of a specific reactions is removed from a message in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectMessageReactionEmojiRemoved(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectMessageReactionEmojiRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectMessageReactionEmojiRemoved = nameof(OnDiscordDirectMessageReactionEmojiRemoved);

    /// <summary>
    /// Called when all of a specific reaction is removed from a message in a guild channel
    /// <code>
    /// void OnDiscordGuildMessageReactionEmojiRemoved(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMessageReactionEmojiRemoved Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMessageReactionEmojiRemoved = nameof(OnDiscordGuildMessageReactionEmojiRemoved);

    /// <summary>
    /// Called when a guild members presence is updated
    /// <code>
    /// void OnDiscordGuildMemberPresenceUpdated(PresenceUpdatedEvent update, GuildMember member, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildMemberPresenceUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildMemberPresenceUpdated = nameof(OnDiscordGuildMemberPresenceUpdated);

    /// <summary>
    /// Called typing starts in a direct message channel
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectTypingStarted(TypingStartedEvent typing, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectTypingStarted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectTypingStarted = nameof(OnDiscordDirectTypingStarted);

    /// <summary>
    /// Called when typing starts in a guild channel 
    /// <code>
    /// void OnDiscordGuildTypingStarted(TypingStartedEvent typing, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildTypingStarted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildTypingStarted = nameof(OnDiscordGuildTypingStarted);

    /// <summary>
    /// Called when a discord user is updated
    /// <code>
    /// void OnDiscordUserUpdated(DiscordUser user)
    /// {
    ///     Puts("OnDiscordUserUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordUserUpdated = nameof(OnDiscordUserUpdated);

    /// <summary>
    /// Called when the voice state in a direct message channel is updated
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectVoiceStateUpdated(VoiceState voice, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectVoiceStateUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectVoiceStateUpdated = nameof(OnDiscordDirectVoiceStateUpdated);

    /// <summary>
    /// Called when the voice state in a guild channel is updated
    /// <code>
    /// void OnDiscordGuildVoiceStateUpdated(VoiceState voice, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildVoiceStateUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildVoiceStateUpdated = nameof(OnDiscordGuildVoiceStateUpdated);
    
    /// <summary>
    /// Sent when someone sends an effect, such as an emoji reaction or a soundboard sound, in a voice channel the current user is connected to.
    /// <code>
    /// void OnDiscordVoiceChannelEffect(VoiceChannelEffectEvent effect, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordVoiceChannelEffect Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordVoiceChannelEffect = nameof(OnDiscordVoiceChannelEffect);

    /// <summary>
    /// Called when the voice server in a guild channel is updated
    /// <code>
    /// void OnDiscordGuildVoiceServerUpdated(VoiceServerUpdatedEvent voice, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildVoiceServerUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildVoiceServerUpdated = nameof(OnDiscordGuildVoiceServerUpdated);

    /// <summary>
    /// Called when a webhook ins a guild is updated
    /// <code>
    /// void OnDiscordGuildWebhookUpdated(WebhooksUpdatedEvent webhook, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildWebhookUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildWebhookUpdated = nameof(OnDiscordGuildWebhookUpdated);

    /// <summary>
    /// Called when an invite to a direct message channel is created
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectInviteCreated(InviteCreatedEvent invite, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectInviteCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectInviteCreated = nameof(OnDiscordDirectInviteCreated);

    /// <summary>
    /// Called when an invite to a guild channel is created 
    /// <code>
    /// void OnDiscordGuildInviteCreated(InviteCreatedEvent invite, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildInviteCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildInviteCreated = nameof(OnDiscordGuildInviteCreated);

    /// <summary>
    /// Called when an invite to a direct message channel is deleted
    /// `channel` may be null if we haven't seen it yet
    /// <code>
    /// void OnDiscordDirectInviteDeleted(InviteCreatedEvent invite, DiscordChannel channel)
    /// {
    ///     Puts("OnDiscordDirectInviteDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordDirectInviteDeleted = nameof(OnDiscordDirectInviteDeleted);

    /// <summary>
    /// Called when an invite to a guild channel is deleted
    /// <code>
    /// void OnDiscordGuildInviteDeleted(InviteCreatedEvent invite, DiscordChannel channel, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildInviteDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildInviteDeleted = nameof(OnDiscordGuildInviteDeleted);

    /// <summary>
    /// Called when the bots application command permission have been updated
    /// <code>
    /// void OnDiscordApplicationCommandPermissionsUpdated(CommandPermissions permissions)
    /// {
    ///     Puts("OnDiscordInteractionCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordApplicationCommandPermissionsUpdated = nameof(OnDiscordApplicationCommandPermissionsUpdated);

    /// <summary>
    /// Called when a discord interaction occurs by a user
    /// <code>
    /// void OnDiscordInteractionCreated(DiscordInteraction interaction)
    /// {
    ///     Puts("OnDiscordInteractionCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordInteractionCreated = nameof(OnDiscordInteractionCreated);

    /// <summary>
    /// Called when a new integration is created a guild
    /// <code>
    /// void OnDiscordGuildIntegrationCreated(IntegrationCreatedEvent integration, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildIntegrationCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildIntegrationCreated = nameof(OnDiscordGuildIntegrationCreated);

    /// <summary>
    /// Called when an integration is updated on a guild
    /// <code>
    /// void OnDiscordGuildIntegrationUpdated(IntegrationUpdatedEvent interaction, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildIntegrationUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildIntegrationUpdated = nameof(OnDiscordGuildIntegrationUpdated);

    /// <summary>
    /// Called when an integration is deleted on a guild
    /// <code>
    /// void OnDiscordGuildIntegrationDeleted(IntegrationDeletedEvent interaction, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildIntegrationDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildIntegrationDeleted = nameof(OnDiscordGuildIntegrationDeleted);

    /// <summary>
    /// Called when a guild thread is created
    /// <code>
    /// void OnDiscordGuildThreadCreated(DiscordChannel thread, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadCreated = nameof(OnDiscordGuildThreadCreated);

    /// <summary>
    /// Called when a guild thread is updated
    /// <code>
    /// void OnDiscordGuildThreadUpdated(DiscordChannel thread, DiscordChannel previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadUpdated = nameof(OnDiscordGuildThreadUpdated);

    /// <summary>
    /// Called when a guild thread is deleted
    /// <code>
    /// void OnDiscordGuildThreadDeleted(DiscordChannel thread, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadDeleted = nameof(OnDiscordGuildThreadDeleted);

    /// <summary>
    /// Called when a guild thread list is synced 
    /// <code>
    /// void OnDiscordGuildThreadListSynced(ThreadListSyncEvent sync, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadListSynced Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadListSynced = nameof(OnDiscordGuildThreadListSynced);

    /// <summary>
    /// Called when a thread member is updated
    /// <code>
    /// void OnDiscordGuildThreadMemberUpdated(ThreadMember member, DiscordChannel thread, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadMemberUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadMemberUpdated = nameof(OnDiscordGuildThreadMemberUpdated);

    /// <summary>
    /// Called when thread members are updated 
    /// <code>
    /// void OnDiscordGuildThreadMembersUpdated(ThreadMembersUpdatedEvent members, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordGuildThreadMembersUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordGuildThreadMembersUpdated = nameof(OnDiscordGuildThreadMembersUpdated);

    /// <summary>
    /// Called when a stage instance is created
    /// <code>
    /// void OnDiscordStageInstanceCreated(StageInstance stage, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordStageInstanceCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordStageInstanceCreated = nameof(OnDiscordStageInstanceCreated);

    /// <summary>
    /// Called when a stage instance is updated
    /// <code>
    /// void OnDiscordStageInstanceUpdated(StageInstance stage, StageInstance previous, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordStageInstanceUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordStageInstanceUpdated = nameof(OnDiscordStageInstanceUpdated);

    /// <summary>
    /// Called when a stage instance is deleted
    /// <code>
    /// void OnDiscordStageInstanceDeleted(StageInstance stage, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordStageInstanceDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordStageInstanceDeleted = nameof(OnDiscordStageInstanceDeleted);

    /// <summary>
    /// Called when an AutoMod rule is created in a guild
    /// <code>
    /// void OnDiscordAutoModRuleCreated(AutoModRule rule, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordAutoModRuleCreated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordAutoModRuleCreated = nameof(OnDiscordAutoModRuleCreated);

    /// <summary>
    /// Called when an AutoMod rule is updated on a guild
    /// <code>
    /// void OnDiscordAutoModRuleUpdated(AutoModRule rule, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordAutoModRuleUpdated Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordAutoModRuleUpdated = nameof(OnDiscordAutoModRuleUpdated);

    /// <summary>
    /// Called when an AutoMod rule is deleted from a guild
    /// <code>
    /// void OnDiscordAutoModRuleDeleted(AutoModRule rule, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordAutoModRuleDeleted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordAutoModRuleDeleted = nameof(OnDiscordAutoModRuleDeleted);

    /// <summary>
    /// Called when an AutoMod rule is executed on a guild
    /// <code>
    /// void OnDiscordAutoModActionExecuted(AutoModActionExecutionEvent rule, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordAutoModActionExecuted Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordAutoModActionExecuted = nameof(OnDiscordAutoModActionExecuted);

    /// <summary>
    /// Called when we receive an event we do not handle yet.
    /// If you need this event, you can listen to it using this hook until we support it
    /// Please create an issue on uMod if this error ever occurs 
    /// <code>
    /// void OnDiscordPollVoteAdded(MessagePollVoteAddedEvent vote, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordPollVoteAdded Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordPollVoteAdded = nameof(OnDiscordPollVoteAdded);
        
    /// <code>
    /// void OnDiscordAutoModActionExecuted(MessagePollVoteRemovedEvent vote, DiscordGuild guild)
    /// {
    ///     Puts("OnDiscordPollVoteRemoved Works!");
    /// }
    /// </code>
    public const string OnDiscordPollVoteRemoved = nameof(OnDiscordPollVoteRemoved);
        
    /// <summary>
    /// <code>
    /// void OnDiscordUnhandledCommand(EventPayload payload)
    /// {
    ///     Puts("OnDiscordUnhandledCommand Works!");
    /// }
    /// </code>
    /// </summary>
    public const string OnDiscordUnhandledCommand = nameof(OnDiscordUnhandledCommand);
    #endregion
}