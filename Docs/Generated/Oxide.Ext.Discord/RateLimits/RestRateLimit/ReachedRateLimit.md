# RestRateLimit.ReachedRateLimit method

Called if we receive a header notifying us of hitting the rate limit

```csharp
public void ReachedRateLimit(DateTimeOffset retryAfter)
```

| parameter | description |
| --- | --- |
| retryAfter | How long until we should retry API request again |

## See Also

* class [RestRateLimit](../RestRateLimit.md)
* namespace [Oxide.Ext.Discord.RateLimits](../RestRateLimit.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->