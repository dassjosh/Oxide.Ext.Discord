﻿using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents an object that supports debug logging
    /// </summary>
    public interface IDebugLoggable
    {
        /// <summary>
        /// Logs a debug message for the object
        /// </summary>
        /// <param name="logger">Current debug logger</param>
        void LogDebug(DebugLogger logger);
    }
}