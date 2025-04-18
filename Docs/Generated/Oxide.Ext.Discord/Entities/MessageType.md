# MessageType enumeration

Represents [Message Types](https://discord.com/developers/docs/resources/channel#message-object-message-types)

```csharp
public enum MessageType : byte
```

## Values

| name | value | description |
| --- | --- | --- |
| Default | `Default` | The default message type |
| RecipientAdd | `RecipientAdd` | The message when a recipient is added |
| RecipientRemove | `RecipientRemove` | The message when a recipient is removed |
| Call | `Call` | The message when a user is called |
| ChannelNameChange | `ChannelNameChange` | The message when a channel name is changed |
| ChannelIconChange | `ChannelIconChange` | The message when a channel icon is changed |
| ChannelPinnedMessage | `ChannelPinnedMessage` | The message when another message is pinned |
| UserJoin | `UserJoin` | The message when a new member joined |
| GuildBoost | `GuildBoost` | The message for when a user boosts a guild |
| GuildBoostTier1 | `GuildBoostTier1` | The message for when a guild reaches Tier 1 of Nitro boosts |
| GuildBoostTier2 | `GuildBoostTier2` | The message for when a guild reaches Tier 2 of Nitro boosts |
| GuildBoostTier3 | `GuildBoostTier3` | The message for when a guild reaches Tier 3 of Nitro boosts |
| ChannelFollowAdd | `ChannelFollowAdd` | The message for when a news channel subscription is added to a text channel |
| GuildDiscoveryDisqualified | `GuildDiscoveryDisqualified` | The message for when a guild discovery is disqualified |
| GuildDiscoveryRequalified | `GuildDiscoveryRequalified` | The message for when a guild discovery is requalified |
| GuildDiscoveryGracePeriodInitialWarning | `GuildDiscoveryGracePeriodInitialWarning` | The message for grace period initial warning |
| GuildDiscoveryGracePeriodFinalWarning | `GuildDiscoveryGracePeriodFinalWarning` | The message for grace period final warning |
| ThreadCreated | `ThreadCreated` | The message created a thread |
| Reply | `Reply` | The message for when the message is a reply |
| ChatInputCommand | `ChatInputCommand` | The message for when the message is an application command |
| ThreadStarterMessage | `ThreadStarterMessage` | Starter message for a thread |
| GuildInviteReminder | `GuildInviteReminder` | Reminder for a guild invite |
| ContextMenuCommand | `ContextMenuCommand` | Reminder for a guild invite |
| AutoModerationAction | `AutoModerationAction` | Message is an auto mod action |
| RoleSubscriptionPurchase | `RoleSubscriptionPurchase` | Message is a role subscription purchase |
| InteractionPremiumUpsell | `InteractionPremiumUpsell` | Message is a interaction premium upsell |
| StageStart | `StageStart` | Message is a stage start |
| StageEnd | `StageEnd` | Message is a stage end |
| StageSpeaker | `StageSpeaker` | Message is a stage speaker |
| StageRaiseHand | `StageRaiseHand` | Message is a stage raise hand |
| StageTopic | `StageTopic` | Message is a stage topic |
| GuildApplicationPremiumSubscription | `GuildApplicationPremiumSubscription` | Message is a Guild Application Premium Subscription |
| GuildIncidentAlertModeEnabled | `GuildIncidentAlertModeEnabled` | Message is a Guild Incident Alert Mode Enabled |
| GuildIncidentAlertModeDisabled | `GuildIncidentAlertModeDisabled` | Message is a Guild Incident Alert Mode Disabled |
| GuildIncidentReportRaid | `GuildIncidentReportRaid` | Message is a Guild Incident Report Raid |
| GuildIncidentReportFalseAlarm | `GuildIncidentReportFalseAlarm` | Message is a Guild Incident Report False Alarm |
| PurchaseNotification | `PurchaseNotification` | Message is a Purchase Notification |
| PollResult | `PurchaseNotification` | Message is a poll result |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [MessageType.cs](../../../../Oxide.Ext.Discord/Entities/MessageType.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
