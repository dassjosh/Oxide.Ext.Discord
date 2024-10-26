namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Discord API Request Status
    /// </summary>
    public enum RequestStatus : byte
    {
        /// <summary>
        /// Request is in the queue waiting to be processed
        /// </summary>
        InQueue,
        
        /// <summary>
        /// Request has been started
        /// </summary>
        Started,
        
        /// <summary>
        /// Requesting is waiting for bucket to be ready
        /// </summary>
        PendingBucket,

        /// <summary>
        /// Request is waiting to start
        /// </summary>
        PendingStart,
        
        /// <summary>
        /// Request is in progress
        /// </summary>
        InProgress,
        
        /// <summary>
        /// Request completed and was not canceled
        /// </summary>
        Completed,
        
        /// <summary>
        /// Request was canceled
        /// </summary>
        Cancelled
    }
}