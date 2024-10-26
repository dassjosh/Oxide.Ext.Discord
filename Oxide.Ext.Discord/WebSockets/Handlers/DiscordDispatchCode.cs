using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#commands-and-events-gateway-events">Gateway Event Codes</a>
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum DiscordDispatchCode : byte
    {
        /// <summary>
        /// Used when we don't have a matching Dispatch Code
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#ready">READY</a> gateway event
        /// </summary>
        [DiscordEnum("READY")] Ready,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#resumed">RESUMED</a> gateway event
        /// </summary>
        [DiscordEnum("RESUMED")] Resumed,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#channel-create">CHANNEL_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("CHANNEL_CREATE")] ChannelCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#channel-update">CHANNEL_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("CHANNEL_UPDATE")] ChannelUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#channel-delete">CHANNEL_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("CHANNEL_DELETE")] ChannelDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#channel-pins-update">CHANNEL_PINS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("CHANNEL_PINS_UPDATE")] ChannelPinsUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#entitlement-create">ENTITLEMENT_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("ENTITLEMENT_CREATE")] EntitlementCreate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#entitlement-update">ENTITLEMENT_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("ENTITLEMENT_UPDATE")] EntitlementUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#entitlement-delete">ENTITLEMENT_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("ENTITLEMENT_DELETE")] EntitlementDelete,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-create">GUILD_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_CREATE")] GuildCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-update">GUILD_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_UPDATE")] GuildUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-delete">GUILD_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_DELETE")] GuildDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-ban-add">GUILD_BAN_ADD</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_BAN_ADD")] GuildBanAdded,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-ban-remove">GUILD_BAN_REMOVE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_BAN_REMOVE")] GuildBanRemoved,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-emojis-update">GUILD_EMOJIS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_EMOJIS_UPDATE")] GuildEmojisUpdated,        
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-stickers-update">GUILD_STICKERS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_STICKERS_UPDATE")] GuildStickersUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-integrations-update">GUILD_INTEGRATIONS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_INTEGRATIONS_UPDATE")] GuildIntegrationsUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-member-add">GUILD_MEMBER_ADD</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_MEMBER_ADD")] GuildMemberAdded,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-member-remove">GUILD_MEMBER_REMOVE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_MEMBER_REMOVE")] GuildMemberRemoved,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-member-update">GUILD_MEMBER_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_MEMBER_UPDATE")] GuildMemberUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-members-chunk">GUILD_MEMBERS_CHUNK</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_MEMBERS_CHUNK")] GuildMembersChunk,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-role-create">GUILD_ROLE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_ROLE_CREATE")] GuildRoleCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-role-update">GUILD_ROLE_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_ROLE_UPDATE")] GuildRoleUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-role-delete">GUILD_ROLE_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_ROLE_DELETE")] GuildRoleDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-create">GUILD_SCHEDULED_EVENT_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_SCHEDULED_EVENT_CREATE")] GuildScheduledEventCreate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-update">GUILD_SCHEDULED_EVENT_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_SCHEDULED_EVENT_UPDATE")] GuildScheduledEventUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-delete">GUILD_SCHEDULED_EVENT_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_SCHEDULED_EVENT_DELETE")] GuildScheduledEventDelete,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-add">GUILD_SCHEDULED_EVENT_USER_ADD</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_SCHEDULED_EVENT_USER_ADD")] GuildScheduledEventUserAdd,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-remove">GUILD_SCHEDULED_EVENT_USER_REMOVE</a> gateway event
        /// </summary>
        [DiscordEnum("GUILD_SCHEDULED_EVENT_USER_REMOVE")] GuildScheduledEventUserRemove,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#integration-create">INTEGRATION_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("INTEGRATION_CREATE")] IntegrationCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#integration-update">INTEGRATION_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("INTEGRATION_UPDATE")] IntegrationUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#integration-delete">INTEGRATION_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("INTEGRATION_DELETE")] IntegrationDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-create">MESSAGE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_CREATE")] MessageCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-update">MESSAGE_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_UPDATE")] MessageUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-delete">MESSAGE_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_DELETE")] MessageDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-delete-bulk">MESSAGE_DELETE_BULK</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_DELETE_BULK")] MessageBulkDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-add">MESSAGE_REACTION_ADD</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_REACTION_ADD")] MessageReactionAdded,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-remove">MESSAGE_REACTION_REMOVE</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_REACTION_REMOVE")] MessageReactionRemoved,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-remove-all">MESSAGE_REACTION_REMOVE_ALL</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_REACTION_REMOVE_ALL")] MessageReactionAllRemoved,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-remove-emoji">MESSAGE_REACTION_REMOVE_EMOJI</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_REACTION_REMOVE_EMOJI")] MessageReactionEmojiRemoved,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#presence-update">PRESENCE_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("PRESENCE_UPDATE")] PresenceUpdated,
        
        /// <summary>
        /// Represents the <a href="">PRESENCES_REPLACE</a> gateway event
        /// </summary>
        [DiscordEnum("PRESENCES_REPLACE")] PresenceReplace,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#typing-start">TYPING_START</a> gateway event
        /// </summary>
        [DiscordEnum("TYPING_START")] TypingStarted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#user-update">USER_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("USER_UPDATE")] UserUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#voice-state-update">VOICE_STATE_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("VOICE_STATE_UPDATE")] VoiceStateUpdated,       
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#voice-channel-effect-send">VOICE_CHANNEL_EFFECT_SEND</a> gateway event
        /// </summary>
        [DiscordEnum("VOICE_CHANNEL_EFFECT_SEND")] VoiceChannelEffectSend,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#voice-server-update">VOICE_SERVER_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("VOICE_SERVER_UPDATE")] VoiceServerUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#webhooks-update">WEBHOOKS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("WEBHOOKS_UPDATE")] WebhooksUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#invite-create">INVITE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("INVITE_CREATE")] InviteCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#invite-delete">INVITE_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("INVITE_DELETE")] InviteDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#application-command-permissions-update">APPLICATION_COMMANDS_PERMISSIONS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("APPLICATION_COMMANDS_PERMISSIONS_UPDATE")] ApplicationCommandsPermissionsUpdate,       
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#interaction-create">INTERACTION_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("INTERACTION_CREATE")] InteractionCreated,

        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-create">THREAD_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_CREATE")] ThreadCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-update">THREAD_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_UPDATE")] ThreadUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-delete">THREAD_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_DELETE")] ThreadDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-list-sync">THREAD_LIST_SYNC</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_LIST_SYNC")] ThreadListSync,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-member-update">THREAD_MEMBER_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_MEMBER_UPDATE")] ThreadMemberUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#thread-members-update">THREAD_MEMBERS_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("THREAD_MEMBERS_UPDATE")] ThreadMembersUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#stage-instance-create">STAGE_INSTANCE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("STAGE_INSTANCE_CREATE")] StageInstanceCreated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#stage-instance-update">STAGE_INSTANCE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("STAGE_INSTANCE_UPDATE")] StageInstanceUpdated,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#stage-instance-delete">STAGE_INSTANCE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("STAGE_INSTANCE_DELETE")] StageInstanceDeleted,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#subscription-create">SUBSCRIPTION_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("SUBSCRIPTION_CREATE")] SubscriptionCreate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#subscription-update">SUBSCRIPTION_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("SUBSCRIPTION_UPDATE")] SubscriptionUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#subscription-delete">SUBSCRIPTION_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("SUBSCRIPTION_DELETE")] SubscriptionDelete,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-create">AUTO_MODERATION_RULE_CREATE</a> gateway event
        /// </summary>
        [DiscordEnum("AUTO_MODERATION_RULE_CREATE")] AutoModerationRuleCreate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-update">AUTO_MODERATION_RULE_UPDATE</a> gateway event
        /// </summary>
        [DiscordEnum("AUTO_MODERATION_RULE_UPDATE")] AutoModerationRuleUpdate,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-delete">AUTO_MODERATION_RULE_DELETE</a> gateway event
        /// </summary>
        [DiscordEnum("AUTO_MODERATION_RULE_DELETE")] AutoModerationRuleDelete,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway#auto-moderation-action-execution">AUTO_MODERATION_ACTION_EXECUTION</a> gateway event
        /// </summary>
        [DiscordEnum("AUTO_MODERATION_ACTION_EXECUTION")] AutoModerationActionExecution,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-add">MESSAGE_POLL_VOTE_ADD</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_POLL_VOTE_ADD")] MessagePollVoteAdded,
        
        /// <summary>
        /// Represents the <a href="https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-remove">MESSAGE_POLL_VOTE_REMOVE</a> gateway event
        /// </summary>
        [DiscordEnum("MESSAGE_POLL_VOTE_REMOVE")] MessagePollVoteRemoved,
    }
}