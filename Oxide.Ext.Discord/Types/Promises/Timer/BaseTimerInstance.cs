// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Types
{
    internal abstract class BaseTimerInstance : BasePoolable
    {
        public Snowflake Id => PendingPromise.Id;
        
        /// <summary>
        /// The pending promise which is an interface for a promise that can be rejected or resolved.
        /// </summary>
        internal IPendingPromise PendingPromise;
        public bool IsCompleted { get; private set; }

        public abstract void Update(float currentTime);

        protected void Init()
        {
            PendingPromise = Promise.Create();
        }
        
        internal void Resolve()
        {
            PendingPromise.Resolve();
            IsCompleted = true;
        }

        public void Reject(Exception ex)
        {
            PendingPromise.Reject(ex);
            IsCompleted = true;
        }
        
        protected override void EnterPool()
        {
            PendingPromise = null;
        }
    }
}