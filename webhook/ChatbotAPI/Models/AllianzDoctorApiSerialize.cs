using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public static class AllianzDoctorApiSerialize
    {
        public static string ToJson(this AllianzDoctorApiResponse self) => JsonConvert.SerializeObject(self, ChatbotAPI.Models.AllianzDoctorApiConverter.Settings);
    }
}