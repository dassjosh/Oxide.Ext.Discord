# SystemChannelFlags enumeration

Represents [System Channel Flags](https://discord.com/developers/docs/resources/guild#guild-object-system-channel-flags)

```csharp
[Flags]
public enum SystemChannelFlags
```

## Values

| name | value | description |
| --- | --- | --- |
| SuppressJoinNotifications | `0x00000001` | Suppress member join notifications |
| SuppressPremiumSubscriptions | `0x00000002` | Suppress server boost notifications |
| SuppressGuildReminderNotifications | `0x00000004` | Suppress server setup tips |
| SuppressJoinNotificationReplies | `0x00000008` | Hide member join sticker reply buttons |
| SuppressRoleSubscriptionPurchaseNotifications | `0x00000010` | Suppress role subscription purchase and renewal notifications |
| SuppressRoleSubscriptionPurchaseNotificationReplies | `0x00000020` | Hide role subscription sticker reply buttons |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Guilds](./GuildsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [SystemChannelFlags.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Guilds/SystemChannelFlags.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->