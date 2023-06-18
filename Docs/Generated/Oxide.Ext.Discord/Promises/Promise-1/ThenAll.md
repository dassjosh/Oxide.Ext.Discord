# Promise&lt;TPromised&gt;.ThenAll method (1 of 2)

```csharp
public IPromise ThenAll(Func<TPromised, IEnumerable<IPromise>> chain)
```

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [Promise&lt;TPromised&gt;](../Promise-1.md)
* namespace [Oxide.Ext.Discord.Promises](../Promise-1.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---

# Promise&lt;TPromised&gt;.ThenAll&lt;TConvert&gt; method (2 of 2)

```csharp
public IPromise<IEnumerable<TConvert>> ThenAll<TConvert>(
    Func<TPromised, IEnumerable<IPromise<TConvert>>> chain)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise-1.md)
* class [Promise&lt;TPromised&gt;](../Promise-1.md)
* namespace [Oxide.Ext.Discord.Promises](../Promise-1.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->