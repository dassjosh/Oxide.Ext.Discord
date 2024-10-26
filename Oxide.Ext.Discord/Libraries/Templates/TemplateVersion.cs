using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Version of a specific template
    /// </summary>
    [JsonConverter(typeof(TemplateVersionConverter))]
    public readonly struct TemplateVersion : IComparable<TemplateVersion>, IEquatable<TemplateVersion>
    {
        /// <summary>
        /// Major Version
        /// </summary>
        public readonly ushort Major;
        
        /// <summary>
        /// Minor Version
        /// </summary>
        public readonly ushort Minor;
        
        /// <summary>
        /// Revision Version
        /// </summary>
        public readonly ushort Revision;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="major">Major Version</param>
        /// <param name="minor">Minor Version</param>
        /// <param name="revision">Revision Version</param>
        public TemplateVersion(ushort major, ushort minor, ushort revision)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
        }
    
        ///<inheritdoc/>
        public int CompareTo(TemplateVersion other)
        {
            int majorComparison = Major.CompareTo(other.Major);
            if (majorComparison != 0)
                return majorComparison;
            int minorComparison = Minor.CompareTo(other.Minor);
            if (minorComparison != 0)
                return minorComparison;
            return Revision.CompareTo(other.Revision);
        }
        
        /// <summary>
        /// Returns if the left template version is less than the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(TemplateVersion left, TemplateVersion right) => left.CompareTo(right) < 0;
        
        /// <summary>
        /// Returns if the left template version is less than or equal the right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(TemplateVersion left, TemplateVersion right) => left.CompareTo(right) <= 0;
        
        /// <summary>
        /// Returns if the right template version is greater than the left
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(TemplateVersion left, TemplateVersion right) => left.CompareTo(right) > 0;
        
        /// <summary>
        /// Returns if the right template version is greater or equal than the left
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(TemplateVersion left, TemplateVersion right) => left.CompareTo(right) >= 0;

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Major}.{Minor}.{Revision}";
        }

        /// <inheritdoc />
        public bool Equals(TemplateVersion other) => Major == other.Major && Minor == other.Minor && Revision == other.Revision;
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is TemplateVersion other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Major, Minor, Revision);
    }
}