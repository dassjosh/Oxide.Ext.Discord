namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents possible HTTP Codes sent from discord
    /// </summary>
    public enum DiscordHttpStatusCode : ushort
    {
        /// <summary>
        /// The request completed successfully.
        /// </summary>
        Ok = 200,
        
        /// <summary>
        /// The entity was created successfully.
        /// </summary>
        Created = 201,
        
        /// <summary>
        /// The request completed successfully but returned no content.
        /// </summary>
        NoContent = 204,
        
        /// <summary>
        /// The entity was not modified (no action was taken).
        /// </summary>
        NotModified = 304,
        
        /// <summary>
        /// The request was improperly formatted, or the server couldn't understand it.
        /// </summary>
        BadRequest = 400,
        
        /// <summary>
        /// The Authorization header was missing or invalid.
        /// </summary>
        Unauthorized = 401,
        
        /// <summary>
        /// The Authorization token you passed did not have permission to the resource.
        /// </summary>
        Forbidden = 403,
        
        /// <summary>
        /// The resource at the location specified doesn't exist.
        /// </summary>
        NotFound = 404,
        
        /// <summary>
        /// The HTTP method used is not valid for the location specified.
        /// </summary>
        MethodNotAllowed = 405,
        
        /// <summary>
        /// You are being rate limited, see Rate Limits.
        /// </summary>
        TooManyRequests = 429,
        
        /// <summary>
        /// Server Error
        /// </summary>
        InternalServerError = 500,
        
        /// <summary>
        /// There was not a gateway available to process your request. Wait a bit and retry.
        /// </summary>
        GatewayUnavailable = 502
    }
}