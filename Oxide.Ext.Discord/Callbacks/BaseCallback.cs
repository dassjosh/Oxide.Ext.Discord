using System;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    /// <summary>
    /// Represents a base callback to be used when needing a lambda callback so no delegate or class is generated
    /// This class is pooled to prevent allocations
    /// </summary>
    public abstract class BaseCallback : BasePoolable
    {
        /// <summary>
        /// The callback to be called by the delegate
        /// </summary>
        protected readonly Action Callback;
        
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseCallback()
        {
            Callback = CallbackInternal;
        }

        /// <summary>
        /// Overridden in the child class to handle the callback
        /// </summary>
        protected abstract void HandleCallback();

        /// <summary>
        /// Run the callback
        /// </summary>
        protected virtual void Run()
        {
            Callback.Invoke();
        }

        private void CallbackInternal()
        {
            try
            {
                HandleCallback();
            }
            finally
            {
                Dispose();
            }
        }
    }
}