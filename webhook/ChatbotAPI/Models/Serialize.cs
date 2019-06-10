using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class Serialize
    {
        public static string ToJson(this DflowWebhookRequest self) => JsonConvert.SerializeObject(self, ChatbotAPI.Models.Converter.Settings);
    }
}