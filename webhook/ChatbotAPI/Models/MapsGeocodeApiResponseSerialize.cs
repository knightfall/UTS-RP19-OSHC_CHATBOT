using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class MapsGeocodeApiResponseSerialize
    {
        public static string ToJson(this MapsGeocodeApiResponse self) => JsonConvert.SerializeObject(self, ChatbotAPI.Models.MapsGeocodeApiResponseConverter.Settings);
    }
}