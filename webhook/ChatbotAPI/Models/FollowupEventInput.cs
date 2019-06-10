using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class FollowupEventInput
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("languageCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Parameters Parameters { get; set; }
    }
}