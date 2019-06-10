using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Intent
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
    }
}