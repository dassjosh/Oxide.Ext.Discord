# PluginId structure

Represents a Plugin ID

```csharp
public struct PluginId : IDebugLoggable, IEquatable<PluginId>
```

## Public Members

| name | description |
| --- | --- |
| [IsValid](#isvalid-property) { get; } | Returns if the PluginId is valid |
| readonly [Id](#id-field) | Hashcode value of the Plugin Name |
| override [Equals](#equals-method)(…) |  |
| [Equals](#equals-method)(…) |  |
| override [GetHashCode](#gethashcode-method)() |  |
| [LogDebug](#logdebug-method)(…) |  |
| override [ToString](#tostring-method)() | Returns the PluginName |
| [operator ==](#pluginid-equality-operator) | Compares two PluginIds if they are equal |
| [operator !=](#pluginid-inequality-operator) | Compares two PluginIds if they are not equal |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [PluginId.cs](../../../../Oxide.Ext.Discord/Plugins/PluginId.cs)
   
   
# ToString method

Returns the PluginName

```csharp
public override string ToString()
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Equals method (1 of 2)

```csharp
public override bool Equals(object obj)
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Equals method (2 of 2)

```csharp
public bool Equals(PluginId other)
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetHashCode method

```csharp
public override int GetHashCode()
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PluginId Inequality operator

Compares two PluginIds if they are not equal

```csharp
public static bool operator !=(PluginId left, PluginId right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## Return Value

True if they are not equal; false otherwise

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PluginId Equality operator

Compares two PluginIds if they are equal

```csharp
public static bool operator ==(PluginId left, PluginId right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## Return Value

True if they are equal; false otherwise

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsValid property

Returns if the PluginId is valid

```csharp
public bool IsValid { get; }
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id field

Hashcode value of the Plugin Name

```csharp
public readonly int Id;
```

## See Also

* struct [PluginId](./PluginId.md)
* namespace [Oxide.Ext.Discord.Plugins](./PluginsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
