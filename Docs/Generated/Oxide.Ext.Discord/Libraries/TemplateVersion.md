# TemplateVersion structure

Version of a specific template

```csharp
public struct TemplateVersion : IComparable<TemplateVersion>, IEquatable<TemplateVersion>
```

## Public Members

| name | description |
| --- | --- |
| [TemplateVersion](#templateversion-constructor)(…) | Constructor |
| readonly [Major](#major-field) | Major Version |
| readonly [Minor](#minor-field) | Minor Version |
| readonly [Revision](#revision-field) | Revision Version |
| [CompareTo](#compareto-method)(…) |  |
| override [Equals](#equals-method)(…) |  |
| [Equals](#equals-method)(…) |  |
| override [GetHashCode](#gethashcode-method)() |  |
| override [ToString](#tostring-method)() |  |
| [operator &gt;](#templateversion-greaterthan-operator) | Returns if the right template version is greater than the left |
| [operator &gt;=](#templateversion-greaterthanorequal-operator) | Returns if the right template version is greater or equal than the left |
| [operator &lt;](#templateversion-lessthan-operator) | Returns if the left template version is less than the right |
| [operator &lt;=](#templateversion-lessthanorequal-operator) | Returns if the left template version is less than or equal the right |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [TemplateVersion.cs](../../../../Oxide.Ext.Discord/Libraries/TemplateVersion.cs)
   
   
# CompareTo method

```csharp
public int CompareTo(TemplateVersion other)
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TemplateVersion LessThan operator

Returns if the left template version is less than the right

```csharp
public static bool operator <(TemplateVersion left, TemplateVersion right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TemplateVersion LessThanOrEqual operator

Returns if the left template version is less than or equal the right

```csharp
public static bool operator <=(TemplateVersion left, TemplateVersion right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TemplateVersion GreaterThan operator

Returns if the right template version is greater than the left

```csharp
public static bool operator >(TemplateVersion left, TemplateVersion right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TemplateVersion GreaterThanOrEqual operator

Returns if the right template version is greater or equal than the left

```csharp
public static bool operator >=(TemplateVersion left, TemplateVersion right)
```

| parameter | description |
| --- | --- |
| left |  |
| right |  |

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToString method

```csharp
public override string ToString()
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Equals method (1 of 2)

```csharp
public override bool Equals(object obj)
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Equals method (2 of 2)

```csharp
public bool Equals(TemplateVersion other)
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetHashCode method

```csharp
public override int GetHashCode()
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TemplateVersion constructor

Constructor

```csharp
public TemplateVersion(ushort major, ushort minor, ushort revision)
```

| parameter | description |
| --- | --- |
| major | Major Version |
| minor | Minor Version |
| revision | Revision Version |

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Major field

Major Version

```csharp
public readonly ushort Major;
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Minor field

Minor Version

```csharp
public readonly ushort Minor;
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Revision field

Revision Version

```csharp
public readonly ushort Revision;
```

## See Also

* struct [TemplateVersion](./TemplateVersion.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
