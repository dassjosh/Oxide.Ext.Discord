namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception when modifying a user with invalid data
    /// </summary>
    public class InvalidUserException : BaseDiscordException
    {
        /// <summary>
        /// Invalid username characters
        /// </summary>
        public static readonly char[] InvalidUserNameCharacters = "@#:".ToCharArray();
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        private InvalidUserException(string message) : base(message) { }

        internal static void ThrowIfInvalidUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return;
            }
            
            if (username.Length < 2 || username.Length > 32)
            {
                throw new InvalidUserException($"Name '{username}' cannot be less than 2 characters or more than 32 characters");
            }
                
            if (username.IndexOfAny(InvalidUserNameCharacters) != -1)
            {
                throw new InvalidUserException($"Name '{username}' Cannot contain any of the following characters [@,#,:]");
            }

            if (username.Contains("```"))
            {
                throw new InvalidUserException($"Name '{username}' Cannot contain \"```\"");
            }

            if (username.Contains("discord"))
            {
                throw new InvalidUserException($"Name '{username}' Cannot contain \"discord\"");
            }
        }
    }
}