using System;
using System.Runtime.CompilerServices;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Extension methods for bytes
    /// </summary>
    public static class ByteExt
    {
        private const double KiloBytes = 1024;
        private const double MegaBytes = KiloBytes * 1024;
        private const double Gigabytes = MegaBytes * 1024;
        
        /// <summary>
        /// Returns the files size in the specified units
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double GetFileSize(this byte[] data, DiscordFileSize size)
        {
            return size switch
            {
                DiscordFileSize.Bytes => data.Length,
                DiscordFileSize.KiloBytes => data.Length / KiloBytes,
                DiscordFileSize.MegaBytes => data.Length / MegaBytes,
                DiscordFileSize.GigaBytes => data.Length / Gigabytes,
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            };
        }
        
        /// <summary>
        /// Checks if the byte array starts with the specified bytes
        /// </summary>
        /// <param name="file">File to check</param>
        /// <param name="startsWith">bytes to start with</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWith(this byte[] file, byte[] startsWith)
        {
            return file.AsSpan().StartsWith(startsWith);
        }
    }
}