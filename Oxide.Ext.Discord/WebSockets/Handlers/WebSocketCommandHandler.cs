using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.WebSockets
{
    /// <summary>
    /// Handles command queueing when the websocket is down
    /// </summary>
    public class WebSocketCommandHandler
    {
        private readonly BotClient _client;
        private readonly DiscordWebSocket _webSocket;
        private readonly ILogger _logger;
        private readonly ConcurrentQueue<WebSocketCommand> _pendingCommands = new();
        private readonly WebsocketRateLimit _rateLimit;
        private readonly AutoResetEvent _online = new(false);
        private readonly AutoResetEvent _commands = new(false);
        private readonly CancellationTokenSource _source;
        private readonly CancellationToken _token;
        private bool _isSocketReady;
        private bool _isDisposed;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Bot Client for socket commands</param>
        /// <param name="webSocket">Websocket to handle commands for</param>
        /// <param name="logger">Logger for this handler</param>
        public WebSocketCommandHandler(BotClient client, DiscordWebSocket webSocket, ILogger logger)
        {
            _client = client;
            _webSocket = webSocket;
            _logger = logger;
            _rateLimit = new WebsocketRateLimit(_logger);
            
            _source = new CancellationTokenSource();
            _token = _source.Token;

            Task.Factory.StartNew(RunInternal, _token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private async void RunInternal()
        {
            try
            {
                await SendCommandsInternal().ConfigureAwait(false);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.Exception($"Unhandled exception in {nameof(WebSocketCommandHandler)}.{nameof(RunInternal)}", ex);
            }
        }

        private async ValueTask SendCommandsInternal()
        {
            while (_source is {IsCancellationRequested: false})
            {
                WebSocketCommand command = null;
                try
                {
                    _online.WaitOne();
                    _commands.WaitOne();

                    if (_rateLimit.HasReachedRateLimit)
                    {
                        DateTimeOffset reset = _rateLimit.NextReset();
                        if (reset > DateTimeOffset.UtcNow)
                        {
                            await reset.DelayUntil(_token).ConfigureAwait(false);
                        }
                    
                        continue;
                    }

                    command = GetNextCommand();
                    if (command == null)
                    {
                        continue;
                    }

                    //If the client has been disconnect don't run it's command
                    if (command.Client.Bot == null)
                    {
                        RemoveCommand(command);
                        continue;
                    }

                    if (!_rateLimit.CanFireRequest(command))
                    {
                        _logger.Warning($"{nameof(WebSocketCommandHandler)}.{nameof(SendCommandsInternal)} Skipping websocket command for plugin {{0}} Exceeded Rate Limit of {{1}} Requests in {{2}} Seconds! Report this error to the plugin author.", command.Client.PluginName, WebsocketRateLimit.MaxRequestPerPlugin, WebsocketRateLimit.RateLimitInterval / 1000);
                        RemoveCommand(command);
                        continue;
                    }
                    
                    _logger.Debug($"{nameof(WebSocketCommandHandler)}.{nameof(SendCommandsInternal)} {{0}} Sending Command {{1}}", command.Client.PluginName, command.Payload.OpCode);

                    _rateLimit.FiredRequest(command);
                    
                    await _webSocket.SendAsync(command.Payload).ConfigureAwait(false);
                    RemoveCommand(command);
                }
                catch(OperationCanceledException) {}
                catch (Exception ex)
                {
                    _logger.Exception("An error occured sending commands", ex);
                    if (command != null)
                    {
                        RemoveCommand(command);
                    }
                    
                    await Task.Delay(1000, _token).ConfigureAwait(false);
                }
                finally
                {
                    if (_isSocketReady)
                    {
                        _online.Set();
                    }
                    
                    if (!_pendingCommands.IsEmpty)
                    {
                        _commands.Set();
                    }
                }
            }
        }

        private WebSocketCommand GetNextCommand()
        {
            if (_isSocketReady && _pendingCommands.TryPeek(out WebSocketCommand command))
            {
                return command;
            }

            return null;
        }

        private void RemoveCommand(WebSocketCommand command)
        {
            _pendingCommands.TryDequeue(out WebSocketCommand _);
            command.Dispose();
        }

        /// <summary>
        /// Enqueue a payload to be sent over the websocket
        /// If the websocket is connected it will be sent immediately
        /// If the websocket is not connected it will be queued until it is back online
        /// </summary>
        /// <param name="command">Command to send over the websocket</param>
        public void Enqueue(WebSocketCommand command)
        {
            _logger.Debug($"{nameof(WebSocketCommandHandler)}.{nameof(Enqueue)} {{0}} Queuing command {{1}}", command.Client.PluginName, command.Payload.OpCode);
            _pendingCommands.Enqueue(command);
            _commands.Set();
        }
        
        internal void OnWebSocketReady()
        {
            _logger.Debug($"{nameof(WebSocketCommandHandler)}.{nameof(OnWebSocketReady)} Socket Connected. Sending queued commands.");
            _isSocketReady = true;
            _online.Set();
        }

        internal void OnSocketDisconnected()
        {
            if (_isDisposed)
            {
                return;
            }
            
            _logger.Debug($"{nameof(WebSocketCommandHandler)}.{nameof(OnSocketDisconnected)} Socket Disconnected. Queuing Commands.");
            _online.Reset();
            while (!_pendingCommands.IsEmpty)
            {
                _pendingCommands.TryDequeue(out WebSocketCommand _);
            }
            _isSocketReady = false;
        }

        internal void OnSocketShutdown()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _online.Reset();
            _commands.Reset();
            _online?.Dispose();
            _commands?.Dispose();
            _source?.Cancel();
        }

        internal IReadOnlyCollection<WebSocketCommand> GetPendingCommands()
        {
            return _pendingCommands;
        }
    }
}