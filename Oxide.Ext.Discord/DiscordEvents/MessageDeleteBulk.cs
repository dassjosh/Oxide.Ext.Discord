using System.Collections.Generic;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class MessageDeleteBulk
    {
        public List<string> ids { get; set; }

        public string channel_id { get; set; }
    }
}
