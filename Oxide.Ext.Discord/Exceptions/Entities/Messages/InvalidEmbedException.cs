namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an invalid embed
    /// </summary>
    public class InvalidEmbedException : BaseDiscordException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        private InvalidEmbedException(string message) : base(message)
        {
            
        }

        internal static void ThrowIfEmbedLimit(int? count)
        {
            if (count > 10)
            {
                throw new InvalidEmbedException("You cannot add more than 10 embeds in a message");
            }
        }
        
        internal static void ThrowIfInvalidTitle(string title)
        {
            if (title.Length > 256)
            {
                throw new InvalidEmbedException("Title cannot be more than 256 characters");
            }
        }
        
        internal static void ThrowIfInvalidDescription(string description)
        {
            if (description.Length > 4096)
            {
                throw new InvalidEmbedException("Description cannot be more than 4096 characters");
            }
        }
        
        internal static void ThrowIfInvalidFieldCount(int count)
        {
            if (count > 25)
            {
                throw new InvalidEmbedException("Embeds cannot have more than 25 fields");
            }
        }

        internal static void ThrowIfInvalidFieldName(string name)
        {
            if (name != null && name.Length > 256)
            {
                throw new InvalidEmbedException("Embed Field Name cannot be more than 256 characters");
            }
        }
        
        internal static void ThrowIfInvalidFieldValue(string value)
        {
            if (value != null && value.Length > 1024)
            {
                throw new InvalidEmbedException("Embed Field Value cannot be more than 1024 characters");
            }
        }
        
        internal static void ThrowIfInvalidFooterText(string text)
        {
            if (text == null)
            {
                throw new InvalidEmbedException("Embed Footer Text cannot be null");
            }
            
            if (text.Length > 2048)
            {
                throw new InvalidEmbedException("Embed Footer Text cannot be more than 2048 characters");
            }
        }
        
        internal static void ThrowIfInvalidAuthorName(string name)
        {
            if (name == null)
            {
                throw new InvalidEmbedException("Embed Author Name cannot be null");
            }
            
            if (name.Length > 256)
            {
                throw new InvalidEmbedException("Embed Author Name cannot be more than 256 characters");
            }
        }
        
        internal static void ThrowIfInvalidUrl(string url)
        {
            if (url == null)
            {
                throw new InvalidEmbedException("Url cannot be null");
            }
        }
    }
}