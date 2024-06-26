// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using DndStartingEquipmentJson;
//
//    var the5EStartingEquipment = The5EStartingEquipment.FromJson(jsonString);

namespace DndStartingEquipmentJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class The5EStartingEquipment
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("class")]
        public Class Class { get; set; }

        [JsonProperty("starting_equipment")]
        public List<StartingEquipment> StartingEquipment { get; set; }

        [JsonProperty("choices_to_make")]
        public long ChoicesToMake { get; set; }

        [JsonProperty("choice_1")]
        public List<Choice1_Element> Choice1 { get; set; }

        [JsonProperty("choice_2")]
        public List<Choice1_Element> Choice2 { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("choice_3", NullValueHandling = NullValueHandling.Ignore)]
        public List<Choice3_Element> Choice3 { get; set; }

        [JsonProperty("choice_4", NullValueHandling = NullValueHandling.Ignore)]
        public List<Choice3_Element> Choice4 { get; set; }

        [JsonProperty("choice_5", NullValueHandling = NullValueHandling.Ignore)]
        public List<Choice3_Element> Choice5 { get; set; }
    }

    public partial class Choice1_Element
    {
        [JsonProperty("choose")]
        public long Choose { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("from")]
        public List<From> From { get; set; }
    }

    public partial class From
    {
        [JsonProperty("item")]
        public Class Item { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("prerequisites", NullValueHandling = NullValueHandling.Ignore)]
        public List<Prerequisite> Prerequisites { get; set; }
    }

    public partial class Class
    {
        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Prerequisite
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("proficiency")]
        public Class Proficiency { get; set; }
    }

    public partial class Choice3_Element
    {
        [JsonProperty("choose")]
        public long Choose { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("from")]
        public List<StartingEquipment> From { get; set; }
    }

    public partial class StartingEquipment
    {
        [JsonProperty("item")]
        public Class Item { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    public enum TypeEnum { Equipment };

    public partial class The5EStartingEquipment
    {
        public static List<The5EStartingEquipment> FromJson(string json) => JsonConvert.DeserializeObject<List<The5EStartingEquipment>>(json, DndStartingEquipmentJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<The5EStartingEquipment> self) => JsonConvert.SerializeObject(self, DndStartingEquipmentJson.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "equipment")
            {
                return TypeEnum.Equipment;
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
            if (value == TypeEnum.Equipment)
            {
                serializer.Serialize(writer, "equipment");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
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
}
