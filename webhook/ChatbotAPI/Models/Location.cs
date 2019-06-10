using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}