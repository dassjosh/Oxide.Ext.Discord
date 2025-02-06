# RecurrenceRule class

Represents [Guild Scheduled Event Recurrence Rule Object](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object)

```csharp
public class RecurrenceRule
```

## Public Members

| name | description |
| --- | --- |
| [RecurrenceRule](#recurrencerule-constructor)() | The default constructor. |
| [ByMonth](#bymonth-property) { get; set; } | Set of specific months to recur on |
| [ByMonthDay](#bymonthday-property) { get; set; } | Set of specific dates within a month to recur on |
| [ByNWeekday](#bynweekday-property) { get; set; } | List of specific days within a specific week (1-5) to recur on |
| [ByWeekday](#byweekday-property) { get; set; } | Set of specific days within a week for the event to recur on |
| [ByYearDay](#byyearday-property) { get; set; } | Set of days within a year to recur on (1-364) |
| [Count](#count-property) { get; set; } | The total amount of times that the event is allowed to recur before stopping |
| [End](#end-property) { get; set; } | Ending time of the recurrence interval |
| [Frequency](#frequency-property) { get; set; } | Ending time of the recurrence interval |
| [Interval](#interval-property) { get; set; } | The spacing between the events, defined by frequency. For example, frequency of WEEKLY and an interval of 2 would be "every-other week" |
| [Start](#start-property) { get; set; } | Starting time of the recurrence interval |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RecurrenceRule.cs](../../../../Oxide.Ext.Discord/Entities/RecurrenceRule.cs)
   
   
# RecurrenceRule constructor

The default constructor.

```csharp
public RecurrenceRule()
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Start property

Starting time of the recurrence interval

```csharp
public DateTime Start { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# End property

Ending time of the recurrence interval

```csharp
public DateTime? End { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Frequency property

Ending time of the recurrence interval

```csharp
public RecurrenceRuleFrequency Frequency { get; set; }
```

## See Also

* enum [RecurrenceRuleFrequency](./RecurrenceRuleFrequency.md)
* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Interval property

The spacing between the events, defined by frequency. For example, frequency of WEEKLY and an interval of 2 would be "every-other week"

```csharp
public int Interval { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ByWeekday property

Set of specific days within a week for the event to recur on

```csharp
public List<RecurrenceRuleWeekday> ByWeekday { get; set; }
```

## See Also

* enum [RecurrenceRuleWeekday](./RecurrenceRuleWeekday.md)
* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ByNWeekday property

List of specific days within a specific week (1-5) to recur on

```csharp
public List<RecurrenceRuleNWeekday> ByNWeekday { get; set; }
```

## See Also

* class [RecurrenceRuleNWeekday](./RecurrenceRuleNWeekday.md)
* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ByMonth property

Set of specific months to recur on

```csharp
public List<RecurrenceRuleMonth> ByMonth { get; set; }
```

## See Also

* enum [RecurrenceRuleMonth](./RecurrenceRuleMonth.md)
* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ByMonthDay property

Set of specific dates within a month to recur on

```csharp
public List<int> ByMonthDay { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ByYearDay property

Set of days within a year to recur on (1-364)

```csharp
public List<int> ByYearDay { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Count property

The total amount of times that the event is allowed to recur before stopping

```csharp
public int? Count { get; set; }
```

## See Also

* class [RecurrenceRule](./RecurrenceRule.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
