# ThreadArchivedLookup class

Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-public-archived-threads-query-string-params) within Discord. Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-private-archived-threads-query-string-params) within Discord. Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads-query-string-params) within Discord.

```csharp
public class ThreadArchivedLookup : IDiscordQueryString
```

## Public Members

| name | description |
| --- | --- |
| [ThreadArchivedLookup](#threadarchivedlookup-constructor)() | The default constructor. |
| [Before](#before-property) { get; set; } | Returns threads before this timestamp |
| [Limit](#limit-property) { get; set; } | Optional maximum number of threads to return |
| [ToQueryString](#toquerystring-method)() |  |

## See Also

* interface [IDiscordQueryString](../Interfaces/IDiscordQueryString.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ThreadArchivedLookup.cs](../../../../Oxide.Ext.Discord/Entities/ThreadArchivedLookup.cs)
   
   
# ToQueryString method

```csharp
public string ToQueryString()
```

## See Also

* class [ThreadArchivedLookup](./ThreadArchivedLookup.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ThreadArchivedLookup constructor

The default constructor.

```csharp
public ThreadArchivedLookup()
```

## See Also

* class [ThreadArchivedLookup](./ThreadArchivedLookup.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Before property

Returns threads before this timestamp

```csharp
public DateTime? Before { get; set; }
```

## See Also

* class [ThreadArchivedLookup](./ThreadArchivedLookup.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Limit property

Optional maximum number of threads to return

```csharp
public int? Limit { get; set; }
```

## See Also

* class [ThreadArchivedLookup](./ThreadArchivedLookup.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
