using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class GuildRoleUpdate
    {
        public string guild_id { get; set; }

        public Role role { get; set; }
    }
}
