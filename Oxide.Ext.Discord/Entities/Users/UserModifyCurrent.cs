using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/user#modify-current-user-json-params">Modify Current User Structure</a>
    /// </summary>
    public class UserModifyCurrent : IDiscordValidation
    {
        /// <summary>
        /// User's username, if changed may cause the user's discriminator to be randomized.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        
        /// <summary>
        /// If passed, modifies the user's avatar
        /// </summary>
        [JsonProperty("avatar")]
        public DiscordImageData Avatar { get; set; }
        
        /// <summary>
        /// If passed, modifies the user's banner
        /// </summary>
        [JsonProperty("banner")]
        public DiscordImageData Banner { get; set; }
        
        /// <inheritdoc/>
        public void Validate()
        {
            InvalidUserException.ThrowIfInvalidUserName(Username);
        }
    }
}