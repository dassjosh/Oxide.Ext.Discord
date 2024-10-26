// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents a promise waiting to be resolved
    /// </summary>
    /// <typeparam name="TPromised">Type of the resolved value</typeparam>
    public interface IPendingPromise<TPromised> : IPromise<TPromised>, IRejectable
    {
        /// <summary>
        /// Resolves the promise with the given value
        /// </summary>
        /// <param name="value"></param>
        void Resolve(TPromised value);
    }
}