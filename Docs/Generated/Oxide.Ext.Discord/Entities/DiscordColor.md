# DiscordColor structure

Represents a Discord Color

```csharp
public struct DiscordColor : IEquatable<DiscordColor>
```

## Public Members

| name | description |
| --- | --- |
| [DiscordColor](#discordcolor-constructor-1-of-7)(…) | DiscordColor Constructor (7 constructors) |
| static readonly [Blue](#blue-field) | Blue Role Color |
| static readonly [Blurple](#blurple-field) | Discord Blurple Color |
| static readonly [BlurpleOld](#blurpleold-field) | Discord Old Blurple Color |
| static readonly [Danger](#danger-field) | Discord Danger Color |
| static readonly [DarkBlue](#darkblue-field) | Dark Blue Role Color |
| static readonly [DarkerGrey](#darkergrey-field) | Darker Gray Role Color |
| static readonly [DarkGreen](#darkgreen-field) | Dark Green Role Color |
| static readonly [DarkGrey](#darkgrey-field) | Dark Gray Role Color |
| static readonly [DarkMagenta](#darkmagenta-field) | Dark Magenta Role Color |
| static readonly [DarkOrange](#darkorange-field) | Dark Orange Role Color |
| static readonly [DarkPurple](#darkpurple-field) | Dark Purple Role Color |
| static readonly [DarkRed](#darkred-field) | Dark Red Role Color |
| static readonly [DarkTeal](#darkteal-field) | Dark Teal Role Color |
| static readonly [Default](#default-field) | Default Role Color |
| static readonly [Fuchsia](#fuchsia-field) | Discord Fuchsia Color |
| static readonly [Gold](#gold-field) | Gold Role Color |
| static readonly [Green](#green-field) | Green Role Color |
| static readonly [LighterGrey](#lightergrey-field) | Lighter Gray Role Color |
| static readonly [LightGrey](#lightgrey-field) | Light Gray Role Color |
| static readonly [LightOrange](#lightorange-field) | Light Orange Role Color |
| static readonly [Magenta](#magenta-field) | Magenta Role Color |
| static readonly [Orange](#orange-field) | Orange Role Color |
| static readonly [Purple](#purple-field) | Purple Role Color |
| static readonly [Red](#red-field) | Red Role Color |
| static readonly [Success](#success-field) | Discord Success Color |
| static readonly [Teal](#teal-field) | Teal Role Color |
| static readonly [Warning](#warning-field) | Discord Warning Color |
| readonly [Color](#color-field) | uint value of the hex color code |
| [Equals](#equals-method)(…) |  |
| override [Equals](#equals-method)(…) |  |
| override [GetHashCode](#gethashcode-method)() |  |
| [ToHex](#tohex-method)() | Returns the color as a hex color code |
| override [ToString](#tostring-method)() | Returns the color as a string |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordColor.cs](../../../../Oxide.Ext.Discord/Entities/DiscordColor.cs)
   
   
# ToString method

Returns the color as a string

```csharp
public override string ToString()
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToHex method

Returns the color as a hex color code

```csharp
public string ToHex()
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Equals method (1 of 2)

```csharp
public bool Equals(DiscordColor other)
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Equals method (2 of 2)

```csharp
public override bool Equals(object obj)
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetHashCode method

```csharp
public override int GetHashCode()
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordColor constructor (1 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(string color)
```

| parameter | description |
| --- | --- |
| color | string hex color code |

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Throw if color is greater than #FFFFFF |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (2 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(uint color)
```

| parameter | description |
| --- | --- |
| color | uint value of hex color code |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (3 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(byte red, byte green, byte blue)
```

| parameter | description |
| --- | --- |
| red | Red color (0-255) |
| green | Green color (0-255) |
| blue | Blue color (0-255) |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (4 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(double red, double green, double blue)
```

| parameter | description |
| --- | --- |
| red | Red color (0.0 - 1.0) |
| green | Green color (0.0 - 1.0) |
| blue | Blue color (0.0 - 1.0) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentOutOfRangeException | Thrown if any of the colors are &lt; 0.0 or &gt; 1.0 |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (5 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(float red, float green, float blue)
```

| parameter | description |
| --- | --- |
| red | Red color (0.0 - 1.0) |
| green | Green color (0.0 - 1.0) |
| blue | Blue color (0.0 - 1.0) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentOutOfRangeException | Thrown if any of the colors are &lt; 0.0 or &gt; 1.0 |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (6 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(int red, int green, int blue)
```

| parameter | description |
| --- | --- |
| red | Red color (0-255) |
| green | Green color (0-255) |
| blue | Blue color (0-255) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentOutOfRangeException | Thrown if any of the colors are &lt; 0 or &gt; 255 |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordColor constructor (7 of 7)

DiscordColor Constructor

```csharp
public DiscordColor(uint red, uint green, uint blue)
```

| parameter | description |
| --- | --- |
| red | Red color (0-255) |
| green | Green color (0-255) |
| blue | Blue color (0-255) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentOutOfRangeException | Thrown if any of the colors are &gt; 255 |

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Color field

uint value of the hex color code

```csharp
public readonly uint Color;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Default field

Default Role Color

```csharp
public static readonly DiscordColor Default;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Teal field

Teal Role Color

```csharp
public static readonly DiscordColor Teal;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkTeal field

Dark Teal Role Color

```csharp
public static readonly DiscordColor DarkTeal;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Green field

Green Role Color

```csharp
public static readonly DiscordColor Green;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkGreen field

Dark Green Role Color

```csharp
public static readonly DiscordColor DarkGreen;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Blue field

Blue Role Color

```csharp
public static readonly DiscordColor Blue;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkBlue field

Dark Blue Role Color

```csharp
public static readonly DiscordColor DarkBlue;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Purple field

Purple Role Color

```csharp
public static readonly DiscordColor Purple;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkPurple field

Dark Purple Role Color

```csharp
public static readonly DiscordColor DarkPurple;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Magenta field

Magenta Role Color

```csharp
public static readonly DiscordColor Magenta;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkMagenta field

Dark Magenta Role Color

```csharp
public static readonly DiscordColor DarkMagenta;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Gold field

Gold Role Color

```csharp
public static readonly DiscordColor Gold;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LightOrange field

Light Orange Role Color

```csharp
public static readonly DiscordColor LightOrange;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Orange field

Orange Role Color

```csharp
public static readonly DiscordColor Orange;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkOrange field

Dark Orange Role Color

```csharp
public static readonly DiscordColor DarkOrange;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Red field

Red Role Color

```csharp
public static readonly DiscordColor Red;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkRed field

Dark Red Role Color

```csharp
public static readonly DiscordColor DarkRed;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LightGrey field

Light Gray Role Color

```csharp
public static readonly DiscordColor LightGrey;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LighterGrey field

Lighter Gray Role Color

```csharp
public static readonly DiscordColor LighterGrey;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkGrey field

Dark Gray Role Color

```csharp
public static readonly DiscordColor DarkGrey;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DarkerGrey field

Darker Gray Role Color

```csharp
public static readonly DiscordColor DarkerGrey;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Success field

Discord Success Color

```csharp
public static readonly DiscordColor Success;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Warning field

Discord Warning Color

```csharp
public static readonly DiscordColor Warning;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Danger field

Discord Danger Color

```csharp
public static readonly DiscordColor Danger;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BlurpleOld field

Discord Old Blurple Color

```csharp
public static readonly DiscordColor BlurpleOld;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Blurple field

Discord Blurple Color

```csharp
public static readonly DiscordColor Blurple;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Fuchsia field

Discord Fuchsia Color

```csharp
public static readonly DiscordColor Fuchsia;
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
