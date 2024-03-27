//    using DndClassJson;
//
//    var the5EClasses = The5EClasses.FromJson(jsonString);

namespace DndClassJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class The5EClasses
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hit_die")]
        public long HitDie { get; set; }

        [JsonProperty("proficiency_choices")]
        public List<ProficiencyChoice> ProficiencyChoices { get; set; }

        [JsonProperty("proficiencies")]
        public List<Proficiency> Proficiencies { get; set; }

        [JsonProperty("saving_throws")]
        public List<Proficiency> SavingThrows { get; set; }

        [JsonProperty("starting_equipment")]
        public ClassLevels StartingEquipment { get; set; }

        [JsonProperty("class_levels")]
        public ClassLevels ClassLevels { get; set; }

        [JsonProperty("subclasses")]
        public List<Subclass> Subclasses { get; set; }

        [JsonProperty("spellcasting")]
        public ClassLevels Spellcasting { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class ClassLevels
    {
        [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty("class", NullValueHandling = NullValueHandling.Ignore)]
        public string Class { get; set; }
    }

    public partial class Proficiency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class ProficiencyChoice
    {
        [JsonProperty("choose")]
        public long Choose { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("from")]
        public List<Subclass> From { get; set; }
    }

    public partial class Subclass
    {
        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public enum TypeEnum { Proficiencies };

    public partial class The5EClasses
    {
        public static List<The5EClasses> FromJson(string json) => JsonConvert.DeserializeObject<List<The5EClasses>>(json, DndClassJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<The5EClasses> self) => JsonConvert.SerializeObject(self, DndClassJson.Converter.Settings);
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

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "proficiencies")
            {
                return TypeEnum.Proficiencies;
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
            if (value == TypeEnum.Proficiencies)
            {
                serializer.Serialize(writer, "proficiencies");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
