# ValueStringBuilder structure

A non-heap-allocation allocating string builder

```csharp
[Obsolete("Types with embedded references are not supported in this version of your compiler.")]
public struct ValueStringBuilder
```

## Public Members

| name | description |
| --- | --- |
| [ValueStringBuilder](#valuestringbuilder-constructor-1-of-2)(…) | Constructor (2 constructors) |
| [Capacity](#capacity-property) { get; } | Current capacity of the builder |
| [Item](#valuestringbuilder-indexer) { get; } | Get the char at the specified index |
| [Length](#length-property) { get; set; } | Length of the builder |
| [RawChars](#rawchars-property) { get; } | Returns the underlying storage of the builder. |
| [Append](#append-method-1-of-18)(…) | Appends char to the builder (18 methods) |
| [AppendLine](#appendline-method)() | Appends a newline |
| [AppendLine](#appendline-method)(…) | Appends *s* followed by a newline |
| [AppendSpan](#appendspan-method)(…) | Requests a writable span of length |
| [AsSpan](#asspan-method)() | Converts the current builder to a ReadOnlySpan |
| [AsSpan](#asspan-method-1-of-3)(…) | Returns a span around the contents of the builder. (3 methods) |
| [Dispose](#dispose-method)() |  |
| [EnsureCapacity](#ensurecapacity-method)(…) | Ensure the builder has a capacity of at least *capacity* |
| [GetPinnableReference](#getpinnablereference-method)() | Get a pinnable reference to the builder. Does not ensure there is a null char after [`Length`](#length-property) This overload is pattern matched in the C# 7.3+ compiler so you can omit the explicit method call, and write eg "fixed (char* c = builder)" |
| [GetPinnableReference](#getpinnablereference-method)(…) | Get a pinnable reference to the builder. |
| [Insert](#insert-method-1-of-2)(…) | Insert a char at the specified index count times (2 methods) |
| override [ToString](#tostring-method)() | Get's the final string and disposes of the builder |
| [TryCopyTo](#trycopyto-method)(…) | Tries to copy the current builder to a Span |

## See Also

* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ValueStringBuilder.cs](../../../../Oxide.Ext.Discord/Types/ValueStringBuilder.cs)
   
   
# EnsureCapacity method

Ensure the builder has a capacity of at least *capacity*

```csharp
public void EnsureCapacity(int capacity)
```

| parameter | description |
| --- | --- |
| capacity |  |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetPinnableReference method (1 of 2)

Get a pinnable reference to the builder. Does not ensure there is a null char after [`Length`](#length-property) This overload is pattern matched in the C# 7.3+ compiler so you can omit the explicit method call, and write eg "fixed (char* c = builder)"

```csharp
public char GetPinnableReference()
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetPinnableReference method (2 of 2)

Get a pinnable reference to the builder.

```csharp
public char GetPinnableReference(bool terminate)
```

| parameter | description |
| --- | --- |
| terminate | Ensures that the builder has a null char after [`Length`](#length-property) |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToString method

Get's the final string and disposes of the builder

```csharp
public override string ToString()
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AsSpan method (1 of 4)

Converts the current builder to a ReadOnlySpan

```csharp
public ReadOnlySpan<char> AsSpan()
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AsSpan method (2 of 4)

Returns a span around the contents of the builder.

```csharp
public ReadOnlySpan<char> AsSpan(bool terminate)
```

| parameter | description |
| --- | --- |
| terminate | Ensures that the builder has a null char after [`Length`](#length-property) |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AsSpan method (3 of 4)

Converts the current builder to a ReadOnlySpan

```csharp
public ReadOnlySpan<char> AsSpan(int start)
```

| parameter | description |
| --- | --- |
| start | Index to start at |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AsSpan method (4 of 4)

Converts the current builder to a ReadOnlySpan

```csharp
public ReadOnlySpan<char> AsSpan(int start, int length)
```

| parameter | description |
| --- | --- |
| start | Index to start at |
| length | Length of the span |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TryCopyTo method

Tries to copy the current builder to a Span

```csharp
public bool TryCopyTo(Span<char> destination, out int charsWritten)
```

| parameter | description |
| --- | --- |
| destination | Span to write the chars to |
| charsWritten | Number of chars written |

## Return Value

True if successfully; false otherwise

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Insert method (1 of 2)

Insert string at the specified index

```csharp
public void Insert(int index, string s)
```

| parameter | description |
| --- | --- |
| index | Index to insert the string |
| s | String to insert |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Insert method (2 of 2)

Insert a char at the specified index count times

```csharp
public void Insert(int index, char value, int count)
```

| parameter | description |
| --- | --- |
| index | Index to insert the char |
| value | Char to insert |
| count | Number of times to insert |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Append method (1 of 18)

Appends char to the builder

```csharp
public void Append(char c)
```

| parameter | description |
| --- | --- |
| c | Char to append |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (2 of 18)

Appends span to the builder

```csharp
public void Append(ReadOnlySpan<char> value)
```

| parameter | description |
| --- | --- |
| value | Span to append |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (3 of 18)

Appends string to the builder

```csharp
public void Append(string s)
```

| parameter | description |
| --- | --- |
| s | string to append |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (4 of 18)

```csharp
public void Append(char c, int count)
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (5 of 18)

Appends a Byte to the builder

```csharp
public void Append(byte value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (6 of 18)

Appends a DateTime to the builder

```csharp
public void Append(DateTime value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (7 of 18)

Appends a DateTimeOffset to the builder

```csharp
public void Append(DateTimeOffset value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (8 of 18)

Appends a Decimal to the builder

```csharp
public void Append(decimal value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (9 of 18)

Appends a Double to the builder

```csharp
public void Append(double value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (10 of 18)

Appends a Single to the builder

```csharp
public void Append(float value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (11 of 18)

Appends a Int32 to the builder

```csharp
public void Append(int value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (12 of 18)

Appends a Int64 to the builder

```csharp
public void Append(long value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (13 of 18)

Appends a SByte to the builder

```csharp
public void Append(sbyte value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (14 of 18)

Appends a SByte to the builder

```csharp
public void Append(short value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (15 of 18)

Appends a TimeSpan to the builder

```csharp
public void Append(TimeSpan value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (16 of 18)

Appends a UInt32 to the builder

```csharp
public void Append(uint value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (17 of 18)

Appends a UInt64 to the builder

```csharp
public void Append(ulong value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Append method (18 of 18)

Appends a SByte to the builder

```csharp
public void Append(ushort value, string format = null, IFormatProvider provider = null)
```

| parameter | description |
| --- | --- |
| value | Value to append |
| format | format for the value |
| provider | Format provider for the value |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendSpan method

Requests a writable span of length

```csharp
public Span<char> AppendSpan(int length)
```

| parameter | description |
| --- | --- |
| length | Length of the request span |

## Return Value

Span of the request length

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendLine method (1 of 2)

Appends a newline

```csharp
public void AppendLine()
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendLine method (2 of 2)

Appends *s* followed by a newline

```csharp
public void AppendLine(string s)
```

| parameter | description |
| --- | --- |
| s |  |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Dispose method

```csharp
public void Dispose()
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ValueStringBuilder constructor (1 of 2)

Constructor

```csharp
public ValueStringBuilder(int initialCapacity)
```

| parameter | description |
| --- | --- |
| initialCapacity | Initial buffer capacity to rent |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ValueStringBuilder constructor (2 of 2)

Constructor

```csharp
public ValueStringBuilder(Span<char> initialBuffer)
```

| parameter | description |
| --- | --- |
| initialBuffer | Initial buffer to use for the chars |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Length property

Length of the builder

```csharp
public int Length { get; set; }
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Capacity property

Current capacity of the builder

```csharp
public int Capacity { get; }
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ValueStringBuilder indexer

Get the char at the specified index

```csharp
public char this[int index] { get; }
```

| parameter | description |
| --- | --- |
| index |  |

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RawChars property

Returns the underlying storage of the builder.

```csharp
public Span<char> RawChars { get; }
```

## See Also

* struct [ValueStringBuilder](./ValueStringBuilder.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
