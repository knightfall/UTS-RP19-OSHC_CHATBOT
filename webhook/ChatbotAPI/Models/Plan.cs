using System;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Plan
    {
        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("planId")]
        public long PlanId { get; set; }
    }
}