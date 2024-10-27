using System;
using System.Runtime.CompilerServices;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Extensions
{
    public static class ByteExt
    {
        private const double KiloBytes = 1024;
        private const double MegaBytes = KiloBytes * 1024;
        private const double Gigabytes = MegaBytes * 1024;
        
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWith(this byte[] file, byte[] type)
        {
            return file.AsSpan().StartsWith(type);
        }
    }
}