using System;
using Oxide.Ext.Discord.Pooling;

namespace Oxide.Ext.Discord.Callbacks
{
    /// <summary>
    /// Represents a base callback to be used when needing a lambda callback so no delegate or class is generated
    /// This class is pooled to prevent allocations
    /// </summary>
    public class BaseCallback : BasePoolable
    {
        /// <summary>
        /// The callback to be called by the delegate
        /// </summary>
        public readonly Action Callback;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseCallback()
        {
            Callback = CallbackInternal;
        }

        /// <summary>
        /// Overridden in the child class to handle the callback
        /// </summary>
        protected virtual void HandleCallback()
        {
            
        }

        /// <summary>
        /// Overridden in the child class to handle the callback cleanup
        /// </summary>
        protected virtual void HandleCleanup()
        {
            
        }
        
        private void CallbackInternal()
        {
            try
            {
                HandleCallback();
            }
            finally
            {
                HandleCleanup();
                CleanupInternal();
            }
        }

        private void CleanupInternal()
        {
            DiscordPool.Free(this);
        }
    }
}