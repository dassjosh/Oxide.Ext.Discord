# DiscordExtHooks class

Represents all hooks available in the discord extension

```csharp
public static class DiscordExtHooks
```

## Public Members

| name | description |
| --- | --- |
| static readonly [HookGatewayIntent](#hookgatewayintent-field) | A mapping of Hooks required Gateway Intent |
| const [OnDiscordApplicationCommandPermissionsUpdated](#ondiscordapplicationcommandpermissionsupdated-field) | Called when the bots application command permission have been updated |
| const [OnDiscordAutoModActionExecuted](#ondiscordautomodactionexecuted-field) | Called when an AutoMod rule is executed on a guild |
| const [OnDiscordAutoModRuleCreated](#ondiscordautomodrulecreated-field) | Called when an AutoMod rule is created in a guild |
| const [OnDiscordAutoModRuleDeleted](#ondiscordautomodruledeleted-field) | Called when an AutoMod rule is deleted from a guild |
| const [OnDiscordAutoModRuleUpdated](#ondiscordautomodruleupdated-field) | Called when an AutoMod rule is updated on a guild |
| const [OnDiscordBotFullyLoaded](#ondiscordbotfullyloaded-field) | Called when the bot has fully loaded all discord guilds If GatewayIntent.GuildMembers is specified then this hook is delayed until all guild members have been loaded |
| const [OnDiscordClientCreated](#ondiscordclientcreated-field) | Called when the DiscordClient is created on the bot and is ready to use. This is called after the Loaded() hook on the plugin. |
| const [OnDiscordDirectChannelCreated](#ondiscorddirectchannelcreated-field) | Called when a direct message (DM) channel has been created. |
| const [OnDiscordDirectChannelDeleted](#ondiscorddirectchanneldeleted-field) | Called when a direct message (DM) channel has been deleted. Not sure if this is possible for DM channels |
| const [OnDiscordDirectChannelPinsUpdated](#ondiscorddirectchannelpinsupdated-field) | Called when a direct message (DM) channel has it's pinned messages updated. Channel may be null if we haven't seen it before. |
| const [OnDiscordDirectChannelUpdated](#ondiscorddirectchannelupdated-field) | Called when a direct message (DM) channel has been updated. |
| const [OnDiscordDirectInviteCreated](#ondiscorddirectinvitecreated-field) | Called when an invite to a direct message channel is created `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectInviteDeleted](#ondiscorddirectinvitedeleted-field) | Called when an invite to a direct message channel is deleted `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageCreated](#ondiscorddirectmessagecreated-field) | Called when a message is created in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageDeleted](#ondiscorddirectmessagedeleted-field) | Called when a message is deleted in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageReactionAdded](#ondiscorddirectmessagereactionadded-field) | Called when a reaction is added to a message in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageReactionEmojiRemoved](#ondiscorddirectmessagereactionemojiremoved-field) | Called when all of a specific reactions is removed from a message in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageReactionRemoved](#ondiscorddirectmessagereactionremoved-field) | Called when a reaction is removed from a message in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageReactionRemovedAll](#ondiscorddirectmessagereactionremovedall-field) | Called when all reactions are removed from a message in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessagesBulkDeleted](#ondiscorddirectmessagesbulkdeleted-field) | Called when a message is deleted in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectMessageUpdated](#ondiscorddirectmessageupdated-field) | Called when a message is updated in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectTypingStarted](#ondiscorddirecttypingstarted-field) | Called typing starts in a direct message channel `channel` may be null if we haven't seen it yet |
| const [OnDiscordDirectVoiceStateUpdated](#ondiscorddirectvoicestateupdated-field) | Called when the voice state in a direct message channel is updated `channel` may be null if we haven't seen it yet |
| const [OnDiscordEntitlementCreated](#ondiscordentitlementcreated-field) | Called when an entitlement has been created |
| const [OnDiscordEntitlementDeleted](#ondiscordentitlementdeleted-field) | Called when an entitlement has been deleted |
| const [OnDiscordEntitlementUpdated](#ondiscordentitlementupdated-field) | Called when an entitlement has been update |
| const [OnDiscordGatewayReady](#ondiscordgatewayready-field) | - Called when the Discord Bot has successfully connected to the gateway and identified successfully. **Note:** Only partial guild information is available at this point. If you need full guild listen for [OnDiscordGuildCreated](#OnDiscordGuildCreated) hook If you need full guild member list listen for [OnDiscordGuildMembersLoaded](#OnDiscordGuildMembersLoaded) |
| const [OnDiscordGatewayReconnected](#ondiscordgatewayreconnected-field) | Called when the websocket has reconnected |
| const [OnDiscordGatewayResumed](#ondiscordgatewayresumed-field) | Called when the websocket has reconnected to the websocket and resumed the previous session |
| const [OnDiscordGetGuildSoundboardSounds](#ondiscordgetguildsoundboardsounds-field) | Called when a guild soundboard is deleted |
| const [OnDiscordGuildChannelCreated](#ondiscordguildchannelcreated-field) | Called when a channel has been created in a guild. |
| const [OnDiscordGuildChannelDeleted](#ondiscordguildchanneldeleted-field) | Called when a channel has been deleted in a guild. |
| const [OnDiscordGuildChannelPinsUpdated](#ondiscordguildchannelpinsupdated-field) | Called when a guild channel has it's pinned messages updated |
| const [OnDiscordGuildChannelUpdated](#ondiscordguildchannelupdated-field) | Called when a channel has been updated in a guild. |
| const [OnDiscordGuildCreated](#ondiscordguildcreated-field) | Called when a discord server is fully loaded while connecting or the bot has joined a new discord server |
| const [OnDiscordGuildDeleted](#ondiscordguilddeleted-field) | Called when a bot is removed from a discord server or that discord server was deleted |
| const [OnDiscordGuildEmojisUpdated](#ondiscordguildemojisupdated-field) | Called when the custom emojis for a guild are created/updated/deleted |
| const [OnDiscordGuildIntegrationCreated](#ondiscordguildintegrationcreated-field) | Called when a new integration is created a guild |
| const [OnDiscordGuildIntegrationDeleted](#ondiscordguildintegrationdeleted-field) | Called when an integration is deleted on a guild |
| const [OnDiscordGuildIntegrationsUpdated](#ondiscordguildintegrationsupdated-field) | Called when a guild integration is updated |
| const [OnDiscordGuildIntegrationUpdated](#ondiscordguildintegrationupdated-field) | Called when an integration is updated on a guild |
| const [OnDiscordGuildInviteCreated](#ondiscordguildinvitecreated-field) | Called when an invite to a guild channel is created |
| const [OnDiscordGuildInviteDeleted](#ondiscordguildinvitedeleted-field) | Called when an invite to a guild channel is deleted |
| const [OnDiscordGuildMemberAdded](#ondiscordguildmemberadded-field) | Called when a guild member has been added to the guild |
| const [OnDiscordGuildMemberAvatarUpdated](#ondiscordguildmemberavatarupdated-field) | Called when a guild member avatar has been updated |
| const [OnDiscordGuildMemberBanned](#ondiscordguildmemberbanned-field) | Called when a guild member is banned |
| const [OnDiscordGuildMemberBoosted](#ondiscordguildmemberboosted-field) | Called when a guild member boosts the server |
| const [OnDiscordGuildMemberBoostEnded](#ondiscordguildmemberboostended-field) | Called when a guild member boost ends |
| const [OnDiscordGuildMemberBoostExtended](#ondiscordguildmemberboostextended-field) | Called when a guild member extends their boost |
| const [OnDiscordGuildMemberDeafened](#ondiscordguildmemberdeafened-field) | Called when a guild member is deafened |
| const [OnDiscordGuildMemberMuted](#ondiscordguildmembermuted-field) | Called when a guild member is muted |
| const [OnDiscordGuildMemberNicknameUpdated](#ondiscordguildmembernicknameupdated-field) | Called when a guild member nickname has been updated |
| const [OnDiscordGuildMemberPresenceUpdated](#ondiscordguildmemberpresenceupdated-field) | Called when a guild members presence is updated |
| const [OnDiscordGuildMemberRemoved](#ondiscordguildmemberremoved-field) | Called when a guild member has been removed from the guild |
| const [OnDiscordGuildMemberRoleAdded](#ondiscordguildmemberroleadded-field) | Called when a role is added to a guild member |
| const [OnDiscordGuildMemberRoleRemoved](#ondiscordguildmemberroleremoved-field) | Called when a role is removed from a guild member |
| const [OnDiscordGuildMembersChunk](#ondiscordguildmemberschunk-field) | Called in a response to a request for guild member chunks |
| const [OnDiscordGuildMembersLoaded](#ondiscordguildmembersloaded-field) | Called when a guild has finished loading all guild members This Discord Extension requests all guild members in the [OnDiscordGuildCreated](#ondiscordguildcreated) Hook |
| const [OnDiscordGuildMemberTimeout](#ondiscordguildmembertimeout-field) | Called when a guild member is placed in [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ) |
| const [OnDiscordGuildMemberTimeoutEnded](#ondiscordguildmembertimeoutended-field) | Called when a guild members [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ) ends |
| const [OnDiscordGuildMemberUnbanned](#ondiscordguildmemberunbanned-field) | Called when a guild member is unbanned |
| const [OnDiscordGuildMemberUndeafened](#ondiscordguildmemberundeafened-field) | Called when a guild member is undeafened |
| const [OnDiscordGuildMemberUnmuted](#ondiscordguildmemberunmuted-field) | Called when a guild member is unmuted |
| const [OnDiscordGuildMemberUpdated](#ondiscordguildmemberupdated-field) | Called when a guild member has been updated This also include when the DiscordUser is updated as well |
| const [OnDiscordGuildMessageCreated](#ondiscordguildmessagecreated-field) | Called when a message is created in a guild channel |
| const [OnDiscordGuildMessageDeleted](#ondiscordguildmessagedeleted-field) | Called when a message is deleted in a guild channel |
| const [OnDiscordGuildMessageReactionAdded](#ondiscordguildmessagereactionadded-field) | Called when a reaction is added to a message in a guild channel |
| const [OnDiscordGuildMessageReactionEmojiRemoved](#ondiscordguildmessagereactionemojiremoved-field) | Called when all of a specific reaction is removed from a message in a guild channel |
| const [OnDiscordGuildMessageReactionRemoved](#ondiscordguildmessagereactionremoved-field) | Called when a reaction is removed from a message in a guild channel |
| const [OnDiscordGuildMessageReactionRemovedAll](#ondiscordguildmessagereactionremovedall-field) | Called when all reactions are removed from a message in a guild channel |
| const [OnDiscordGuildMessagesBulkDeleted](#ondiscordguildmessagesbulkdeleted-field) | Called when a message is deleted in a guild channel |
| const [OnDiscordGuildMessageUpdated](#ondiscordguildmessageupdated-field) | Called when a message is updated in a guild channel |
| const [OnDiscordGuildRoleCreated](#ondiscordguildrolecreated-field) | Called when a discord guild role is created |
| const [OnDiscordGuildRoleDeleted](#ondiscordguildroledeleted-field) | Called when a discord guild role is deleted |
| const [OnDiscordGuildRoleUpdated](#ondiscordguildroleupdated-field) | Called when a discord guild role is updated |
| const [OnDiscordGuildScheduledEventCreated](#ondiscordguildscheduledeventcreated-field) | Called when a discord guild scheduled event is created |
| const [OnDiscordGuildScheduledEventDeleted](#ondiscordguildscheduledeventdeleted-field) | Called when a discord guild scheduled event is deleted |
| const [OnDiscordGuildScheduledEventUpdated](#ondiscordguildscheduledeventupdated-field) | Called when a discord guild scheduled event is updated |
| const [OnDiscordGuildScheduledEventUserAdded](#ondiscordguildscheduledeventuseradded-field) | Called when a discord user is added to a guild scheduled event |
| const [OnDiscordGuildScheduledEventUserRemoved](#ondiscordguildscheduledeventuserremoved-field) | Called when a discord user is removed from a guild scheduled event |
| const [OnDiscordGuildSoundboardCreated](#ondiscordguildsoundboardcreated-field) | Called when a guild soundboard is created |
| const [OnDiscordGuildSoundboardDeleted](#ondiscordguildsoundboarddeleted-field) | Called when a guild soundboard is deleted |
| const [OnDiscordGuildSoundboardUpdated](#ondiscordguildsoundboardupdated-field) | Called when a guild soundboard is updated |
| const [OnDiscordGuildStickersUpdated](#ondiscordguildstickersupdated-field) | Called when the guild stickers are updated |
| const [OnDiscordGuildThreadCreated](#ondiscordguildthreadcreated-field) | Called when a guild thread is created |
| const [OnDiscordGuildThreadDeleted](#ondiscordguildthreaddeleted-field) | Called when a guild thread is deleted |
| const [OnDiscordGuildThreadListSynced](#ondiscordguildthreadlistsynced-field) | Called when a guild thread list is synced |
| const [OnDiscordGuildThreadMembersUpdated](#ondiscordguildthreadmembersupdated-field) | Called when thread members are updated |
| const [OnDiscordGuildThreadMemberUpdated](#ondiscordguildthreadmemberupdated-field) | Called when a thread member is updated |
| const [OnDiscordGuildThreadUpdated](#ondiscordguildthreadupdated-field) | Called when a guild thread is updated |
| const [OnDiscordGuildTypingStarted](#ondiscordguildtypingstarted-field) | Called when typing starts in a guild channel |
| const [OnDiscordGuildUnavailable](#ondiscordguildunavailable-field) | Called when a guild become unavailable due to a network outage |
| const [OnDiscordGuildUpdated](#ondiscordguildupdated-field) | Called when any updates are made to a guild Note: previous will be null if guild previously not loaded |
| const [OnDiscordGuildVoiceServerUpdated](#ondiscordguildvoiceserverupdated-field) | Called when the voice server in a guild channel is updated |
| const [OnDiscordGuildVoiceStateUpdated](#ondiscordguildvoicestateupdated-field) | Called when the voice state in a guild channel is updated |
| const [OnDiscordGuildWebhookUpdated](#ondiscordguildwebhookupdated-field) | Called when a webhook ins a guild is updated |
| const [OnDiscordHeartbeatSent](#ondiscordheartbeatsent-field) | Called when a heartbeat is sent over the websocket to discord to keep the connection open |
| const [OnDiscordInteractionCreated](#ondiscordinteractioncreated-field) | Called when a discord interaction occurs by a user |
| const [OnDiscordPlayerLinked](#ondiscordplayerlinked-field) | These hooks are called when a player is linked or unlinked using discord link. It will be called for every plugins registered to receive hooks. **Note:** If your plugin supports discord link you should not supply any other hooks as the extension provides them for you. **Note:** Discord Link hooks are considered global hooks and will be called on all plugins regardless of bot |
| const [OnDiscordPlayerUnlink](#ondiscordplayerunlink-field) | Called when a player is being unlinked from DiscordLink Library This is called before the unlink occurs |
| const [OnDiscordPlayerUnlinked](#ondiscordplayerunlinked-field) | Called when a player has unlinked their discord and player together using the DiscordLink library |
| const [OnDiscordPollVoteAdded](#ondiscordpollvoteadded-field) | Called when we receive an event we do not handle yet. If you need this event, you can listen to it using this hook until we support it Please create an issue on uMod if this error ever occurs |
| const [OnDiscordPollVoteRemoved](#ondiscordpollvoteremoved-field) |  |
| const [OnDiscordSetupHeartbeat](#ondiscordsetupheartbeat-field) | Called when we receive the heartbeat interval from the websocket |
| const [OnDiscordStageInstanceCreated](#ondiscordstageinstancecreated-field) | Called when a stage instance is created |
| const [OnDiscordStageInstanceDeleted](#ondiscordstageinstancedeleted-field) | Called when a stage instance is deleted |
| const [OnDiscordStageInstanceUpdated](#ondiscordstageinstanceupdated-field) | Called when a stage instance is updated |
| const [OnDiscordSubscriptionCreated](#ondiscordsubscriptioncreated-field) | Called when a subscription is created |
| const [OnDiscordSubscriptionDeleted](#ondiscordsubscriptiondeleted-field) | Called when a subscription is deleted |
| const [OnDiscordSubscriptionUpdated](#ondiscordsubscriptionupdated-field) | Called when a subscription is updated |
| const [OnDiscordUnhandledCommand](#ondiscordunhandledcommand-field) | void OnDiscordUnhandledCommand(EventPayload payload) { Puts("OnDiscordUnhandledCommand Works!"); } |
| const [OnDiscordUserUpdated](#ondiscorduserupdated-field) | Called when a discord user is updated |
| const [OnDiscordVoiceChannelEffect](#ondiscordvoicechanneleffect-field) | Sent when someone sends an effect, such as an emoji reaction or a soundboard sound, in a voice channel the current user is connected to. |
| const [OnDiscordWebsocketClosed](#ondiscordwebsocketclosed-field) | Called when the web socket is closed for any reason. |
| const [OnDiscordWebsocketErrored](#ondiscordwebsocketerrored-field) | Called when the web socket has an error. |
| const [OnDiscordWebsocketOpened](#ondiscordwebsocketopened-field) | Called when the discord socket connects. |
| static [IsDiscordHook](#isdiscordhook-method)(…) | Returns true if the hook is a Discord Extension Hook |
| static [IsGlobalHook](#isglobalhook-method)(…) | Returns true if the hook is a Discord Extension Global Hook |
| static [IsPluginHook](#ispluginhook-method)(…) | Returns true if the hook is a Discord Extension Plugin Hook |

## See Also

* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordExtHooks.cs](../../../../Oxide.Ext.Discord/Constants/DiscordExtHooks.cs)
   
   
# IsGlobalHook method

Returns true if the hook is a Discord Extension Global Hook

```csharp
public static bool IsGlobalHook(string hook)
```

| parameter | description |
| --- | --- |
| hook | Name of the hook |

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsPluginHook method

Returns true if the hook is a Discord Extension Plugin Hook

```csharp
public static bool IsPluginHook(string hook)
```

| parameter | description |
| --- | --- |
| hook | Name of the hook |

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsDiscordHook method

Returns true if the hook is a Discord Extension Hook

```csharp
public static bool IsDiscordHook(string hook)
```

| parameter | description |
| --- | --- |
| hook | Name of the hook |

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HookGatewayIntent field

A mapping of Hooks required Gateway Intent

```csharp
public static readonly Hash<string, GatewayIntents> HookGatewayIntent;
```

## See Also

* enum [GatewayIntents](../Entities/GatewayIntents.md)
* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordClientCreated field

Called when the DiscordClient is created on the bot and is ready to use. This is called after the Loaded() hook on the plugin.

```csharp
void OnDiscordClientCreated()
{
    Puts("OnDiscordClientCreated Works!");
}
```

```csharp
public const string OnDiscordClientCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordBotFullyLoaded field

Called when the bot has fully loaded all discord guilds If GatewayIntent.GuildMembers is specified then this hook is delayed until all guild members have been loaded

```csharp
void OnDiscordBotFullyLoaded()
{
    Puts("OnDiscordBotFullyLoaded Works!");
}
```

```csharp
public const string OnDiscordBotFullyLoaded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordWebsocketOpened field

Called when the discord socket connects.

```csharp
void OnDiscordWebsocketOpened()
{
    Puts("OnDiscordWebsocketOpened Works!");
}
```

```csharp
public const string OnDiscordWebsocketOpened;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordWebsocketClosed field

Called when the web socket is closed for any reason.

```csharp
void OnDiscordWebsocketClosed(string reason, ushort code)
{
    Puts("OnDiscordWebsocketClosed Works!");
}
```

```csharp
public const string OnDiscordWebsocketClosed;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordWebsocketErrored field

Called when the web socket has an error.

```csharp
void OnDiscordWebsocketErrored(Exception ex, string message)
{
    Puts("OnDiscordWebsocketErrored Works!");
}
```

```csharp
public const string OnDiscordWebsocketErrored;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordSetupHeartbeat field

Called when we receive the heartbeat interval from the websocket

```csharp
void OnDiscordSetupHeartbeat(float heartbeat)
{
    Puts("OnDiscordHeartbeatSent Works!");
}
```

```csharp
public const string OnDiscordSetupHeartbeat;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordHeartbeatSent field

Called when a heartbeat is sent over the websocket to discord to keep the connection open

```csharp
void OnDiscordHeartbeatSent()
{
    Puts("OnDiscordHeartbeatSent Works!");
}
```

```csharp
public const string OnDiscordHeartbeatSent;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordPlayerLinked field

These hooks are called when a player is linked or unlinked using discord link. It will be called for every plugins registered to receive hooks. **Note:** If your plugin supports discord link you should not supply any other hooks as the extension provides them for you. **Note:** Discord Link hooks are considered global hooks and will be called on all plugins regardless of bot

```csharp
void OnDiscordPlayerLinked(IPlayer player, DiscordUser discord)
{
    Puts("OnDiscordPlayerLinked Works!");
}
```

```csharp
public const string OnDiscordPlayerLinked;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordPlayerUnlink field

Called when a player is being unlinked from DiscordLink Library This is called before the unlink occurs

```csharp
void OnDiscordPlayerUnlink(IPlayer player, DiscordUser discord)
{
    Puts("OnDiscordPlayerUnlink Works!");
}
```

```csharp
public const string OnDiscordPlayerUnlink;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordPlayerUnlinked field

Called when a player has unlinked their discord and player together using the DiscordLink library

```csharp
void OnDiscordPlayerUnlinked(IPlayer player, DiscordUser discord)
{
    Puts("OnDiscordPlayerUnlinked Works!");
}
```

```csharp
public const string OnDiscordPlayerUnlinked;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGatewayReady field

- Called when the Discord Bot has successfully connected to the gateway and identified successfully. **Note:** Only partial guild information is available at this point. If you need full guild listen for [OnDiscordGuildCreated](#OnDiscordGuildCreated) hook If you need full guild member list listen for [OnDiscordGuildMembersLoaded](#OnDiscordGuildMembersLoaded)

```csharp
void OnDiscordGatewayReady(GatewayReadyEvent ready)
{
    Puts("OnDiscordGatewayReady Works!");
}
```

```csharp
public const string OnDiscordGatewayReady;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGatewayResumed field

Called when the websocket has reconnected to the websocket and resumed the previous session

```csharp
void OnDiscordGatewayResumed(GatewayResumedEvent resume)
{
    Puts("OnDiscordGatewayResumed Works!");
}
```

```csharp
public const string OnDiscordGatewayResumed;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGatewayReconnected field

Called when the websocket has reconnected

```csharp
void OnDiscordGatewayReconnected()
{
    Puts("OnDiscordGatewayReconnected Works!");
}
```

```csharp
public const string OnDiscordGatewayReconnected;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectChannelCreated field

Called when a direct message (DM) channel has been created.

```csharp
void OnDiscordDirectChannelCreated(DiscordChannel channel)
{
    Puts("OnDiscordDirectChannelCreated Works!");
}
```

```csharp
public const string OnDiscordDirectChannelCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildChannelCreated field

Called when a channel has been created in a guild.

```csharp
void OnDiscordGuildChannelCreated(DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildChannelCreated Works!");
}
```

```csharp
public const string OnDiscordGuildChannelCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectChannelUpdated field

Called when a direct message (DM) channel has been updated.

```csharp
Note: previous will be null if previous channel not found
void OnDiscordDirectChannelUpdated(DiscordChannel channel, DiscordChannel previous)
{
    Puts("OnDiscordDirectChannelUpdated Works!");
}
```

```csharp
public const string OnDiscordDirectChannelUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildChannelUpdated field

Called when a channel has been updated in a guild.

```csharp
void OnDiscordGuildChannelUpdated(DiscordChannel channel, DiscordChannel previous, DiscordGuild guild)
{
    Puts("OnDiscordGuildChannelUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildChannelUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectChannelDeleted field

Called when a direct message (DM) channel has been deleted. Not sure if this is possible for DM channels

```csharp
Note: Not sure if this will ever happen but we handle it if it does
void OnDiscordDirectChannelDeleted(DiscordChannel channel)
{
    Puts("OnDiscordDirectChannelDeleted Works!");
}
```

```csharp
public const string OnDiscordDirectChannelDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildChannelDeleted field

Called when a channel has been deleted in a guild.

```csharp
void OnDiscordGuildChannelDeleted(DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildChannelDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildChannelDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectChannelPinsUpdated field

Called when a direct message (DM) channel has it's pinned messages updated. Channel may be null if we haven't seen it before.

```csharp
void OnDiscordDirectChannelPinsUpdated(ChannelPinsUpdatedEvent update, DiscordChannel channel)
{
    Puts("OnDiscordDirectChannelPinsUpdated Works!");
}
```

```csharp
public const string OnDiscordDirectChannelPinsUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordEntitlementCreated field

Called when an entitlement has been created

```csharp
void OnDiscordEntitlementCreated(DiscordEntitlement entitlement, DiscordGuild guild)
{
    Puts("OnDiscordEntitlementCreated Works!");
}
```

```csharp
public const string OnDiscordEntitlementCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordEntitlementUpdated field

Called when an entitlement has been update

```csharp
void OnDiscordEntitlementUpdated(DiscordEntitlement entitlement, DiscordGuild guild)
{
    Puts("OnDiscordEntitlementUpdated Works!");
}
```

```csharp
public const string OnDiscordEntitlementUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordEntitlementDeleted field

Called when an entitlement has been deleted

```csharp
void OnDiscordEntitlementDeleted(DiscordEntitlement entitlement, DiscordGuild guild)
{
    Puts("OnDiscordEntitlementDeleted Works!");
}
```

```csharp
public const string OnDiscordEntitlementDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildChannelPinsUpdated field

Called when a guild channel has it's pinned messages updated

```csharp
void OnDiscordGuildChannelPinsUpdated(ChannelPinsUpdatedEvent update, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildChannelPinsUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildChannelPinsUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildCreated field

Called when a discord server is fully loaded while connecting or the bot has joined a new discord server

```csharp
void OnDiscordGuildCreated(GuildDiscordGuild guild)
{
    Puts("OnDiscordGuildCreated Works!");
}
```

```csharp
public const string OnDiscordGuildCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildUpdated field

Called when any updates are made to a guild Note: previous will be null if guild previously not loaded

```csharp
void OnDiscordGuildUpdated(DiscordGuild guild, DiscordGuild previous)
{
    Puts("OnDiscordGuildUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildUnavailable field

Called when a guild become unavailable due to a network outage

```csharp
void OnDiscordGuildUnavailable(DiscordGuild guild)
{
    Puts("OnDiscordGuildUnavailable Works!");
}
```

```csharp
public const string OnDiscordGuildUnavailable;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildDeleted field

Called when a bot is removed from a discord server or that discord server was deleted

```csharp
void OnDiscordGuildDeleted(DiscordGuild guild)
{
    Puts("OnDiscordGuildDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberBanned field

Called when a guild member is banned

```csharp
void OnDiscordGuildMemberBanned(GuildMemberBannedEvent ban, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberBanned Works!");
}
```

```csharp
public const string OnDiscordGuildMemberBanned;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberUnbanned field

Called when a guild member is unbanned

```csharp
void OnDiscordGuildMemberUnbanned(GuildMemberBannedEvent ban, DiscordGuild guild)
{
    Puts("OnDiscordGuildBanRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildMemberUnbanned;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildEmojisUpdated field

Called when the custom emojis for a guild are created/updated/deleted

```csharp
void OnDiscordGuildEmojisUpdated(GuildEmojisUpdatedEvent emojis, Hash<Snowflake, DiscordEmoji> previous, DiscordGuild guild)
{
    Puts("OnDiscordGuildEmojisUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildEmojisUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildStickersUpdated field

Called when the guild stickers are updated

```csharp
void OnDiscordGuildStickersUpdated(GuildStickersUpdatedEvent stickers, Hash<Snowflake, DiscordSticker> previous, DiscordGuild guild)
{
    Puts("OnDiscordGuildStickersUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildStickersUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildIntegrationsUpdated field

Called when a guild integration is updated

```csharp
void OnDiscordGuildIntegrationsUpdated(GuildIntegrationsUpdatedEvent integration, DiscordGuild guild)
{
    Puts("OnDiscordGuildIntegrationsUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildIntegrationsUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberAdded field

Called when a guild member has been added to the guild

```csharp
void OnDiscordGuildMemberAdded(GuildMemberAddedEvent member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberAdded Works!");
}
```

```csharp
public const string OnDiscordGuildMemberAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberRemoved field

Called when a guild member has been removed from the guild

```csharp
void OnDiscordGuildMemberRemoved(GuildMemberRemovedEvent member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildMemberRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberUpdated field

Called when a guild member has been updated This also include when the DiscordUser is updated as well

```csharp
void OnDiscordGuildMemberUpdated(GuildMemberUpdatedEvent member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildMemberUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberNicknameUpdated field

Called when a guild member nickname has been updated

```csharp
void OnDiscordGuildMemberNicknameUpdated(GuildMember member, string oldNickname, string newNickname, DateTime? lastNicknameUpdate, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberNicknameUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildMemberNicknameUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberAvatarUpdated field

Called when a guild member avatar has been updated

```csharp
void OnDiscordGuildMemberAvatarUpdated(GuildMember member, string oldAvatar, string newAvatar, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberAvatarUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildMemberAvatarUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberDeafened field

Called when a guild member is deafened

```csharp
void OnDiscordGuildMemberDeafened(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberDeafened Works!");
}
```

```csharp
public const string OnDiscordGuildMemberDeafened;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberUndeafened field

Called when a guild member is undeafened

```csharp
void OnDiscordGuildMemberUndeafened(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberUndeafened Works!");
}
```

```csharp
public const string OnDiscordGuildMemberUndeafened;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberMuted field

Called when a guild member is muted

```csharp
void OnDiscordGuildMemberMuted(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberMuted Works!");
}
```

```csharp
public const string OnDiscordGuildMemberMuted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberUnmuted field

Called when a guild member is unmuted

```csharp
void OnDiscordGuildMemberUnmuted(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberUnmuted Works!");
}
```

```csharp
public const string OnDiscordGuildMemberUnmuted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberTimeout field

Called when a guild member is placed in [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ)

```csharp
void OnDiscordGuildMemberTimeout(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberTimeout Works!");
}
```

```csharp
public const string OnDiscordGuildMemberTimeout;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberTimeoutEnded field

Called when a guild members [Timeout](https://support.discord.com/hc/en-us/articles/4413305239191-Time-Out-FAQ) ends

```csharp
void OnDiscordGuildMemberTimeoutEnded(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberTimeoutEnded Works!");
}
```

```csharp
public const string OnDiscordGuildMemberTimeoutEnded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberBoosted field

Called when a guild member boosts the server

```csharp
void OnDiscordGuildMemberBoosted(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberBoosted Works!");
}
```

```csharp
public const string OnDiscordGuildMemberBoosted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberBoostExtended field

Called when a guild member extends their boost

```csharp
void OnDiscordGuildMemberBoostExtended(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberBoostExtended Works!");
}
```

```csharp
public const string OnDiscordGuildMemberBoostExtended;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberBoostEnded field

Called when a guild member boost ends

```csharp
void OnDiscordGuildMemberBoostEnded(GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberBoostEnded Works!");
}
```

```csharp
public const string OnDiscordGuildMemberBoostEnded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberRoleAdded field

Called when a role is added to a guild member

```csharp
void OnDiscordGuildMemberRoleAdded(GuildMember member, Snowflake roleId, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberRoleAdded Works!");
}
```

```csharp
public const string OnDiscordGuildMemberRoleAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberRoleRemoved field

Called when a role is removed from a guild member

```csharp
void OnDiscordGuildMemberRoleRemoved(GuildMember member, Snowflake roleId, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberRoleRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildMemberRoleRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMembersLoaded field

Called when a guild has finished loading all guild members This Discord Extension requests all guild members in the [OnDiscordGuildCreated](#ondiscordguildcreated) Hook

```csharp
void OnDiscordGuildMembersLoaded(DiscordGuild guild)
{
    Puts("OnDiscordGuildMembersLoaded Works!");
}
```

```csharp
public const string OnDiscordGuildMembersLoaded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMembersChunk field

Called in a response to a request for guild member chunks

```csharp
void OnDiscordGuildMembersChunk(GuildMembersChunkEvent chunk, DiscordGuild guild)
{
    Puts("OnDiscordGuildMembersChunk Works!");
}
```

```csharp
public const string OnDiscordGuildMembersChunk;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildRoleCreated field

Called when a discord guild role is created

```csharp
void OnDiscordGuildRoleCreated(DiscordRole role, DiscordGuild guild)
{
    Puts("OnDiscordGuildRoleCreated Works!");
}
```

```csharp
public const string OnDiscordGuildRoleCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildRoleUpdated field

Called when a discord guild role is updated

```csharp
void OnDiscordGuildRoleUpdated(DiscordRole role, DiscordRole previous, DiscordGuild guild)
{
    Puts("OnDiscordGuildRoleUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildRoleUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildRoleDeleted field

Called when a discord guild role is deleted

```csharp
void OnDiscordGuildRoleDeleted(DiscordRole role, DiscordGuild guild)
{
    Puts("OnDiscordGuildRoleDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildRoleDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildScheduledEventCreated field

Called when a discord guild scheduled event is created

```csharp
void OnDiscordGuildScheduledEventCreated(GuildScheduledEvent guildEvent, DiscordGuild guild)
{
    Puts("OnDiscordGuildScheduledEventCreated Works!");
}
```

```csharp
public const string OnDiscordGuildScheduledEventCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildScheduledEventUpdated field

Called when a discord guild scheduled event is updated

```csharp
void OnDiscordGuildScheduledEventUpdated(GuildScheduledEvent guildEvent, DiscordGuild guild)
{
    Puts("OnDiscordGuildScheduledEventUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildScheduledEventUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildScheduledEventDeleted field

Called when a discord guild scheduled event is deleted

```csharp
void OnDiscordGuildScheduledEventDeleted(GuildScheduledEvent guildEvent, DiscordGuild guild)
{
    Puts("OnDiscordGuildScheduledEventDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildScheduledEventDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildScheduledEventUserAdded field

Called when a discord user is added to a guild scheduled event

```csharp
void OnDiscordGuildScheduledEventUserAdded(GuildScheduleEventUserAddedEvent added, GuildScheduledEvent, scheduledEvent, DiscordGuild guild)
{
    Puts("OnDiscordGuildScheduledEventUserAdded Works!");
}
```

```csharp
public const string OnDiscordGuildScheduledEventUserAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildScheduledEventUserRemoved field

Called when a discord user is removed from a guild scheduled event

```csharp
void OnDiscordGuildScheduledEventUserRemoved(GuildScheduleEventUserRemovedEvent removed, GuildScheduledEvent, scheduledEvent, DiscordGuild guild)
{
    Puts("OnDiscordGuildScheduledEventUserRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildScheduledEventUserRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageCreated field

Called when a message is created in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageCreated(DiscordMessage message, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageCreated Works!");
}
```

```csharp
public const string OnDiscordDirectMessageCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageCreated field

Called when a message is created in a guild channel

```csharp
void OnDiscordGuildMessageCreated(DiscordMessage message, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageCreated Works!");
}
```

```csharp
public const string OnDiscordGuildMessageCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageUpdated field

Called when a message is updated in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageUpdated(DiscordMessage message, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageUpdated Works!");
}
```

```csharp
public const string OnDiscordDirectMessageUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageUpdated field

Called when a message is updated in a guild channel

```csharp
void OnDiscordDirectMessageUpdated(DiscordMessage message, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildMessageUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageDeleted field

Called when a message is deleted in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageDeleted(DiscordMessage message, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageDeleted Works!");
}
```

```csharp
public const string OnDiscordDirectMessageDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageDeleted field

Called when a message is deleted in a guild channel

```csharp
void OnDiscordGuildMessageDeleted(DiscordMessage message, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildMessageDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessagesBulkDeleted field

Called when a message is deleted in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessagesBulkDeleted(List<Snowflake> messageIds, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessagesBulkDeleted Works!");
}
```

```csharp
public const string OnDiscordDirectMessagesBulkDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessagesBulkDeleted field

Called when a message is deleted in a guild channel

```csharp
void OnDiscordGuildMessagesBulkDeleted(List<Snowflake> messageIds, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessagesBulkDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildMessagesBulkDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageReactionAdded field

Called when a reaction is added to a message in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageReactionAdded(MessageReactionAddedEvent reaction, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageReactionAdded Works!");
}
```

```csharp
public const string OnDiscordDirectMessageReactionAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageReactionAdded field

Called when a reaction is added to a message in a guild channel

```csharp
void OnDiscordGuildMessageReactionAdded(MessageReactionAddedEvent reaction, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageReactionAdded Works!");
}
```

```csharp
public const string OnDiscordGuildMessageReactionAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageReactionRemoved field

Called when a reaction is removed from a message in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageReactionRemoved(MessageReactionRemovedEvent reaction, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageReactionRemoved Works!");
}
```

```csharp
public const string OnDiscordDirectMessageReactionRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageReactionRemoved field

Called when a reaction is removed from a message in a guild channel

```csharp
void OnDiscordGuildMessageReactionRemoved(MessageReactionRemovedEvent reaction, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageReactionRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildMessageReactionRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageReactionRemovedAll field

Called when all reactions are removed from a message in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageReactionRemovedAll(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageReactionRemovedAll Works!");
}
```

```csharp
public const string OnDiscordDirectMessageReactionRemovedAll;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageReactionRemovedAll field

Called when all reactions are removed from a message in a guild channel

```csharp
void OnDiscordGuildMessageReactionRemovedAll(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageReactionRemovedAll Works!");
}
```

```csharp
public const string OnDiscordGuildMessageReactionRemovedAll;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectMessageReactionEmojiRemoved field

Called when all of a specific reactions is removed from a message in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectMessageReactionEmojiRemoved(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel)
{
    Puts("OnDiscordDirectMessageReactionEmojiRemoved Works!");
}
```

```csharp
public const string OnDiscordDirectMessageReactionEmojiRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMessageReactionEmojiRemoved field

Called when all of a specific reaction is removed from a message in a guild channel

```csharp
void OnDiscordGuildMessageReactionEmojiRemoved(MessageReactionRemovedAllEmojiEvent reaction, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildMessageReactionEmojiRemoved Works!");
}
```

```csharp
public const string OnDiscordGuildMessageReactionEmojiRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildMemberPresenceUpdated field

Called when a guild members presence is updated

```csharp
void OnDiscordGuildMemberPresenceUpdated(PresenceUpdatedEvent update, GuildMember member, DiscordGuild guild)
{
    Puts("OnDiscordGuildMemberPresenceUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildMemberPresenceUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectTypingStarted field

Called typing starts in a direct message channel `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectTypingStarted(TypingStartedEvent typing, DiscordChannel channel)
{
    Puts("OnDiscordDirectTypingStarted Works!");
}
```

```csharp
public const string OnDiscordDirectTypingStarted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildTypingStarted field

Called when typing starts in a guild channel

```csharp
void OnDiscordGuildTypingStarted(TypingStartedEvent typing, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildTypingStarted Works!");
}
```

```csharp
public const string OnDiscordGuildTypingStarted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordUserUpdated field

Called when a discord user is updated

```csharp
void OnDiscordUserUpdated(DiscordUser user)
{
    Puts("OnDiscordUserUpdated Works!");
}
```

```csharp
public const string OnDiscordUserUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectVoiceStateUpdated field

Called when the voice state in a direct message channel is updated `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectVoiceStateUpdated(VoiceState voice, DiscordChannel channel)
{
    Puts("OnDiscordDirectVoiceStateUpdated Works!");
}
```

```csharp
public const string OnDiscordDirectVoiceStateUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildVoiceStateUpdated field

Called when the voice state in a guild channel is updated

```csharp
void OnDiscordGuildVoiceStateUpdated(VoiceState voice, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildVoiceStateUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildVoiceStateUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordVoiceChannelEffect field

Sent when someone sends an effect, such as an emoji reaction or a soundboard sound, in a voice channel the current user is connected to.

```csharp
void OnDiscordVoiceChannelEffect(VoiceChannelEffectEvent effect, DiscordGuild guild)
{
    Puts("OnDiscordVoiceChannelEffect Works!");
}
```

```csharp
public const string OnDiscordVoiceChannelEffect;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildVoiceServerUpdated field

Called when the voice server in a guild channel is updated

```csharp
void OnDiscordGuildVoiceServerUpdated(VoiceServerUpdatedEvent voice, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildVoiceServerUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildVoiceServerUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildWebhookUpdated field

Called when a webhook ins a guild is updated

```csharp
void OnDiscordGuildWebhookUpdated(WebhooksUpdatedEvent webhook, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildWebhookUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildWebhookUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectInviteCreated field

Called when an invite to a direct message channel is created `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectInviteCreated(InviteCreatedEvent invite, DiscordChannel channel)
{
    Puts("OnDiscordDirectInviteCreated Works!");
}
```

```csharp
public const string OnDiscordDirectInviteCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildInviteCreated field

Called when an invite to a guild channel is created

```csharp
void OnDiscordGuildInviteCreated(InviteCreatedEvent invite, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildInviteCreated Works!");
}
```

```csharp
public const string OnDiscordGuildInviteCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordDirectInviteDeleted field

Called when an invite to a direct message channel is deleted `channel` may be null if we haven't seen it yet

```csharp
void OnDiscordDirectInviteDeleted(InviteCreatedEvent invite, DiscordChannel channel)
{
    Puts("OnDiscordDirectInviteDeleted Works!");
}
```

```csharp
public const string OnDiscordDirectInviteDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildInviteDeleted field

Called when an invite to a guild channel is deleted

```csharp
void OnDiscordGuildInviteDeleted(InviteCreatedEvent invite, DiscordChannel channel, DiscordGuild guild)
{
    Puts("OnDiscordGuildInviteDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildInviteDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordApplicationCommandPermissionsUpdated field

Called when the bots application command permission have been updated

```csharp
void OnDiscordApplicationCommandPermissionsUpdated(CommandPermissions permissions)
{
    Puts("OnDiscordInteractionCreated Works!");
}
```

```csharp
public const string OnDiscordApplicationCommandPermissionsUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordInteractionCreated field

Called when a discord interaction occurs by a user

```csharp
void OnDiscordInteractionCreated(DiscordInteraction interaction)
{
    Puts("OnDiscordInteractionCreated Works!");
}
```

```csharp
public const string OnDiscordInteractionCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildIntegrationCreated field

Called when a new integration is created a guild

```csharp
void OnDiscordGuildIntegrationCreated(IntegrationCreatedEvent integration, DiscordGuild guild)
{
    Puts("OnDiscordGuildIntegrationCreated Works!");
}
```

```csharp
public const string OnDiscordGuildIntegrationCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildIntegrationUpdated field

Called when an integration is updated on a guild

```csharp
void OnDiscordGuildIntegrationUpdated(IntegrationUpdatedEvent interaction, DiscordGuild guild)
{
    Puts("OnDiscordGuildIntegrationUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildIntegrationUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildIntegrationDeleted field

Called when an integration is deleted on a guild

```csharp
void OnDiscordGuildIntegrationDeleted(IntegrationDeletedEvent interaction, DiscordGuild guild)
{
    Puts("OnDiscordGuildIntegrationDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildIntegrationDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadCreated field

Called when a guild thread is created

```csharp
void OnDiscordGuildThreadCreated(DiscordChannel thread, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadCreated Works!");
}
```

```csharp
public const string OnDiscordGuildThreadCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadUpdated field

Called when a guild thread is updated

```csharp
void OnDiscordGuildThreadUpdated(DiscordChannel thread, DiscordChannel previous, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildThreadUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadDeleted field

Called when a guild thread is deleted

```csharp
void OnDiscordGuildThreadDeleted(DiscordChannel thread, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildThreadDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadListSynced field

Called when a guild thread list is synced

```csharp
void OnDiscordGuildThreadListSynced(ThreadListSyncEvent sync, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadListSynced Works!");
}
```

```csharp
public const string OnDiscordGuildThreadListSynced;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadMemberUpdated field

Called when a thread member is updated

```csharp
void OnDiscordGuildThreadMemberUpdated(ThreadMember member, DiscordChannel thread, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadMemberUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildThreadMemberUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildThreadMembersUpdated field

Called when thread members are updated

```csharp
void OnDiscordGuildThreadMembersUpdated(ThreadMembersUpdatedEvent members, DiscordGuild guild)
{
    Puts("OnDiscordGuildThreadMembersUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildThreadMembersUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordStageInstanceCreated field

Called when a stage instance is created

```csharp
void OnDiscordStageInstanceCreated(StageInstance stage, DiscordGuild guild)
{
    Puts("OnDiscordStageInstanceCreated Works!");
}
```

```csharp
public const string OnDiscordStageInstanceCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordStageInstanceUpdated field

Called when a stage instance is updated

```csharp
void OnDiscordStageInstanceUpdated(StageInstance stage, StageInstance previous, DiscordGuild guild)
{
    Puts("OnDiscordStageInstanceUpdated Works!");
}
```

```csharp
public const string OnDiscordStageInstanceUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordStageInstanceDeleted field

Called when a stage instance is deleted

```csharp
void OnDiscordStageInstanceDeleted(StageInstance stage, DiscordGuild guild)
{
    Puts("OnDiscordStageInstanceDeleted Works!");
}
```

```csharp
public const string OnDiscordStageInstanceDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordSubscriptionCreated field

Called when a subscription is created

```csharp
void OnDiscordSubscriptionCreated(DiscordSubscription subscription)
{
    Puts("OnDiscordSubscriptionCreated Works!");
}
```

```csharp
public const string OnDiscordSubscriptionCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordSubscriptionUpdated field

Called when a subscription is updated

```csharp
void OnDiscordSubscriptionUpdated(DiscordSubscription subscription)
{
    Puts("OnDiscordSubscriptionUpdated Works!");
}
```

```csharp
public const string OnDiscordSubscriptionUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordSubscriptionDeleted field

Called when a subscription is deleted

```csharp
void OnDiscordSubscriptionDeleted(DiscordSubscription subscription)
{
    Puts("OnDiscordSubscriptionDeleted Works!");
}
```

```csharp
public const string OnDiscordSubscriptionDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildSoundboardCreated field

Called when a guild soundboard is created

```csharp
void OnDiscordGuildSoundboardCreated(DiscordSoundboard soundboard, DiscordGuild guid)
{
    Puts("OnDiscordGuildSoundboardCreated Works!");
}
```

```csharp
public const string OnDiscordGuildSoundboardCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildSoundboardUpdated field

Called when a guild soundboard is updated

```csharp
void OnDiscordGuildSoundboardUpdated(DiscordSoundboard soundboard, DiscordGuild guid)
{
    Puts("OnDiscordGuildSoundboardUpdated Works!");
}
```

```csharp
public const string OnDiscordGuildSoundboardUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGuildSoundboardDeleted field

Called when a guild soundboard is deleted

```csharp
void OnDiscordGuildSoundboardDeleted(DiscordSoundboard soundboard, DiscordGuild guid)
{
    Puts("OnDiscordGuildSoundboardDeleted Works!");
}
```

```csharp
public const string OnDiscordGuildSoundboardDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordGetGuildSoundboardSounds field

Called when a guild soundboard is deleted

```csharp
void OnDiscordGetGuildSoundboardSounds(List<DiscordSoundboard> soundboard, DiscordGuild guid)
{
    Puts("OnDiscordGetGuildSoundboardSounds Works!");
}
```

```csharp
public const string OnDiscordGetGuildSoundboardSounds;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordAutoModRuleCreated field

Called when an AutoMod rule is created in a guild

```csharp
void OnDiscordAutoModRuleCreated(AutoModRule rule, DiscordGuild guild)
{
    Puts("OnDiscordAutoModRuleCreated Works!");
}
```

```csharp
public const string OnDiscordAutoModRuleCreated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordAutoModRuleUpdated field

Called when an AutoMod rule is updated on a guild

```csharp
void OnDiscordAutoModRuleUpdated(AutoModRule rule, DiscordGuild guild)
{
    Puts("OnDiscordAutoModRuleUpdated Works!");
}
```

```csharp
public const string OnDiscordAutoModRuleUpdated;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordAutoModRuleDeleted field

Called when an AutoMod rule is deleted from a guild

```csharp
void OnDiscordAutoModRuleDeleted(AutoModRule rule, DiscordGuild guild)
{
    Puts("OnDiscordAutoModRuleDeleted Works!");
}
```

```csharp
public const string OnDiscordAutoModRuleDeleted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordAutoModActionExecuted field

Called when an AutoMod rule is executed on a guild

```csharp
void OnDiscordAutoModActionExecuted(AutoModActionExecutionEvent rule, DiscordGuild guild)
{
    Puts("OnDiscordAutoModActionExecuted Works!");
}
```

```csharp
public const string OnDiscordAutoModActionExecuted;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordPollVoteAdded field

Called when we receive an event we do not handle yet. If you need this event, you can listen to it using this hook until we support it Please create an issue on uMod if this error ever occurs

```csharp
void OnDiscordPollVoteAdded(MessagePollVoteAddedEvent vote, DiscordGuild guild)
{
    Puts("OnDiscordPollVoteAdded Works!");
}
```

```csharp
public const string OnDiscordPollVoteAdded;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordPollVoteRemoved field

```csharp
public const string OnDiscordPollVoteRemoved;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnDiscordUnhandledCommand field

```csharp
void OnDiscordUnhandledCommand(EventPayload payload)
{
    Puts("OnDiscordUnhandledCommand Works!");
}
```

```csharp
public const string OnDiscordUnhandledCommand;
```

## See Also

* class [DiscordExtHooks](./DiscordExtHooks.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
