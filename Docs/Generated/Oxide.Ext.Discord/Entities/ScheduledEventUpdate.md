# ScheduledEventUpdate class

Represents [Guild Scheduled Event Update](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event) within discord

```csharp
public class ScheduledEventUpdate
```

## Public Members

| name | description |
| --- | --- |
| [ScheduledEventUpdate](#scheduledeventupdate-constructor)() | The default constructor. |
| [ChannelId](#channelid-property) { get; set; } | The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is External |
| [Description](#description-property) { get; set; } | The description of the scheduled event (1-1000 characters) |
| [EntityMetadata](#entitymetadata-property) { get; set; } | Additional metadata for the guild scheduled event |
| [EntityType](#entitytype-property) { get; set; } | The type of the scheduled event |
| [Name](#name-property) { get; set; } | The name of the scheduled event (1-100 characters) |
| [PrivacyLevel](#privacylevel-property) { get; set; } | The privacy level of the scheduled event |
| [ScheduledEndTime](#scheduledendtime-property) { get; set; } | The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent.md#entitytype-property) is EXTERNAL |
| [ScheduledStartTime](#scheduledstarttime-property) { get; set; } | The time the scheduled event will start |
| [Status](#status-property) { get; set; } | The status of the scheduled event |
| [Validate](#validate-method)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ScheduledEventUpdate.cs](../../../../Oxide.Ext.Discord/Entities/ScheduledEventUpdate.cs)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ScheduledEventUpdate constructor

The default constructor.

```csharp
public ScheduledEventUpdate()
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is External

```csharp
public Snowflake? ChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EntityMetadata property

Additional metadata for the guild scheduled event

```csharp
public ScheduledEventEntityMetadata EntityMetadata { get; set; }
```

## See Also

* class [ScheduledEventEntityMetadata](./ScheduledEventEntityMetadata.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

The name of the scheduled event (1-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PrivacyLevel property

The privacy level of the scheduled event

```csharp
public ScheduledEventPrivacyLevel? PrivacyLevel { get; set; }
```

## See Also

* enum [ScheduledEventPrivacyLevel](./ScheduledEventPrivacyLevel.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ScheduledStartTime property

The time the scheduled event will start

```csharp
public DateTime? ScheduledStartTime { get; set; }
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ScheduledEndTime property

The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent.md#entitytype-property) is EXTERNAL

```csharp
public DateTime? ScheduledEndTime { get; set; }
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

The description of the scheduled event (1-1000 characters)

```csharp
public string Description { get; set; }
```

## See Also

* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EntityType property

The type of the scheduled event

```csharp
public ScheduledEventEntityType? EntityType { get; set; }
```

## See Also

* enum [ScheduledEventEntityType](./ScheduledEventEntityType.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Status property

The status of the scheduled event

```csharp
public ScheduledEventStatus? Status { get; set; }
```

## See Also

* enum [ScheduledEventStatus](./ScheduledEventStatus.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
