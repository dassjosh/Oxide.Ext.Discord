# DiscordDispatchCode enumeration

Represents the [Gateway Event Codes](https://discord.com/developers/docs/topics/gateway#commands-and-events-gateway-events)

```csharp
public enum DiscordDispatchCode : byte
```

## Values

| name | value | description |
| --- | --- | --- |
| Unknown | `Unknown` | Used when we don't have a matching Dispatch Code |
| Ready | `Ready` | Represents the [READY](https://discord.com/developers/docs/topics/gateway#ready) gateway event |
| Resumed | `Resumed` | Represents the [RESUMED](https://discord.com/developers/docs/topics/gateway#resumed) gateway event |
| ChannelCreated | `ChannelCreated` | Represents the [CHANNEL_CREATE](https://discord.com/developers/docs/topics/gateway#channel-create) gateway event |
| ChannelUpdated | `ChannelUpdated` | Represents the [CHANNEL_UPDATE](https://discord.com/developers/docs/topics/gateway#channel-update) gateway event |
| ChannelDeleted | `ChannelDeleted` | Represents the [CHANNEL_DELETE](https://discord.com/developers/docs/topics/gateway#channel-delete) gateway event |
| ChannelPinsUpdate | `ChannelPinsUpdate` | Represents the [CHANNEL_PINS_UPDATE](https://discord.com/developers/docs/topics/gateway#channel-pins-update) gateway event |
| EntitlementCreate | `EntitlementCreate` | Represents the [ENTITLEMENT_CREATE](https://discord.com/developers/docs/topics/gateway-events#entitlement-create) gateway event |
| EntitlementUpdate | `EntitlementUpdate` | Represents the [ENTITLEMENT_UPDATE](https://discord.com/developers/docs/topics/gateway-events#entitlement-update) gateway event |
| EntitlementDelete | `EntitlementDelete` | Represents the [ENTITLEMENT_DELETE](https://discord.com/developers/docs/topics/gateway-events#entitlement-delete) gateway event |
| GuildCreated | `GuildCreated` | Represents the [GUILD_CREATE](https://discord.com/developers/docs/topics/gateway#guild-create) gateway event |
| GuildUpdated | `GuildUpdated` | Represents the [GUILD_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-update) gateway event |
| GuildDeleted | `GuildDeleted` | Represents the [GUILD_DELETE](https://discord.com/developers/docs/topics/gateway#guild-delete) gateway event |
| GuildBanAdded | `GuildBanAdded` | Represents the [GUILD_BAN_ADD](https://discord.com/developers/docs/topics/gateway#guild-ban-add) gateway event |
| GuildBanRemoved | `GuildBanRemoved` | Represents the [GUILD_BAN_REMOVE](https://discord.com/developers/docs/topics/gateway#guild-ban-remove) gateway event |
| GuildEmojisUpdated | `GuildEmojisUpdated` | Represents the [GUILD_EMOJIS_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-emojis-update) gateway event |
| GuildStickersUpdate | `GuildStickersUpdate` | Represents the [GUILD_STICKERS_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-stickers-update) gateway event |
| GuildIntegrationsUpdated | `GuildIntegrationsUpdated` | Represents the [GUILD_INTEGRATIONS_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-integrations-update) gateway event |
| GuildMemberAdded | `GuildMemberAdded` | Represents the [GUILD_MEMBER_ADD](https://discord.com/developers/docs/topics/gateway#guild-member-add) gateway event |
| GuildMemberRemoved | `GuildMemberRemoved` | Represents the [GUILD_MEMBER_REMOVE](https://discord.com/developers/docs/topics/gateway#guild-member-remove) gateway event |
| GuildMemberUpdated | `GuildMemberUpdated` | Represents the [GUILD_MEMBER_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-member-update) gateway event |
| GuildMembersChunk | `GuildMembersChunk` | Represents the [GUILD_MEMBERS_CHUNK](https://discord.com/developers/docs/topics/gateway#guild-members-chunk) gateway event |
| GuildRoleCreated | `GuildRoleCreated` | Represents the [GUILD_ROLE_CREATE](https://discord.com/developers/docs/topics/gateway#guild-role-create) gateway event |
| GuildRoleUpdated | `GuildRoleUpdated` | Represents the [GUILD_ROLE_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-role-update) gateway event |
| GuildRoleDeleted | `GuildRoleDeleted` | Represents the [GUILD_ROLE_DELETE](https://discord.com/developers/docs/topics/gateway#guild-role-delete) gateway event |
| GuildScheduledEventCreate | `GuildScheduledEventCreate` | Represents the [GUILD_SCHEDULED_EVENT_CREATE](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-create) gateway event |
| GuildScheduledEventUpdate | `GuildScheduledEventUpdate` | Represents the [GUILD_SCHEDULED_EVENT_UPDATE](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-update) gateway event |
| GuildScheduledEventDelete | `GuildScheduledEventDelete` | Represents the [GUILD_SCHEDULED_EVENT_DELETE](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-delete) gateway event |
| GuildScheduledEventUserAdd | `GuildScheduledEventUserAdd` | Represents the [GUILD_SCHEDULED_EVENT_USER_ADD](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-add) gateway event |
| GuildScheduledEventUserRemove | `GuildScheduledEventUserRemove` | Represents the [GUILD_SCHEDULED_EVENT_USER_REMOVE](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-remove) gateway event |
| IntegrationCreated | `IntegrationCreated` | Represents the [INTEGRATION_CREATE](https://discord.com/developers/docs/topics/gateway#integration-create) gateway event |
| IntegrationUpdated | `IntegrationUpdated` | Represents the [INTEGRATION_UPDATE](https://discord.com/developers/docs/topics/gateway#integration-update) gateway event |
| IntegrationDeleted | `IntegrationDeleted` | Represents the [INTEGRATION_DELETE](https://discord.com/developers/docs/topics/gateway#integration-delete) gateway event |
| MessageCreated | `MessageCreated` | Represents the [MESSAGE_CREATE](https://discord.com/developers/docs/topics/gateway#message-create) gateway event |
| MessageUpdated | `MessageUpdated` | Represents the [MESSAGE_UPDATE](https://discord.com/developers/docs/topics/gateway#message-update) gateway event |
| MessageDeleted | `MessageDeleted` | Represents the [MESSAGE_DELETE](https://discord.com/developers/docs/topics/gateway#message-delete) gateway event |
| MessageBulkDeleted | `MessageBulkDeleted` | Represents the [MESSAGE_DELETE_BULK](https://discord.com/developers/docs/topics/gateway#message-delete-bulk) gateway event |
| MessageReactionAdded | `MessageReactionAdded` | Represents the [MESSAGE_REACTION_ADD](https://discord.com/developers/docs/topics/gateway#message-reaction-add) gateway event |
| MessageReactionRemoved | `MessageReactionRemoved` | Represents the [MESSAGE_REACTION_REMOVE](https://discord.com/developers/docs/topics/gateway#message-reaction-remove) gateway event |
| MessageReactionAllRemoved | `MessageReactionAllRemoved` | Represents the [MESSAGE_REACTION_REMOVE_ALL](https://discord.com/developers/docs/topics/gateway#message-reaction-remove-all) gateway event |
| MessageReactionEmojiRemoved | `MessageReactionEmojiRemoved` | Represents the [MESSAGE_REACTION_REMOVE_EMOJI](https://discord.com/developers/docs/topics/gateway#message-reaction-remove-emoji) gateway event |
| PresenceUpdated | `PresenceUpdated` | Represents the [PRESENCE_UPDATE](https://discord.com/developers/docs/topics/gateway#presence-update) gateway event |
| PresenceReplace | `PresenceReplace` | Represents the [PRESENCES_REPLACE]() gateway event |
| TypingStarted | `TypingStarted` | Represents the [TYPING_START](https://discord.com/developers/docs/topics/gateway#typing-start) gateway event |
| UserUpdated | `UserUpdated` | Represents the [USER_UPDATE](https://discord.com/developers/docs/topics/gateway#user-update) gateway event |
| VoiceStateUpdated | `VoiceStateUpdated` | Represents the [VOICE_STATE_UPDATE](https://discord.com/developers/docs/topics/gateway#voice-state-update) gateway event |
| VoiceChannelEffectSend | `VoiceChannelEffectSend` | Represents the [VOICE_CHANNEL_EFFECT_SEND](https://discord.com/developers/docs/topics/gateway-events#voice-channel-effect-send) gateway event |
| VoiceServerUpdated | `VoiceServerUpdated` | Represents the [VOICE_SERVER_UPDATE](https://discord.com/developers/docs/topics/gateway#voice-server-update) gateway event |
| WebhooksUpdated | `WebhooksUpdated` | Represents the [WEBHOOKS_UPDATE](https://discord.com/developers/docs/topics/gateway#webhooks-update) gateway event |
| InviteCreated | `InviteCreated` | Represents the [INVITE_CREATE](https://discord.com/developers/docs/topics/gateway#invite-create) gateway event |
| InviteDeleted | `InviteDeleted` | Represents the [INVITE_DELETE](https://discord.com/developers/docs/topics/gateway#invite-delete) gateway event |
| ApplicationCommandsPermissionsUpdate | `ApplicationCommandsPermissionsUpdate` | Represents the [APPLICATION_COMMANDS_PERMISSIONS_UPDATE](https://discord.com/developers/docs/topics/gateway#application-command-permissions-update) gateway event |
| InteractionCreated | `InteractionCreated` | Represents the [INTERACTION_CREATE](https://discord.com/developers/docs/topics/gateway#interaction-create) gateway event |
| ThreadCreated | `ThreadCreated` | Represents the [THREAD_CREATE](https://discord.com/developers/docs/topics/gateway#thread-create) gateway event |
| ThreadUpdated | `ThreadUpdated` | Represents the [THREAD_UPDATE](https://discord.com/developers/docs/topics/gateway#thread-update) gateway event |
| ThreadDeleted | `ThreadDeleted` | Represents the [THREAD_DELETE](https://discord.com/developers/docs/topics/gateway#thread-delete) gateway event |
| ThreadListSync | `ThreadListSync` | Represents the [THREAD_LIST_SYNC](https://discord.com/developers/docs/topics/gateway#thread-list-sync) gateway event |
| ThreadMemberUpdated | `ThreadMemberUpdated` | Represents the [THREAD_MEMBER_UPDATE](https://discord.com/developers/docs/topics/gateway#thread-member-update) gateway event |
| ThreadMembersUpdated | `ThreadMembersUpdated` | Represents the [THREAD_MEMBERS_UPDATE](https://discord.com/developers/docs/topics/gateway#thread-members-update) gateway event |
| StageInstanceCreated | `StageInstanceCreated` | Represents the [STAGE_INSTANCE_CREATE](https://discord.com/developers/docs/topics/gateway#stage-instance-create) gateway event |
| StageInstanceUpdated | `StageInstanceUpdated` | Represents the [STAGE_INSTANCE_CREATE](https://discord.com/developers/docs/topics/gateway#stage-instance-update) gateway event |
| StageInstanceDeleted | `StageInstanceDeleted` | Represents the [STAGE_INSTANCE_CREATE](https://discord.com/developers/docs/topics/gateway#stage-instance-delete) gateway event |
| SubscriptionCreate | `SubscriptionCreate` | Represents the [SUBSCRIPTION_CREATE](https://discord.com/developers/docs/topics/gateway-events#subscription-create) gateway event |
| SubscriptionUpdate | `SubscriptionUpdate` | Represents the [SUBSCRIPTION_UPDATE](https://discord.com/developers/docs/topics/gateway-events#subscription-update) gateway event |
| SubscriptionDelete | `SubscriptionDelete` | Represents the [SUBSCRIPTION_DELETE](https://discord.com/developers/docs/topics/gateway-events#subscription-delete) gateway event |
| GuildSoundboardSoundCreate | `GuildSoundboardSoundCreate` | Represents the [GUILD_SOUNDBOARD_SOUND_CREATE](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-create) gateway event |
| GuildSoundboardSoundUpdate | `GuildSoundboardSoundUpdate` | Represents the [GUILD_SOUNDBOARD_SOUND_UPDATE](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-update) gateway event |
| GuildSoundboardSoundDelete | `GuildSoundboardSoundDelete` | Represents the [GUILD_SOUNDBOARD_SOUND_DELETE](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-delete) gateway event |
| GuildSoundboardSoundsUpdate | `GuildSoundboardSoundsUpdate` | Represents the [GUILD_SOUNDBOARD_SOUNDS_UPDATE](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sounds-update) gateway event |
| SoundboardSounds | `SoundboardSounds` | Represents the [SOUNDBOARD_SOUNDS](https://discord.com/developers/docs/events/gateway-events#soundboard-sounds) gateway event |
| AutoModerationRuleCreate | `AutoModerationRuleCreate` | Represents the [AUTO_MODERATION_RULE_CREATE](https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-create) gateway event |
| AutoModerationRuleUpdate | `AutoModerationRuleUpdate` | Represents the [AUTO_MODERATION_RULE_UPDATE](https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-update) gateway event |
| AutoModerationRuleDelete | `AutoModerationRuleDelete` | Represents the [AUTO_MODERATION_RULE_DELETE](https://discord.com/developers/docs/topics/gateway#auto-moderation-rule-delete) gateway event |
| AutoModerationActionExecution | `AutoModerationActionExecution` | Represents the [AUTO_MODERATION_ACTION_EXECUTION](https://discord.com/developers/docs/topics/gateway#auto-moderation-action-execution) gateway event |
| MessagePollVoteAdded | `MessagePollVoteAdded` | Represents the [MESSAGE_POLL_VOTE_ADD](https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-add) gateway event |
| MessagePollVoteRemoved | `MessagePollVoteRemoved` | Represents the [MESSAGE_POLL_VOTE_REMOVE](https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-remove) gateway event |

## See Also

* namespace [Oxide.Ext.Discord.WebSockets](./WebSocketsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordDispatchCode.cs](../../../../Oxide.Ext.Discord/WebSockets/DiscordDispatchCode.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
