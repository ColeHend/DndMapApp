namespace ClassesDto
{
    /// <summary>
    /// Class Entity
    /// </summary>
    public class ClassEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitDie { get; set; }
        public List<string> Proficiencies { get; set; }
        public List<string> SavingThrows { get; set; }
        public List<ChoicesEntity<string>> ProficiencyChoices { get; set; }
        public List<LevelEntity> ClassLevels { get; set; }
        public List<SubclassEntity> Subclasses { get; set; }
        public Feature<List<Feature<string, string>>, string>? Spellcasting { get; set; }
        public StartingEquipmentEntity StartingEquipment { get; set; }
    }

    public class SubclassEntity
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public List<string> Desc { get; set; }
        public List<LevelEntity> Features { get; set; }
        public List<SpellsDto> Spells { get; set; }
    }
    /// <summary>
    /// Level Entity
    /// </summary>
    public class LevelEntity
    {
        public Info<string> Info { get; set; } = new Info<string>();
        public List<Feature<object, string>> Features { get; set; } = new List<Feature<object, string>>();
        public Dictionary<string, string> ClassSpecific { get; set; } = new Dictionary<string, string>();
        public int AbilityScoreBonus { get; set; }
        public int ProfBonus { get; set; }
        public Dictionary<string, int> Spellcasting { get; set; } = new Dictionary<string, int>();
    }
    
    public class ChoiceDesc {
        public EquipmentChoicesDto Choice { get; set; }
        public List<string> Desc { get; set; }
    }
}