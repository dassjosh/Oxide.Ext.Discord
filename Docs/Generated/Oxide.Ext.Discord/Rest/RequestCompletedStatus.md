# RequestCompletedStatus enumeration

Represents the completed status for the request

```csharp
public enum RequestCompletedStatus : byte
```

## Values

| name | value | description |
| --- | --- | --- |
| Success | `Success` | The request completed successfully |
| ErrorFatal | `ErrorFatal` | The request encountered a fatal error |
| ErrorRetry | `ErrorRetry` | The error attempt multiple times to complete the request and was unsuccessful |
| Cancelled | `Cancelled` | The request was canceled. The [`DiscordClient`](../Clients/DiscordClient.md) was disconnected while making the request |

## See Also

* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RequestCompletedStatus.cs](../../../../Oxide.Ext.Discord/Rest/RequestCompletedStatus.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
