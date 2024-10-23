using System;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Types;

#pragma warning disable CS1591

namespace Oxide.Ext.Discord.Logging
{
    public static class LoggerExt
    {
        #region Verbose
        public static void Verbose(this ILogger logger, string message)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message);
            }
        }
        
        public static void Verbose<T1>(this ILogger logger, string message, T1 arg0)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0);
            }
        }
        
        public static void Verbose<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1);
            }
        }
        
        public static void Verbose<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        
        public static void Verbose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
        {
            if (logger.IsLogging(DiscordLogLevel.Verbose))
            {
                HandleLog(logger, DiscordLogLevel.Verbose, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        #endregion

        #region Debug
        public static void Debug(this ILogger logger, string message)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message);
            }
        }
        
        public static void Debug<T1>(this ILogger logger, string message, T1 arg0)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0);
            }
        }
        
        public static void Debug<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1);
            }
        }
        
        public static void Debug<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2);
            }
        }
        
        public static void Debug<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        
        public static void Debug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
        {
            if (logger.IsLogging(DiscordLogLevel.Debug))
            {
                HandleLog(logger, DiscordLogLevel.Debug, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        #endregion
        
        #region Info
        public static void Info(this ILogger logger, string message)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message);
            }
        }
        
        public static void Info<T1>(this ILogger logger, string message, T1 arg0)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0);
            }
        }
        
        public static void Info<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1);
            }
        }
        
        public static void Info<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2);
            }
        }
        
        public static void Info<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        
        public static void Info<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
        {
            if (logger.IsLogging(DiscordLogLevel.Info))
            {
                HandleLog(logger, DiscordLogLevel.Info, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        #endregion
        
        #region Warning
        public static void Warning(this ILogger logger, string message)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message);
            }
        }
        
        public static void Warning<T1>(this ILogger logger, string message, T1 arg0)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0);
            }
        }
        
        public static void Warning<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1);
            }
        }
        
        public static void Warning<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2);
            }
        }
        
        public static void Warning<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        
        public static void Warning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
        {
            if (logger.IsLogging(DiscordLogLevel.Warning))
            {
                HandleLog(logger, DiscordLogLevel.Warning, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        #endregion
        
        #region Error
        public static void Error(this ILogger logger, string message)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message);
            }
        }
        
        public static void Error<T1>(this ILogger logger, string message, T1 arg0)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0);
            }
        }
        
        public static void Error<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1);
            }
        }
        
        public static void Error<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2);
            }
        }
        
        public static void Error<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        
        public static void Error<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10)
        {
            if (logger.IsLogging(DiscordLogLevel.Error))
            {
                HandleLog(logger, DiscordLogLevel.Error, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        #endregion
        
        #region Exception
        public static void Exception(this ILogger logger, string message, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, exception);
            }
        }
        
        public static void Exception<T1>(this ILogger logger, string message, T1 arg0, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, exception);
            }
        }
        
        public static void Exception<T1, T2>(this ILogger logger, string message, T1 arg0, T2 arg1, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, exception);
            }
        }
        
        public static void Exception<T1, T2, T3>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, exception);
            }
        }
        
        public static void Exception<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, Exception exception = null)
        {
            if (logger.IsLogging(DiscordLogLevel.Exception))
            {
                HandleLog(logger, DiscordLogLevel.Exception, message, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, exception);
            }
        }
        #endregion

        #region HandleLog
        private static void HandleLog(ILogger logger, DiscordLogLevel level, string message, Exception exception = null)
        {
            logger.Log(level, message, Array.Empty<object>(), exception);
        }
        
        private static void HandleLog<T1>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(1);
            array[0] = arg0;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(2);
            array[0] = arg0;
            array[1] = arg1;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(3);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(4);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(5);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(6);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6, T7>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(7);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            array[6] = arg6;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6, T7, T8>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(8);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            array[6] = arg6;
            array[7] = arg7;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(9);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            array[6] = arg6;
            array[7] = arg7;
            array[8] = arg8;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(10);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            array[6] = arg6;
            array[7] = arg7;
            array[8] = arg8;
            array[9] = arg9;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        
        private static void HandleLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ILogger logger, DiscordLogLevel level, string message, T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, Exception exception = null)
        {
            object[] array = ArrayPool<object>.Instance.Get(11);
            array[0] = arg0;
            array[1] = arg1;
            array[2] = arg2;
            array[3] = arg3;
            array[4] = arg4;
            array[5] = arg5;
            array[6] = arg6;
            array[7] = arg7;
            array[8] = arg8;
            array[9] = arg9;
            array[10] = arg10;
            logger.Log(level, message, array, exception);
            ArrayPool<object>.Instance.Free(ref array);
        }
        #endregion
    }
}