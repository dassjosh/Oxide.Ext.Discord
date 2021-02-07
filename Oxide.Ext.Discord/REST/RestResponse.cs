using Newtonsoft.Json;

namespace uMod.Ext.Discord.REST
{
    public class RestResponse
    {
        public string Data { get; }

        public RestResponse(string data)
        {
            Data = data;
        }

        public T ParseData<T>() => JsonConvert.DeserializeObject<T>(Data);
    }
}
