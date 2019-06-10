using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class AllianzSerialize
    {
        public static string ToJson(this AllianzApiResponse self) => JsonConvert.SerializeObject(self, AllianzConverter.Settings);
    }
}