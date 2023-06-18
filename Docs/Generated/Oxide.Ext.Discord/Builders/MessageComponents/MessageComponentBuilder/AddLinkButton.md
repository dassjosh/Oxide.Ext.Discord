# MessageComponentBuilder.AddLinkButton method

Adds a link button to the current action row

```csharp
public MessageComponentBuilder AddLinkButton(string label, string url, bool disabled = false, 
    bool addToNewRow = false, DiscordEmoji emoji = null)
```

| parameter | description |
| --- | --- |
| label | Text on the button |
| url | URL for the button |
| disabled | if the button should be disabled |
| addToNewRow | Show the button be added to a new row |
| emoji | Emoji to display on the button |

## Return Value

[`MessageComponentBuilder`](../MessageComponentBuilder.md)

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Thrown if the button goes outside the max number of action rows |

## See Also

* class [DiscordEmoji](../../../Entities/Emojis/DiscordEmoji.md)
* class [MessageComponentBuilder](../MessageComponentBuilder.md)
* namespace [Oxide.Ext.Discord.Builders.MessageComponents](../MessageComponentBuilder.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->