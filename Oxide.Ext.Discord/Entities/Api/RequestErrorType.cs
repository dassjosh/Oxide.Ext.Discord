namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a Discord Request Error Type
    /// </summary>
    public enum RequestErrorType : byte
    {
        /// <summary>
        /// A generic web error occured
        /// </summary>
        GenericWeb,
        
        /// <summary>
        /// An Internal HTTP Error Occured
        /// </summary>
        Internal,
        
        /// <summary>
        /// A Ratelimit Error Occured
        /// </summary>
        RateLimit,
        
        /// <summary>
        /// An Invalid request was passed to discord
        /// </summary>
        ApiError,

        /// <summary>
        /// An error occured during JSON serialization
        /// </summary>
        Serialization,
        
        /// <summary>
        /// A non web error occured
        /// </summary>
        Generic
    }
}