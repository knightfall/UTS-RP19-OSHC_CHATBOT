using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class ChildrenJson
    {
        [JsonProperty("numOfChild")]
        public long NumOfChild { get; set; }

        [JsonProperty("child1")]
        public Myself Child1 { get; set; }

    }
}