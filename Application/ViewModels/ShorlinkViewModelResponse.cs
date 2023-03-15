using Newtonsoft.Json;

namespace Application.ViewModels
{
    public class ShorlinkViewModelResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
