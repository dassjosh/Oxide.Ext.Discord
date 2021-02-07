using System.Collections.Generic;
using System.Threading;
using uMod.Ext.Discord.Helpers;
using uMod.Ext.Discord.Logging;

namespace uMod.Ext.Discord.REST
{
    public class Bucket : List<Request>
    {
        public string BucketId;
        
        public int RateLimit;

        public int RateLimitRemaining;

        public double RateLimitReset;

        public double ErrorResendDelayUntil;

        public readonly BotRestHandler Handler;

        private Thread _thread;

        private readonly ILogger _logger;

        public Bucket(BotRestHandler handler, string bucketId, ILogger logger)
        {
            Handler = handler;
            BucketId = bucketId;
            _logger = logger;
            _logger.Debug($"New Bucket Created with id: {bucketId}");
        }

        public void Close()
        {
            _thread?.Abort();
            _thread = null;
        }

        public bool ShouldCleanup() => (_thread == null || !_thread.IsAlive) && Time.TimeSinceEpoch() > RateLimitReset;

        public void Queue(Request request)
        {
            lock (this)
            {
                Add(request);
            }

            if (_thread == null || !_thread.IsAlive)
            {
                _thread = new Thread(RunThread);
                _thread.Start();
            }
        }

        private void RunThread()
        {
            try
            {
                while (Count > 0)
                {
                    FireRequests();
                }
            }
            catch (ThreadAbortException)
            {
                _logger.Info("Bucket thread has been aborted.");
            }
        }

        private void FireRequests()
        {
            double timeSince = Time.TimeSinceEpoch();
            if (Handler.RateLimit.HasReachedRateLimit)
            {
                int resetIn = (int) ((Handler.RateLimit.NextBucketReset - timeSince) * 1000);
                _logger.Debug($"Global Rate limit hit. Sleeping until Reset: {resetIn}ms");
                Thread.Sleep(resetIn);
                return;
            }
            
            if (RateLimitRemaining == 0 && RateLimitReset > timeSince)
            {
                int resetIn = (int) ((RateLimitReset - timeSince) * 1000);
                _logger.Debug($"Bucket Rate limit hit. Sleeping until Reset: {resetIn}ms");
                Thread.Sleep(resetIn);
                return;
            }

            if (ErrorResendDelayUntil > timeSince)
            {
                int resetIn = (int) ((ErrorResendDelayUntil - timeSince) * 1000);
                _logger.Debug($"Web request error occured delaying next send until: {resetIn}ms ");
                Thread.Sleep(resetIn);
                return;
            }

            for (int index = 0; index < Count; index++)
            {
                Request request = this[index];
                if (request.HasTimedOut())
                {
                    request.Close(false);
                }
            }

            //It's possible we removed a request that has timed out.
            if (Count == 0)
            {
                return;
            }
            
            Handler.RateLimit.FiredRequest();
            this[0].Fire(this);
        }
    }
}
