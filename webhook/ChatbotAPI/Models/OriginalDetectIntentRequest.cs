using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class OriginalDetectIntentRequest
    {
        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public Payload Payload { get; set; }
    }
}