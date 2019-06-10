using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class MedibankSerialize
    {
        public static string ToJson(this MedibankResponseJson self) => JsonConvert.SerializeObject(self, MedibankConverter.Settings);
    }
}