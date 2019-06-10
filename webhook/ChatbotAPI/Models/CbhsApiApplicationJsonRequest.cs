using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class CbhsApiAppjsonRequestCouple
    {
        public static CbhsApiAppjsonRequestCouple FromJson(string json) => JsonConvert.DeserializeObject<CbhsApiAppjsonRequestCouple>(json, CbhsApiAppjsonRequestCoupleConverter
        .Settings);
    }

    public partial class CbhsApiAppjsonRequestSoleParent
    {
        public static CbhsApiAppjsonRequestSoleParent FromJson(string json) => JsonConvert.DeserializeObject<CbhsApiAppjsonRequestSoleParent>(json, CbhsApiAppjsonRequestSoleParentConverter.Settings);
    }
}
