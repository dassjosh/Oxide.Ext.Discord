// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Types
{
    internal sealed class EventTimerInstance : BaseTimerInstance
    {
        /// <summary>
        /// Predicate for resolving the promise
        /// </summary>
        private Func<float, bool> _predicate;

        /// <summary>
        /// The time the promise was started
        /// </summary>
        private float _timeStarted;

        private bool _state;

        public static EventTimerInstance Create(Func<float, bool> predicate, float timeStarted, bool state)
        {
            EventTimerInstance timer = DiscordPool.Internal.Get<EventTimerInstance>();
            timer.Init(predicate, timeStarted, state);
            return timer;
        }

        private void Init(Func<float, bool> predicate, float timeStarted, bool state)
        {
            base.Init();
            _predicate = predicate;
            _timeStarted = timeStarted;
            _state = state;
        }
        
        public override void Update(float currentTime)
        {
            float elapsedTime = currentTime - _timeStarted;
            try
            {
                if (_predicate(elapsedTime) == _state)
                {
                    Resolve();
                }
            }
            catch (Exception ex)
            {
                Reject(ex);
            }
        }
    }
}