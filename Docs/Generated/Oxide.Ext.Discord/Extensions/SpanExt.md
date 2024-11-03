# SpanExt class

Span Extension Methods

```csharp
public static class SpanExt
```

## Public Members

| name | description |
| --- | --- |
| static [TryFormat](#tryformat-method-1-of-14)(…) | Tries to write the formatted values to out span (14 methods) |
| static [TryParseNextString](#tryparsenextstring-method)(…) | Parses the next string from the input splitting on the token |

## See Also

* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [SpanExt.cs](../../../../Oxide.Ext.Discord/Extensions/SpanExt.cs)
   
   
# TryParseNextString method

Parses the next string from the input splitting on the token

```csharp
public static bool TryParseNextString(this ReadOnlySpan<char> input, ReadOnlySpan<char> token, 
    out ReadOnlySpan<char> remaining, out ReadOnlySpan<char> parsed)
```

| parameter | description |
| --- | --- |
| input | Input string |
| token | Token to split on |
| remaining | Remaining text of the span |
| parsed | The parsed string |

## Return Value

True if successfully parsed; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TryFormat method (1 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this byte value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (2 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this DateTime value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (3 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this DateTimeOffset value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (4 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this decimal value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (5 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this double value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (6 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this float value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (7 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this int value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (8 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this long value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (9 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this sbyte value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (10 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this short value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (11 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this TimeSpan value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (12 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this uint value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (13 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this ulong value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# TryFormat method (14 of 14)

Tries to write the formatted values to out span

```csharp
public static bool TryFormat(this ushort value, out ReadOnlySpan<char> written, 
    ReadOnlySpan<char> format = default, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to be formatted |
| written | Span the format is written to |
| format | The format to apply to the span |
| provider | Formatting provider |

## Return Value

true if format was successful; false otherwise

## See Also

* class [SpanExt](./SpanExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
