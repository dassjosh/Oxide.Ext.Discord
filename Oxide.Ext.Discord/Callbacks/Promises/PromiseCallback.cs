using System;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class PromiseCallback : BasePromiseCallback
    {
        internal readonly Action RunResolve;
        private Action _onResolve;
        private Promise _promise;

        public PromiseCallback()
        {
            RunResolve = ResolveInternal;
        }

        internal static PromiseCallback Create(Promise promise, Action onResolve, Action<Exception> onReject)
        {
            PromiseCallback callback = DiscordPool.Internal.Get<PromiseCallback>();
            callback.OnInit(promise, onResolve, onReject);
            return callback;
        }

        private void OnInit(Promise promise, Action onResolve, Action<Exception> onFail)
        {
            base.OnInit(promise, onFail);
            _promise = promise;
            _onResolve = onResolve;
        }

        private void ResolveInternal()
        {
            try
            {
                _onResolve?.Invoke();
                _promise.Resolve();
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