using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Result
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("latLng")]
        public LatLng LatLng { get; set; }

        [JsonProperty("doctor")]
        public List<long> Doctor { get; set; }

        [JsonProperty("doctorTypes")]
        public object DoctorTypes { get; set; }

        [JsonProperty("language")]
        public List<long> Language { get; set; }

        [JsonProperty("languages")]
        public object Languages { get; set; }

        [JsonProperty("visa")]
        public List<long> Visa { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("gender")]
        public bool Gender { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("openingHours")]
        public object OpeningHours { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("bulk")]
        public List<long> Bulk { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("hours")]
        public Hours Hours { get; set; }
    }
}