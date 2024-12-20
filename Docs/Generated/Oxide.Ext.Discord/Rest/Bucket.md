# Bucket class

Contains bucket information for a REST API Bucket

```csharp
public class Bucket : BasePoolable, IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [Bucket](#bucket-constructor)() | The default constructor. |
| [Init](#init-method)(…) | Creates a new bucket for the given [`RestHandler`](./RestHandler.md) |
| [LogDebug](#logdebug-method)(…) |  |
| [QueueRequest](#queuerequest-method)(…) | Queues a new request for the bucket |

## Protected Members

| name | description |
| --- | --- |
| override [EnterPool](#enterpool-method)() |  |
| override [LeavePool](#leavepool-method)() |  |

## See Also

* class [BasePoolable](../Types/BasePoolable.md)
* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [Bucket.cs](../../../../Oxide.Ext.Discord/Rest/Bucket.cs)
   
   
# Init method

Creates a new bucket for the given [`RestHandler`](./RestHandler.md)

```csharp
public void Init(BucketId bucketId, RestHandler rest, ILogger logger)
```

| parameter | description |
| --- | --- |
| bucketId | ID of the bucket. If not a known bucket, then it will be part of the route. If known bucket, it will be the Discord bucket ID |
| rest | The handler that owns this Bucket |
| logger | Logger for this bucket |

## See Also

* struct [BucketId](./BucketId.md)
* class [RestHandler](./RestHandler.md)
* interface [ILogger](../Interfaces/ILogger.md)
* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# QueueRequest method

Queues a new request for the bucket

```csharp
public void QueueRequest(RequestHandler handler)
```

| parameter | description |
| --- | --- |
| handler | [`RequestHandler`](./RequestHandler.md) to be queued |

## See Also

* class [RequestHandler](./RequestHandler.md)
* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LeavePool method

```csharp
protected override void LeavePool()
```

## See Also

* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EnterPool method

```csharp
protected override void EnterPool()
```

## See Also

* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Bucket constructor

The default constructor.

```csharp
public Bucket()
```

## See Also

* class [Bucket](./Bucket.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
