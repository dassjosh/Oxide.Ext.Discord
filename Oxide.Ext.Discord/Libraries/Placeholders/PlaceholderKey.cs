using System;
using System.Diagnostics.Contracts;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a Placeholder Key. This is the key for placeholder usage and lookup
    /// </summary>
    public readonly struct PlaceholderKey : IComparable<PlaceholderKey>, IEquatable<PlaceholderKey>, IDiscordKey
    {
        /// <summary>
        /// Placeholder Key
        /// </summary>
        public readonly string Placeholder;

        /// <summary>
        /// If <see cref="Placeholder"/> Is a Valid Key
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Placeholder);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="placeholder">Placeholder Value</param>
        public PlaceholderKey(string placeholder)
        {
            Placeholder = placeholder;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">
        /// Prefix for the placeholder Key.
        /// Pass in the nameof the plugin type for the Placeholder key
        /// <code>nameof(DiscordExtension)</code>
        /// </param>
        /// <param name="key">Placeholder Value</param>
        /// <param name="format">Format to be applied (Optional)</param>
        public PlaceholderKey(string prefix, string key, string format = null)
        {
            Placeholder = string.IsNullOrEmpty(format) ? $"{prefix.ToLower()}.{key}" : $"{prefix.ToLower()}.{key}:{format}";
        }
        
        /// <summary>
        /// Applies a format to a given <see cref="PlaceholderKey"/>
        /// </summary>
        /// <param name="format">Format to be applied</param>
        /// <returns>string placeholder containing the placeholder with the given format</returns>
        [Pure]
        public string WithFormat(string format) => $"{{{Placeholder}:{format}}}";

        /// <summary>
        /// Returns the PlaceholderKey formatted as a usable placeholder in text
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{{{Placeholder}}}";

        /// <inheritdoc />
        public int CompareTo(PlaceholderKey other) => string.Compare(Placeholder, other.Placeholder, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Implicitly converts to <see cref="string"/> by calling the <see cref="ToString"/> method.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static implicit operator string(PlaceholderKey key) => key.ToString();

        /// <inheritdoc />
        public bool Equals(PlaceholderKey other) => Placeholder == other.Placeholder;
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is PlaceholderKey other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => (Placeholder != null ? Placeholder.GetHashCode() : 0);
    }
}