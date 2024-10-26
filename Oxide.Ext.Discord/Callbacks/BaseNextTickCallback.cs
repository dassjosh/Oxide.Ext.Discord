using Oxide.Core;

namespace Oxide.Ext.Discord.Callbacks
{
    /// <summary>
    /// Represents a callback that calls next tick
    /// </summary>
    public abstract class BaseNextTickCallback : BaseCallback
    {
        /// <inheritdoc/>
        protected sealed override void Run()
        {
            Interface.Oxide.NextTick(Callback);
        }
    }
}