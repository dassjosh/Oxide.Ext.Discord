# ServerLocale structure

Represents a Server Locale

```csharp
public struct ServerLocale : IEquatable<ServerLocale>
```

## Public Members

| name | description |
| --- | --- |
| static readonly [Default](#default-field) | The default locale for servers |
| static [Parse](#parse-method)(…) | Parses a locale returning a [`ServerLocale`](./ServerLocale.md) |
| [IsDefault](#isdefault-property) { get; } | Returns if the Locale is the default server language "en" |
| [IsValid](#isvalid-property) { get; } | Returns if the Locale is valid |
| readonly [Id](#id-field) | ID of the Locale |
| override [Equals](#equals-method)(…) |  |
| [Equals](#equals-method)(…) |  |
| [GetDiscordLocale](#getdiscordlocale-method)() | Returns the [`DiscordLocale`](./DiscordLocale.md) for this server locale |
| override [GetHashCode](#gethashcode-method)() |  |
| override [ToString](#tostring-method)() | Returns the ID of the ServerLocale |
| [operator ==](#serverlocale-equality-operator) | Returns if two Server Locales are equal to each other |
| [operator !=](#serverlocale-inequality-operator) | Returns if two Server Locales are not equal to each other |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ServerLocale.cs](../../../../Oxide.Ext.Discord/Libraries/ServerLocale.cs)
   
   
# GetDiscordLocale method

Returns the [`DiscordLocale`](./DiscordLocale.md) for this server locale

```csharp
public DiscordLocale GetDiscordLocale()
```

## See Also

* struct [DiscordLocale](./DiscordLocale.md)
* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Parse method

Parses a locale returning a [`ServerLocale`](./ServerLocale.md)

```csharp
public static ServerLocale Parse(string locale)
```

| parameter | description |
| --- | --- |
| locale |  |

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Equals method (1 of 2)

```csharp
public override bool Equals(object obj)
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Equals method (2 of 2)

```csharp
public bool Equals(ServerLocale other)
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetHashCode method

```csharp
public override int GetHashCode()
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ServerLocale Equality operator

Returns if two Server Locales are equal to each other

```csharp
public static bool operator ==(ServerLocale left, ServerLocale right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ServerLocale Inequality operator

Returns if two Server Locales are not equal to each other

```csharp
public static bool operator !=(ServerLocale left, ServerLocale right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToString method

Returns the ID of the ServerLocale

```csharp
public override string ToString()
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsValid property

Returns if the Locale is valid

```csharp
public bool IsValid { get; }
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsDefault property

Returns if the Locale is the default server language "en"

```csharp
public bool IsDefault { get; }
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id field

ID of the Locale

```csharp
public readonly string Id;
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Default field

The default locale for servers

```csharp
public static readonly ServerLocale Default;
```

## See Also

* struct [ServerLocale](./ServerLocale.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
