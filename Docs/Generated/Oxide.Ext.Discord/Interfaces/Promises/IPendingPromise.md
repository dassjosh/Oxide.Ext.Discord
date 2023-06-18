# IPendingPromise interface

Represents a promise the is still pending waiting to be resolved

```csharp
public interface IPendingPromise : IPromise, IRejectable
```

## Members

| name | description |
| --- | --- |
| [Resolve](IPendingPromise/Resolve.md)() | Resolves the promise |

## See Also

* interface [IPromise](./IPromise.md)
* interface [IRejectable](./IRejectable.md)
* namespace [Oxide.Ext.Discord.Interfaces.Promises](./PromisesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [IPendingPromise.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Interfaces/Promises/IPendingPromise.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->