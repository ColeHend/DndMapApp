
namespace MyExtensions
{
    using DndClassJson;
    using DndClassLevelsJson;
    using DndEquipmentJson;
    using DndFeatureJson;
    using DndSpellCastingJson;
    using DndStartingEquipmentJson;
    using DndSubClassJson;
    using ClassesDto;
    using System.Linq;

    public static class Extensions
    {
        public static ClassDto ToClassDto(The5EClasses the5EClasses, List<The5EClassLevels> classLevels, List<The5ESubClasses> subClasses, List<The5EFeatures> features, List<The5EStartingEquipment> startingEquipment, List<The5EEquipment> equipment, List<The5ESpellcasting> spellCasting)
        {
            classLevels = classLevels.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            features = features.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            subClasses = subClasses.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            spellCasting = spellCasting.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            startingEquipment = startingEquipment.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            var equipmentStart = startingEquipment.FirstOrDefault() ?? new The5EStartingEquipment();
            The5ESpellcasting theCastingDesc;
            if (spellCasting.Count == 0)
            {
                theCastingDesc = new The5ESpellcasting();
            } else
            {
                theCastingDesc = spellCasting.First();
            };
            return new ClassDto
            {
                Id = (int)the5EClasses.Id,
                Name = the5EClasses.Name,
                HitDie = (int)the5EClasses.HitDie,
                ProficiencyChoices = the5EClasses.ProficiencyChoices.Select(x => new ChoicesDto
                {
                    Choose = (int)x.Choose,
                    Type = x.Type.ToString(),
                    Choices = x.From.Select(y => y.Name).ToList()
                }).ToList(),
                Proficiencies = the5EClasses.Proficiencies.Select(x => x.Name).ToList(),
                SavingThrows = the5EClasses.SavingThrows.Select(x => x.Name).ToList(),
                ClassLevels = classLevels.Select(x => {
                    var classLevel = new ClassLevelsDto();
                    classLevel.Level = (int)x.Level;
                    classLevel.AbilityScoreBonus = (int)(x.AbilityScoreBonuses ?? 0);
                    classLevel.ProfBonus = (int)(x.ProfBonus ?? 0);
                    classLevel.FeatureChoices = x.Features.Select(y => y.Name).ToList();
                    classLevel.Features = x.Features.Select(y => features.Where(z => z.Name == y.Name).FirstOrDefault()).Select(y => new FeatureDto
                    {
                        Class = y?.Class?.Name ?? the5EClasses.Name,
                        Subclass = y?.Subclass?.Name,
                        Name = y?.Name ?? "null",
                        Desc = y?.Desc?.ToArray() ?? new string[] { "" },
                        Choice = new ChoicesDto
                        {
                            Choose = (int)(y?.Choice?.Choose ?? 0),
                            Type = y?.Choice?.Type.ToString() ?? "null",
                            Choices = y?.Choice?.From.Select(z => z.Name).ToList() ?? new List<string>()
                        }
                    }).ToList();
                    var levelClassSpecific = new ClassSpecificDto();
                    var classSpecific = x.ClassSpecific;
                    levelClassSpecific.ActionSurges = (int?)classSpecific?.ActionSurges;
                    levelClassSpecific.ArcaneRecoveryLevels = (int?)classSpecific?.ArcaneRecoveryLevels;
                    levelClassSpecific.AdditionalMagicalSecretsMaxLvl = (int?)x.SubclassSpecific?.AdditionalMagicalSecretsMaxLvl;
                    levelClassSpecific.RageDamageBonus = (int?)classSpecific?.RageDamageBonus;
                    levelClassSpecific.RageCount = (int?)classSpecific?.RageCount;
                    levelClassSpecific.AuraRange = (int?)classSpecific?.AuraRange;
                    levelClassSpecific.BardicInspirationDie = (int?)classSpecific?.BardicInspirationDie;
                    levelClassSpecific.BrutalCriticalDice = (int?)classSpecific?.BrutalCriticalDice;
                    levelClassSpecific.ChannelDivinityCharges = (int?)classSpecific?.ChannelDivinityCharges;
                    levelClassSpecific.CreatingSpellSlots = classSpecific?.CreatingSpellSlots != null ? classSpecific?.CreatingSpellSlots.Select(y => new CreatingSpellSlotDto
                    {
                        SpellSlotLevel = (int)y.SpellSlotLevel,
                        SorceryPointCost = (int)y.SorceryPointCost
                    }).ToList() : null;
                    levelClassSpecific.WildShapeMaxCr = (int?)classSpecific?.WildShapeMaxCr;
                    levelClassSpecific.MartialArts = classSpecific?.MartialArts?.DiceValue != null ? new MartialArtsDto
                    {
                        DiceValue = (int)(classSpecific?.MartialArts.DiceValue ?? 0),
                        DiceCount = (int)(classSpecific?.MartialArts.DiceCount ?? 0)
                    } : null;
                    levelClassSpecific.SneakAttack = classSpecific?.SneakAttack?.DiceValue != null ? new MartialArtsDto
                    {
                        DiceValue = (int)(classSpecific?.SneakAttack.DiceValue ?? 0),
                        DiceCount = (int)(classSpecific?.SneakAttack.DiceCount ?? 0)
                    } : null;
                    levelClassSpecific.DestroyUndeadCr = (int?)classSpecific?.DestroyUndeadCr;
                    levelClassSpecific.ExtraAttacks = (int?)classSpecific?.ExtraAttacks;
                    levelClassSpecific.FavoredEnemies = (int?)classSpecific?.FavoredEnemies;
                    levelClassSpecific.FavoredTerrain = (int?)classSpecific?.FavoredTerrain;
                    levelClassSpecific.IndomitableUses = (int?)classSpecific?.IndomitableUses;
                    levelClassSpecific.InvocationsKnown = (int?)classSpecific?.InvocationsKnown;
                    levelClassSpecific.MetamagicKnown = (int?)classSpecific?.MetamagicKnown;
                    levelClassSpecific.MysticArcanumLevel6 = (int?)classSpecific?.MysticArcanumLevel6;
                    levelClassSpecific.MagicalSecretsMax5 = (int?)classSpecific?.MagicalSecretsMax5;
                    levelClassSpecific.MagicalSecretsMax7 = (int?)classSpecific?.MagicalSecretsMax7;
                    levelClassSpecific.MagicalSecretsMax9 = (int?)classSpecific?.MagicalSecretsMax9;
                    levelClassSpecific.MysticArcanumLevel7 = (int?)classSpecific?.MysticArcanumLevel7;
                    levelClassSpecific.MysticArcanumLevel8 = (int?)classSpecific?.MysticArcanumLevel8;
                    levelClassSpecific.MysticArcanumLevel9 = (int?)classSpecific?.MysticArcanumLevel9;
                    levelClassSpecific.SongOfRestDie = (int?)classSpecific?.SongOfRestDie;
                    levelClassSpecific.SorceryPoints = (int?)classSpecific?.SorceryPoints;
                    levelClassSpecific.UnarmoredMovement = (int?)classSpecific?.UnarmoredMovement;
                    levelClassSpecific.WildShapeFly = classSpecific?.WildShapeFly;
                    levelClassSpecific.WildShapeSwim = classSpecific?.WildShapeSwim;

                    classLevel.ClassSpecific = levelClassSpecific;
                    classLevel.Class = x.Class.Name;
                    classLevel.Subclass = x.Subclass?.Name ?? string.Empty;
                    classLevel.Spellcasting = x?.Spellcasting?.ToDictionary(y => y.Key, y => (int)y.Value) ?? new Dictionary<string, int>();
                    return classLevel;
                }).ToList(),
                Subclasses = subClasses.Select(x => new SubclassDto
                {
                    Name = x.Name,
                    Desc = x.Desc.ToList(),
                    Features = x.Features
                        .Select(y => y.Name)
                        .ToList()
                        .Select(y => features.Where(z => z.Name == y).FirstOrDefault())
                        .Select(y => new FeatureDto
                        {
                            Class = y?.Class?.Name ?? the5EClasses.Name,
                            Subclass = y?.Subclass?.Name,
                            Name = y?.Name ?? "null",
                            Desc = y?.Desc?.ToArray() ?? new string[] { "" },
                            Choice = new ChoicesDto
                            {
                                Choose = (int)(y?.Choice?.Choose ?? 0),
                                Type = y?.Choice?.Type.ToString() ?? "null",
                                Choices = y?.Choice?.From.Select(z => z.Name).ToList() ?? new List<string>()
                            }
                        }).ToList(),
                }).ToList(),
                Spellcasting = spellCasting.Count > 0 ? new SpellCastingDto
                {
                    Name = theCastingDesc?.Class?.Name ?? the5EClasses.Name,
                    Level = (int)(theCastingDesc?.Level ?? 0),
                    SpellcastingAbility = theCastingDesc?.SpellcastingAbility?.Name ?? string.Empty,
                    Info = theCastingDesc.Info?.Select(x => new InfoDto
                    {
                        Name = x?.Name ?? string.Empty,
                        Desc = x?.Desc?.ToList() ?? new List<string>()
                    }).ToList(),

                } : null,
                StartingEquipment = new StartingEquipmentDto
                {
                    Class = equipmentStart.Class.Name ?? the5EClasses.Name,
                    Choice1 = equipmentStart.Choice1.Select(y => new ChoicesDto
                    {
                        Choose = y?.Choose != null ? (int)y.Choose : 0,
                        Type = y?.Type != null ? y.Type.ToString() : "null",
                        Choices = y?.From != null ? y.From.Select(z => z.Item.Name).ToList() : new List<string>()
                    }).ToList(),
                    Choice2 = equipmentStart.Choice2.Select(y => new ChoicesDto
                    {
                        Choose = y?.Choose != null ? (int)y.Choose : 0,
                        Type = y?.Type != null ? y.Type.ToString() : "null",
                        Choices = y?.From != null ? y.From.Select(z => z.Item.Name).ToList() : new List<string>()
                    }).ToList(),
                    Choice3 = equipmentStart.Choice3 != null ? equipmentStart.Choice3.Select(y => new EquipmentChoicesDto
                    {
                        Choose = y?.Choose != null ? (int)y.Choose : 0,
                        Type = y?.Type != null ? y.Type.ToString() : "null",
                        Choices = y?.From != null ? y.From.Select(z => new ItemDto
                        {
                            Item = z.Item.Name,
                            Quantity = (int)z.Quantity,

                        }).ToList() : new List<ItemDto>()
                    }).ToList() : new List<EquipmentChoicesDto>(),
                    Choice4 = equipmentStart.Choice4 != null ? equipmentStart.Choice4.Select(y => new EquipmentChoicesDto
                    {
                        Choose = y?.Choose != null ? (int)y.Choose : 0,
                        Type = y?.Type != null ? y.Type.ToString() : "null",
                        Choices = y?.From != null ? y.From.Select(z => new ItemDto
                        {
                            Item = z.Item.Name,
                            Quantity = (int)z.Quantity,

                        }).ToList() : new List<ItemDto>()
                    }).ToList() : new List<EquipmentChoicesDto>(),
                    Choice5 = equipmentStart.Choice5 != null ? equipmentStart.Choice5.Select(y => new EquipmentChoicesDto
                    {
                        Choose = y?.Choose != null ? (int)y.Choose : 0,
                        Type = y?.Type != null ? y.Type.ToString() : "null",
                        Choices = y?.From != null ? y.From.Select(z => new ItemDto
                        {
                            Item = z.Item.Name,
                            Quantity = (int)z.Quantity,

                        }).ToList() : new List<ItemDto>()
                    }).ToList() : new List<EquipmentChoicesDto>(),

                }

            };
        }
    }
}