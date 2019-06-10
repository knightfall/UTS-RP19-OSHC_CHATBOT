using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class MedibankResponseJson
    {
        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("visaEndDate")]
        public string VisaEndDate { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("courseCompletionDate")]
        public string CourseCompletionDate { get; set; }

        [JsonProperty("fundId")]
        public long FundId { get; set; }
    }
}