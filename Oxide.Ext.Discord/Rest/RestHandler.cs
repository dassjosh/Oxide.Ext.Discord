using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Represents a REST handler for a bot
    /// </summary>
    public class RestHandler : IDebugLoggable
    {
        /// <summary>
        /// <see cref="HttpClient"/> for API Requests
        /// </summary>
        public readonly HttpClient Client;

        /// <summary>
        /// Global Rate Limit for the bot
        /// </summary>
        public readonly RestRateLimit RateLimit;
        
        /// <summary>
        /// Buckets with Routes we don't know the Hash of yet
        /// </summary>
        public readonly ConcurrentDictionary<BucketId, Bucket> Buckets = new();

        /// <summary>
        /// Route to Bucket ID
        /// </summary>
        public readonly ConcurrentDictionary<BucketId, BucketId> RouteToBucketId = new();

        private readonly ILogger _logger;
        
        internal static readonly RestHandler Global = new(DiscordExtension.GlobalLogger);

        /// <summary>
        /// Creates a new REST handler for bot / webhook clients
        /// </summary>
        /// <param name="logger"></param>
        public RestHandler(ILogger logger)
        {
            HttpClientHandler handler = new()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false
            };
            Client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(DiscordEndpoints.Rest.ApiUrl)
            };
            Client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            Client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            Client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("deflate"));
            Client.DefaultRequestHeaders.Add("user-agent", $"DiscordBot (https://github.com/dassjosh/Oxide.Ext.Discord, v{DiscordExtension.FullExtensionVersion})");
            _logger = logger;
            RateLimit = new RestRateLimit(logger);
        }
        
        /// <summary>
        /// Creates a new REST handler for a bot client
        /// </summary>
        /// <param name="client">Client the request is for</param>
        /// <param name="logger">Logger from the client</param>
        public RestHandler(BotClient client, ILogger logger) : this(logger)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", client.Connection.ApiToken);
        }

        /// <summary>
        /// Performs ann HTTP Get Request with TResult response
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="options">Options for the request</param>
        /// <typeparam name="TResult">Result to be returned from the request</typeparam>
        public IPromise<TResult> Get<TResult>(DiscordClient client, string url, RequestOptions? options = null) => CreateRequest<TResult>(client, url, RequestMethod.GET, null, options);

        /// <summary>
        /// Performs a HTTP Post Request
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to post</param>
        /// <param name="options">Options for the request</param>
        public IPromise Post(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest(client, url, RequestMethod.POST, data, options);

        /// <summary>
        /// Performs an HTTP Post Request with TResult response
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to post</param>
        /// <param name="options">Options for the request</param>
        /// <typeparam name="TResult">Result to be returned from the request</typeparam>
        public IPromise<TResult> Post<TResult>(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest<TResult>(client, url, RequestMethod.POST, data, options);

        /// <summary>
        /// Performs an HTTP Put Request
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to put</param>
        /// <param name="options">Options for the request</param>
        public IPromise Put(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest(client, url, RequestMethod.PUT, data, options);

        /// <summary>
        /// Performs an HTTP Put Request with TResult response
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to put</param>
        /// <typeparam name="TResult">Result to be returned from the request</typeparam>
        /// <param name="options">Options for the request</param>
        public IPromise<TResult> Put<TResult>(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest<TResult>(client, url, RequestMethod.PUT, data, options);

        /// <summary>
        /// Performs an HTTP Patch Request
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to patch</param>
        /// <param name="options">Options for the request</param>
        public IPromise Patch(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest(client, url, RequestMethod.PATCH, data, options);

        /// <summary>
        /// Performs an HTTP Patch Request with TResult response
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="data">Data to patch</param>
        /// <param name="options">Options for the request</param>
        /// <typeparam name="TResult">Result to be returned from the request</typeparam>
        public IPromise<TResult> Patch<TResult>(DiscordClient client, string url, object data, RequestOptions? options = null) => CreateRequest<TResult>(client, url, RequestMethod.PATCH, data, options);
        
        /// <summary>
        /// Performs a HTTP Delete Request
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="options">Options for the request</param>
        public IPromise Delete(DiscordClient client, string url, RequestOptions? options = null) => CreateRequest(client, url, RequestMethod.DELETE, null, options);
        
        /// <summary>
        /// Performs an HTTP Delete Request with TResult response
        /// </summary>
        /// <param name="client">Client for the request</param>
        /// <param name="url">Url for the request</param>
        /// <param name="options">Options for the request</param>
        /// <typeparam name="TResult">Result to be returned from the request</typeparam>
        public IPromise<TResult> Delete<TResult>(DiscordClient client, string url, RequestOptions? options = null) => CreateRequest<TResult>(client, url, RequestMethod.DELETE, null, options);

        /// <summary>
        /// Creates a new request and queues it to be run
        /// </summary>
        /// <param name="client">Client making the request</param>
        /// <param name="url">URL of the request</param>
        /// <param name="method">HTTP method of the request</param>
        /// <param name="data">Data to be sent with the request</param>
        /// <param name="options">Options for the request</param>
        private IPromise CreateRequest(DiscordClient client, string url, RequestMethod method, object data, RequestOptions? options)
        {
            PerformValidation(data);
            IPendingPromise promise = Promise.Create();
            Request request = Request.CreateRequest(DiscordPool.Internal, client, Client, method, url, data, promise, options ?? default(RequestOptions));
            StartRequest(request);
            return promise;
        }

        /// <summary>
        /// Creates a new request and queues it to be run
        /// </summary>
        /// <param name="client">Client making the request</param>
        /// <param name="url">URL of the request</param>
        /// <param name="method">HTTP method of the request</param>
        /// <param name="data">Data to be sent with the request</param>
        /// <param name="options">Options for the request</param>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        private IPromise<T> CreateRequest<T>(DiscordClient client, string url, RequestMethod method, object data, RequestOptions? options)
        {
            PerformValidation(data);
            IPendingPromise<T> promise = Promise<T>.Create();
            Request<T> request = Request<T>.CreateRequest(DiscordPool.Internal, client, Client, method, url, data, promise, options ?? default(RequestOptions));
            StartRequest(request);
            return promise;
        }

        private void PerformValidation(object data)
        {
            if (!DiscordConfig.Instance.Validation.EnableValidation || data is not IDiscordValidation validate)
            {
                return;
            }
            
            try
            {
                validate.Validate();
            }
            catch (Exception)
            {
                _logger.Error($"An error occured duration object validation.\n{JsonConvert.SerializeObject(data, DiscordJson.IndentedSettings)}");
                throw;
            }
        }

        /// <summary>
        /// Starts the request
        /// </summary>
        /// <param name="request">Request to be started</param>
        public void StartRequest(BaseRequest request)
        {
            _logger.Debug($"{nameof(RestHandler)}.{nameof(StartRequest)} Method: {{0}} Route: {{1}}", request.Method, request.Route);
            RequestHandler handler = RequestHandler.CreateRequest(request);
            QueueBucket(handler, request);
        }
        
        /// <summary>
        /// Queues the request for the bucket
        /// </summary>
        public void QueueBucket(RequestHandler handler, BaseRequest request)
        {
            BucketId bucketId = BucketIdFactory.GenerateId(request.Method, request.Route);
            _logger.Debug("RestHandler Queuing Bucket for {0} bucket {1}",  request.Route, bucketId);
            Bucket bucket = GetBucket(bucketId);
            bucket.QueueRequest(handler);
        }

        internal void UpgradeToKnownBucket(Bucket bucket, BucketId newBucketId)
        {
            _logger.Debug("RestHandler Upgrading To Known Bucket for Old ID: {0} New ID: {1}", bucket.Id, newBucketId);
            RouteToBucketId[bucket.Id] = newBucketId;

            if (Buckets.TryGetValue(newBucketId, out Bucket existing))
            {
                existing.Merge(bucket);
                bucket.Dispose();
                return;
            }

            Buckets.TryRemove(bucket.Id, out Bucket _);
            bucket.Id = newBucketId;
            bucket.IsKnownBucket = true;
            Buckets[newBucketId] = bucket;
        }

        internal void RemoveBucket(Bucket bucket)
        {
            Buckets.TryRemove(bucket.Id, out Bucket _);
            bucket.ShutDown();
            bucket.Dispose();
        }

        /// <summary>
        /// Returns the bucket with the given ID
        /// </summary>
        /// <param name="bucketId"></param>
        /// <returns></returns>
        public Bucket GetBucket(BucketId bucketId)
        {
            if (RouteToBucketId.TryGetValue(bucketId, out BucketId value))
            {
                bucketId = value;
            }

            if (!Buckets.TryGetValue(bucketId, out Bucket bucket))
            {
                bucket = DiscordPool.Internal.Get<Bucket>();
                bucket.Init(bucketId, this, _logger);
                Buckets[bucketId] = bucket;
            }

            return bucket;
        }

        internal void OnClientClosed(DiscordClient client)
        {
            _logger.Debug($"{nameof(RestHandler)}.{nameof(OnClientClosed)} Client: {{0}}", client.Plugin.FullName());
            foreach (Bucket bucket in Buckets.Values)
            {
                bucket.AbortClientRequests(client);
            }
        }

        /// <summary>
        /// Shutdown the REST handler
        /// </summary>
        public void Shutdown()
        {
            foreach (KeyValuePair<BucketId, Bucket> bucket in Buckets)
            {
                bucket.Value.ShutDown();
                bucket.Value.Dispose();
            }
            
            RouteToBucketId.Clear();
            Buckets.Clear();
            RateLimit.Shutdown();
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendList("Buckets", Buckets.Values);
        }
    }
}