# ScheduledEventCreate class

Represents [Guild Scheduled Event Create](https://discord.com/developers/docs/resources/guild-scheduled-event#create-guild-scheduled-event) within discord

```csharp
public class ScheduledEventCreate
```

## Public Members

| name | description |
| --- | --- |
| [ScheduledEventCreate](ScheduledEventCreate/ScheduledEventCreate.md)() | The default constructor. |
| [ChannelId](ScheduledEventCreate/ChannelId.md) { get; set; } | The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is External |
| [Description](ScheduledEventCreate/Description.md) { get; set; } | The description of the scheduled event (1-1000 characters) |
| [EntityMetadata](ScheduledEventCreate/EntityMetadata.md) { get; set; } | Additional metadata for the guild scheduled event |
| [EntityType](ScheduledEventCreate/EntityType.md) { get; set; } | The type of the scheduled event |
| [Image](ScheduledEventCreate/Image.md) { get; set; } | The cover image of the scheduled event |
| [Name](ScheduledEventCreate/Name.md) { get; set; } | The name of the scheduled event (1-100 characters) |
| [PrivacyLevel](ScheduledEventCreate/PrivacyLevel.md) { get; set; } | The privacy level of the scheduled event |
| [ScheduledEndTime](ScheduledEventCreate/ScheduledEndTime.md) { get; set; } | The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent/EntityType.md) is EXTERNAL |
| [ScheduledStartTime](ScheduledEventCreate/ScheduledStartTime.md) { get; set; } | The time the scheduled event will start |
| [Validate](ScheduledEventCreate/Validate.md)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [ScheduledEventCreate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Guilds/ScheduledEvents/ScheduledEventCreate.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->