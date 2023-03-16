using Newtonsoft.Json;

namespace Data
{
    public class ShortlinkSeedData
    {
        [JsonProperty("short_url")]
        public string Id { get; set; }

        [JsonProperty("hits")]
        public int Hit { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("shortUrl")]
        public string ShortUrl { get; set; }
    }
}
