using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class QuoteIdentifier
    {
        [JsonProperty("referenceNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ReferenceNumber { get; set; }
    }
}