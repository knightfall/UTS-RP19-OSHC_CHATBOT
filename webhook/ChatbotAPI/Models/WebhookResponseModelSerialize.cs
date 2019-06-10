using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class WebhookResponseModelSerialize
    {
        public static string ToJson(this WebhookResponseModel self) => JsonConvert.SerializeObject(self, ChatbotAPI.Models.WebhookResponseModelConverter.Settings);
    }
}