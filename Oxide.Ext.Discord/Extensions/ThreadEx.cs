using System.Threading;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Extensions
{
    internal static class ThreadEx
    {
        /// <summary>
        /// Main thread
        /// </summary>
        private static readonly int MainThreadId = Thread.CurrentThread.ManagedThreadId;

        /// <summary>
        /// Determine if current thread is the main thread
        /// </summary>
        internal static bool IsMain => MainThreadId == Thread.CurrentThread.ManagedThreadId;

        internal static void Initialize()
        {
            DiscordExtension.GlobalLogger.Verbose("Main Thread ID: {0}", MainThreadId);
        }
    }
}