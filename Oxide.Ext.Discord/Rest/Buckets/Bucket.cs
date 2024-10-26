using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Contains bucket information for a REST API Bucket
    /// </summary>
    public class Bucket : BasePoolable, IDebugLoggable
    {
        /// <summary>
        /// The ID of this bucket which is based on the route
        /// </summary>
        internal BucketId Id;

        /// <summary>
        /// The number of requests that can be made per rate limit reset
        /// </summary>
        internal int Limit;

        /// <summary>
        /// How many requests are remaining before hitting the rate limit for the bucket
        /// </summary>
        internal volatile int Remaining;

        /// <summary>
        /// How long until the rate limit resets
        /// </summary>
        internal DateTimeOffset ResetAt;

        internal bool IsKnownBucket;

        private RestRateLimit _rateLimit;
        private ILogger _logger;
        private RestHandler _rest;
        
        private readonly SemaphoreSlim _requestSync = new(1, 1);
        private readonly object _completedSync = new();
        internal readonly AdjustableSemaphore ActiveRequestsSemaphore = new(1);
        private readonly DiscordConcurrentQueue<RequestHandler> _requestQueue = new();
        private readonly ConcurrentDictionary<Snowflake, RequestHandler> _activeRequests = new();
        private readonly HashSet<string> _routes = new();

        private bool _isShutdown;

        /// <summary>
        /// Creates a new bucket for the given <see cref="RestHandler"/>
        /// </summary>
        /// <param name="bucketId">ID of the bucket. If not a known bucket, then it will be part of the route. If known bucket, it will be the Discord bucket ID</param>
        /// <param name="rest">The handler that owns this Bucket</param>
        /// <param name="logger">Logger for this bucket</param>
        public void Init(BucketId bucketId, RestHandler rest, ILogger logger)
        {
            Id = bucketId;
            _rest = rest;
            _rateLimit = rest.RateLimit;
            _logger = logger;
            _logger.Debug($"{nameof(Bucket)}.{nameof(Init)} Bucket Created: {{0}}", Id);
            ActiveRequestsSemaphore.Reset();
            Limit = 1;
            Remaining = 1;
            ResetAt = DateTimeOffset.MinValue;
            _routes.Add(bucketId.Id);
        }

        /// <summary>
        /// Queues a new request for the bucket
        /// </summary>
        /// <param name="handler"><see cref="RequestHandler"/> to be queued</param>
        public void QueueRequest(RequestHandler handler)
        {
            BaseRequest request = handler.Request;
            request.Bucket?.DequeueRequest(handler);
            request.Bucket = this;
            if (handler.Request.Status == RequestStatus.InQueue)
            {
                _requestQueue.Add(handler);
            }
            else
            {
                _activeRequests.TryAdd(handler.Request.Id, handler);
            }

            if (ResetAt < DateTimeOffset.UtcNow)
            {
                Remaining = Limit;
            }
            
            CheckPendingRequests();
            _logger.Debug("Queued Request Bucket ID: {0} Request ID: {1} Requests: {2} Queued: {3}", Id, request.Id, request.Method, request.Route, _activeRequests.Count, _requestQueue.Count);
        }

        private void CheckPendingRequests()
        {
            while(_activeRequests.Count < Limit && _requestQueue.TryTake(out RequestHandler handler))
            {
                _activeRequests[handler.Request.Id] = handler;
                handler.StartRequest();
            }
        }

        private void DequeueRequest(RequestHandler handler)
        {
            _activeRequests.TryRemove(handler.Request.Id, out RequestHandler _);
            _requestQueue.Remove(handler);
        }
        
        internal void Merge(Bucket data)
        {
            List<RequestHandler> handlers = DiscordPool.Internal.GetList<RequestHandler>();
            handlers.AddRange(data._activeRequests.Values);

            foreach (RequestHandler handler in handlers)
            {
                QueueRequest(handler);
            }
            
            data._activeRequests.Clear();

            handlers.Clear();
            foreach (RequestHandler handler in data._requestQueue)
            {
                handlers.Add(handler);
            }

            foreach (RequestHandler handler in handlers)
            {
                QueueRequest(handler);
            }
            
            DiscordPool.Internal.FreeList(handlers);

            foreach (string route in data._routes)
            {
                _routes.Add(route);
            }
        }

        internal async ValueTask WaitUntilBucketAvailable(RequestHandler handler, CancellationToken token)
        {
            BaseRequest request = handler.Request;
            DiscordClient client = request.Client;

            if (_isShutdown)
            {
                return;
            }

            if (request.Options.IgnoreRateLimit)
            {
                return;
            }

            await _requestSync.WaitAsync(token).ConfigureAwait(false);
            
            try
            {
                while (true)
                {
                    if (_rateLimit.HasReachedRateLimit)
                    {
                        DateTimeOffset resetAt = _rateLimit.NextReset();
                        _logger.Debug($"{nameof(Bucket)}.{nameof(WaitUntilBucketAvailable)} Plugin: {{0}} Bucket ID: {{1}} Request ID: {{2}} Can't Start Request Due to Global Rate Limit Method: {{3}} Url: {{4}} Waiting For: {{5}} Seconds", client.PluginName, Id, request.Id, request.Method, request.Route, (resetAt - DateTimeOffset.UtcNow).TotalSeconds);
                        await resetAt.DelayUntil(token).ConfigureAwait(false);
                        continue;
                    }

                    if ((Limit == 0 || Remaining == 0) && ResetAt > DateTimeOffset.UtcNow)
                    {
                        _logger.Debug($"{nameof(Bucket)}.{nameof(WaitUntilBucketAvailable)} Plugin: {{0}} Bucket ID: {{1}} Request ID: {{2}} Can't Start Request Due to Bucket Rate Limit Method: {{3}} Url: {{4}} Limit: {{5}} Remaining: {{6}} Waiting For: {{7}} Seconds", client.PluginName, Id, request.Id, request.Method, request.Route, Limit, Remaining, (ResetAt - DateTimeOffset.UtcNow).TotalSeconds);
                        await ResetAt.DelayUntil(token).ConfigureAwait(false);
                        continue;
                    }

                    if (Remaining < 0)
                    {
                        _logger.Debug($"{nameof(Bucket)}.{nameof(WaitUntilBucketAvailable)} Plugin: {{0}} Bucket ID: {{1}} Request ID: {{2}} Can't Start Request Due to Remaining < 0: {{3}} Url: {{4}} Limit: {{5}} Remaining: {{6}} Waiting For: {{7}} Seconds", client.PluginName, Id, request.Id, request.Method, request.Route, Limit, Remaining, (ResetAt - DateTimeOffset.UtcNow).TotalSeconds);
                        await ResetAt.DelayUntil(100, token).ConfigureAwait(false);
                        continue;
                    }

                    _logger.Debug($"{nameof(Bucket)}.{nameof(WaitUntilBucketAvailable)} Plugin: {{0}} Bucket ID: {{1}} Request ID: {{2}} Can Start Request: Bucket: {{3}}/{{4}} Reset In: {{5}}", client.PluginName, Id, request.Id, Remaining, Limit, (ResetAt - DateTimeOffset.UtcNow).TotalSeconds);
                    break;
                }
                
                OnRequestStarted(handler);
            }
            finally
            {
                _requestSync.Release();
            }
        }
        
        private void OnRequestStarted(RequestHandler handler)
        {
            if (!handler.Request.Options.IgnoreRateLimit)
            {
                Interlocked.Decrement(ref Remaining);
                _rateLimit.FiredRequest();
                _logger.Debug($"{nameof(Bucket)}.{nameof(OnRequestStarted)} ID: {{0}} Has Started Bucket {{1}}/{{2}}", handler.Request.Id, Remaining, Limit);
            }
        }

        internal void OnRequestCompleted(RequestHandler handler, RequestResponse response)
        {
            RateLimitResponse rateLimit = response.RateLimit;

            if (_isShutdown)
            {
                return;
            }
            
            if (!_activeRequests.TryRemove(handler.Request.Id, out RequestHandler _))
            {
                _logger.Warning("Failed to remove request from bucket!!! Bucket ID: {0} Request ID: {1} Method: {2} Route: {3} Status: {4}", Id, handler.Request.Id, handler.Request.Method, handler.Request.Route, handler.Request.Status);
            }

            lock (_completedSync)
            {
                if (!handler.Request.Options.IgnoreRateLimit && !IsKnownBucket && rateLimit is {BucketId: {IsValid: true}})
                {
                    _rest.UpgradeToKnownBucket(this, rateLimit.BucketId);
                    if (!IsKnownBucket)
                    {
                        ActiveRequestsSemaphore.AllowAllThrough();
                    }
                }
                
                CheckPendingRequests();
                
                if (_activeRequests.Count == 0)
                {
                    OnBucketCompleted();
                }
            }
        }
        
        internal void UpdateRateLimits(RequestHandler handler, RequestResponse response)
        {
            BaseRequest request = handler.Request;
            RateLimitResponse rateLimit = response.RateLimit;
            
            if (rateLimit == null)
            {
                return;
            }
            
            if (request.Options.IgnoreRateLimit)
            {
                return;
            }
            
            if (rateLimit.IsGlobalRateLimit)
            {
                _rateLimit.ReachedRateLimit(rateLimit.ResetAt);
            }
            
            if (request.Client.Logger.IsLogging(DiscordLogLevel.Verbose))
            {
                request.Client.Logger.Verbose($"{nameof(Bucket)}.{nameof(UpdateRateLimits)} Pre Bucket ID: {{0}} Scope: {{1}} Request ID: {{2}} Limit: {{3}} Remaining: {{4}} Reset: {{5}} Reset In: {{6}}s Rate Limit Bucket ID: {{7}}", Id, rateLimit.Scope, request.Id, Limit, Remaining, ResetAt, (ResetAt - DateTimeOffset.UtcNow).TotalSeconds, rateLimit.BucketId);
            }

            DateTimeOffset currentResetAt = ResetAt;
            if (rateLimit.ResetAt > currentResetAt)
            {
                ResetAt = rateLimit.ResetAt;
                //Ensure the ResetAt really is Greater
                if (rateLimit.ResetAt > currentResetAt + TimeSpan.FromMilliseconds(250) || Limit != rateLimit.Limit)
                {
                    Limit = rateLimit.Limit;
                    Interlocked.Exchange(ref Remaining, rateLimit.Remaining);
                }
            }
            else
            {
                Interlocked.Exchange(ref Remaining, Math.Min(Remaining, rateLimit.Remaining));
            }

            if (ActiveRequestsSemaphore.MaximumCount != rateLimit.Limit)
            {
                ActiveRequestsSemaphore.MaximumCount = Math.Max(rateLimit.Limit, 1);
            }
            
            if(request.Client.Logger.IsLogging(DiscordLogLevel.Verbose))
            {
                request.Client.Logger.Verbose($"{nameof(Bucket)}.{nameof(UpdateRateLimits)} Post Bucket ID: {{0}} Scope: {{1}} Request ID: {{2}} Limit: {{3}} Remaining: {{4}} Reset: {{5}} Reset In: {{6}}s Rate Limit Bucket ID: {{7}}", Id, rateLimit.Scope, request.Id, Limit, Remaining, ResetAt, (ResetAt - DateTimeOffset.UtcNow).TotalSeconds, rateLimit.BucketId);
            }
        }

        internal void AbortClientRequests(DiscordClient client)
        {
            List<RequestHandler> handlers = DiscordPool.Internal.GetList<RequestHandler>();
            foreach (RequestHandler handler in _requestQueue)
            {
                if (handler.Request.Client.PluginId == client.PluginId)
                {
                    handlers.Add(handler);
                }
            }
            
            _requestQueue.RemoveAll(r => handlers.Contains(r));
            foreach (RequestHandler handler in handlers)
            {
                handler.Abort();
                handler.Dispose();
            }
            
            DiscordPool.Internal.FreeList(handlers);

            _activeRequests.RemoveAll(h => h.Request.Client.PluginId == client.PluginId, h =>
            {
                h.Abort();
                h.Dispose();
            });
        }

        private void OnBucketCompleted()
        {
            if (!IsKnownBucket)
            {
                _logger.Debug($"{nameof(Bucket)}.{nameof(OnBucketCompleted)} Bucket Completed: {{0}}", Id);
                _rest.RemoveBucket(this);
            }
        }

        internal void ShutDown()
        {
            _logger.Debug("Shutting down bucket ID: {0}", Id);
            foreach (RequestHandler handler in _requestQueue)
            {
                handler.Abort();
                handler.Dispose();
            }
                
            _requestQueue.Clear();
            
            foreach (RequestHandler handler in _activeRequests.Values)
            {
                handler.Abort();
                handler.Dispose();
            }
            
            _activeRequests.Clear();
            _isShutdown = true;
        }

        ///<inheritdoc/>
        protected override void LeavePool()
        {
            _isShutdown = false;
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            ActiveRequestsSemaphore.AllowAllThrough();
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("ID", Id.Id);
            logger.AppendField("Known Bucket", IsKnownBucket);
            logger.AppendField("Remaining", Remaining);
            logger.AppendField("Limit", Limit);
            logger.AppendField("Reset At", ResetAt.ToString());
            logger.AppendField("Reset In", ((ResetAt - DateTimeOffset.UtcNow).TotalSeconds).ToString(CultureInfo.InvariantCulture), "Seconds");
            logger.AppendField("Active Count", _activeRequests.Count);
            logger.AppendField("Queue Count", _requestQueue.Count);
            logger.AppendFieldOutOf("Semaphore", ActiveRequestsSemaphore.Available, ActiveRequestsSemaphore.MaximumCount);
            logger.AppendList("Routes", _routes);
            logger.AppendList("Active Requests", _activeRequests.Values);
            logger.AppendList("Queued Requests", _requestQueue);
        }
    }
}