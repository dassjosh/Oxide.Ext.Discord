// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Oxide.Core;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
#if PROMISE_DEBUG
using Oxide.Ext.Discord.Logging;
#endif

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Implements a non-generic C# promise; this is a promise that simply resolves without delivering a value.
    /// https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise
    /// </summary>
    public sealed class Promise : BasePromise, IPendingPromise
    {
        /// <summary>
        /// Completed handlers that accept no value.
        /// </summary>
        private readonly List<ResolveHandler> _resolves = new(1);

        private readonly Action _onResolve;
        private readonly Action _onResolveInternal;

        private readonly ManualResetValueTaskSource _taskSource = new();

        /// <summary>
        /// Constructor for the promise
        /// </summary>
        public Promise()
        {
            _onResolve = Resolve;
            _onResolveInternal = InvokeResolveHandlersInternal;
        }

        /// <summary>
        /// Creates a Promise
        /// </summary>
        /// <returns></returns>
        public static Promise Create() => DiscordPool.Internal.Get<Promise>();

        /// <summary>
        /// Returns a promise that has been resolved
        /// </summary>
        /// <returns></returns>
        public static IPromise Resolved()
        {
            Promise promise = Create();
            promise.State = PromiseState.Resolved;
            promise.DelayedDispose();
            return promise;
        }

        /// <summary>
        /// Convert an exception directly into a rejected promise.
        /// </summary>
        public static IPromise Rejected(Exception ex)
        {
            Promise promise = Create();
            promise.State = PromiseState.Rejected;
            promise.Exception = ex;
            promise.DelayedDispose();
            return promise;
        }

        /// <summary>
        /// Helper function to clear out all handlers after resolution or rejection.
        /// </summary>
        protected override void ClearHandlers()
        {
            _resolves.Clear();
            base.ClearHandlers();
        }

        /// <summary>
        /// Invoke all resolve handlers.
        /// </summary>
        private void InvokeResolveHandlers()
        {
            if (ThreadEx.IsMain)
            {
                InvokeResolveHandlersInternal();
                return;
            }
            
            Interface.Oxide.NextTick(_onResolveInternal);
        }

        private void InvokeResolveHandlersInternal()
        {
            if (_resolves != null)
            {
                for (int i = 0; i < _resolves.Count; i++)
                {
                    ResolveHandler resolve = _resolves[i];
#if PROMISE_DEBUG
                     DiscordExtension.GlobalLogger.Info($"Invoking Resolve ID: {Id}");
#endif
                    resolve.Resolve();
                }
            }

            ClearHandlers();
            DelayedDispose();
        }
        
        ///<inheritdoc/>
        public void Resolve()
        {
            PromiseException.ThrowIfDisposed(this);
            PromiseException.ThrowIfNotPending(State);
            State = PromiseState.Resolved;
            _taskSource.SetResult();
            InvokeResolveHandlers();
        }

        ///<inheritdoc/>
        public override void Reject(Exception ex)
        {
            base.Reject(ex);
            _taskSource.SetException(ex);
        }

        ///<inheritdoc/>
        public IPromise Catch(Action<Exception> onRejected)
        {
            PromiseException.ThrowIfDisposed(this);
            if (State == PromiseState.Resolved)
            {
                return this;
            }

            Promise resultPromise = Create();

            void RejectHandler(Exception exception)
            {
                try
                {
                    onRejected(exception);
                    resultPromise.Resolve();
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then catch reject of Promise", ex);
                    resultPromise.Reject(ex);
                }
            }

            AddHandlers(new ResolveHandler(resultPromise._onResolve, resultPromise), new RejectHandler(RejectHandler, resultPromise));

            return resultPromise;
        }

        ///<inheritdoc/>
        public IPromise Catch<TException>(Action<TException> onRejected) where TException : Exception
        {
            return Catch(ex =>
            {
                if (ex is TException exception)
                {
                    onRejected.Invoke(exception);
                }
            });
        }
        
        ///<inheritdoc/>
        public IPromise<TConvert> Then<TConvert>(Func<IPromise<TConvert>> onResolved) => Then(onResolved, null);

        ///<inheritdoc/>
        public IPromise Then(Func<IPromise> onResolved) => Then(onResolved, null);

        ///<inheritdoc/>
        public IPromise Then(Action onResolved) => Then(onResolved, null);

        ///<inheritdoc/>
        public IPromise<TConvert> Then<TConvert>(Func<IPromise<TConvert>> onResolved, Func<Exception, IPromise<TConvert>> onRejected)
        {
            PromiseException.ThrowIfDisposed(this);
            if (State == PromiseState.Resolved)
            {
                try
                {
                    return onResolved();
                } 
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then then resolved of Promise", ex);
                    return Promise<TConvert>.Rejected(ex);
                }
            }

            // This version of the function must supply an onResolved.
            // Otherwise, there is no way to get the converted value to pass to the resulting promise.
            Promise<TConvert> resultPromise = Promise<TConvert>.Create<TConvert>();

            void ResolveHandler()
            {
                onResolved().Then(resultPromise);
            }

            void RejectHandler(Exception exception)
            {
                if (onRejected == null)
                {
                    resultPromise.Reject(exception);
                    return;
                }

                try
                {
                    onRejected(exception).Then(resultPromise);
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception($"An error occured during then convert Promise to Promise<{typeof(TConvert).Name}>", ex);
                    resultPromise.Reject(ex);
                }
            }

            AddHandlers(new ResolveHandler(ResolveHandler, resultPromise), new RejectHandler(RejectHandler, resultPromise));

            return resultPromise;
        }

        ///<inheritdoc/>
        public IPromise Then(Func<IPromise> onResolved, Action<Exception> onRejected)
        {
            PromiseException.ThrowIfDisposed(this);
            if (State == PromiseState.Resolved)
            {
                try
                {
                    return onResolved();
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then then resolved of Promise", ex);
                    return Rejected(ex);
                }
            }

            Promise resultPromise = Create();

            Action resolveHandler;
            if (onResolved != null)
            {
                void ResolveHandler()
                {
                    onResolved().Then(resultPromise);
                }

                resolveHandler = ResolveHandler;
            }
            else
            {
                resolveHandler = resultPromise._onResolve;
            }

            Action<Exception> rejectHandler;
            if (onRejected != null)
            {
                rejectHandler = ex =>
                {
                    onRejected(ex);
                    resultPromise.Reject(ex);
                };
            }
            else
            {
                rejectHandler = resultPromise.OnReject;
            }

            AddHandlers(new ResolveHandler(resolveHandler, resultPromise), new RejectHandler(rejectHandler, resultPromise));
            
            return resultPromise;
        }

        ///<inheritdoc/>
        public IPromise Then(IPromise promise)
        {
            Promise prom = (Promise)promise;
            return Then(prom._onResolve, prom.OnReject);
        }
        
        ///<inheritdoc/>
        public IPromise Then(Action onResolved, Action<Exception> onRejected)
        {
            PromiseException.ThrowIfDisposed(this);
            if (State == PromiseState.Resolved)
            {
                try
                {
                    onResolved();
                    return this;
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then then resolved of Promise", ex);
                    return Rejected(ex);
                }
            }

            Promise resultPromise = Create();

            PromiseCallback callback = PromiseCallback.Create(resultPromise, onResolved, onRejected);

            AddHandlers(new ResolveHandler(callback.RunResolve, resultPromise), new RejectHandler(callback.RunRejected, resultPromise));

            return resultPromise;
        }

        /// <summary>
        /// Helper function to invoke or register resolve/reject handlers.
        /// </summary>
        private void AddHandlers(ResolveHandler resolve, RejectHandler reject)
        {
            if (State == PromiseState.Resolved)
            {
                resolve.Resolve();
            }
            else if (State == PromiseState.Rejected)
            {
                reject.Reject(Exception);
            }
            else
            {
                _resolves.Add(resolve);
                Rejects.Add(reject);
            }
        }

        ///<inheritdoc/>
        public IPromise ThenAll(Func<IEnumerable<IPromise>> chain) => Then( All(chain()));

        ///<inheritdoc/>
        public IPromise<IEnumerable<TConvert>> ThenAll<TConvert>(Func<IEnumerable<IPromise<TConvert>>> chain) => Then(() => Promise<TConvert>.All(chain()));

        /// <summary>
        /// Returns a promise that resolves when all of the promises in the enumerable argument have resolved.
        /// Returns a promise of a collection of the resolved results.
        /// </summary>
        public static IPromise All(params IPromise[] promises) => All((IEnumerable<IPromise>)promises); // Cast is required to force use of the other All function.

        /// <summary>
        /// Returns a promise that resolves when all of the promises in the enumerable argument have resolved.
        /// Returns a promise of a collection of the resolved results.
        /// </summary>
        public static IPromise All(IEnumerable<IPromise> promisesEnumerable)
        {
            List<IPromise> promises = DiscordPool.Internal.GetList<IPromise>();
            promises.AddRange(promisesEnumerable);
            if (promises.Count == 0)
            {
                return Resolved();
            }

            int remainingCount = promises.Count;
            Promise resultPromise = Create();

            for (int index = 0; index < promises.Count; index++)
            {
                IPromise promise = promises[index];
                promise.Then(() =>
                    {
                        --remainingCount;
                        if (remainingCount <= 0 && resultPromise.State == PromiseState.Pending)
                        {
                            // This will never happen if any of the promises errored.
                            resultPromise.Resolve();
                        }
                    })
                    .Catch(ex =>
                    {
                        if (resultPromise.State == PromiseState.Pending)
                        {
                            // If a promise errored and the result promise is still pending, reject it.
                            resultPromise.Reject(ex);
                        }
                    });
            }
            
            DiscordPool.Internal.FreeList(promises);

            return resultPromise;
        }

        ///<inheritdoc/>
        public IPromise ThenSequence(Func<IEnumerable<Func<IPromise>>> chain) => Then( Sequence(chain()));

        /// <summary>
        /// Chain a number of operations using promises.
        /// Takes a number of functions each of which starts an async operation and yields a promise.
        /// </summary>
        public static IPromise Sequence(params Func<IPromise>[] fns) => Sequence((IEnumerable<Func<IPromise>>)fns);

        /// <summary>
        /// Chain a sequence of operations using promises.
        /// Takes a collection of functions each of which starts an async operation and yields a promise.
        /// </summary>
        public static IPromise Sequence(IEnumerable<Func<IPromise>> fns)
        {
            Promise promise = Create();
            fns.Aggregate(Resolved(), (prevPromise, fn) => prevPromise.Then(fn)).Then(promise._onResolve).Catch(promise.OnReject);
            return promise;
        }

        ///<inheritdoc/>
        public IPromise Finally(Action onComplete)
        {
            if (State == PromiseState.Resolved)
            {
                try
                {
                    onComplete();
                    return this;
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then complete finally of Promise", ex);
                    return Rejected(ex);
                }
            }

            Promise promise = Create();

            Then(promise._onResolve);
            Catch(exception => 
            {
                try 
                {
                    onComplete();
                    promise.Reject(exception);
                } 
                catch (Exception ex) 
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured during then catch finally of Promise", ex);
                    promise.Reject(ex);
                }
            });

            return promise.Then(onComplete);
        }

        ///<inheritdoc/>
        public IPromise ContinueWith(Func<IPromise> onComplete)
        {
            Promise promise = Create();

            Then(promise._onResolve);
            Catch(_ => promise.Resolve());

            return promise.Then(onComplete);
        }

        ///<inheritdoc/>
        public IPromise<TConvert> ContinueWith<TConvert>(Func<IPromise<TConvert>> onComplete)
        {
            Promise promise = Create();

            Then(promise._onResolve);
            Catch(_ => promise.Resolve());

            return promise.Then(onComplete);
        }

        ///<inheritdoc/>
        public ValueTask AsTask()
        {
            return _taskSource.GetTask();
        }
    
        ///<inheritdoc/>
        public ValueTaskAwaiter GetAwaiter()
        {
            return AsTask().GetAwaiter();
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            base.EnterPool();
            _resolves.Clear();
            _taskSource.Reset();
        }
    }
}