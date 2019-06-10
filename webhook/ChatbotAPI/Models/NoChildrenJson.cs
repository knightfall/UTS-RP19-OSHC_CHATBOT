using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class NoChildrenJson
    {
        [JsonProperty("numOfChild")]
        public long NumOfChild { get; set; }
    }
}