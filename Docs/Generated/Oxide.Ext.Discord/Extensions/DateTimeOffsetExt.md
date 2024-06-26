# DateTimeOffsetExt class

DateTimeOffset Extensions

```csharp
public static class DateTimeOffsetExt
```

## Public Members

| name | description |
| --- | --- |
| static [DelayUntil](#delayuntil-method-1-of-2)(…) | Delay until the DateTimeOffset with 25ms - 40 padding (2 methods) |

## See Also

* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DateTimeOffsetExt.cs](../../../../Oxide.Ext.Discord/Extensions/DateTimeOffsetExt.cs)
   
   
# DelayUntil method (1 of 2)

Delay until the DateTimeOffset with 25ms - 40 padding

```csharp
public static ValueTask DelayUntil(this DateTimeOffset time, CancellationToken token = default)
```

| parameter | description |
| --- | --- |
| time |  |
| token |  |

## See Also

* class [DateTimeOffsetExt](./DateTimeOffsetExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DelayUntil method (2 of 2)

Delay until the DateTimeOffset with additionalMs padding

```csharp
public static ValueTask DelayUntil(this DateTimeOffset time, int additionalMs, 
    CancellationToken token = default)
```

| parameter | description |
| --- | --- |
| time | Time to wait until |
| additionalMs | Additional millisecond padding |
| token | Cancellation Token |

## See Also

* class [DateTimeOffsetExt](./DateTimeOffsetExt.md)
* namespace [Oxide.Ext.Discord.Extensions](./ExtensionsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
