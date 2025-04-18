# EnumCache&lt;T&gt; class

Represents a cache of enum strings

```csharp
public sealed class EnumCache<T> : Singleton<EnumCache>
    where T : Enum, IConvertible
```

| parameter | description |
| --- | --- |
| T | Enum type |

## Public Members

| name | description |
| --- | --- |
| readonly [Values](#values-field) | Readonly Collection of Enum Values |
| [Next](#next-method)(…) | Returns the next enum values. If the value is the last value, it will start from the beginning |
| [Previous](#previous-method)(…) | Returns the previous enum values. |
| [ToLower](#tolower-method)(…) | Returns the lowered string representation of the enum |
| [ToNumber](#tonumber-method)(…) | Converts the enum to it's number form as a string |
| [ToString](#tostring-method)(…) | Returns the string representation of the enum |

## See Also

* class [Singleton&lt;T&gt;](../Types/Singleton%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [EnumCache.cs](../../../../Oxide.Ext.Discord/Cache/EnumCache.cs)
   
   
# ToString method

Returns the string representation of the enum

```csharp
public string ToString(T value)
```

| parameter | description |
| --- | --- |
| value | Enum value |

## Return Value

Enum value as string

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToLower method

Returns the lowered string representation of the enum

```csharp
public string ToLower(T value)
```

| parameter | description |
| --- | --- |
| value | Enum value |

## Return Value

Enum value as lowered string

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToNumber method

Converts the enum to it's number form as a string

```csharp
public string ToNumber(T value)
```

| parameter | description |
| --- | --- |
| value |  |

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Next method

Returns the next enum values. If the value is the last value, it will start from the beginning

```csharp
public T Next(T value)
```

| parameter | description |
| --- | --- |
| value | Value to get the next enum from |

## Return Value

Next enum from the given value

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Previous method

Returns the previous enum values.

```csharp
public T Previous(T value)
```

| parameter | description |
| --- | --- |
| value | Value to get the previous enum from |

## Return Value

Previous enum from the given value

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Values field

Readonly Collection of Enum Values

```csharp
public readonly ReadOnlyCollection<T> Values;
```

## See Also

* class [EnumCache&lt;T&gt;](./EnumCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
