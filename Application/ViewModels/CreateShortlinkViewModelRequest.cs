using Newtonsoft.Json;

namespace Application.ViewModels
{
    public class CreateShortlinkViewModelRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
