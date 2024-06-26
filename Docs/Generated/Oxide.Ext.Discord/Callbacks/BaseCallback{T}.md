# BaseCallback&lt;T&gt; class

Represents a base callback to be used when needing a lambda callback so no delegate or class is generated This class is pooled to prevent allocations

```csharp
public abstract class BaseCallback<T> : BasePoolable
```

## Public Members

| name | description |
| --- | --- |
| virtual [Start](#start-method)(…) | Run the callback |

## Protected Members

| name | description |
| --- | --- |
| [BaseCallback](#basecallback&amp;lt;t&amp;gt;-constructor)() | Constructor |
| abstract [HandleCallback](#handlecallback-method)(…) | Overridden in the child class to handle the callback |

## See Also

* class [BasePoolable](../Types/BasePoolable.md)
* namespace [Oxide.Ext.Discord.Callbacks](./CallbacksNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseCallback.cs](../../../../Oxide.Ext.Discord/Callbacks/BaseCallback.cs)
   
   
# HandleCallback method

Overridden in the child class to handle the callback

```csharp
protected abstract void HandleCallback(T data)
```

## See Also

* class [BaseCallback&lt;T&gt;](./BaseCallback%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Callbacks](./CallbacksNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Start method

Run the callback

```csharp
public virtual void Start(T data)
```

## See Also

* class [BaseCallback&lt;T&gt;](./BaseCallback%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Callbacks](./CallbacksNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BaseCallback&lt;T&gt; constructor

Constructor

```csharp
protected BaseCallback()
```

## See Also

* class [BaseCallback&lt;T&gt;](./BaseCallback%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Callbacks](./CallbacksNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
