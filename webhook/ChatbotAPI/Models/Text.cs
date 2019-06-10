using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class Text
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TextText { get; set; }
    }
}