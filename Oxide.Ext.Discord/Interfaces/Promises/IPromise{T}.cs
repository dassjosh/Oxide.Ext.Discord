// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Implements a C# promise.
    /// https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise
    /// </summary>
    public interface IPromise<TPromised>
    {
        /// <summary>
        /// ID of the promise, useful for debugging.
        /// </summary>
        Snowflake Id { get; }
        
        /// <summary>
        /// Handle errors for the promise. 
        /// </summary>
        IPromise Catch(Action<Exception> onRejected);
        
        /// <summary>
        /// Catches a specified exception
        /// </summary>
        IPromise Catch<TException>(Action<TException> onRejected) where TException : Exception;

        /// <summary>
        /// Handle errors for the promise. 
        /// </summary>
        IPromise<TPromised> Catch(Func<Exception, TPromised> onRejected);

        /// <summary>
        /// Add a resolved callback that chains a value promise (optionally converting to a different value type).
        /// </summary>
        IPromise<TConvert> Then<TConvert>(Func<TPromised, IPromise<TConvert>> onResolved);

        /// <summary>
        /// Add a resolved callback.
        /// </summary>
        IPromise<TPromised> Then(Action<TPromised> onResolved);

        /// <summary>
        /// Add a resolved callback and a rejected callback.
        /// The resolved callback chains a value promise (optionally converting to a different value type).
        /// </summary>
        IPromise<TConvert> Then<TConvert>(Func<TPromised, IPromise<TConvert>> onResolved, Func<Exception, IPromise<TConvert>> onRejected);

        /// <summary>
        /// Adds a callback from the given promise
        /// </summary>
        /// <param name="promise">Promise to use for the callback</param>
        IPromise<TPromised> Then(IPromise<TPromised> promise);
        
        /// <summary>
        /// Add a resolved callback and a rejected callback.
        /// The resolved callback chains a non-value promise.
        /// </summary>
        IPromise Then(Func<TPromised, IPromise> onResolved, Action<Exception> onRejected);

        /// <summary>
        /// Add a resolved callback and a rejected callback.
        /// </summary>
        IPromise<TPromised> Then(Action<TPromised> onResolved, Action<Exception> onRejected);

        /// <summary>
        /// Return a new promise with a different value.
        /// May also change the type of the value.
        /// </summary>
        IPromise<TConvert> Then<TConvert>(Func<TPromised, TConvert> transform);

        /// <summary>
        /// Chain an enumerable of promises, all of which must resolve.
        /// Returns a promise for a collection of the resolved results.
        /// The resulting promise is resolved when all of the promises have resolved.
        /// It is rejected as soon as any of the promises have been rejected.
        /// </summary>
        IPromise<IEnumerable<TConvert>> ThenAll<TConvert>(Func<TPromised, IEnumerable<IPromise<TConvert>>> chain);

        /// <summary>
        /// Chain an enumerable of promises, all of which must resolve.
        /// Converts to a non-value promise.
        /// The resulting promise is resolved when all of the promises have resolved.
        /// It is rejected as soon as any of the promises have been rejected.
        /// </summary>
        IPromise ThenAll(Func<TPromised, IEnumerable<IPromise>> chain);

        /// <summary> 
        /// Add a finally callback. 
        /// Finally callbacks will always be called, even if any preceding promise is rejected, or encounters an error.
        /// The returned promise will be resolved or rejected, as per the preceding promise.
        /// </summary> 
        IPromise<TPromised> Finally(Action onComplete);

        /// <summary>
        /// Add a callback that chains a non-value promise.
        /// ContinueWith callbacks will always be called, even if any preceding promise is rejected, or encounters an error.
        /// The state of the returning promise will be based on the new non-value promise, not the preceding (rejected or resolved) promise.
        /// </summary>
        IPromise ContinueWith(Func<IPromise> onResolved);

        /// <summary> 
        /// Add a callback that chains a value promise (optionally converting to a different value type).
        /// ContinueWith callbacks will always be called, even if any preceding promise is rejected, or encounters an error.
        /// The state of the returning promise will be based on the new value promise, not the preceding (rejected or resolved) promise.
        /// </summary> 
        IPromise<TConvert> ContinueWith<TConvert>(Func<IPromise<TConvert>> onComplete);
        
        /// <summary>
        /// returns the task for this promise
        /// </summary>
        /// <returns></returns>
        ValueTask<TPromised> AsTask();
    
        /// <summary>
        /// returns the task awaiter for this promise
        /// </summary>
        /// <returns></returns>
        ValueTaskAwaiter<TPromised> GetAwaiter();
    }
}