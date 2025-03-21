# DiscordWebsocketCloseCode enumeration

Represents [Socket Close Event Codes](https://discord.com/developers/docs/topics/opcodes-and-status-codes#gateway-gateway-close-event-codes)

```csharp
public enum DiscordWebsocketCloseCode
```

## Values

| name | value | description |
| --- | --- | --- |
| UnknownError | `UnknownError` | We're not sure what went wrong. Try reconnecting? |
| UnknownOpcode | `UnknownOpcode` | You sent an invalid Gateway opcode or an invalid payload for an opcode. Don't do that! |
| DecodeError | `DecodeError` | You sent an invalid payload to us. Don't do that! |
| NotAuthenticated | `NotAuthenticated` | You sent us a payload prior to identifying, or this session has been invalidated. |
| AuthenticationFailed | `AuthenticationFailed` | The account token sent with your identify payload is incorrect. |
| AlreadyAuthenticated | `AlreadyAuthenticated` | You sent more than one identify payload. Don't do that! |
| InvalidSequence | `InvalidSequence` | The sequence sent when resuming the session was invalid. Reconnect and start a new session. |
| RateLimited | `RateLimited` | Woah nelly! You're sending payloads to us too quickly. Slow it down! You will be disconnected on receiving this. |
| SessionTimedOut | `SessionTimedOut` | Your session timed out. Reconnect and start a new one. |
| InvalidShard | `InvalidShard` | You sent us an invalid shard when identifying. |
| ShardingRequired | `ShardingRequired` | The session would have handled too many guilds - you are required to shard your connection to connect. |
| InvalidApiVersion | `InvalidApiVersion` | You sent an invalid version for the gateway. |
| InvalidIntents | `InvalidIntents` | You sent an invalid intent for a Gateway Intent. You may have incorrectly calculated the bitwise value. |
| DisallowedIntent | `DisallowedIntent` | You sent a disallowed intent for a Gateway Intent. You may have tried to specify an intent that you have not enabled or are not allowlisted for. |
| DiscordExtensionReconnect | `DiscordExtensionReconnect` | Used to identify a reconnect should occur to discord |
| UnknownCloseCode | `UnknownCloseCode` | Used when a code is sent that we don't have yet. |

## See Also

* namespace [Oxide.Ext.Discord.WebSockets](./WebSocketsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordWebsocketCloseCode.cs](../../../../Oxide.Ext.Discord/WebSockets/DiscordWebsocketCloseCode.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
