using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class OutputContext
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("lifespanCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? LifespanCount { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public OutputContextParameters Parameters { get; set; }
    }
}