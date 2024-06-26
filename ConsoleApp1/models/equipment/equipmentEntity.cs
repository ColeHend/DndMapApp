// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using DndEquipmentJson;
//
//    var the5EEquipment = The5EEquipment.FromJson(jsonString);

namespace DndEquipmentJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class The5EEquipment
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("equipment_category")]
        public EquipmentCategory EquipmentCategory { get; set; }

        [JsonProperty("weapon_category", NullValueHandling = NullValueHandling.Ignore)]
        public WeaponCategory? WeaponCategory { get; set; }

        [JsonProperty("weapon_range", NullValueHandling = NullValueHandling.Ignore)]
        public WeaponRange? WeaponRange { get; set; }

        [JsonProperty("category_range", NullValueHandling = NullValueHandling.Ignore)]
        public CategoryRange? CategoryRange { get; set; }

        [JsonProperty("cost")]
        public Cost Cost { get; set; }

        [JsonProperty("damage", NullValueHandling = NullValueHandling.Ignore)]
        public Damage Damage { get; set; }

        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public Range Range { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public double? Weight { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("throw_range", NullValueHandling = NullValueHandling.Ignore)]
        public Range ThrowRange { get; set; }

        [JsonProperty("2h_damage", NullValueHandling = NullValueHandling.Ignore)]
        public Damage The2HDamage { get; set; }

        [JsonProperty("special", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Special { get; set; }

        [JsonProperty("armor_category", NullValueHandling = NullValueHandling.Ignore)]
        public string ArmorCategory { get; set; }

        [JsonProperty("armor_class", NullValueHandling = NullValueHandling.Ignore)]
        public ArmorClass ArmorClass { get; set; }

        [JsonProperty("str_minimum", NullValueHandling = NullValueHandling.Ignore)]
        public long? StrMinimum { get; set; }

        [JsonProperty("stealth_disadvantage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StealthDisadvantage { get; set; }

        [JsonProperty("gear_category", NullValueHandling = NullValueHandling.Ignore)]
        public GearCategory? GearCategory { get; set; }

        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Desc { get; set; }

        [JsonProperty("contents", NullValueHandling = NullValueHandling.Ignore)]
        public List<Content> Contents { get; set; }

        [JsonProperty("tool_category", NullValueHandling = NullValueHandling.Ignore)]
        public ToolCategory? ToolCategory { get; set; }

        [JsonProperty("vehicle_category", NullValueHandling = NullValueHandling.Ignore)]
        public VehicleCategory? VehicleCategory { get; set; }

        [JsonProperty("speed", NullValueHandling = NullValueHandling.Ignore)]
        public Cost Speed { get; set; }

        [JsonProperty("capacity", NullValueHandling = NullValueHandling.Ignore)]
        public string Capacity { get; set; }
    }

    public partial class ArmorClass
    {
        [JsonProperty("base")]
        public long Base { get; set; }

        [JsonProperty("dex_bonus")]
        public bool DexBonus { get; set; }

        [JsonProperty("max_bonus")]
        public long? MaxBonus { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("item_url")]
        public Uri ItemUrl { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    public partial class Cost
    {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }
    }

    public partial class Damage
    {
        [JsonProperty("damage_dice")]
        public string DamageDice { get; set; }

        [JsonProperty("damage_bonus")]
        public long DamageBonus { get; set; }

        [JsonProperty("damage_type")]
        public DamageType DamageType { get; set; }
    }

    public partial class DamageType
    {
        [JsonProperty("ref")]
        public Ref Ref { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("normal")]
        public long Normal { get; set; }

        [JsonProperty("long")]
        public long? Long { get; set; }
    }

    public enum CategoryRange { MartialMelee, MartialRanged, SimpleMelee, SimpleRanged };

    public enum Unit { Cp, FtRound, Gp, Mph, Sp };

    public enum Name { Bludgeoning, Piercing, Slashing };

    public enum Ref { DamageTypes12, DamageTypes2, DamageTypes8 };

    public enum EquipmentCategory { AdventuringGear, Armor, MountsAndVehicles, Tools, Weapon };

    public enum GearCategory { Ammunition, ArcaneFocus, DruidicFocus, EquipmentPack, HolySymbol, Kit, StandardGear };

    public enum ToolCategory { ArtisanSTools, GamingSets, MusicalInstrument, OtherTools };

    public enum VehicleCategory { MountsAndOtherAnimals, TackHarnessAndDrawnVehicles, WaterborneVehicles };

    public enum WeaponCategory { Martial, Simple };

    public enum WeaponRange { Melee, Ranged };

    public partial class The5EEquipment
    {
        public static List<The5EEquipment> FromJson(string json) => JsonConvert.DeserializeObject<List<The5EEquipment>>(json, DndEquipmentJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<The5EEquipment> self) => JsonConvert.SerializeObject(self, DndEquipmentJson.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NameConverter.Singleton,
                RefConverter.Singleton,
                CategoryRangeConverter.Singleton,
                UnitConverter.Singleton,
                EquipmentCategoryConverter.Singleton,
                GearCategoryConverter.Singleton,
                ToolCategoryConverter.Singleton,
                VehicleCategoryConverter.Singleton,
                WeaponCategoryConverter.Singleton,
                WeaponRangeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Bludgeoning":
                    return Name.Bludgeoning;
                case "Piercing":
                    return Name.Piercing;
                case "Slashing":
                    return Name.Slashing;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.Bludgeoning:
                    serializer.Serialize(writer, "Bludgeoning");
                    return;
                case Name.Piercing:
                    serializer.Serialize(writer, "Piercing");
                    return;
                case Name.Slashing:
                    serializer.Serialize(writer, "Slashing");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class RefConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Ref) || t == typeof(Ref?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "damage-types/12":
                    return Ref.DamageTypes12;
                case "damage-types/2":
                    return Ref.DamageTypes2;
                case "damage-types/8":
                    return Ref.DamageTypes8;
            }
            throw new Exception("Cannot unmarshal type Ref");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Ref)untypedValue;
            switch (value)
            {
                case Ref.DamageTypes12:
                    serializer.Serialize(writer, "damage-types/12");
                    return;
                case Ref.DamageTypes2:
                    serializer.Serialize(writer, "damage-types/2");
                    return;
                case Ref.DamageTypes8:
                    serializer.Serialize(writer, "damage-types/8");
                    return;
            }
            throw new Exception("Cannot marshal type Ref");
        }

        public static readonly RefConverter Singleton = new RefConverter();
    }

    internal class CategoryRangeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CategoryRange) || t == typeof(CategoryRange?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Martial Melee":
                    return CategoryRange.MartialMelee;
                case "Martial Ranged":
                    return CategoryRange.MartialRanged;
                case "Simple Melee":
                    return CategoryRange.SimpleMelee;
                case "Simple Ranged":
                    return CategoryRange.SimpleRanged;
            }
            throw new Exception("Cannot unmarshal type CategoryRange");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CategoryRange)untypedValue;
            switch (value)
            {
                case CategoryRange.MartialMelee:
                    serializer.Serialize(writer, "Martial Melee");
                    return;
                case CategoryRange.MartialRanged:
                    serializer.Serialize(writer, "Martial Ranged");
                    return;
                case CategoryRange.SimpleMelee:
                    serializer.Serialize(writer, "Simple Melee");
                    return;
                case CategoryRange.SimpleRanged:
                    serializer.Serialize(writer, "Simple Ranged");
                    return;
            }
            throw new Exception("Cannot marshal type CategoryRange");
        }

        public static readonly CategoryRangeConverter Singleton = new CategoryRangeConverter();
    }

    internal class UnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Unit) || t == typeof(Unit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cp":
                    return Unit.Cp;
                case "ft/round":
                    return Unit.FtRound;
                case "gp":
                    return Unit.Gp;
                case "mph":
                    return Unit.Mph;
                case "sp":
                    return Unit.Sp;
            }
            throw new Exception("Cannot unmarshal type Unit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Unit)untypedValue;
            switch (value)
            {
                case Unit.Cp:
                    serializer.Serialize(writer, "cp");
                    return;
                case Unit.FtRound:
                    serializer.Serialize(writer, "ft/round");
                    return;
                case Unit.Gp:
                    serializer.Serialize(writer, "gp");
                    return;
                case Unit.Mph:
                    serializer.Serialize(writer, "mph");
                    return;
                case Unit.Sp:
                    serializer.Serialize(writer, "sp");
                    return;
            }
            throw new Exception("Cannot marshal type Unit");
        }

        public static readonly UnitConverter Singleton = new UnitConverter();
    }

    internal class EquipmentCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EquipmentCategory) || t == typeof(EquipmentCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Adventuring Gear":
                    return EquipmentCategory.AdventuringGear;
                case "Armor":
                    return EquipmentCategory.Armor;
                case "Mounts and Vehicles":
                    return EquipmentCategory.MountsAndVehicles;
                case "Tools":
                    return EquipmentCategory.Tools;
                case "Weapon":
                    return EquipmentCategory.Weapon;
            }
            throw new Exception("Cannot unmarshal type EquipmentCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EquipmentCategory)untypedValue;
            switch (value)
            {
                case EquipmentCategory.AdventuringGear:
                    serializer.Serialize(writer, "Adventuring Gear");
                    return;
                case EquipmentCategory.Armor:
                    serializer.Serialize(writer, "Armor");
                    return;
                case EquipmentCategory.MountsAndVehicles:
                    serializer.Serialize(writer, "Mounts and Vehicles");
                    return;
                case EquipmentCategory.Tools:
                    serializer.Serialize(writer, "Tools");
                    return;
                case EquipmentCategory.Weapon:
                    serializer.Serialize(writer, "Weapon");
                    return;
            }
            throw new Exception("Cannot marshal type EquipmentCategory");
        }

        public static readonly EquipmentCategoryConverter Singleton = new EquipmentCategoryConverter();
    }

    internal class GearCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GearCategory) || t == typeof(GearCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Ammunition":
                    return GearCategory.Ammunition;
                case "Arcane focus":
                    return GearCategory.ArcaneFocus;
                case "Druidic focus":
                    return GearCategory.DruidicFocus;
                case "Equipment Pack":
                    return GearCategory.EquipmentPack;
                case "Holy Symbol":
                    return GearCategory.HolySymbol;
                case "Kit":
                    return GearCategory.Kit;
                case "Standard Gear":
                    return GearCategory.StandardGear;
            }
            throw new Exception("Cannot unmarshal type GearCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GearCategory)untypedValue;
            switch (value)
            {
                case GearCategory.Ammunition:
                    serializer.Serialize(writer, "Ammunition");
                    return;
                case GearCategory.ArcaneFocus:
                    serializer.Serialize(writer, "Arcane focus");
                    return;
                case GearCategory.DruidicFocus:
                    serializer.Serialize(writer, "Druidic focus");
                    return;
                case GearCategory.EquipmentPack:
                    serializer.Serialize(writer, "Equipment Pack");
                    return;
                case GearCategory.HolySymbol:
                    serializer.Serialize(writer, "Holy Symbol");
                    return;
                case GearCategory.Kit:
                    serializer.Serialize(writer, "Kit");
                    return;
                case GearCategory.StandardGear:
                    serializer.Serialize(writer, "Standard Gear");
                    return;
            }
            throw new Exception("Cannot marshal type GearCategory");
        }

        public static readonly GearCategoryConverter Singleton = new GearCategoryConverter();
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

    internal class ToolCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ToolCategory) || t == typeof(ToolCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Artisan's Tools":
                    return ToolCategory.ArtisanSTools;
                case "Gaming Sets":
                    return ToolCategory.GamingSets;
                case "Musical Instrument":
                    return ToolCategory.MusicalInstrument;
                case "Other Tools":
                    return ToolCategory.OtherTools;
            }
            throw new Exception("Cannot unmarshal type ToolCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ToolCategory)untypedValue;
            switch (value)
            {
                case ToolCategory.ArtisanSTools:
                    serializer.Serialize(writer, "Artisan's Tools");
                    return;
                case ToolCategory.GamingSets:
                    serializer.Serialize(writer, "Gaming Sets");
                    return;
                case ToolCategory.MusicalInstrument:
                    serializer.Serialize(writer, "Musical Instrument");
                    return;
                case ToolCategory.OtherTools:
                    serializer.Serialize(writer, "Other Tools");
                    return;
            }
            throw new Exception("Cannot marshal type ToolCategory");
        }

        public static readonly ToolCategoryConverter Singleton = new ToolCategoryConverter();
    }

    internal class VehicleCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VehicleCategory) || t == typeof(VehicleCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Mounts and Other Animals":
                    return VehicleCategory.MountsAndOtherAnimals;
                case "Tack, Harness, and Drawn Vehicles":
                    return VehicleCategory.TackHarnessAndDrawnVehicles;
                case "Waterborne Vehicles":
                    return VehicleCategory.WaterborneVehicles;
            }
            throw new Exception("Cannot unmarshal type VehicleCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VehicleCategory)untypedValue;
            switch (value)
            {
                case VehicleCategory.MountsAndOtherAnimals:
                    serializer.Serialize(writer, "Mounts and Other Animals");
                    return;
                case VehicleCategory.TackHarnessAndDrawnVehicles:
                    serializer.Serialize(writer, "Tack, Harness, and Drawn Vehicles");
                    return;
                case VehicleCategory.WaterborneVehicles:
                    serializer.Serialize(writer, "Waterborne Vehicles");
                    return;
            }
            throw new Exception("Cannot marshal type VehicleCategory");
        }

        public static readonly VehicleCategoryConverter Singleton = new VehicleCategoryConverter();
    }

    internal class WeaponCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WeaponCategory) || t == typeof(WeaponCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Martial":
                    return WeaponCategory.Martial;
                case "Simple":
                    return WeaponCategory.Simple;
            }
            throw new Exception("Cannot unmarshal type WeaponCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WeaponCategory)untypedValue;
            switch (value)
            {
                case WeaponCategory.Martial:
                    serializer.Serialize(writer, "Martial");
                    return;
                case WeaponCategory.Simple:
                    serializer.Serialize(writer, "Simple");
                    return;
            }
            throw new Exception("Cannot marshal type WeaponCategory");
        }

        public static readonly WeaponCategoryConverter Singleton = new WeaponCategoryConverter();
    }

    internal class WeaponRangeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WeaponRange) || t == typeof(WeaponRange?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Melee":
                    return WeaponRange.Melee;
                case "Ranged":
                    return WeaponRange.Ranged;
            }
            throw new Exception("Cannot unmarshal type WeaponRange");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WeaponRange)untypedValue;
            switch (value)
            {
                case WeaponRange.Melee:
                    serializer.Serialize(writer, "Melee");
                    return;
                case WeaponRange.Ranged:
                    serializer.Serialize(writer, "Ranged");
                    return;
            }
            throw new Exception("Cannot marshal type WeaponRange");
        }

        public static readonly WeaponRangeConverter Singleton = new WeaponRangeConverter();
    }
}
