namespace ClassesDto
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitDie { get; set; }
        public List<ChoicesDto> ProficiencyChoices { get; set; }
        public List<string> Proficiencies { get; set; }
        public List<string> SavingThrows { get; set; }
        public List<ClassLevelsDto> ClassLevels { get; set; }
        public List<SubclassDto> Subclasses { get; set; }
        public SpellCastingDto? Spellcasting { get; set; }
        public StartingEquipmentDto StartingEquipment { get; set; }

    }


    public class ClassLevelsDto
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int AbilityScoreBonus { get; set; }
        public int ProfBonus { get; set; }
        public List<string> FeatureChoices { get; set; }
        public List<FeatureDto> Features { get; set; }
        public ClassSpecificDto ClassSpecific { get; set; }
        public string Class { get; set; }
        public string Subclass { get; set; }
        public Dictionary<string, int> Spellcasting { get; set; }
    }

    public class SubclassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubclassFlavor { get; set; }
        public List<string> Desc { get; set; }
        public List<FeatureDto> Features { get; set; }
        public string Class { get; set; }
        public List<SpellsDto> Spells { get; set; }
    }
    public class SpellsDto
    {
        public List<Prerequisite> Prerequisites { get; set; }
        public string Name { get; set; }

    }

    public class FeatureDto
    {
        public string Class { get; set; }
        public string? Subclass { get; set; }
        public string Name { get; set; }
        public string[] Desc { get; set; }
        public ChoicesDto? Choice { get; set; }
    }

    public class StartingEquipmentDto
    {
        public string Class { get; set; }
        public int? Quantity { get; set; }
        public List<ChoicesDto> Choice1 { get; set; }
        public List<ChoicesDto> Choice2 { get; set; }
        public List<EquipmentChoicesDto> Choice3 { get; set; }
        public List<EquipmentChoicesDto> Choice4 { get; set; }
        public List<EquipmentChoicesDto> Choice5 { get; set; }

    }
    public class Prerequisite
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class SpellCastingDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string SpellcastingAbility { get; set; }
        public List<InfoDto> Info { get; set; }

    }

    public class ClassSpecificDto
    {
        public int? AdditionalMagicalSecretsMaxLvl { get; set; }
        public int? RageCount { get; set; }

        public int? RageDamageBonus { get; set; }

        public int? BrutalCriticalDice { get; set; }

        public int? BardicInspirationDie { get; set; }

        public int? SongOfRestDie { get; set; }

        public int? MagicalSecretsMax5 { get; set; }

        public int? MagicalSecretsMax7 { get; set; }

        public int? MagicalSecretsMax9 { get; set; }

        public int? ChannelDivinityCharges { get; set; }

        public double? DestroyUndeadCr { get; set; }

        public double? WildShapeMaxCr { get; set; }

        public bool? WildShapeSwim { get; set; }

        public bool? WildShapeFly { get; set; }

        public int? ActionSurges { get; set; }

        public int? IndomitableUses { get; set; }

        public int? ExtraAttacks { get; set; }

        public MartialArtsDto? MartialArts { get; set; }

        public int? UnarmoredMovement { get; set; }

        public int? AuraRange { get; set; }

        public int? FavoredEnemies { get; set; }

        public int? FavoredTerrain { get; set; }
        public MartialArtsDto? SneakAttack { get; set; }

        public int? SorceryPoints { get; set; }

        public int? MetamagicKnown { get; set; }

        public List<CreatingSpellSlotDto>? CreatingSpellSlots { get; set; }

        public int? InvocationsKnown { get; set; }

        public int? MysticArcanumLevel6 { get; set; }

        public int? MysticArcanumLevel7 { get; set; }

        public int? MysticArcanumLevel8 { get; set; }

        public int? MysticArcanumLevel9 { get; set; }

        public int? ArcaneRecoveryLevels { get; set; }
    }

    public class MartialArtsDto
    {
        public int DiceCount { get; set; }

        public int DiceValue { get; set; }
    }
    public class CreatingSpellSlotDto
    {
        public int SpellSlotLevel { get; set; }

        public int SorceryPointCost { get; set; }
    }
    public class InfoDto
    {
        public string Name { get; set; }
        public List<string> Desc { get; set; }

    }
    public class ChoicesDto
    {
        public int Choose { get; set; }
        public string Type { get; set; }
        public List<string> Choices { get; set; }
    }
    public class EquipmentChoicesDto
    {
        public int Choose { get; set; }
        public string Type { get; set; }
        public List<ItemDto> Choices { get; set; }
    }

    public class ItemDto
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
    }
}