using System.Net.Http;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a REST response from discord
    /// </summary>
    public class RequestResponse : BasePoolable
    {
        internal RequestCompletedStatus Status;
        internal RateLimitResponse RateLimit;
        internal ResponseError Error;
        internal DiscordHttpStatusCode Code;
        internal string Content;

        /// <summary>
        /// Create new REST response with the given data
        /// </summary>
        /// <param name="response">The Web Response for the request</param>
        /// <param name="status">The status of the request indicating if it was successful</param>
        /// <param name="error">If the request had an error the error created from the request</param>
        private async ValueTask Init(HttpResponseMessage response, RequestCompletedStatus status, ResponseError error = null)
        {
            Status = status;
            Error = error;

            if (response != null)
            {
                Code = (DiscordHttpStatusCode)response.StatusCode;
                Content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                RateLimit = DiscordPool.Internal.Get<RateLimitResponse>();
                RateLimit.Init(response.Headers, Code, Content);
                error?.SetResponse(Code, Content);
                error?.SetRateLimitResponse(RateLimit.Message, RateLimit.Code);
            }
        }

        /// <summary>
        /// Creates a success REST API response
        /// </summary>
        /// <param name="httpResponse">The Web Response for the request</param>
        /// <returns>A success <see cref="RequestResponse"/></returns>
        public static async ValueTask<RequestResponse> CreateSuccessResponse(HttpResponseMessage httpResponse)
        {
            RequestResponse response = DiscordPool.Internal.Get<RequestResponse>();
            await response.Init(httpResponse, RequestCompletedStatus.Success).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Creates a Web Exception REST API response
        /// </summary>
        /// <param name="error">Rest Error that occured</param>
        /// <param name="httpResponse">Web Response for the request</param>
        /// <param name="status">The request status containing the fail reason</param>
        /// <returns>A web exception <see cref="RequestResponse"/></returns>
        public static async ValueTask<RequestResponse> CreateExceptionResponse(ResponseError error, HttpResponseMessage httpResponse, RequestCompletedStatus status)
        {
            RequestResponse response = DiscordPool.Internal.Get<RequestResponse>();
            await response.Init(httpResponse, status, error).ConfigureAwait(false);
            return response;
        }
        
        /// <summary>
        /// Creates a REST API response for a cancelled request
        /// </summary>
        /// <returns>A cancelled <see cref="RequestResponse"/></returns>
        public static async ValueTask<RequestResponse> CreateCancelledResponse()
        {
            RequestResponse response = DiscordPool.Internal.Get<RequestResponse>();
            await response.Init(null, RequestCompletedStatus.Cancelled).ConfigureAwait(false);
            return response;
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            RateLimit?.Dispose();
            Status = default;
            RateLimit = null;
            Error = null;
            Code = 0;
            Content = null;
        }
    }
}