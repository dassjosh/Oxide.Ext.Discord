using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.WebSockets;

/// <summary>
/// Handles the web socket connection and events
/// </summary>
internal class WebSocketHandler
{
    private readonly IWebSocketEventHandler _handler;
    private readonly ILogger _logger;

    private readonly Memory<byte> _receiveBuffer;
    private readonly Memory<byte> _sendBuffer;
    private readonly AutoResetEvent _sendLock = new(true);
        
    private DiscordWebsocketClient _client;
    public SocketState SocketState => _client?.SocketState ?? SocketState.Disconnected;
    public Snowflake WebsocketId => _client?.WebsocketId ?? default(Snowflake);

    //private readonly ZlibDecompressorHandler _decompressor;
        
    private const int SendChunkSize = 1024;
    private const int ReceiveChunkSize = 2048;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="handler">Handles for web socket events</param>
    /// <param name="logger"></param>
    public WebSocketHandler(IWebSocketEventHandler handler, ILogger logger)
    {
        _handler = handler;
        _logger = logger;
        _receiveBuffer = new byte[Math.Max(ReceiveChunkSize, SendChunkSize)];
        _sendBuffer = new byte[SendChunkSize];
    }

    /// <summary>
    /// Connects to the websocket at the given URL
    /// </summary>
    /// <param name="url"></param>
    /// <exception cref="DiscordWebSocketException"></exception>
    public void Connect(string url)
    {
        if (SocketState == SocketState.Connecting || SocketState == SocketState.Connected)
        {
            throw new DiscordWebSocketException("Socket is already running. Please disconnect before attempting to connect.");
        }

        DisposeSocket();
        _client = new DiscordWebsocketClient(_logger);
            
        Task.Factory.StartNew(RunInternal, url, _client.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }

    private async void RunInternal(object url)
    {
        await RunWebsocket((string)url).ConfigureAwait(false);
    }
        
    private async ValueTask RunWebsocket(string url)
    {
        DiscordWebsocketClient client = _client;
        Snowflake id = client.WebsocketId;
        try
        {
            _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(Connect)} Connecting Websocket To: {{0}}", url);
            await client.ConnectAsync(new Uri(url)).ConfigureAwait(false);
            await _handler.SocketOpened(id).ConfigureAwait(false);
            _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(Connect)} Websocket Connected");
            await ReceiveHandlerAsync(client).ConfigureAwait(false);
            _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(Connect)} Websocket Disconnecting State: {{0}} Websocket: {{1}}", client.SocketState, client.WebSocketState);
            if (client.SocketState == SocketState.Connected)
            {
                await client.CloseSocket(WebSocketCloseStatus.NormalClosure, "Websocket completed").ConfigureAwait(false);
                DisposeSocket();
            }
        }
        catch (OperationCanceledException)
        {
            DisposeSocket();
        }
        catch (WebSocketException ex)
        {
            DisposeSocket();
            if (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
            {
                _logger.Verbose("Disconnected Socket Because: {0} Error Code: {1} HResult:{2}\n{3}", ex.WebSocketErrorCode, ex.ErrorCode, ex.HResult, ex);
                await _handler.SocketClosed(id, WebSocketCloseStatus.NormalClosure, string.Empty).ConfigureAwait(false);
            }
            else
            {
                _logger.Debug("Disconnected Socket Because: {0} Error Code: {1} HResult:{2}\n{3}", ex.WebSocketErrorCode, ex.ErrorCode, ex.HResult, ex);
                await _handler.SocketErrored(id, ex).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            DisposeSocket();
            await _handler.SocketErrored(id, ex).ConfigureAwait(false);
            _logger.Exception("A Unhandled Websocket Error Occured", ex);
        }
    }

    private async ValueTask ReceiveHandlerAsync(DiscordWebsocketClient client)
    {
        DiscordJsonReader reader = new();
        MemoryStream input = reader.Stream;
        Memory<byte> array = _receiveBuffer;
            
        _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(ReceiveHandlerAsync)} Start Receive for {{0}}", client.WebsocketId);
        while (!client.IsCancelRequested && client.WebSocketState == WebSocketState.Open && client.SocketState == SocketState.Connected)
        {
            _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(ReceiveHandlerAsync)} Waiting to receive for {{0}} State: {{1}} Is Cancelled: {{2}}", client.WebsocketId, client.SocketState, client.IsCancelRequested);
            ValueWebSocketReceiveResult result = await client.ReceiveAsync(array).ConfigureAwait(false);
            if (client.Token.IsCancellationRequested)
            {
                return;
            }

            await input.WriteAsync(array.Slice(0, result.Count), client.Token).ConfigureAwait(false);

            if (result.EndOfMessage)
            {
                try
                {
                    input.Position = 0;
                    await ProcessReceivedMessageAsync(client, result, reader).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.Exception("An error occured processing websocket message.", ex);
                }
                finally
                {
                    input.SetLength(0);
                }
            }
        }
    }

    private ValueTask ProcessReceivedMessageAsync(DiscordWebsocketClient client, ValueWebSocketReceiveResult result, DiscordJsonReader reader)
    {
        _logger.Verbose($"{nameof(WebSocketHandler)}.{nameof(ProcessReceivedMessageAsync)} Processing Receive Message For: {{0}} State: {{1}} Type: {{2}} Size: {{3}}", client.WebsocketId, client.SocketState, result.MessageType, reader.Stream.Length);

        if (client.WebSocketState == WebSocketState.CloseReceived && result.MessageType == WebSocketMessageType.Close)
        {
            if (client.SocketState != SocketState.Disconnected && client.SocketState != SocketState.Disconnecting)
            {
                WebSocketCloseStatus closeStatus = client.CloseStatus ?? WebSocketCloseStatus.NormalClosure;
                return DisconnectInternal(client, closeStatus, $"Websocket closed by Discord. {client.CloseStatusDescription}", true);
            }

            return new ValueTask();
        }

        //_logger.Debug($"{nameof(WebSocketHandler)}.{nameof(ProcessReceivedMessage)} Invoke On Message: {{0}}", message);
        return _handler.SocketMessage(client.WebsocketId, reader);
    }

    /// <summary>
    /// Sends the string message over the web socket
    /// </summary>
    /// <param name="stream">Stream to send</param>
    public ValueTask<bool> SendAsync(MemoryStream stream)
    {
        if (stream.Length == 0)
        {
            return new ValueTask<bool>(false);
        }
            
        _sendLock.WaitOne();
        try
        {
            DiscordWebsocketClient client = _client;
            if (client == null || client.WebSocketState != WebSocketState.Open)
            {
                return new ValueTask<bool>(false);
            }
            
            return SendInternalAsync(_client, stream);
        }
        finally
        {
            _sendLock.Set();
        }
    }
        
    private async ValueTask<bool> SendInternalAsync(DiscordWebsocketClient client, MemoryStream stream)
    {
        stream.Position = 0;
        int readIndex = 0;
        while (!client.IsCancelRequested)
        {
            int read = await stream.ReadAsync(_sendBuffer, client.Token).ConfigureAwait(false);
            readIndex += read;
            bool endOfMessage = readIndex == stream.Length;
            //_logger.Debug($"{nameof(WebSocketHandler)}.{nameof(SendInternalAsync)} Sending Message Amount: {{0}} ({{1}}/{{2}}) Message: {{3}} - {{4}} End Of Message: {{5}}", read, readIndex, stream.Length, g, g.Length, endOfMessage);
            await client.SendAsync(_sendBuffer.Slice(0, read), WebSocketMessageType.Text, endOfMessage).ConfigureAwait(false);
            if (endOfMessage)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Disconnects from the websocket with the given code and reason
    /// </summary>
    /// <param name="code">Code to close with</param>
    /// <param name="reason">Reason for the close</param>
    /// <returns></returns>
    public ValueTask Disconnect(int code, string reason)
    {
        return Disconnect((WebSocketCloseStatus)code, reason);
    }
        
    /// <summary>
    /// Disconnects from the websocket with the given code and reason
    /// </summary>
    /// <param name="status"><see cref="WebSocketCloseStatus"/>to close with</param>
    /// <param name="reason">Reason for the close</param>
    /// <returns></returns>
    public ValueTask Disconnect(WebSocketCloseStatus status, string reason)
    {
        return DisconnectInternal(_client, status, reason, false);
    }

    /// <summary>
    /// Disconnects from the websocket with the given code and reason
    /// </summary>
    /// <param name="client">Client for the websocket</param>
    /// <param name="status">Status to close with</param>
    /// <param name="reason">Reason for the close</param>
    /// <param name="closeReceived">If we received a close from the websocket</param>
    /// <returns></returns>
    private async ValueTask DisconnectInternal(DiscordWebsocketClient client, WebSocketCloseStatus status, string reason, bool closeReceived)
    {
        _logger.Debug($"{nameof(WebSocketHandler)}.{nameof(Disconnect)} Status: {{0}} Reason: {{1}} Close Received: {{2}} Socket State: {{3}} Client State: {{4}} Cancel Requested {{5}}",
            status, reason, closeReceived, client?.WebSocketState, client?.SocketState, client?.IsCancelRequested);

        if (client == null)
        {
            return;
        }
            
        Snowflake id = client.WebsocketId;
            
        try
        {
            if (client.SocketState == SocketState.Connected && !client.IsCancelRequested)
            {
                await client.CloseSocket(status, reason).ConfigureAwait(false);
                DisposeSocket();
                await _handler.SocketClosed(id, status, reason).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            _logger.Exception("An error occured closing socket ID: {0}", id, ex);
        }
    }

    private void DisposeSocket()
    {
        _client?.Dispose();
        _client = null;
    }
}