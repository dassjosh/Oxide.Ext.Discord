using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Discord Template for Emoji
    /// </summary>
    public class EmojiTemplate
    {
        /// <summary>
        /// Emoji Name or ID
        /// </summary>
        [JsonProperty("Emoji Name Or ID")]
        public string Emoji { get; set; } = string.Empty;
        
        /// <summary>
        /// If the emoji is Animated
        /// </summary>
        [JsonProperty("For Custom Emojis Is The Emoji Animated")]
        public bool Animated { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        [JsonConstructor]
        public EmojiTemplate() { }

        /// <summary>
        /// Unicode emoji constructor
        /// </summary>
        /// <param name="emoji">Unicode Emoji</param>
        public EmojiTemplate(string emoji)
        {
            Emoji = emoji;
        }
        
        /// <summary>
        /// Custom Emoji Constructor
        /// </summary>
        /// <param name="emojiId">ID of the emoji</param>
        /// <param name="animated">Is the emoji animated?</param>
        public EmojiTemplate(Snowflake emojiId, bool animated = false)
        {
            Emoji = emojiId.ToString();
            Animated = animated;
        }
        
        /// <summary>
        /// Converts the <see cref="EmojiTemplate"/> to a <see cref="DiscordEmoji"/>
        /// </summary>
        /// <returns></returns>
        public DiscordEmoji ToEmoji()
        {
            if (string.IsNullOrEmpty(Emoji))
            {
                return null;
            }
            
            if (Snowflake.TryParse(Emoji, out Snowflake id))
            {
                return new DiscordEmoji
                {
                    EmojiId = id,
                    Animated = Animated
                };
            }
            
            InvalidEmojiException.ThrowIfInvalidEmojiString(Emoji);

            return new DiscordEmoji
            {
                Name = Emoji
            };
        }
    }
}