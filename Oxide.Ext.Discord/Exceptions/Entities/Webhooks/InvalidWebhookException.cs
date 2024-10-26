namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents a Webhook Create Exception
    /// </summary>
    public class InvalidWebhookException : BaseDiscordException
    {
        /// <summary>
        /// Invalid username characters
        /// </summary>
        public static readonly char[] InvalidUserNameCharacters = "@#:".ToCharArray();
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        private InvalidWebhookException(string message) : base(message) { }

        internal static void ThrowIfInvalidName(string name)
        {
            const int MaxLength = 80;
            if (string.IsNullOrEmpty(name) || name.Length > MaxLength)
            {
                throw new InvalidWebhookException($"Name '{name}' cannot be less than 1 character or more than {MaxLength} characters");
            }

            if (name.IndexOfAny(InvalidUserNameCharacters) != -1)
            {
                throw new InvalidWebhookException($"Name '{name}' Cannot contain any of the following characters [@,#,:]");
            }

            if (name.Contains("```"))
            {
                throw new InvalidWebhookException($"Name '{name}' Cannot contain \"```\"");
            }

            if (name.Contains("discord"))
            {
                throw new InvalidWebhookException($"Name '{name}' Cannot contain \"discord\"");
            }
        }
    }
}