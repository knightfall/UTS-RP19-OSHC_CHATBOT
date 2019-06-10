using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Hours
    {
        [JsonProperty("Wednesday")]
        public string Wednesday { get; set; }

        [JsonProperty("Thursday")]
        public string Thursday { get; set; }

        [JsonProperty("Friday")]
        public string Friday { get; set; }

        [JsonProperty("Saturday")]
        public string Saturday { get; set; }

        [JsonProperty("Sunday")]
        public string Sunday { get; set; }

        [JsonProperty("Monday")]
        public string Monday { get; set; }

        [JsonProperty("Tuesday")]
        public string Tuesday { get; set; }
    }
}