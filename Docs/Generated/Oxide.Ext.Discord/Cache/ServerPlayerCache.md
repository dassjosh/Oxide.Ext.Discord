# ServerPlayerCache class

Cache for server IPlayer

```csharp
public sealed class ServerPlayerCache : Singleton<ServerPlayerCache>
```

## Public Members

| name | description |
| --- | --- |
| [GetAllPlayers](#getallplayers-method)(…) | Returns an IEnumerable matching player names |
| [GetOnlinePlayers](#getonlineplayers-method)(…) | Returns an IEnumerable matching player names that are online |
| [GetPlayerById](#getplayerbyid-method)(…) | Returns the IPlayer for the given ID |

## See Also

* class [Singleton&lt;T&gt;](../Types/Singleton%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ServerPlayerCache.cs](../../../../Oxide.Ext.Discord/Cache/ServerPlayerCache.cs)
   
   
# GetPlayerById method

Returns the IPlayer for the given ID

```csharp
public IPlayer GetPlayerById(string id)
```

| parameter | description |
| --- | --- |
| id | ID of the player |

## Return Value

IPlayer

## See Also

* class [ServerPlayerCache](./ServerPlayerCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetOnlinePlayers method

Returns an IEnumerable matching player names that are online

```csharp
public IEnumerable<IPlayer> GetOnlinePlayers(string name)
```

| parameter | description |
| --- | --- |
| name | Name to match on |

## See Also

* class [ServerPlayerCache](./ServerPlayerCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetAllPlayers method

Returns an IEnumerable matching player names

```csharp
public IEnumerable<IPlayer> GetAllPlayers(string name)
```

| parameter | description |
| --- | --- |
| name | Name to match on |

## See Also

* class [ServerPlayerCache](./ServerPlayerCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
