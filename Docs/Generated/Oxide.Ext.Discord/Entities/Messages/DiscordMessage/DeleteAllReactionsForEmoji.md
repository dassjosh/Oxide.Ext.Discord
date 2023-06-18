# DiscordMessage.DeleteAllReactionsForEmoji method (1 of 2)

Deletes all the reactions for a given emoji on a message. This endpoint requires the MANAGE_MESSAGES permission to be present on the current user. Valid emoji formats are the unicode emoji character '😀' or for custom emoji format must be &lt;emojiName:emojiId&gt; See [Delete All Reactions for Emoji](https://discord.com/developers/docs/resources/channel#delete-all-reactions-for-emoji)

```csharp
public IPromise DeleteAllReactionsForEmoji(DiscordClient client, DiscordEmoji emoji)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emoji | Emoji to delete all reactions for |

## See Also

* interface [IPromise](../../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* class [DiscordEmoji](../../Emojis/DiscordEmoji.md)
* class [DiscordMessage](../DiscordMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Messages](../DiscordMessage.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---

# DiscordMessage.DeleteAllReactionsForEmoji method (2 of 2)

Deletes all the reactions for a given emoji on a message. This endpoint requires the MANAGE_MESSAGES permission to be present on the current user. Valid emoji formats are the unicode emoji character '😀' or for custom emoji format must be &lt;emojiName:emojiId&gt; See [Delete All Reactions for Emoji](https://discord.com/developers/docs/resources/channel#delete-all-reactions-for-emoji)

```csharp
public IPromise DeleteAllReactionsForEmoji(DiscordClient client, string emoji)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emoji | Emoji to delete all reactions for |

## See Also

* interface [IPromise](../../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* class [DiscordMessage](../DiscordMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Messages](../DiscordMessage.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->