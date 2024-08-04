# TimeSpanPlaceholders class

TimeSpan placeholders

```csharp
public static class TimeSpanPlaceholders
```

## Public Members

| name | description |
| --- | --- |
| static [Days](#days-method)(…) | Days placeholder |
| static [Formatted](#formatted-method)(…) | Formats Timespan into a text string placeholder Text is localized if used with DiscordInteraction or IPlayer Ex: 1 days 2 hours 3 minutes 4 seconds Ex: 2 hour 0 minutes 53 seconds |
| static [Hours](#hours-method)(…) | Hours placeholder |
| static [Milliseconds](#milliseconds-method)(…) | Milliseconds placeholder |
| static [Minutes](#minutes-method)(…) | Minutes placeholder |
| static [RegisterPlaceholders](#registerplaceholders-method)(…) | Registers placeholders for the given plugin. |
| static [Seconds](#seconds-method)(…) | Seconds placeholder |
| static [TotalDays](#totaldays-method)(…) | TotalDays placeholder |
| static [TotalHours](#totalhours-method)(…) | TotalHours placeholder |
| static [TotalMilliseconds](#totalmilliseconds-method)(…) | TotalMilliseconds placeholder |
| static [TotalMinutes](#totalminutes-method)(…) | TotalMinutes placeholder |
| static [TotalSeconds](#totalseconds-method)(…) | TotalSeconds placeholder |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [TimeSpanPlaceholders.cs](../../../../Oxide.Ext.Discord/Libraries/TimeSpanPlaceholders.cs)
   
   
# Days method

Days placeholder

```csharp
public static int Days(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Formatted method

Formats Timespan into a text string placeholder Text is localized if used with DiscordInteraction or IPlayer Ex: 1 days 2 hours 3 minutes 4 seconds Ex: 2 hour 0 minutes 53 seconds

```csharp
public static string Formatted(PlaceholderState state, TimeSpan time)
```

## See Also

* class [PlaceholderState](./PlaceholderState.md)
* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Hours method

Hours placeholder

```csharp
public static int Hours(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Minutes method

Minutes placeholder

```csharp
public static int Minutes(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Seconds method

Seconds placeholder

```csharp
public static int Seconds(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Milliseconds method

Milliseconds placeholder

```csharp
public static int Milliseconds(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalDays method

TotalDays placeholder

```csharp
public static double TotalDays(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalHours method

TotalHours placeholder

```csharp
public static double TotalHours(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalMinutes method

TotalMinutes placeholder

```csharp
public static double TotalMinutes(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalSeconds method

TotalSeconds placeholder

```csharp
public static double TotalSeconds(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalMilliseconds method

TotalMilliseconds placeholder

```csharp
public static double TotalMilliseconds(TimeSpan time)
```

## See Also

* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RegisterPlaceholders method

Registers placeholders for the given plugin.

```csharp
public static void RegisterPlaceholders(Plugin plugin, TimespanKeys keys, 
    PlaceholderDataKey dataKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin to register placeholders for |
| keys | Prefix to use for the placeholders |
| dataKey | Data key in [`PlaceholderData`](./PlaceholderData.md) |

## See Also

* class [TimespanKeys](./TimespanKeys.md)
* struct [PlaceholderDataKey](./PlaceholderDataKey.md)
* class [TimeSpanPlaceholders](./TimeSpanPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
