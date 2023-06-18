# DiscordMessage.GetMessage method

Returns a specific message in the channel. If operating on a guild channel, this endpoint requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user. See [Get Channel Messages](https://discord.com/developers/docs/resources/channel#get-channel-message)

```csharp
public static IPromise<DiscordMessage> GetMessage(DiscordClient client, Snowflake channelId, 
    Snowflake messageId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| channelId | Channel ID where the message is |
| messageId | Message ID of the message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise-1.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [DiscordMessage](../DiscordMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Messages](../DiscordMessage.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->