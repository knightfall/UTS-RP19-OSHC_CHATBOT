using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class CbhsApiAppjsonRequestSoleParentSerialize
    {
        public static string ToJson(this CbhsApiAppjsonRequestSoleParent self) => JsonConvert.SerializeObject(self, CbhsApiAppjsonRequestSoleParentConverter.Settings);
    }
}