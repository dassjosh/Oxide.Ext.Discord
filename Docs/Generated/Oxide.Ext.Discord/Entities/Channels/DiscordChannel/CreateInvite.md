# DiscordChannel.CreateInvite method

Create a new invite object for the channel. Only usable for guild channels. Requires the CREATE_INSTANT_INVITE permission. See [Create Channel Invite](https://discord.com/developers/docs/resources/channel#create-channel-invite)

```csharp
public IPromise<DiscordInvite> CreateInvite(DiscordClient client, ChannelInvite invite)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| invite | Invite to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise-1.md)
* class [DiscordInvite](../../Invites/DiscordInvite.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* class [ChannelInvite](../ChannelInvite.md)
* class [DiscordChannel](../DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](../DiscordChannel.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->