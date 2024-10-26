using System.Buffers;
using System.IO;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Stream Extension Methods
    /// </summary>
    public static class StreamExt
    {
        /// <summary>
        /// Copies one stream to another using a pooled byte[] buffer
        /// </summary>
        /// <param name="from">Stream to copy from</param>
        /// <param name="to">Stream to copy to</param>
        public static void CopyToPooled(this Stream from, Stream to)
        {
            from.Position = 0;
            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);

            int bytesRead;
            while ((bytesRead = from.Read(buffer, 0, buffer.Length)) != 0)
            {
                to.Write(buffer, 0, bytesRead);
            }

            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}