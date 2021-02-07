using System.Collections.Generic;
using Newtonsoft.Json;
using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class GuildMembersChunk
    {
        public string guild_id { get; set; }

        public List<GuildMember> members { get; set; }

        [JsonProperty("chunk_index")]
        public int ChunkIndex { get; set; }	
        
        [JsonProperty("chunk_count")]
        public int ChunkCount { get; set; }	
        
        [JsonProperty("not_found")]
        public List<string> NotFound { get; set; }
        
        [JsonProperty("presences")]
        public List<Presence> Presences { get; set; }      
        
        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }
}
