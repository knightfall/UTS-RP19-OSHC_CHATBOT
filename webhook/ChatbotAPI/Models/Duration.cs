using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Duration
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public string DurationDuration { get; set; }
    }
}