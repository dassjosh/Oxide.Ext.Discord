using System.Net.Http;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Represents a Request that does not return data
    /// </summary>
    public class Request : BaseRequest
    {
        private IPendingPromise _promise;

        /// <summary>
        /// Creates a REST API request that returns type of T from the response
        /// </summary>
        /// <param name="pluginPool"><see cref="DiscordPluginPool"/> for the request</param>
        /// <param name="client">Client making the request</param>
        /// <param name="httpClient"><see cref="HttpClient"/> for the request</param>
        /// <param name="method">HTTP web method</param>
        /// <param name="route">Route for the request</param>
        /// <param name="data">Data being passed into the request. Null if no data is passed</param>
        /// <param name="promise">Promise for the request</param>
        /// <param name="options">Options for the request</param>
        /// <returns>A <see cref="Request{T}"/></returns>
        public static Request CreateRequest(DiscordPluginPool pluginPool, DiscordClient client, HttpClient httpClient, RequestMethod method, string route, object data, IPendingPromise promise, RequestOptions options)
        {
            Request request = pluginPool.Get<Request>();
            request.Init(client, httpClient, method, route, data, options);
            request._promise = promise;
            return request;
        }

        ///<inheritdoc/>
        protected override void OnRequestSuccess(RequestResponse response)
        {
            _promise.Resolve();
        }

        ///<inheritdoc/>
        protected override void OnRequestError(RequestResponse response)
        {
            _promise.Finally(response.Error.LogError);
            _promise.Reject(response.Error);
        }

        internal override void Abort()
        {
            if (Status != RequestStatus.Cancelled)
            {
                _promise.Reject(new RequestCancelledException());
                base.Abort();
            }
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            _promise = null;
        }
    }
}