using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class FulfillmentMessage
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public Text Text { get; set; }
    }
}