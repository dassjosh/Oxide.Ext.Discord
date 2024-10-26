// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Timer Implementation using promises
    /// </summary>
    internal sealed class PromiseTimer : Singleton<PromiseTimer>
    {
        /// <summary>
        /// The current running total for time that this PromiseTimer has run for
        /// </summary>
        private float _currentTime;

        /// <summary>
        /// Currently pending promises
        /// </summary>
        private readonly List<BaseTimerInstance> _waiting = new();

        private PromiseTimer() { }

        /// <summary>
        /// Resolve the returned promise once the time has elapsed
        /// </summary>
        public IPromise WaitFor(float seconds) => SetupTimer(DelayTimerInstance.Create(_currentTime + seconds));

        /// <summary>
        /// Resolve the returned promise once the predicate evaluates to false
        /// </summary>
        public IPromise WaitWhile(Func<float, bool> predicate) => SetupTimer(EventTimerInstance.Create(predicate, _currentTime, false));

        /// <summary>
        /// Resolve the returned promise once the predicate evaluates to true
        /// </summary>
        public IPromise WaitUntil(Func<float, bool> predicate) => SetupTimer(EventTimerInstance.Create(predicate, _currentTime, true));
        
        private IPromise SetupTimer(BaseTimerInstance timer)
        {
            _waiting.Add(timer);
            return timer.PendingPromise;
        }
        
        /// <summary>
        /// Cancel a waiting promise and reject it immediately.
        /// </summary>
        public bool Cancel(IPromise promise)
        {
            BaseTimerInstance timer = FindInWaiting(promise);
            if (timer == null)
            {
                return false;
            }

            timer.Reject(new PromiseCancelledException("Promise was cancelled by user."));
            _waiting.Remove(timer);

            return true;
        }

        /// <summary>
        /// Update all pending promises. Must be called for the promises to progress and resolve at all.
        /// </summary>
        internal void Update(float deltaTime)
        {
            _currentTime += deltaTime;
            if (_waiting.Count == 0)
            {
                return;
            }
            
            for (int index = 0; index < _waiting.Count;)
            {
                BaseTimerInstance timer = _waiting[index];
                timer.Update(_currentTime);
                if (timer.IsCompleted)
                {
                    _waiting.Remove(timer);
                }
            }
        }

        private BaseTimerInstance FindInWaiting(IPromise promise)
        {
            for (int index = 0; index < _waiting.Count; index++)
            {
                BaseTimerInstance instance = _waiting[index];
                if (instance.Id == promise.Id)
                {
                    return instance;
                }
            }

            return null;
        }
    }
}