# CommandOption class

Represents [ApplicationCommandOption](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-structure)

```csharp
public class CommandOption
```

## Public Members

| name | description |
| --- | --- |
| [CommandOption](#commandoption-constructor)() | Constructor |
| [CommandOption](#commandoption-constructor)(…) | Constructor |
| [Autocomplete](#autocomplete-property) { get; set; } | If autocomplete interactions are enabled for this `STRING`, `INTEGER`, or `NUMBER` type option |
| [ChannelTypes](#channeltypes-property) { get; set; } | If the option is a channel type, the channels shown will be restricted to these types See [`ChannelType`](./ChannelType.md) |
| [Choices](#choices-property) { get; set; } | Choices for STRING, INTEGER, and NUMBER types for the user to pick from, max 25 See [`CommandOptionChoice`](./CommandOptionChoice.md) |
| [Description](#description-property) { get; set; } | Description the command option (1-100 characters) |
| [DescriptionLocalizations](#descriptionlocalizations-property) { get; set; } | Localization dictionary for the description field. Values follow the same restrictions as description |
| [MaxLength](#maxlength-property) { get; set; } | For option type STRING, the maximum allowed length (minimum of 1) |
| [MaxValue](#maxvalue-property) { get; set; } | If the option is an INTEGER or NUMBER type, the maximum value permitted |
| [MinLength](#minlength-property) { get; set; } | For option type STRING, the minimum allowed length (minimum of 0) |
| [MinValue](#minvalue-property) { get; set; } | If the option is an INTEGER or NUMBER type, the minimum value permitted |
| [Name](#name-property) { get; set; } | Name of the command option (1-32 characters) |
| [NameLocalizations](#namelocalizations-property) { get; set; } | Localization dictionary for the name field. Values follow the same restrictions as name |
| [Options](#options-property) { get; set; } | If the option is a subcommand or subcommand group type, these nested options will be the parameters See [`CommandOption`](./CommandOption.md) |
| [Required](#required-property) { get; set; } | If the parameter is required or optional Defaults to false |
| [Type](#type-property) { get; set; } | Type of option See [`CommandOptionType`](./CommandOptionType.md) |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [CommandOption.cs](../../../../Oxide.Ext.Discord/Entities/CommandOption.cs)
   
   
# CommandOption constructor (1 of 2)

Constructor

```csharp
public CommandOption()
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CommandOption constructor (2 of 2)

Constructor

```csharp
public CommandOption(string name, string description, CommandOptionType type, 
    List<CommandOption> options = null)
```

## See Also

* enum [CommandOptionType](./CommandOptionType.md)
* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

Type of option See [`CommandOptionType`](./CommandOptionType.md)

```csharp
public CommandOptionType Type { get; set; }
```

## See Also

* enum [CommandOptionType](./CommandOptionType.md)
* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the command option (1-32 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NameLocalizations property

Localization dictionary for the name field. Values follow the same restrictions as name

```csharp
public Hash<string, string> NameLocalizations { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

Description the command option (1-100 characters)

```csharp
public string Description { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DescriptionLocalizations property

Localization dictionary for the description field. Values follow the same restrictions as description

```csharp
public Hash<string, string> DescriptionLocalizations { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Required property

If the parameter is required or optional Defaults to false

```csharp
public bool? Required { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Choices property

Choices for STRING, INTEGER, and NUMBER types for the user to pick from, max 25 See [`CommandOptionChoice`](./CommandOptionChoice.md)

```csharp
public List<CommandOptionChoice> Choices { get; set; }
```

## See Also

* class [CommandOptionChoice](./CommandOptionChoice.md)
* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Options property

If the option is a subcommand or subcommand group type, these nested options will be the parameters See [`CommandOption`](./CommandOption.md)

```csharp
public List<CommandOption> Options { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChannelTypes property

If the option is a channel type, the channels shown will be restricted to these types See [`ChannelType`](./ChannelType.md)

```csharp
public List<ChannelType> ChannelTypes { get; set; }
```

## See Also

* enum [ChannelType](./ChannelType.md)
* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MinValue property

If the option is an INTEGER or NUMBER type, the minimum value permitted

```csharp
public double? MinValue { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxValue property

If the option is an INTEGER or NUMBER type, the maximum value permitted

```csharp
public double? MaxValue { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MinLength property

For option type STRING, the minimum allowed length (minimum of 0)

```csharp
public int? MinLength { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxLength property

For option type STRING, the maximum allowed length (minimum of 1)

```csharp
public int? MaxLength { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Autocomplete property

If autocomplete interactions are enabled for this `STRING`, `INTEGER`, or `NUMBER` type option

```csharp
public bool? Autocomplete { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
