# BaseClient class

BaseClient that can connect to discord

```csharp
public abstract class BaseClient
```

## Public Members

| name | description |
| --- | --- |
| [Initialized](#initialized-property) { get; protected set; } | If the connection is initialized and not disconnected |
| [Rest](#rest-property) { get; protected set; } | Rest handler for all discord API calls |
| readonly [Clients](#clients-field) | List of all clients that are using this bot client |
| virtual [AddClient](#addclient-method)(…) | Add a [`DiscordClient`](./DiscordClient.md) to this bot / webhook client |
| [GetClientPluginList](#getclientpluginlist-method)() | Returns the list of plugins for this bot |
| virtual [RemoveClient](#removeclient-method)(…) | Removes the [`DiscordClient`](./DiscordClient.md) from this bot / webhook client |

## Protected Members

| name | description |
| --- | --- |
| [BaseClient](#baseclient-constructor)() | Constructor |
| readonly [_clients](#_clients-field) | List of all clients using this client |

## See Also

* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseClient.cs](../../../../Oxide.Ext.Discord/Clients/BaseClient.cs)
   
   
# GetClientPluginList method

Returns the list of plugins for this bot

```csharp
public string GetClientPluginList()
```

## See Also

* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddClient method

Add a [`DiscordClient`](./DiscordClient.md) to this bot / webhook client

```csharp
public virtual void AddClient(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to add |

## Return Value

True if this is the initial setup of the client; false otherwise

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Thrown if [`DiscordClient`](./DiscordClient.md) already has been added to this bot / webhook client |

## See Also

* class [DiscordClient](./DiscordClient.md)
* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RemoveClient method

Removes the [`DiscordClient`](./DiscordClient.md) from this bot / webhook client

```csharp
public virtual bool RemoveClient(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to remove |

## Return Value

returns true if the client is shutting down; false otherwise

## See Also

* class [DiscordClient](./DiscordClient.md)
* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BaseClient constructor

Constructor

```csharp
protected BaseClient()
```

## See Also

* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Rest property

Rest handler for all discord API calls

```csharp
public RestHandler Rest { get; protected set; }
```

## See Also

* class [RestHandler](../Rest/RestHandler.md)
* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Initialized property

If the connection is initialized and not disconnected

```csharp
public bool Initialized { get; protected set; }
```

## See Also

* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# _clients field

List of all clients using this client

```csharp
protected readonly List<DiscordClient> _clients;
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Clients field

List of all clients that are using this bot client

```csharp
public readonly IReadOnlyList<DiscordClient> Clients;
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* class [BaseClient](./BaseClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
