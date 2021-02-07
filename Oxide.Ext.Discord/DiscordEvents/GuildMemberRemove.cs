using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class GuildMemberRemove
    {
        public string guild_id { get; set; }

        public User user { get; set; }
    }
}
