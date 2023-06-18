# GuildScheduledEvent.Edit method

Modify a guild scheduled event. Returns the modified [`guild scheduled event`](../GuildScheduledEvent.md) object on success. See [Modify Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event)

```csharp
public IPromise<GuildScheduledEvent> Edit(DiscordClient client, Snowflake guildId, 
    Snowflake eventId, ScheduledEventUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to modify event in |
| eventId | Id of the event to update |
| update | Guild Scheduled Event to update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../../Interfaces/Promises/IPromise-1.md)
* class [DiscordClient](../../../../Clients/DiscordClient.md)
* struct [Snowflake](../../../Snowflake.md)
* class [ScheduledEventUpdate](../ScheduledEventUpdate.md)
* class [GuildScheduledEvent](../GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](../GuildScheduledEvent.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->