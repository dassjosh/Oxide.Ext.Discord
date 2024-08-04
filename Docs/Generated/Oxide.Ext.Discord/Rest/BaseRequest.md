# BaseRequest class

Represents a base request class for REST API calls

```csharp
public abstract class BaseRequest : BasePoolable, IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [Data](#data-field) | Data to be sent with the request |
| [Id](#id-field) | ID of the request. Generated from the DateTimeOffset when the request was created |
| [Method](#method-field) | HTTP request method |
| [Options](#options-field) | Options for the request |
| [Route](#route-field) | Route on the API |
| [Status](#status-field) | Current status of the request |
| [LogDebug](#logdebug-method)(…) |  |

## Protected Members

| name | description |
| --- | --- |
| [BaseRequest](#baserequest-constructor)() | The default constructor. |
| [Logger](#logger-field) | Logger for the request |
| override [EnterPool](#enterpool-method)() |  |
| [Init](#init-method)(…) | Initializes the request |
| override [LeavePool](#leavepool-method)() |  |
| abstract [OnRequestError](#onrequesterror-method)(…) | Callback for API calls that error |
| abstract [OnRequestSuccess](#onrequestsuccess-method)(…) | Callback for successful API Calls |

## See Also

* class [BasePoolable](../Types/BasePoolable.md)
* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseRequest.cs](../../../../Oxide.Ext.Discord/Rest/BaseRequest.cs)
   
   
# Init method

Initializes the request

```csharp
protected void Init(DiscordClient client, HttpClient httpClient, RequestMethod method, 
    string route, object data, RequestOptions options)
```

## See Also

* class [DiscordClient](../Clients/DiscordClient.md)
* struct [RequestOptions](./RequestOptions.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnRequestSuccess method

Callback for successful API Calls

```csharp
protected abstract void OnRequestSuccess(RequestResponse response)
```

| parameter | description |
| --- | --- |
| response | Response for the API Call |

## See Also

* class [RequestResponse](../Entities/RequestResponse.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnRequestError method

Callback for API calls that error

```csharp
protected abstract void OnRequestError(RequestResponse response)
```

| parameter | description |
| --- | --- |
| response | Response for the error |

## See Also

* class [RequestResponse](../Entities/RequestResponse.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EnterPool method

```csharp
protected override void EnterPool()
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LeavePool method

```csharp
protected override void LeavePool()
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BaseRequest constructor

The default constructor.

```csharp
protected BaseRequest()
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id field

ID of the request. Generated from the DateTimeOffset when the request was created

```csharp
public Snowflake Id;
```

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Method field

HTTP request method

```csharp
public RequestMethod Method;
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Status field

Current status of the request

```csharp
public RequestStatus Status;
```

## See Also

* enum [RequestStatus](./RequestStatus.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Route field

Route on the API

```csharp
public string Route;
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Data field

Data to be sent with the request

```csharp
public object Data;
```

## See Also

* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Options field

Options for the request

```csharp
public RequestOptions Options;
```

## See Also

* struct [RequestOptions](./RequestOptions.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Logger field

Logger for the request

```csharp
protected ILogger Logger;
```

## See Also

* interface [ILogger](../Interfaces/ILogger.md)
* class [BaseRequest](./BaseRequest.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
