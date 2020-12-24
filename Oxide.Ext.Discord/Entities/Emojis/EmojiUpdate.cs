using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Emojis
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]

    public class EmojiUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }
}