# DebugLogger class

Debug Logger used for logging debug information

```csharp
public class DebugLogger
```

## Public Members

| name | description |
| --- | --- |
| [DebugLogger](#debuglogger-constructor)() | The default constructor. |
| [AppendChannelPath](#appendchannelpath-method)(…) | Appends a channel path to the logger. This path will include the guild name / Parent Channel Name (Optional) / Channel Name |
| [AppendField](#appendfield-method-1-of-12)(…) | Appends a field into the logger (12 methods) |
| [AppendFieldEnum&lt;T&gt;](#appendfieldenum&amp;lt;t&amp;gt;-method)(…) | Appends a field with the given name and enum value |
| [AppendFieldOutOf](#appendfieldoutof-method)(…) | Appends a field with the given name and int amount over int total value |
| [AppendFieldPrefix](#appendfieldprefix-method)(…) | Appends the field name into the logger |
| [AppendIndent](#appendindent-method)() | Appends the current indent into the logger |
| [AppendLine](#appendline-method)() | Appends a line to the logger |
| [AppendLine](#appendline-method-1-of-2)(…) | Appends a line to the logger with the given character repeated amount time (2 methods) |
| [AppendList](#appendlist-method-1-of-2)(…) | Appends an IEnumerable where T is string items to add to the logger (2 methods) |
| [AppendList&lt;T&gt;](#appendlist&amp;lt;t&amp;gt;-method-1-of-2)(…) | Appends an IEnumerable where T is [`IDebugLoggable`](../Interfaces/IDebugLoggable.md) items to add to the logger (2 methods) |
| [AppendMethod](#appendmethod-method)(…) | Appends a field with the given name and method info |
| [AppendNullField](#appendnullfield-method)(…) | Appends a field with the given name and Null value |
| [AppendObject](#appendobject-method)(…) | Appends a [`IDebugLoggable`](../Interfaces/IDebugLoggable.md) object to the logger with the given name |
| [DecrementIndent](#decrementindent-method)() | Decrements the Indent |
| [EndArray](#endarray-method)() | Ends an array on the logger |
| [EndObject](#endobject-method)() | Ends an object on the logger |
| [IncrementIndent](#incrementindent-method)() | Increments the Indent |
| [StartArray](#startarray-method)(…) | Starts an array on the logger with the given name |
| [StartObject](#startobject-method)(…) | Starts an object on the logger with the given name |
| override [ToString](#tostring-method)() | Returns the logged data as a string |

## See Also

* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DebugLogger.cs](../../../../Oxide.Ext.Discord/Logging/DebugLogger.cs)
   
   
# IncrementIndent method

Increments the Indent

```csharp
public void IncrementIndent()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DecrementIndent method

Decrements the Indent

```csharp
public void DecrementIndent()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendIndent method

Appends the current indent into the logger

```csharp
public void AppendIndent()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendFieldPrefix method

Appends the field name into the logger

```csharp
public void AppendFieldPrefix(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendField method (1 of 12)

Appends a field with the given name and bool value

```csharp
public void AppendField(string name, bool value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (2 of 12)

Appends a field with the given name and double value

```csharp
public void AppendField(string name, double value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (3 of 12)

Appends a field with the given name and float value

```csharp
public void AppendField(string name, float value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (4 of 12)

Appends a field with the given name and int value

```csharp
public void AppendField(string name, int value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (5 of 12)

Appends a field with the given name and long value

```csharp
public void AppendField(string name, long value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (6 of 12)

Appends a field into the logger

```csharp
public void AppendField(string name, ReadOnlySpan<char> value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (7 of 12)

Appends a field with the given name and Snowflake value

```csharp
public void AppendField(string name, Snowflake value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (8 of 12)

Appends a field with the given name and Snowflake? value

```csharp
public void AppendField(string name, Snowflake? value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (9 of 12)

Appends a field into the logger

```csharp
public void AppendField(string name, string value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (10 of 12)

Appends a field with the given name and TimeSpan value

```csharp
public void AppendField(string name, TimeSpan time)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| time | TimeSpan value |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (11 of 12)

Appends a field with the given name and ulong value

```csharp
public void AppendField(string name, ulong value)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendField method (12 of 12)

Appends a field with the given name and values seperated by a space

```csharp
public void AppendField(string name, string value1, string value2)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value1 | First value |
| value2 | Second value |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendFieldEnum&lt;T&gt; method

Appends a field with the given name and enum value

```csharp
public void AppendFieldEnum<T>(string name, T value)
    where T : Enum, IComparable, IFormattable, IConvertible
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| value | Value of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendFieldOutOf method

Appends a field with the given name and int amount over int total value

```csharp
public void AppendFieldOutOf(string name, int amount, int total)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| amount | Amount / Top value |
| total | Total / Bottom Value |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendMethod method

Appends a field with the given name and method info

```csharp
public void AppendMethod(string name, MethodInfo info)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| info | Method info to append |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendNullField method

Appends a field with the given name and Null value

```csharp
public void AppendNullField(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the field |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendLine method (1 of 3)

Appends a line to the logger

```csharp
public void AppendLine()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendLine method (2 of 3)

Appends a line to the logger with the given string value

```csharp
public void AppendLine(string value)
```

| parameter | description |
| --- | --- |
| value | Value of the line |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendLine method (3 of 3)

Appends a line to the logger with the given character repeated amount time

```csharp
public void AppendLine(char character, int amount)
```

| parameter | description |
| --- | --- |
| character | Character to repeat |
| amount | Amount of times to repeat the character |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendChannelPath method

Appends a channel path to the logger. This path will include the guild name / Parent Channel Name (Optional) / Channel Name

```csharp
public void AppendChannelPath(string name, DiscordGuild guild, DiscordChannel channel, 
    DiscordChannel parent = null)
```

| parameter | description |
| --- | --- |
| name | Name of the field |
| guild | Guild for the name |
| channel | Channel for the channel name |
| parent | Parent for the Parent Channel Name |

## See Also

* class [DiscordGuild](../Entities/DiscordGuild.md)
* class [DiscordChannel](../Entities/DiscordChannel.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendObject method

Appends a [`IDebugLoggable`](../Interfaces/IDebugLoggable.md) object to the logger with the given name

```csharp
public void AppendObject(string name, IDebugLoggable obj)
```

| parameter | description |
| --- | --- |
| name | Name of the object |
| obj | Object to be logged |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppendList method (1 of 4)

Appends an IEnumerable where T is string items to add to the logger

```csharp
public void AppendList(string name, IEnumerable<string> items)
```

| parameter | description |
| --- | --- |
| name | Name of the list |
| items | String items to add |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendList method (2 of 4)

Appends an List where T is string items to add to the logger

```csharp
public void AppendList(string name, List<string> items)
```

| parameter | description |
| --- | --- |
| name | Name of the list |
| items | String items to add |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendList&lt;T&gt; method (3 of 4)

Appends an IEnumerable where T is [`IDebugLoggable`](../Interfaces/IDebugLoggable.md) items to add to the logger

```csharp
public void AppendList<T>(string name, IEnumerable<T> items)
    where T : IDebugLoggable
```

| parameter | description |
| --- | --- |
| name | Name of the list |
| items | Loggable items to add |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AppendList&lt;T&gt; method (4 of 4)

Appends an List where T is [`IDebugLoggable`](../Interfaces/IDebugLoggable.md) items to add to the logger

```csharp
public void AppendList<T>(string name, List<T> items)
    where T : IDebugLoggable
```

| parameter | description |
| --- | --- |
| name | Name of the list |
| items | Loggable items to add |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# StartArray method

Starts an array on the logger with the given name

```csharp
public void StartArray(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the array |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EndArray method

Ends an array on the logger

```csharp
public void EndArray()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# StartObject method

Starts an object on the logger with the given name

```csharp
public void StartObject(string name)
```

| parameter | description |
| --- | --- |
| name |  |

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EndObject method

Ends an object on the logger

```csharp
public void EndObject()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToString method

Returns the logged data as a string

```csharp
public override string ToString()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DebugLogger constructor

The default constructor.

```csharp
public DebugLogger()
```

## See Also

* class [DebugLogger](./DebugLogger.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
