# BaseMessageBuilder&lt;TMessage,TBuilder&gt; class

Represents a builder for [`BaseMessageCreate`](../../../Entities/Messages/BaseMessageCreate.md)

```csharp
public abstract class BaseMessageBuilder<TMessage, TBuilder>
    where TMessage : BaseMessageCreate
    where TBuilder : BaseMessageBuilder
```

| parameter | description |
| --- | --- |
| TMessage |  |
| TBuilder |  |

## Public Members

| name | description |
| --- | --- |
| virtual [AddActionRow](BaseMessageBuilder-2/AddActionRow.md)(…) | Adds a single [`ActionRowComponent`](../../../Entities/Interactions/MessageComponents/ActionRowComponent.md) |
| virtual [AddAllowedMentions](BaseMessageBuilder-2/AddAllowedMentions.md)(…) | Adds [`AllowedMention`](../../../Entities/Messages/AllowedMentions/AllowedMention.md) to the response |
| virtual [AddAttachment](BaseMessageBuilder-2/AddAttachment.md)(…) | Adds an attachment to the message |
| virtual [AddComponents](BaseMessageBuilder-2/AddComponents.md)(…) | Adds a collection MessageComponents/&gt; (2 methods) |
| virtual [AddContent](BaseMessageBuilder-2/AddContent.md)(…) | Adds message text |
| virtual [AddEmbed](BaseMessageBuilder-2/AddEmbed.md)(…) | Adds a [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md) (2 methods) |
| virtual [AddEmbeds](BaseMessageBuilder-2/AddEmbeds.md)(…) | Adds a collection of [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md) to the response |
| virtual [AsTts](BaseMessageBuilder-2/AsTts.md)(…) | Marks the message As Text-To-Speech |
| [Build](BaseMessageBuilder-2/Build.md)() | Returns the built message |
| virtual [SuppressEmbeds](BaseMessageBuilder-2/SuppressEmbeds.md)() | Suppresses embeds on this response |

## Protected Members

| name | description |
| --- | --- |
| [BaseMessageBuilder](BaseMessageBuilder-2/BaseMessageBuilder.md)(…) | Constructor |
| readonly [Builder](BaseMessageBuilder-2/Builder.md) | This builder |
| readonly [Message](BaseMessageBuilder-2/Message.md) | Message the builder is for |

## See Also

* class [BaseMessageCreate](../../../Entities/Messages/BaseMessageCreate.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [BaseMessageBuilder.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Builders/Messages/BaseBuilders/BaseMessageBuilder.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->