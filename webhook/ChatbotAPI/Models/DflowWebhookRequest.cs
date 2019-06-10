﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ChatbotAPI.Models;
//
//    var dflowWebhookRequest = DflowWebhookRequest.FromJson(jsonString);

using System.Net.Mime;

namespace ChatbotAPI.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class DflowWebhookRequest
    {
        [JsonProperty("responseId", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseId { get; set; }

        [JsonProperty("queryResult", NullValueHandling = NullValueHandling.Ignore)]
        public QueryResult QueryResult { get; set; }

        [JsonProperty("originalDetectIntentRequest", NullValueHandling = NullValueHandling.Ignore)]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }

        [JsonProperty("session", NullValueHandling = NullValueHandling.Ignore)]
        public string Session { get; set; }

        [JsonProperty("alternativeQueryResults", NullValueHandling = NullValueHandling.Ignore)]
        public List<AlternativeQueryResult> AlternativeQueryResults { get; set; }
    }
    public partial class AlternativeQueryResultOutputContext
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public OutputContextParameters Parameters { get; set; }
    }
    public partial class DflowWebhookRequest
    {
        public static DflowWebhookRequest FromJson(string json) => JsonConvert.DeserializeObject<DflowWebhookRequest>(json, ChatbotAPI.Models.Converter.Settings);
    }
}
