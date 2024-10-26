# PlaceholderKey structure

Represents a Placeholder Key. This is the key for placeholder usage and lookup

```csharp
public struct PlaceholderKey : IComparable<PlaceholderKey>, IDiscordKey, IEquatable<PlaceholderKey>
```

## Public Members

| name | description |
| --- | --- |
| [PlaceholderKey](#placeholderkey-constructor-1-of-2)(…) | Constructor (2 constructors) |
| [IsValid](#isvalid-property) { get; } | If [`Placeholder`](#placeholder-field) Is a Valid Key |
| readonly [Placeholder](#placeholder-field) | Placeholder Key |
| [CompareTo](#compareto-method)(…) |  |
| override [Equals](#equals-method)(…) |  |
| [Equals](#equals-method)(…) |  |
| override [GetHashCode](#gethashcode-method)() |  |
| override [ToString](#tostring-method)() | Returns the PlaceholderKey formatted as a usable placeholder in text |
| [WithFormat](#withformat-method)(…) | Applies a format to a given [`PlaceholderKey`](./PlaceholderKey.md) |
| [implicit operator](#placeholderkey-implicit-operator) | Implicitly converts to String by calling the [`ToString`](#tostring-method) method. |

## See Also

* interface [IDiscordKey](../Interfaces/IDiscordKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [PlaceholderKey.cs](../../../../Oxide.Ext.Discord/Libraries/PlaceholderKey.cs)
   
   
# WithFormat method

Applies a format to a given [`PlaceholderKey`](./PlaceholderKey.md)

```csharp
public string WithFormat(string format)
```

| parameter | description |
| --- | --- |
| format | Format to be applied |

## Return Value

string placeholder containing the placeholder with the given format

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToString method

Returns the PlaceholderKey formatted as a usable placeholder in text

```csharp
public override string ToString()
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CompareTo method

```csharp
public int CompareTo(PlaceholderKey other)
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PlaceholderKey Implicit operator

Implicitly converts to String by calling the [`ToString`](#tostring-method) method.

```csharp
public static implicit operator string(PlaceholderKey key)
```

| parameter | description |
| --- | --- |
| key |  |

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Equals method (1 of 2)

```csharp
public override bool Equals(object obj)
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Equals method (2 of 2)

```csharp
public bool Equals(PlaceholderKey other)
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetHashCode method

```csharp
public override int GetHashCode()
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PlaceholderKey constructor (1 of 2)

Constructor

```csharp
public PlaceholderKey(string placeholder)
```

| parameter | description |
| --- | --- |
| placeholder | Placeholder Value |

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# PlaceholderKey constructor (2 of 2)

Constructor

```csharp
public PlaceholderKey(string prefix, string key, string format = null)
```

| parameter | description |
| --- | --- |
| prefix | Prefix for the placeholder Key. Pass in the nameof the plugin type for the Placeholder key |
| key | Placeholder Value |
| format | Format to be applied (Optional) |

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsValid property

If [`Placeholder`](#placeholder-field) Is a Valid Key

```csharp
public bool IsValid { get; }
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Placeholder field

Placeholder Key

```csharp
public readonly string Placeholder;
```

## See Also

* struct [PlaceholderKey](./PlaceholderKey.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
