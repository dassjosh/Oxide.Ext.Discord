// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Specifies the state of a promise.
    /// </summary>
    public enum PromiseState : byte
    {
        /// The promise is in-flight.
        Pending,
        
        /// The promise has been rejected.
        Rejected,
        
        /// The promise has been resolved.
        Resolved
    }
}