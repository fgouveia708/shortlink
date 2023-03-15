using Newtonsoft.Json;

namespace Application.ViewModels
{
    public class GetShorlinkViewModelRequest
    {
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
