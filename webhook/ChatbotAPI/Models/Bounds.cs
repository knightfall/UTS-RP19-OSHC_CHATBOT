using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Bounds
    {
        [JsonProperty("northeast")]
        public Location Northeast { get; set; }

        [JsonProperty("southwest")]
        public Location Southwest { get; set; }
    }
}