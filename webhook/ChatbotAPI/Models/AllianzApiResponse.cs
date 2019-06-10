using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotAPI.Models
{
    public partial class AllianzApiResponse
    {
        [JsonProperty("details")]
        public object Details { get; set; }

        [JsonProperty("gatewayRef")]
        public string GatewayRef { get; set; }

        [JsonProperty("hasDetails")]
        public bool HasDetails { get; set; }

        [JsonProperty("merchantNo")]
        public string MerchantNo { get; set; }

        [JsonProperty("premium")]
        public Premium Premium { get; set; }

        [JsonProperty("purchased")]
        public bool Purchased { get; set; }

        [JsonProperty("quoteIdentifier")]
        public QuoteIdentifier QuoteIdentifier { get; set; }

        [JsonProperty("quoteRequest")]
        public QuoteRequest QuoteRequest { get; set; }
    }

    public partial class AllianzApiResponse
    {
        public static AllianzApiResponse FromJson(string json) => JsonConvert.DeserializeObject<AllianzApiResponse>(json, AllianzConverter.Settings);
    }
}
