# ScheduledEventUpdate class

Represents [Guild Scheduled Event Update](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event) within discord

```csharp
public class ScheduledEventUpdate
```

## Public Members

| name | description |
| --- | --- |
| [ScheduledEventUpdate](ScheduledEventUpdate/ScheduledEventUpdate.md)() | The default constructor. |
| [ChannelId](ScheduledEventUpdate/ChannelId.md) { get; set; } | The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is External |
| [Description](ScheduledEventUpdate/Description.md) { get; set; } | The description of the scheduled event (1-1000 characters) |
| [EntityMetadata](ScheduledEventUpdate/EntityMetadata.md) { get; set; } | Additional metadata for the guild scheduled event |
| [EntityType](ScheduledEventUpdate/EntityType.md) { get; set; } | The type of the scheduled event |
| [Name](ScheduledEventUpdate/Name.md) { get; set; } | The name of the scheduled event (1-100 characters) |
| [PrivacyLevel](ScheduledEventUpdate/PrivacyLevel.md) { get; set; } | The privacy level of the scheduled event |
| [ScheduledEndTime](ScheduledEventUpdate/ScheduledEndTime.md) { get; set; } | The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent/EntityType.md) is EXTERNAL |
| [ScheduledStartTime](ScheduledEventUpdate/ScheduledStartTime.md) { get; set; } | The time the scheduled event will start |
| [Status](ScheduledEventUpdate/Status.md) { get; set; } | The status of the scheduled event |
| [Validate](ScheduledEventUpdate/Validate.md)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [ScheduledEventUpdate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Guilds/ScheduledEvents/ScheduledEventUpdate.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->