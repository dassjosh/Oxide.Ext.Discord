# DiscordGuild.EditSticker method

Modify the given sticker. Requires the MANAGE_EMOJIS_AND_STICKERS permission. Returns the updated sticker object on success. See [Modify Guild Sticker](https://discord.com/developers/docs/resources/sticker#modify-guild-sticker)

```csharp
public IPromise<DiscordSticker> EditSticker(DiscordClient client, DiscordSticker sticker)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| sticker | Sticker to modify |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise-1.md)
* class [DiscordSticker](../../Stickers/DiscordSticker.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* class [DiscordGuild](../DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds](../DiscordGuild.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->