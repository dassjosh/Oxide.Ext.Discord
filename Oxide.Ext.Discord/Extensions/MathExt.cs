using System;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Extensions for math operations
    /// </summary>
    public static class MathExt
    {
        /// <summary>
        /// Returns the value of {T} clamped between min and max value
        /// </summary>
        /// <param name="val">Value to be clamped</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max Value</param>
        /// <typeparam name="T">Type to be clamped</typeparam>
        /// <returns>Value of {T} clamped between min and max</returns>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            if (val.CompareTo(max) > 0) return max;
            return val;
        }

        /// <summary>
        /// Returns the min value between left and right
        /// </summary>
        /// <param name="left">Left argument</param>
        /// <param name="right">Right argument</param>
        /// <typeparam name="T">Type of IComparable{T}</typeparam>
        /// <returns>Left if less than or equal to right else right</returns>
        public static T Min<T>(T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) > 0 ? right : left;
        }
        
        /// <summary>
        /// Returns the Max value between left and right
        /// </summary>
        /// <param name="left">Left argument</param>
        /// <param name="right">Right argument</param>
        /// <typeparam name="T">Type of IComparable{T}</typeparam>
        /// <returns>Left if greater than or equal to right else right</returns>
        public static T Max<T>(T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) < 0 ? right : left;
        }
    }
}