using Newtonsoft.Json;

namespace Application.ViewModels
{
    public class CreateShortlinkViewModelResponse
    {
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
