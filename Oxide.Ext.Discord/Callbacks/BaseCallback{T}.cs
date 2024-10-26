using System;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    /// <summary>
    /// Represents a base callback to be used when needing a lambda callback so no delegate or class is generated
    /// This class is pooled to prevent allocations
    /// </summary>
    public abstract class BaseCallback<T> : BasePoolable
    {
        /// <summary>
        /// The callback to be called by the delegate
        /// </summary>
        private readonly Action<T> _callback;
        
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseCallback()
        {
            _callback = CallbackInternal;
        }

        /// <summary>
        /// Overridden in the child class to handle the callback
        /// </summary>
        protected abstract void HandleCallback(T data);

        /// <summary>
        /// Run the callback
        /// </summary>
        public virtual void Start(T data)
        {
            _callback.Invoke(data);
        }

        private void CallbackInternal(T data)
        {
            try
            {
                HandleCallback(data);
            }
            finally
            {
                Dispose();
            }
        }
    }
}