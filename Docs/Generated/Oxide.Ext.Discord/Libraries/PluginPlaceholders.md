# PluginPlaceholders class

Plugin placeholders

```csharp
public static class PluginPlaceholders
```

## Public Members

| name | description |
| --- | --- |
| static [Author](#author-method)(…) | Author placeholder |
| static [Description](#description-method)(…) | Description placeholder |
| static [FullName](#fullname-method)(…) | Plugin) placeholder |
| static [HookTime](#hooktime-method)(…) | TotalHookTime placeholder |
| static [LangMessage](#langmessage-method)(…) | Lang message for a plugin |
| static [Name](#name-method)(…) | Name placeholder |
| static [RegisterPlaceholders](#registerplaceholders-method)(…) | Registers placeholders for the given plugin. |
| static [Title](#title-method)(…) | Title placeholder |
| static [Version](#version-method)(…) | Version placeholder |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [PluginPlaceholders.cs](../../../../Oxide.Ext.Discord/Libraries/PluginPlaceholders.cs)
   
   
# Name method

Name placeholder

```csharp
public static string Name(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Title method

Title placeholder

```csharp
public static string Title(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Author method

Author placeholder

```csharp
public static string Author(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Version method

Version placeholder

```csharp
public static string Version(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description method

Description placeholder

```csharp
public static string Description(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# FullName method

Plugin) placeholder

```csharp
public static string FullName(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HookTime method

TotalHookTime placeholder

```csharp
public static TimeSpan HookTime(Plugin plugin)
```

## See Also

* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LangMessage method

Lang message for a plugin

```csharp
public static string LangMessage(PlaceholderState state, Plugin plugin)
```

## See Also

* class [PlaceholderState](./PlaceholderState.md)
* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RegisterPlaceholders method

Registers placeholders for the given plugin.

```csharp
public static void RegisterPlaceholders(Plugin plugin, PluginKeys keys, PlaceholderDataKey dataKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin to register placeholders for |
| keys | Prefix to use for the placeholders |
| dataKey | Data key in [`PlaceholderData`](./PlaceholderData.md) |

## See Also

* class [PluginKeys](./PluginKeys.md)
* struct [PlaceholderDataKey](./PlaceholderDataKey.md)
* class [PluginPlaceholders](./PluginPlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
