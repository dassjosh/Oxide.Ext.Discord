# BaseRateLimit class

Represents a base rate limit for websocket and rest api requests

```csharp
public abstract class BaseRateLimit
```

## Public Members

| name | description |
| --- | --- |
| [HasReachedRateLimit](#hasreachedratelimit-property) { get; } | Returns true if we have reached the global rate limit |
| virtual [NextReset](#nextreset-method)() | Returns the next reset for the rate limit |
| [Shutdown](#shutdown-method)() | Called when a bot is shutting down |

## Protected Members

| name | description |
| --- | --- |
| [BaseRateLimit](#baseratelimit-constructor)(…) | Base Rate Limit Constructor |
| [LastReset](#lastreset-field) | Returns when the last reset occured |
| readonly [Logger](#logger-field) | Logger for the rate limit |
| readonly [MaxRequests](#maxrequests-field) | The max number of requests this rate limit can handle per interval |
| [NumRequests](#numrequests-field) | The number of requests that have executed since the last reset |
| readonly [ResetInterval](#resetinterval-field) | The interval in which this resets at |
| [FiredRequestInternal](#firedrequestinternal-method)() | Called when an API request is fired |
| abstract [OnRateLimitReset](#onratelimitreset-method)() | Called when the rate limit is reset |

## See Also

* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseRateLimit.cs](../../../../Oxide.Ext.Discord/Types/BaseRateLimit.cs)
   
   
# NextReset method

Returns the next reset for the rate limit

```csharp
public virtual DateTimeOffset NextReset()
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# FiredRequestInternal method

Called when an API request is fired

```csharp
protected void FiredRequestInternal()
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnRateLimitReset method

Called when the rate limit is reset

```csharp
protected abstract void OnRateLimitReset()
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Shutdown method

Called when a bot is shutting down

```csharp
public void Shutdown()
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BaseRateLimit constructor

Base Rate Limit Constructor

```csharp
protected BaseRateLimit(int maxRequests, long interval, ILogger logger)
```

| parameter | description |
| --- | --- |
| maxRequests | Max requests per interval |
| interval | Reset Interval in milliseconds |
| logger | Logger |

## See Also

* interface [ILogger](../Interfaces/ILogger.md)
* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HasReachedRateLimit property

Returns true if we have reached the global rate limit

```csharp
public bool HasReachedRateLimit { get; }
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NumRequests field

The number of requests that have executed since the last reset

```csharp
protected int NumRequests;
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LastReset field

Returns when the last reset occured

```csharp
protected DateTimeOffset LastReset;
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxRequests field

The max number of requests this rate limit can handle per interval

```csharp
protected readonly int MaxRequests;
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ResetInterval field

The interval in which this resets at

```csharp
protected readonly long ResetInterval;
```

## See Also

* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Logger field

Logger for the rate limit

```csharp
protected readonly ILogger Logger;
```

## See Also

* interface [ILogger](../Interfaces/ILogger.md)
* class [BaseRateLimit](./BaseRateLimit.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
