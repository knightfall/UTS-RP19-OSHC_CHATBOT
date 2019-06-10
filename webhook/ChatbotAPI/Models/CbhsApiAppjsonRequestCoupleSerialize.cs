using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class CbhsApiAppjsonRequestCoupleSerialize
    {
        public static string ToJson(this CbhsApiAppjsonRequestCouple self) => JsonConvert.SerializeObject(self, CbhsApiAppjsonRequestCoupleConverter.Settings);
    }
}