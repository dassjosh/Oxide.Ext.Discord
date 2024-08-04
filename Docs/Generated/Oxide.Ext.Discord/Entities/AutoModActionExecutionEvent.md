# AutoModActionExecutionEvent class

Represents [Auto Moderation Action Execution Event](https://discord.com/developers/docs/topics/gateway#auto-moderation-action-execution-auto-moderation-action-execution-event-fields)

```csharp
public class AutoModActionExecutionEvent
```

## Public Members

| name | description |
| --- | --- |
| [AutoModActionExecutionEvent](#automodactionexecutionevent-constructor)() | The default constructor. |
| [Action](#action-property) { get; set; } | The action which was executed |
| [AlertSystemMessageId](#alertsystemmessageid-property) { get; set; } | The id of any system auto moderation messages posted as a result of this action |
| [Content](#content-property) { get; set; } | The user generated text content |
| [GuildId](#guildid-property) { get; set; } | Id of the guild in which action was executed |
| [MatchedContent](#matchedcontent-property) { get; set; } | The substring in content that triggered the rule |
| [MatchedKeyword](#matchedkeyword-property) { get; set; } | The word or phrase configured in the rule that triggered the rule |
| [MessageId](#messageid-property) { get; set; } | Id of any user message which content belongs to |
| [RuleId](#ruleid-property) { get; set; } | Id of the rule which action belongs to |
| [RuleTriggerType](#ruletriggertype-property) { get; set; } | The [`AutoModTriggerType`](./AutoModTriggerType.md) of rule which was triggered |
| [UserId](#userid-property) { get; set; } | Id of the user which generated the content which triggered the rule |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [AutoModActionExecutionEvent.cs](../../../../Oxide.Ext.Discord/Entities/AutoModActionExecutionEvent.cs)
   
   
# AutoModActionExecutionEvent constructor

The default constructor.

```csharp
public AutoModActionExecutionEvent()
```

## See Also

* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

Id of the guild in which action was executed

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Action property

The action which was executed

```csharp
public AutoModAction Action { get; set; }
```

## See Also

* class [AutoModAction](./AutoModAction.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RuleId property

Id of the rule which action belongs to

```csharp
public Snowflake RuleId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RuleTriggerType property

The [`AutoModTriggerType`](./AutoModTriggerType.md) of rule which was triggered

```csharp
public AutoModTriggerType RuleTriggerType { get; set; }
```

## See Also

* enum [AutoModTriggerType](./AutoModTriggerType.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UserId property

Id of the user which generated the content which triggered the rule

```csharp
public Snowflake? UserId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MessageId property

Id of any user message which content belongs to

```csharp
public Snowflake? MessageId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AlertSystemMessageId property

The id of any system auto moderation messages posted as a result of this action

```csharp
public Snowflake? AlertSystemMessageId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Content property

The user generated text content

```csharp
public string Content { get; set; }
```

## See Also

* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MatchedKeyword property

The word or phrase configured in the rule that triggered the rule

```csharp
public string MatchedKeyword { get; set; }
```

## See Also

* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MatchedContent property

The substring in content that triggered the rule

```csharp
public string MatchedContent { get; set; }
```

## See Also

* class [AutoModActionExecutionEvent](./AutoModActionExecutionEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
