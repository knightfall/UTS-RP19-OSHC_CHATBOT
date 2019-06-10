using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class AlternativeQueryResult
    {
        [JsonProperty("queryText", NullValueHandling = NullValueHandling.Ignore)]
        public string QueryText { get; set; }
        [JsonProperty("outputContexts", NullValueHandling = NullValueHandling.Ignore)]
        public List<AlternativeQueryResultOutputContext> OutputContexts { get; set; }
        [JsonProperty("languageCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }
    }
}