using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="ResponseError"/>
    /// </summary>
    public class ResponseErrorKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="ResponseError.HttpStatusCode"/>
        /// </summary>
        public readonly PlaceholderKey Code;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="ResponseErrorMessage.Message"/>
        /// </summary>
        public readonly PlaceholderKey Message;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public ResponseErrorKeys(string prefix)
        {
            Code = new PlaceholderKey(prefix, "code");
            Message = new PlaceholderKey(prefix, "message");
        }
    }
}