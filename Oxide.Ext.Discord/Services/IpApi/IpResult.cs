using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Services.IpApi
{
    internal class IpResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        public bool IsSuccess => Status == "success";
    }
}