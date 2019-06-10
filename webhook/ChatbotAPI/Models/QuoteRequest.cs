using System;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class QuoteRequest
    {
        [JsonProperty("adults")]
        public long Adults { get; set; }

        [JsonProperty("dependants")]
        public long Dependants { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("quoteId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long QuoteId { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }
    }
}