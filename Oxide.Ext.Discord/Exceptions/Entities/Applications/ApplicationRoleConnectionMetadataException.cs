using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exceptions for <see cref="ApplicationRoleConnectionMetadata"/>
    /// </summary>
    public class ApplicationRoleConnectionMetadataException : BaseDiscordException
    {
        private static readonly Regex KeyRegex = new(@"^\w+$", RegexOptions.Compiled);
        
        private ApplicationRoleConnectionMetadataException(string message) : base(message) { }

        internal static void ThrowIfInvalidKeyException(string key)
        {
            const int MaxLength = 50;
            
            if (string.IsNullOrEmpty(key))
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Key)} cannot be null or empty");
            }

            if (key.Length > MaxLength)
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Key)} cannot be more than {MaxLength} characters");
            }

            if (!KeyRegex.IsMatch(key))
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Key)} can only be the following characters a-z, 0-9, or _");
            }
        }
        
        internal static void ThrowIfInvalidNameException(string name)
        {
            const int MaxLength = 100;
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Name)} cannot be null or empty");
            }

            if (name.Length > MaxLength)
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Name)} cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidDescriptionException(string name)
        {
            const int MaxLength = 200;
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Description)} cannot be null or empty");
            }

            if (name.Length > MaxLength)
            {
                throw new ApplicationRoleConnectionMetadataException($"{nameof(ApplicationRoleConnectionMetadata)}.{nameof(ApplicationRoleConnectionMetadata.Description)} cannot be more than {MaxLength} characters");
            }
        }
    }
}