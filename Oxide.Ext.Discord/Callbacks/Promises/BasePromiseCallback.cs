﻿using System;
using Oxide.Core;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    internal abstract class BasePromiseCallback : BasePoolable
    {
        internal readonly Action<Exception> RunRejected;
        private Action<Exception> _onFail;
        private readonly Action _dispose;
        private BasePromise _rejectable;

        protected BasePromiseCallback()
        {
            RunRejected = FailInternal;
            _dispose = Dispose;
        }

        protected void OnInit(BasePromise rejectable, Action<Exception> onFail)
        {
            _rejectable = rejectable;
            _onFail = onFail;
        }

        private void FailInternal(Exception exception)
        {
            try
            {
                _onFail?.Invoke(exception);
                _rejectable.Reject(exception);
            }
            catch (Exception ex)
            {
                _rejectable.Reject(ex);
            }
            finally
            {
                DelayDispose();
            }
        }

        protected override void EnterPool()
        {
            _rejectable = null;
            _onFail = null;
        }

        protected void DelayDispose()
        {
            Interface.Oxide.NextTick(_dispose);
        }
    }
}