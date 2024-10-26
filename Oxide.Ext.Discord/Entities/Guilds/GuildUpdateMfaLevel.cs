using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#modify-guild-mfa-level-json-params">Guild MFA Level Update</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildUpdateMfaLevel
    {
        /// <summary>
        /// <see cref="GuildMfaLevel"/>
        /// </summary>
        [JsonProperty("level")]
        public GuildMfaLevel Level { get; set; }
    }
}