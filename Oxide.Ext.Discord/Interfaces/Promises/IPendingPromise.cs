// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents a promise the is still pending waiting to be resolved
    /// </summary>
    public interface IPendingPromise : IPromise, IRejectable
    {
        /// <summary>
        /// Resolves the promise
        /// </summary>
        void Resolve();
    }
}