using System.Text;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Constants
{
    /// <summary>
    /// Encoding format the Discord Uses
    /// </summary>
    public sealed class DiscordEncoding : Singleton<DiscordEncoding>
    {
        /// <summary>
        /// Encoding format used by Discord
        /// </summary>
        public readonly Encoding Encoding = new UTF8Encoding(false);
        
        private DiscordEncoding() {}
    }
}