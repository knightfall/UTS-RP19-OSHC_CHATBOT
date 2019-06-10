using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Premium
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("nettAmount")]
        public long NettAmount { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("premiumId")]
        public long PremiumId { get; set; }

        [JsonProperty("refundAmount")]
        public long RefundAmount { get; set; }

        [JsonProperty("refundReason")]
        public object RefundReason { get; set; }
    }
}