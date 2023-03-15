using Newtonsoft.Json;

namespace Domain.Messages
{
    public class ThirdPartyIntegration
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
