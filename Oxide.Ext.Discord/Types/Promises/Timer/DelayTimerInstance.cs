// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Types
{
    internal sealed class DelayTimerInstance : BaseTimerInstance
    {
        private float _endTime;

        public static DelayTimerInstance Create(float endTime)
        {
            DelayTimerInstance timer = DiscordPool.Internal.Get<DelayTimerInstance>();
            timer.Init(endTime);
            return timer;
        }

        private void Init(float endTime)
        {
            base.Init();
            _endTime = endTime;
        }
        
        public override void Update(float currentTime)
        {
            if (_endTime <= currentTime)
            {
                Resolve();
            }
        }
    }
}