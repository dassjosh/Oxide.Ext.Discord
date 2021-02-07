using System;
using System.Timers;
using uMod.Ext.Discord.Helpers;

namespace uMod.Ext.Discord.REST
{
    public class BotGlobalRateLimit
    {
        public int Global;

        private Timer _timer;
        private double _lastReset;
        private double _retryAfter;

        private const int MaxRequestsPerMinute = 110;
        private const int ResetInterval = ResetIntervalSeconds * 1000;
        private const int ResetIntervalSeconds = 60;

        public BotGlobalRateLimit()
        {
            _timer = new Timer(ResetInterval);
            _timer.Elapsed += ResetGlobal;
            _timer.Start();
            _lastReset = Time.TimeSinceEpoch();
        }

        private void ResetGlobal(object sender, ElapsedEventArgs e)
        {
            lock (this)
            {
                Global = 0;
                _lastReset = Time.TimeSinceEpoch();
            }
        }

        public void FiredRequest()
        {
            lock (this)
            {
                Global += 1;
            }
        }

        public void ReachedRateLimit(double retryAfter)
        {
            Global = MaxRequestsPerMinute;
            _retryAfter = retryAfter;
        }

        public bool HasReachedRateLimit => Global >= MaxRequestsPerMinute;

        public double NextBucketReset => Math.Max(_lastReset + ResetIntervalSeconds, Time.TimeSinceEpoch() + _retryAfter) ;

        public void Shutdown()
        {
            if (_timer == null)
            {
                return;
            }
            
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}