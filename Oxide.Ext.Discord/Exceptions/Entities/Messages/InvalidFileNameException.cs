using System.Text.RegularExpressions;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception throw when an attachment filename contains invalid characters
    /// </summary>
    public class InvalidFileNameException : BaseDiscordException
    {
        /// <summary>
        /// Regex file name validation ensuring filenames are valid
        /// </summary>
        public static readonly Regex FilenameValidation = new("^[a-zA-Z0-9_.-]*$", RegexOptions.Compiled);
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">invalid file name</param>
        private InvalidFileNameException(string fileName) : base($"'{fileName}' is not a valid filename for discord. " +
                                                                 "Valid filename characters are alphanumeric with underscores, dashes, or dots") 
        { }

        internal static void ThrowIfInvalid(string fileName)
        {
            if (!FilenameValidation.IsMatch(fileName))
            {
                throw new InvalidFileNameException(fileName);
            }
        }
    }
}