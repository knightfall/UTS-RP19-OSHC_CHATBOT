using System;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Myself
    {
        [JsonProperty("DOB")]
        public DateTimeOffset Dob { get; set; }
    }
}