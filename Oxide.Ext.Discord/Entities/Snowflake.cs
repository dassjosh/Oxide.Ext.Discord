using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents an ID in discord.
    /// </summary>
    [JsonConverter(typeof(SnowflakeConverter))]
    public readonly struct Snowflake : IComparable<Snowflake>, IEquatable<Snowflake>, IComparable<ulong>, IEquatable<ulong>, IDiscordKey
    {
        /// <summary>
        /// DateTimeOffset since discord Epoch
        /// </summary>
        public static readonly DateTimeOffset DiscordEpoch = new(2015, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// Snowflake Value
        /// </summary>
        public readonly ulong Id;

        /// <summary>
        /// Create a new snowflake from a ulong
        /// </summary>
        /// <param name="id"></param>
        public Snowflake(ulong id)
        {
            Id = id;
        }
        
        /// <summary>
        /// Create a new snowflake from a string
        /// </summary>
        /// <param name="id"></param>
        public Snowflake(string id): this(ulong.Parse(id)) {}

        /// <summary>
        /// Create a new snowflake from a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        /// <param name="span"></param>
        public Snowflake(ReadOnlySpan<char> span) : this(ulong.Parse(span)) {}

        /// <summary>
        /// Create a snowflake from a DateTimeOffset and increment
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="increment">Increment value of the snowflake</param>
        public Snowflake(DateTimeOffset offset, ulong increment = 0)
        {
            Id = ((ulong)(DiscordEpoch - offset).TotalMilliseconds << 22) + increment;
        }

        /// <summary>
        /// Returns when the ID was created
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset GetCreationDate()
        {
            return DiscordEpoch + TimeSpan.FromMilliseconds(Id >> 22);
        }
        
        /// <summary>
        /// Returns if the ID value is not 0
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Id != 0;
        }

        /// <summary>
        /// Try to parse the a string into a snowflake value
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="snowflake">Snowflake to return</param>
        /// <returns>True if parse succeeded; false otherwise</returns>
        public static bool TryParse(string value, out Snowflake snowflake)
        {
            if(ulong.TryParse(value, out ulong id))
            {
                snowflake = new Snowflake(id);
                return true;
            }

            snowflake = default;
            return false;
        }
    
        /// <summary>
        /// Try to parse the a string into a snowflake value
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="snowflake">Snowflake to return</param>
        /// <returns>True if parse succeeded; false otherwise</returns>
        public static bool TryParse(ReadOnlySpan<char> value, out Snowflake snowflake)
        {
            if(ulong.TryParse(value, out ulong id))
            {
                snowflake = new Snowflake(id);
                return true;
            }

            snowflake = default;
            return false;
        }

        /// <summary>
        /// Try to format the snowflake into the span
        /// </summary>
        /// <param name="destination">Span to write the snowflake into</param>
        /// <param name="charsWritten">Number of characters written</param>
        /// <param name="format">Snowflake formatting</param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null)
        {
            return Id.TryFormat(destination, out charsWritten, format, provider);
        }

        /// <summary>
        /// Returns if the two snowflakes are the same ID.
        /// </summary>
        /// <param name="other">Other snowflake to compare</param>
        /// <returns>True if the snowflake IDs match; false otherwise.</returns>
        public bool Equals(Snowflake other)
        {
            return Id == other.Id;
        }
        
        /// <summary>
        /// Returns if the obj is snowflake or ulong with matching ID.
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>True if equal; False otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is Snowflake snowflake)
            {
                return Equals(snowflake);
            }

            if (obj is ulong id)
            {
                return Equals(id);
            }

            return false;
        }
        
        /// <summary>
        /// Returns if other equals our ID
        /// </summary>
        /// <param name="other">Other to compare against</param>
        /// <returns>True if ID equals; False otherwise.</returns>
        public bool Equals(ulong other)
        {
            return Id == other;
        }

        /// <summary>
        /// Returns the HashCode of the ID
        /// </summary>
        /// <returns>ID fields hashcode</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Returns ID as a string
        /// </summary>
        /// <returns>ID as a string</returns>
        public override string ToString()
        {
            return StringCache<ulong>.Instance.ToString(Id);
        }

        /// <summary>
        /// Returns the ID field of num compared to this snowflakes ID field
        /// </summary>
        /// <param name="num">Value to compare ID to</param>
        /// <returns>A value indication if the num is less than, equal to, or greater than our ID</returns>
        public int CompareTo(Snowflake num)
        {
            return Id.CompareTo(num.Id);
        }
        
        /// <summary>
        /// Returns the ID field of num compared to this snowflakes ID field
        /// </summary>
        /// <param name="other">Value to compare ID to</param>
        /// <returns>A value indication if the num is less than, equal to, or greater than our ID</returns>
        public int CompareTo(ulong other)
        {
            return Id.CompareTo(other);
        }

        /// <summary>
        /// Returns true if left and right are equal
        /// </summary>
        /// <param name="left">Snowflake to compare</param>
        /// <param name="right">Snowflake to compare</param>
        /// <returns>True if the snowflake ID's are equal; false otherwise</returns>
        public static bool operator == (Snowflake left, Snowflake right)
        {
            return left.Id == right.Id;
        }

        /// <summary>
        /// Returns true if left and right are not equal
        /// </summary>
        /// <param name="left">Snowflake to compare</param>
        /// <param name="right">Snowflake to compare</param>
        /// <returns>True if the snowflake ID's are not equal; false otherwise</returns>
        public static bool operator !=(Snowflake left, Snowflake right)
        {
            return !(left == right);
        }
        
        /// <summary>
        /// Returns true if left snowflake's ID is less than right's ID
        /// </summary>
        /// <param name="left">Snowflake to be less than</param>
        /// <param name="right">Snowflake to be greater than</param>
        /// <returns>True if left is less than right</returns>
        public static bool operator <(Snowflake left, Snowflake right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Returns true if left snowflake's ID is greater than right's ID
        /// </summary>
        /// <param name="left">Snowflake to be greater than</param>
        /// <param name="right">Snowflake to be less than</param>
        /// <returns>True if left is greater than right</returns>
        public static bool operator >(Snowflake left, Snowflake right)
        {
            return left.CompareTo(right) > 0;
        }
        
        /// <summary>
        /// Returns true if left snowflake's ID is less than right's ID or equal
        /// </summary>
        /// <param name="left">Snowflake to be less than or equal</param>
        /// <param name="right">Snowflake to be greater than or equal</param>
        /// <returns>True if left is less than or equal to right</returns>
        public static bool operator <=(Snowflake left, Snowflake right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Returns true if left snowflake's ID is greater or equal to right's ID
        /// </summary>
        /// <param name="left">Snowflake to be greater than or equal</param>
        /// <param name="right">Snowflake to be less than or equal</param>
        /// <returns>True if left is greater or equal to right</returns>
        public static bool operator >=(Snowflake left, Snowflake right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Converts snowflake to a ulong
        /// </summary>
        /// <param name="snowflake">Snowflake to be converted to ulong</param>
        /// <returns>Snowflake ID as ulong</returns>
        public static implicit operator ulong(Snowflake snowflake) => snowflake.Id;
        
        /// <summary>
        /// Converts a ulong to a snowflake
        /// </summary>
        /// <param name="id">Id to be converted to snowflake</param>
        /// <returns>ID converted to a snowflake</returns>
        public static explicit operator Snowflake(ulong id) => new(id);
        
        /// <summary>
        /// Converts snowflake to a string
        /// </summary>
        /// <param name="snowflake">Snowflake to be converted to string</param>
        /// <returns>Snowflake ID as string</returns>
        public static implicit operator string(Snowflake snowflake) => snowflake.Id.ToString();
        
        /// <summary>
        /// Converts a string to a snowflake
        /// </summary>
        /// <param name="id">Id to be converted to snowflake</param>
        /// <returns>ID converted to a snowflake</returns>
        public static explicit operator Snowflake(string id)
        {
            return TryParse(id, out Snowflake snowflake) ? snowflake : default;
        }
    }
}