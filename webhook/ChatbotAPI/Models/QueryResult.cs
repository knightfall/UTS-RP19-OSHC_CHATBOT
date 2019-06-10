using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class QueryResult
    {
        [JsonProperty("queryText", NullValueHandling = NullValueHandling.Ignore)]
        public string QueryText { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Parameters Parameters { get; set; }

        [JsonProperty("allRequiredParamsPresent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllRequiredParamsPresent { get; set; }

        [JsonProperty("fulfillmentText", NullValueHandling = NullValueHandling.Ignore)]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages", NullValueHandling = NullValueHandling.Ignore)]
        public List<FulfillmentMessage> FulfillmentMessages { get; set; }

        [JsonProperty("outputContexts", NullValueHandling = NullValueHandling.Ignore)]
        public List<OutputContext> OutputContexts { get; set; }

        [JsonProperty("intent", NullValueHandling = NullValueHandling.Ignore)]
        public Intent Intent { get; set; }

        [JsonProperty("intentDetectionConfidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? IntentDetectionConfidence { get; set; }

        [JsonProperty("languageCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }
    }
}