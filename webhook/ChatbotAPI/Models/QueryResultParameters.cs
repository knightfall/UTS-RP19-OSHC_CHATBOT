using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class QueryResultParameters
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }
    }
}