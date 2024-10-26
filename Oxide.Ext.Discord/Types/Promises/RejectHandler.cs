// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a handler invoked when the promise is rejected.
    /// </summary>
    public readonly struct RejectHandler
    {
        /// <summary>
        /// Callback fn.
        /// </summary>
        private readonly Action<Exception> _callback;

        /// <summary>
        /// The promise that is rejected when there is an error while invoking the handler.
        /// </summary>
        private readonly IRejectable _rejectable;
        
        internal RejectHandler(Action<Exception> callback, IRejectable rejectable)
        {
            _callback = callback;
            _rejectable = rejectable;
        }

        internal void Reject(Exception exception)
        {
            try
            {
                _callback(exception);
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("An error occured during reject of Promise", ex);
                _rejectable.Reject(ex);
            }
        }
    }
}