using System;
using System.Runtime.CompilerServices;
using System.Text;
namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// StringBuilder extension methods
    /// </summary>
    public static class StringBuilderExt
    {
        /// <summary>
        /// Replaces the text at the index and length with the span value
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Replace(this StringBuilder builder, ReadOnlySpan<char> value, int index, int length)
        {
            builder.Remove(index, length);
            builder.Insert(index, value);
        }
        
        /// <summary>
        /// Trim empty space to the left and right of the StringBuilder
        /// </summary>
        /// <param name="sb">StringBuilder to trim</param>
        /// <returns>The passed in StringBuilder</returns>
        public static StringBuilder Trim(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0) return sb;

            //Process Left Side
            if (char.IsWhiteSpace(sb[0]))
            {
                int index = 1;
                while (index < sb.Length && char.IsWhiteSpace(sb[index]))
                {
                    index++;
                }

                sb.Remove(0, index + 1);
                if (sb.Length == 0)
                {
                    return sb;
                }
            }

            //Process Right Side
            if (char.IsWhiteSpace(sb[sb.Length - 1]))
            {
                int index = sb.Length - 2;
                while (index >= 0 && char.IsWhiteSpace(sb[index]))
                {
                    index--;
                }
                
                sb.Length = index + 1;
            }

            return sb;
        }
    }
}