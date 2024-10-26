using System;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a Placeholder Data Key
    /// This is the key used to store a value into Placeholder Data
    /// </summary>
    public readonly struct PlaceholderDataKey : IEquatable<PlaceholderDataKey>
    {
        /// <summary>
        /// Value of the key
        /// </summary>
        public readonly string Key;

        /// <summary>
        /// If the <see cref="Key"/> is a valid value
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Key);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Value of the key</param>
        public PlaceholderDataKey(string key) 
        {
            Key = key;
        }

        /// <inheritdoc />
        public bool Equals(PlaceholderDataKey other) => Key == other.Key;
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is PlaceholderDataKey other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => (Key != null ? Key.GetHashCode() : 0);
    }
}