using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Pooling;

namespace Oxide.Ext.Discord.Rest.Requests.Data
{
    /// <summary>
    /// Represents Request Data to be passed into the REST API request
    /// </summary>
    public class RequestData : BasePoolable
    {
        /// <summary>
        /// Data serialized to bytes 
        /// </summary>
        public byte[] Contents;
        
        /// <summary>
        /// The content type of the data
        /// </summary>
        public string ContentType;
        
        /// <summary>
        /// Data to be serialized into the request
        /// </summary>
        protected object Data;

        /// <summary>
        /// Client making the request
        /// </summary>
        protected DiscordClient Client;

        private const string DefaultContentType = "application/json";

        /// <summary>
        /// Creates request data for the given request
        /// </summary>
        /// <param name="request">Request to create data for</param>
        /// <returns><see cref="RequestData"/></returns>
        public static RequestData CreateRequestData(BaseRequest request)
        {
            if (request.Data is IFileAttachments attachments && attachments.FileAttachments != null && attachments.FileAttachments.Count != 0)
            {
                MultipartRequestData multipart = DiscordPool.Get<MultipartRequestData>();
                multipart.Init(request.Client, attachments);
                return multipart;
            }
            
            RequestData data = DiscordPool.Get<RequestData>();
            data.Init(request.Client, request.Data);
            return data;
        }
        
        private void Init(DiscordClient client, object data)
        {
            Client = client;
            Data = data;
            ContentType = DefaultContentType;
            if (Data != null)
            {
                Contents = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data, Client.Bot.ClientSerializerSettings));
            }
        }

        /// <summary>
        /// Writes the request data to the web request
        /// </summary>
        /// <param name="request">Request to be written to</param>
        public void WriteRequestData(WebRequest request)
        {
            if (Contents == null || Contents.Length == 0)
            {
                return;
            }

            request.ContentLength = Contents.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(Contents, 0, Contents.Length);
            }
        }
        
        ///<inheritdoc/>
        protected override void DisposeInternal()
        {
            DiscordPool.Free(this);
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            Contents = null;
            ContentType = null;
            Data = null;
            Client = null;
        }
    }
}