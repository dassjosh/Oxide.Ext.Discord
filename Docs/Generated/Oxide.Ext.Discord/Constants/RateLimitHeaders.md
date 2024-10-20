# RateLimitHeaders class

Represents [Header Format](https://discord.com/developers/docs/topics/rate-limits#header-format)

```csharp
public static class RateLimitHeaders
```

## Public Members

| name | description |
| --- | --- |
| const [BucketId](#bucketid-field) | A unique string denoting the rate limit being encountered (non-inclusive of top-level resources in the path) |
| const [BucketLimit](#bucketlimit-field) | The number of requests that can be made |
| const [BucketRemaining](#bucketremaining-field) | The number of remaining requests that can be made |
| const [BucketReset](#bucketreset-field) | Epoch time (seconds since 00:00:00 UTC on January 1, 1970) at which the rate limit resets |
| const [BucketResetAfter](#bucketresetafter-field) | Total time (in seconds) of when the current rate limit bucket will reset. Can have decimals to match previous millisecond rate-limit precision |
| const [IsGlobal](#isglobal-field) | Returned only on HTTP 429 responses if the rate limit encountered is the global rate limit (not per-route) |
| const [RetryAfter](#retryafter-field) | The number of seconds to wait before submitting another request. |
| const [Scope](#scope-field) | Scope of the rate limit |

## See Also

* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RateLimitHeaders.cs](../../../../Oxide.Ext.Discord/Constants/RateLimitHeaders.cs)
   
   
# RetryAfter field

The number of seconds to wait before submitting another request.

```csharp
public const string RetryAfter;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsGlobal field

Returned only on HTTP 429 responses if the rate limit encountered is the global rate limit (not per-route)

```csharp
public const string IsGlobal;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BucketId field

A unique string denoting the rate limit being encountered (non-inclusive of top-level resources in the path)

```csharp
public const string BucketId;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BucketLimit field

The number of requests that can be made

```csharp
public const string BucketLimit;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BucketRemaining field

The number of remaining requests that can be made

```csharp
public const string BucketRemaining;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BucketResetAfter field

Total time (in seconds) of when the current rate limit bucket will reset. Can have decimals to match previous millisecond rate-limit precision

```csharp
public const string BucketResetAfter;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BucketReset field

Epoch time (seconds since 00:00:00 UTC on January 1, 1970) at which the rate limit resets

```csharp
public const string BucketReset;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Scope field

Scope of the rate limit

```csharp
public const string Scope;
```

## See Also

* class [RateLimitHeaders](./RateLimitHeaders.md)
* namespace [Oxide.Ext.Discord.Constants](./ConstantsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
