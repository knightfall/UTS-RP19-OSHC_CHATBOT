using System;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    public partial class CbhsApiAppjsonRequestSoleParent
    {
        [JsonProperty("hasLoadedStep2b")]
        public bool HasLoadedStep2B { get; set; }

        [JsonProperty("hasLoadedStep2c")]
        public bool HasLoadedStep2C { get; set; }

        [JsonProperty("hasLoadedStep2aOnce")]
        public bool HasLoadedStep2AOnce { get; set; }

        [JsonProperty("hasLoadedStep2bOnce")]
        public bool HasLoadedStep2BOnce { get; set; }

        [JsonProperty("hasLoadedStep2cOnce")]
        public bool HasLoadedStep2COnce { get; set; }

        [JsonProperty("hasLoadedStep2dOnce")]
        public bool HasLoadedStep2DOnce { get; set; }

        [JsonProperty("hasAttemptedTokenRetrievalOnce")]
        public bool HasAttemptedTokenRetrievalOnce { get; set; }

        [JsonProperty("hasAttemptedPaymentOnce")]
        public bool HasAttemptedPaymentOnce { get; set; }

        [JsonProperty("hasAttemptedSFDCSyncOnce")]
        public bool HasAttemptedSfdcSyncOnce { get; set; }

        [JsonProperty("hasCompletedApplication")]
        public bool HasCompletedApplication { get; set; }

        [JsonProperty("curMemNum")]
        public string CurMemNum { get; set; }

        [JsonProperty("curCoverage")]
        public string CurCoverage { get; set; }

        [JsonProperty("curFund")]
        public string CurFund { get; set; }

        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty("selectedState")]
        public string SelectedState { get; set; }

        [JsonProperty("coverType")]
        public string CoverType { get; set; }

        [JsonProperty("myself")]
        public Myself Myself { get; set; }

        [JsonProperty("partner")]
        public NoPartner Partner { get; set; }

        [JsonProperty("numOfChild")]
        public long NumOfChild { get; set; }

        [JsonProperty("visa")]
        public string Visa { get; set; }

        [JsonProperty("passportCountry")]
        public string PassportCountry { get; set; }

        [JsonProperty("childrenJSON")]
        public ChildrenJson ChildrenJson { get; set; }

        [JsonProperty("prevPageStep")]
        public long PrevPageStep { get; set; }

        [JsonProperty("currentPageStep")]
        public string CurrentPageStep { get; set; }
    }
}