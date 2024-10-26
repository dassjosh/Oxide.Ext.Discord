using System;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class PromiseCallback<T> : BasePromiseCallback
    {
        internal readonly Action<T> RunResolve;
        private Action<T> _onResolve;
        private Promise<T> _promise;

        public PromiseCallback()
        {
            RunResolve = ResolveInternal;
        }

        internal static PromiseCallback<T> Create(Promise<T> promise, Action<T> onResolve, Action<Exception> onReject)
        {
            PromiseCallback<T> callback = DiscordPool.Internal.Get<PromiseCallback<T>>();
            callback.OnInit(promise, onResolve, onReject);
            return callback;
        }

        private void OnInit(Promise<T> promise, Action<T> onResolve, Action<Exception> onFail)
        {
            base.OnInit(promise, onFail);
            _promise = promise;
            _onResolve = onResolve;
        }

        private void ResolveInternal(T value)
        {
            try
            {
                _onResolve?.Invoke(value);
                _promise.Resolve(value);
            }
            catch (Exception ex)
            {
                _promise.Reject(ex);
            }
            finally
            {
                DelayDispose();
            }
        }

        protected override void EnterPool()
        {
            base.EnterPool();
            _onResolve = null;
            _promise = null;
        }
    }
}