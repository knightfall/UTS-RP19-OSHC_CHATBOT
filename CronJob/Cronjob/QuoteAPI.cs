using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Cronjob
{
    public partial class AllianzApiResponse
    {
        [JsonProperty("details")]
        public object Details { get; set; }

        [JsonProperty("gatewayRef")]
        public string GatewayRef { get; set; }

        [JsonProperty("hasDetails")]
        public bool HasDetails { get; set; }

        [JsonProperty("merchantNo")]
        public string MerchantNo { get; set; }

        [JsonProperty("premium")]
        public Premium Premium { get; set; }

        [JsonProperty("purchased")]
        public bool Purchased { get; set; }

        [JsonProperty("quoteIdentifier")]
        public QuoteIdentifier QuoteIdentifier { get; set; }

        [JsonProperty("quoteRequest")]
        public QuoteRequest QuoteRequest { get; set; }
    }

    public partial class Premium
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("nettAmount")]
        public long NettAmount { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("premiumId")]
        public long PremiumId { get; set; }

        [JsonProperty("refundAmount")]
        public long RefundAmount { get; set; }

        [JsonProperty("refundReason")]
        public object RefundReason { get; set; }
    }

    public partial class Plan
    {
        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("planId")]
        public long PlanId { get; set; }
    }

    public partial class QuoteIdentifier
    {
        [JsonProperty("referenceNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ReferenceNumber { get; set; }
    }

    public partial class QuoteRequest
    {
        [JsonProperty("adults")]
        public long Adults { get; set; }

        [JsonProperty("dependants")]
        public long Dependants { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("quoteId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long QuoteId { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }
    }

    public partial class AllianzApiResponse
    {
        public static AllianzApiResponse FromJson(string json) => JsonConvert.DeserializeObject<AllianzApiResponse>(json, AllianzConverter.Settings);
    }

    public static class AllianzSerialize
    {
        public static string ToJson(this AllianzApiResponse self) => JsonConvert.SerializeObject(self, AllianzConverter.Settings);
    }

    internal static class AllianzConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
    public partial class MedibankResponseJson
    {
        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("visaEndDate")]
        public string VisaEndDate { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("courseCompletionDate")]
        public string CourseCompletionDate { get; set; }

        [JsonProperty("fundId")]
        public long FundId { get; set; }
    }

    public partial class MedibankResponseJson
    {
        public static MedibankResponseJson FromJson(string json) => JsonConvert.DeserializeObject<MedibankResponseJson>(json, MedibankConverter.Settings);
    }

    public static class MedibankSerialize
    {
        public static string ToJson(this MedibankResponseJson self) => JsonConvert.SerializeObject(self, MedibankConverter.Settings);
    }

    internal static class MedibankConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
