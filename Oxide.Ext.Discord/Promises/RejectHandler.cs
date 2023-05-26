// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using Oxide.Ext.Discord.Interfaces.Promises;

namespace Oxide.Ext.Discord.Promises
{
    /// <summary>
    /// Represents a handler invoked when the promise is rejected.
    /// </summary>
    public struct RejectHandler
    {
        /// <summary>
        /// Callback fn.
        /// </summary>
        private readonly Action<Exception> _callback;

        /// <summary>
        /// The promise that is rejected when there is an error while invoking the handler.
        /// </summary>
        private readonly IRejectable _rejectable;
        
        public RejectHandler(Action<Exception> callback, IRejectable rejectable)
        {
            _callback = callback;
            _rejectable = rejectable;
        }

        public void Reject(Exception exception)
        {
            try
            {
                _callback(exception);
            }
            catch (Exception ex)
            {
                _rejectable.Reject(ex);
            }
        }
    }
}