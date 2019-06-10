using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Parameters
    {
        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("number.original", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? NumberOriginal { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public Duration Duration { get; set; }

        [JsonProperty("partner", NullValueHandling = NullValueHandling.Ignore)]
        public string Partner { get; set; }

        [JsonProperty("child", NullValueHandling = NullValueHandling.Ignore)]
        public string Child { get; set; }
    }
}