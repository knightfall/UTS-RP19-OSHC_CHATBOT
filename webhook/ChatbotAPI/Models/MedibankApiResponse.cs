using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotAPI.Models
{
    public partial class MedibankResponseJson
    {
        public static MedibankResponseJson FromJson(string json) => JsonConvert.DeserializeObject<MedibankResponseJson>(json, MedibankConverter.Settings);
    }
}
