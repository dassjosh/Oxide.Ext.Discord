using System;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exceptions for promises
    /// </summary>
    public class PromiseException : BaseDiscordException
    {
        private PromiseException(string message) : base(message) { }

        internal static void ThrowIfNotPending(PromiseState state)
        {
            if (state != PromiseState.Pending) throw new PromiseException($"Attempt to reject a promise that is already in state: {state}, a promise can only be rejected when it is still in state: {PromiseState.Pending}");
        }

        internal static void ThrowIfDisposed(BasePromise promise)
        {
            if (promise.Disposed) throw new ObjectDisposedException($"{promise.GetType().GetRealTypeName()}");
        }
    }
}