using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Geometry
    {
        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("viewport")]
        public Bounds Viewport { get; set; }
    }
}