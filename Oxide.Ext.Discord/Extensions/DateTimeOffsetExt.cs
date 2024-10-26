using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// <see cref="DateTimeOffset"/> Extensions
    /// </summary>
    public static class DateTimeOffsetExt
    {
        /// <summary>
        /// Delay until the DateTimeOffset with 25ms - 40 padding
        /// </summary>
        /// <param name="time"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ValueTask DelayUntil(this DateTimeOffset time, CancellationToken token = default) => time.DelayUntil(Core.Random.Range(25, 40), token);

        /// <summary>
        /// Delay until the DateTimeOffset with additionalMs padding
        /// </summary>
        /// <param name="time">Time to wait until</param>
        /// <param name="additionalMs">Additional millisecond padding</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async ValueTask DelayUntil(this DateTimeOffset time, int additionalMs, CancellationToken token = default)
        {
            TimeSpan duration = time >= DateTimeOffset.UtcNow ? time - DateTimeOffset.UtcNow : TimeSpan.Zero;
            await Task.Delay(duration + TimeSpan.FromMilliseconds(additionalMs), token).ConfigureAwait(false);
        }
    }
}