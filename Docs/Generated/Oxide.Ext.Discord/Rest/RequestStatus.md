# RequestStatus enumeration

Discord API Request Status

```csharp
public enum RequestStatus : byte
```

## Values

| name | value | description |
| --- | --- | --- |
| InQueue | `InQueue` | Request is in the queue waiting to be processed |
| Started | `Started` | Request has been started |
| PendingBucket | `PendingBucket` | Requesting is waiting for bucket to be ready |
| PendingStart | `PendingStart` | Request is waiting to start |
| InProgress | `InProgress` | Request is in progress |
| Completed | `Completed` | Request completed and was not canceled |
| Cancelled | `Cancelled` | Request was canceled |

## See Also

* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RequestStatus.cs](../../../../Oxide.Ext.Discord/Rest/RequestStatus.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
