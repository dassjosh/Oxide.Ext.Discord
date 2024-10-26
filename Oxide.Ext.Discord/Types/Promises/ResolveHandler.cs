// Originally from: https://github.com/Real-Serious-Games/C-Sharp-Promise
// Modified by: MJSU

using System;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a handler invoked when the promise is resolved.
    /// </summary>
    internal readonly struct ResolveHandler
    {
        /// <summary>
        /// Callback fn.
        /// </summary>
        private readonly Action _resolve;

        /// <summary>
        /// The promise that is rejected when there is an error while invoking the handler.
        /// </summary>
        private readonly IRejectable _rejectable;

        public ResolveHandler(Action resolve, IRejectable rejectable)
        {
            _resolve = resolve;
            _rejectable = rejectable;
        }
        
        public void Resolve()
        {
            try
            {
                _resolve();
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception($"An error occured during resolve of Promise", ex);
                _rejectable.Reject(ex);
            }
        }
    }
}