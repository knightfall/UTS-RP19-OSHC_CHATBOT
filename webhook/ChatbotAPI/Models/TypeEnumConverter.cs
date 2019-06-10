using System;
using Newtonsoft.Json;

namespace ChatbotAPI.Models
{
    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "mobile":
                    return TypeEnum.Mobile;
                case "practice":
                    return TypeEnum.Practice;
                case "tele":
                    return TypeEnum.Tele;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Mobile:
                    serializer.Serialize(writer, "mobile");
                    return;
                case TypeEnum.Practice:
                    serializer.Serialize(writer, "practice");
                    return;
                case TypeEnum.Tele:
                    serializer.Serialize(writer, "tele");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}