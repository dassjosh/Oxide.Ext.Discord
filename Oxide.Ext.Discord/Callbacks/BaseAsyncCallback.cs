using System;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    /// <summary>
    /// Represents a base callback to be used when needing a lambda callback so no delegate or class is generated
    /// This class is pooled to prevent allocations
    /// </summary>
    public abstract class BaseAsyncCallback : BasePoolable
    {
        /// <summary>
        /// The callback to be called by the delegate
        /// </summary>
        private readonly Func<ValueTask> _callback;
        
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseAsyncCallback()
        {
            _callback = CallbackInternal;
        }

        /// <summary>
        /// Overridden in the child class to handle the callback
        /// </summary>
        protected abstract ValueTask HandleCallback();

        /// <summary>
        /// Returns Exception message if an error occurs 
        /// </summary>
        /// <returns></returns>
        protected abstract string GetExceptionMessage();
        
        /// <summary>
        /// Runs the callback using async
        /// </summary>
        protected void Run()
        {
            Task.Run(_callback);
        }

        private async ValueTask CallbackInternal()
        {
            try
            {
                await HandleCallback().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("{0}.CallbackInternal had exception. Callback Data: {1}", GetType().GetRealTypeName(), GetExceptionMessage(), ex);
            }
            finally
            {
                Dispose();
            }
        }
    }
}