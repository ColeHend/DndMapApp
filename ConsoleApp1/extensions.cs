
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
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;
    using ConsoleApp1.models.DTO;
    using DndRacesJson;
    using DndSubRaceJson;
    using DndRaceTraitJson;
    using DndProficencyJson;
    using DndBackgroundsJson;
    using DndLanguagesJson;
    using DndEquipmentCategoryJson;
    using DndFeatsJson;
    using SpellsDto;
    using DndSpellsJson;
    using SecondSpells5e;
    using SRDSpellsjson;

    public static class Extensions
    {
        private static void AddString(this Dictionary<string, string> dictionary, string key, object? value)
        {
            if (value != null)
            {
                string theValue = JsonConvert.SerializeObject(value);
                dictionary.Add(key, theValue);
            }
        }



        public static Item ToItemDto(The5EEquipment the5EEquipment, bool logs = false)
        {
            var getItemType = (The5EEquipment eqipment) =>
            {
                if (eqipment.WeaponCategory != null)
                {
                    return "Weapon";
                }
                else if (eqipment.ArmorCategory != null)
                {
                    return "Armor";
                }
                else
                {
                    return "Item";
                }
            };
            var getItem = (string type) =>
            {
                if (type == "Weapon")
                {
                    return new Weapon();
                }
                else if (type == "Armor")
                {
                    return new Armor();
                }
                else
                {
                    return new Item();
                }
            };
            var itemType = getItemType(the5EEquipment);
            var newItem = getItem(itemType);
            newItem.Name = the5EEquipment.Name;
            newItem.EquipmentCategory = the5EEquipment.EquipmentCategory.ToString();
            newItem.Cost = new ConsoleApp1.models.DTO.Cost
            {
                Quantity = (int)the5EEquipment.Cost.Quantity,
                Unit = the5EEquipment.Cost.Unit.ToString()
            };
            newItem.Weight = (int?)the5EEquipment.Weight;

            if (the5EEquipment.Properties != null && the5EEquipment.Properties.Count() > 0)
            {
                newItem.Tags = the5EEquipment.Properties.Select(x => x.Name).ToList();
            }

            if (the5EEquipment.Desc != null)
            {
                newItem.Desc = the5EEquipment.Desc;
            }

            if (itemType == "Weapon")
            {
                newItem = (Weapon)newItem;
                ((Weapon)newItem).WeaponCategory = the5EEquipment.WeaponCategory.ToString();
                ((Weapon)newItem).WeaponRange = the5EEquipment.WeaponRange.ToString();
                ((Weapon)newItem).CategoryRange = the5EEquipment.CategoryRange.ToString();
                ((Weapon)newItem).Damage = new List<ConsoleApp1.models.DTO.Damage>
                {
                    new ConsoleApp1.models.DTO.Damage
                    {
                        DamageDice = the5EEquipment.Damage.DamageDice,
                        DamageBonus = (int)the5EEquipment.Damage.DamageBonus,
                        DamageType = the5EEquipment.Damage.DamageType.Name.ToString()
                    }
                };
                ((Weapon)newItem).Range = new ConsoleApp1.models.DTO.Range
                {
                    Normal = (int)the5EEquipment.Range.Normal,
                    Long = (int)(the5EEquipment.Range.Long ?? 0)
                };
            }
            else if (itemType == "Armor")
            {
                newItem = (Armor)newItem;
                ((Armor)newItem).ArmorCategory = the5EEquipment.ArmorCategory.ToString();
                ((Armor)newItem).StealthDisadvantage = (bool)(the5EEquipment.StealthDisadvantage ?? false);
                ((Armor)newItem).StrMin = (int)(the5EEquipment.StrMinimum ?? 0);
                ((Armor)newItem).ArmorClass = new ConsoleApp1.models.DTO.ArmorClass
                {
                    Base = (int)the5EEquipment.ArmorClass.Base,
                    DexBonus = the5EEquipment.ArmorClass.DexBonus,
                    MaxBonus = (int?)the5EEquipment.ArmorClass.MaxBonus
                };
            }

            return newItem;
        }

        public static FeatEntity ToFeatDto(The5EFeats the5EFeats, bool logs = false)
        {
            var newFeat = new FeatEntity();
            newFeat.Name = the5EFeats.Name;
            newFeat.Desc = the5EFeats.Desc;
            newFeat.PreReqs = the5EFeats.Prerequisites.Select(x => new Feature<string, string>
            {
                Info = new Info<string>
                {
                    Type = "AbilityScore"
                },
                Name = x.AbilityScore.Name,
                Value = x.MinimumScore.ToString()
            }).ToList();
            return newFeat;
        }

        public static BackgroundEntity ToBackgroundDto(The5EBackgrounds the5EBackgrounds, List<The5EProficency> proficency, List<The5ELanguages> languages, List<The5EEquipment> equipment, bool logs = false)
        {
            var newBackground = new BackgroundEntity();
            newBackground.Name = the5EBackgrounds.Name;
            newBackground.StartingProficiencies = proficency
                .Where(x => the5EBackgrounds.StartingProficiencies.Select(y => y.Name).Contains(x.Name))
                .Select(x => new Feature<string, string>
                {
                    Name = x.Type.ToString(),
                    Value = x.Name
                })
                .ToList();
            newBackground.LanguageChoice = new ChoicesEntity<string>();
            newBackground.LanguageChoice.Choose = (int)the5EBackgrounds.LanguageOptions.Choose;
            newBackground.LanguageChoice.Type = the5EBackgrounds.LanguageOptions.Type.ToString();
            newBackground.LanguageChoice.Choices = languages.Select(x => x.Name).ToList();
            newBackground.StartingEquipment = the5EBackgrounds.StartingEquipment.Select(x => new ItemDto
            {
                Item = x.Equipment.Name,
                Quantity = (int)x.Quantity

            }).ToList();
            newBackground.StartingEquipmentChoices = the5EBackgrounds.StartingEquipmentOptions.Select(x => new EquipmentChoicesDto
            {
                Choose = (int)x.Choose,
                Type = x.Type.ToString(),
                Choices = new List<ItemDto>
                {
                    new ItemDto
                    {
                        Item = "Emblem",
                        Quantity = 1
                    },
                    new ItemDto
                    {
                        Item = "Reliquary",
                        Quantity = 1
                    },
                    new ItemDto
                    {
                        Item = "Amulet",
                        Quantity = 1
                    }
                }
            }).ToList();
            newBackground.Feature = new List<Feature<List<string>, string>>
            {
                new Feature<List<string>, string>
                {
                    Name = the5EBackgrounds.Feature.Name,
                    Value = the5EBackgrounds.Feature.Desc
                }
            };
            return newBackground;
        }

        public static RaceEntity ToRaceDto(The5ERaces the5ERaces, List<The5ESubRace> subRaces, List<The5ERaceTrait> raceTraits, List<The5EProficency> proficency, bool logs = false)
        {
            // ------------ creation data ------------------------
            var newRace = new RaceEntity();
            // 
            if (logs) Console.WriteLine(" Writing Basics!");
            newRace.Id = (int)the5ERaces.Id;
            newRace.Name = the5ERaces.Name;
            newRace.Speed = the5ERaces.Speed.ToString();
            newRace.AbilityBonuses = the5ERaces.AbilityBonuses.Select(x => new Feature<int, string>
            {
                Name = x.Name,
                Value = (int)x.Bonus
            }).ToList();
            if (the5ERaces.AbilityBonusOptions != null)
            {
                newRace.AbilityBonusChoice = new ChoicesEntity<Feature<int, string>>();
                newRace.AbilityBonusChoice.Choose = (int)(the5ERaces.AbilityBonusOptions.Choose ?? 0);
                newRace.AbilityBonusChoice.Type = the5ERaces.AbilityBonusOptions.Type != null ? the5ERaces.AbilityBonusOptions.Type.ToString() : string.Empty;
                newRace.AbilityBonusChoice.Choices = the5ERaces.AbilityBonusOptions.From?
                    .Select(x => new Feature<int, string>
                    {
                        Name = x.Name,
                        Value = (int)x.Bonus
                    })
                    .ToList() ?? new List<Feature<int, string>>();
            }
            newRace.Alignment = the5ERaces.Alignment;
            newRace.Age = the5ERaces.Age;
            newRace.Size = the5ERaces.Size;
            newRace.SizeDescription = the5ERaces.SizeDescription;
            newRace.StartingProficencies = proficency
                .Where(x => the5ERaces.StartingProficiencies.Select(y => y.Name).Contains(x.Name))
                .Select(x => new Feature<string, string>
                {
                    Name = x.Type.ToString(),
                    Value = x.Name
                })
                .ToList();
            if (the5ERaces.StartingProficiencyOptions != null)
            {
                newRace.StartingProficenciesChoice = new ChoicesEntity<Feature<string, string>>();
                newRace.StartingProficenciesChoice.Choose = (int)(the5ERaces.StartingProficiencyOptions.Choose ?? 0);
                newRace.StartingProficenciesChoice.Type = the5ERaces.StartingProficiencyOptions.Type != null ? the5ERaces.StartingProficiencyOptions.Type.ToString() : string.Empty;
                newRace.StartingProficenciesChoice.Choices = proficency
                    .Where(x => the5ERaces.StartingProficiencyOptions.From?.Select(y => y.Name).Contains(x.Name) ?? false)
                    .Select(x => new Feature<string, string>
                    {
                        Name = x.Name,
                        Value = x.Type.ToString()
                    })
                    .ToList();
            }
            newRace.Languages = the5ERaces.Languages.Select(x => x.Name).ToList();
            if (the5ERaces.LanguageOptions != null)
            {
                newRace.LanguageChoice = new ChoicesEntity<string>();
                newRace.LanguageChoice.Choose = (int)(the5ERaces.LanguageOptions.Choose ?? 0);
                newRace.LanguageChoice.Type = the5ERaces.LanguageOptions.Type != null ? the5ERaces.LanguageOptions.Type.ToString() : string.Empty;
                newRace.LanguageChoice.Choices = the5ERaces.LanguageOptions.From?.Select(x => x.Name).ToList() ?? new List<string>();
            }
            newRace.LanguageDesc = the5ERaces.LanguageDesc;
            newRace.Traits = raceTraits
                .Where(x => the5ERaces.Traits.Select(y => y.Name).Contains(x.Name))
                .Select(x => new Feature<List<string>, string>
                {
                    Name = x.Name,
                    Value = x.Desc
                })
                .ToList();
            if (the5ERaces.TraitOptions != null)
            {
                newRace.TraitChoice = new ChoicesEntity<Feature<List<string>, string>>();
                newRace.TraitChoice.Choose = (int)(the5ERaces.TraitOptions.Choose ?? 0);
                newRace.TraitChoice.Type = the5ERaces.TraitOptions.Type != null ? the5ERaces.TraitOptions.Type.ToString() : string.Empty;
                newRace.TraitChoice.Choices = raceTraits
                    .Where(x => the5ERaces.TraitOptions.From?.Select(y => y.Name).Contains(x.Name) ?? false)
                    .Select(x => new Feature<List<string>, string>
                    {
                        Name = x.Name,
                        Value = x.Desc
                    })
                    .ToList();
            }
            if (subRaces.Count() > 0)
            {
                if (logs) Console.WriteLine(" Writing Subraces!");
                newRace.SubRaces = subRaces.Select(subRace =>
                {
                    var newSubRace = new SubRaceEntity();
                    newSubRace.Id = (int)subRace.Id;
                    newSubRace.Name = subRace.Name;
                    newSubRace.Desc = subRace.Desc;
                    newSubRace.AbilityBonuses = subRace.AbilityBonuses.Select(x => new Feature<int, string>
                    {
                        Name = x.Name,
                        Value = (int)x.Bonus
                    }).ToList();
                    if (subRace.AbilityBonusOptions != null)
                    {
                        newSubRace.AbilityBonusChoice = new ChoicesEntity<Feature<int, string>>();
                        newSubRace.AbilityBonusChoice.Choose = (int)subRace.AbilityBonusOptions.Choose;
                        newSubRace.AbilityBonusChoice.Type = subRace.AbilityBonusOptions.Type != null ? subRace.AbilityBonusOptions.Type.ToString() : string.Empty;
                        newSubRace.AbilityBonusChoice.Choices = subRace.AbilityBonusOptions.From?
                            .Select(x => new Feature<int, string>
                            {
                                Name = x.Name,
                                Value = (int)x.Bonus
                            })
                            .ToList() ?? new List<Feature<int, string>>();
                    }
                    else
                    {
                        newSubRace.AbilityBonusChoice = null;
                    }
                    newSubRace.Alignment = subRace.Alignment;
                    newSubRace.Age = subRace.Age;
                    newSubRace.Size = subRace.Size;
                    newSubRace.SizeDescription = subRace.SizeDescription;
                    newSubRace.StartingProficencies = proficency
                        .Where(x => subRace.StartingProficiencies.Select(y => y.Name).Contains(x.Name))
                        .Select(x => new Feature<string, string>
                        {
                            Name = x.Type.ToString(),
                            Value = x.Name
                        })
                        .ToList();
                    if (subRace.StartingProficiencyOptions != null)
                    {
                        newSubRace.StartingProficenciesChoice = new ChoicesEntity<Feature<string, string>>();
                        newSubRace.StartingProficenciesChoice.Choose = (int)subRace.StartingProficiencyOptions.Choose;
                        newSubRace.StartingProficenciesChoice.Type = subRace.StartingProficiencyOptions.Type != null ? subRace.StartingProficiencyOptions.Type.ToString() : string.Empty;
                        newSubRace.StartingProficenciesChoice.Choices = proficency
                            .Where(x => subRace.StartingProficiencyOptions.From?.Select(y => y.Name).Contains(x.Name) ?? false)
                            .Select(x => new Feature<string, string>
                            {
                                Name = x.Name,
                                Value = x.Type.ToString()
                            })
                            .ToList();
                    }
                    else
                    {
                        newSubRace.StartingProficenciesChoice = null;
                    }
                    newSubRace.Languages = subRace.Languages.Select(x => x.Name).ToList();
                    if (subRace.LanguageOptions != null)
                    {
                        newSubRace.LanguageChoice = new ChoicesEntity<string>();
                        newSubRace.LanguageChoice.Choose = (int)(subRace.LanguageOptions.Choose ?? 0);
                        newSubRace.LanguageChoice.Type = subRace.LanguageOptions.Type != null ? subRace.LanguageOptions.Type.ToString() : string.Empty;
                        newSubRace.LanguageChoice.Choices = subRace.LanguageOptions.From?.Select(x => x.Name).ToList() ?? new List<string>();
                    }
                    else
                    {
                        newSubRace.LanguageChoice = null;
                    }
                    newSubRace.Traits = raceTraits
                        .Where(x => subRace.RacialTraits.Select(y => y.Name).Contains(x.Name))
                        .Select(x => new Feature<List<string>, string>
                        {
                            Name = x.Name,
                            Value = x.Desc
                        })
                        .ToList();

                    if (subRace.RacialTraitOptions != null)
                    {
                        newSubRace.TraitChoice = new ChoicesEntity<Feature<List<string>, string>>();
                        newSubRace.TraitChoice.Choose = (int)(subRace.RacialTraitOptions.Choose ?? 0);
                        newSubRace.TraitChoice.Type = subRace.RacialTraitOptions.Type != null ? subRace.RacialTraitOptions.Type.ToString() : string.Empty;
                        newSubRace.TraitChoice.Choices = raceTraits
                            .Where(x => subRace.RacialTraitOptions.From?.Select(y => y.Name).Contains(x.Name) ?? false)
                            .Select(x => new Feature<List<string>, string>
                            {
                                Name = x.Name,
                                Value = x.Desc
                            })
                            .ToList();
                    }
                    else
                    {
                        newSubRace.TraitChoice = null;
                    }
                    return newSubRace;
                }).ToList();
            }
            else
            {
                newRace.SubRaces = new List<SubRaceEntity>();
            }

            return newRace;
        }

        public static ClassDto ToClassDto(The5EClasses the5EClasses, List<The5EClassLevels> classLevels, List<The5ESubClasses> subClasses, List<The5EFeatures> features, List<The5EStartingEquipment> startingEquipment, List<The5EEquipment> equipment, List<The5ESpellcasting> spellCasting, bool logs = false)
        {
            // ------------ creation data ------------------------
            classLevels = classLevels.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            features = features.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            subClasses = subClasses.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            spellCasting = spellCasting.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            startingEquipment = startingEquipment.Where(x => x.Class.Name == the5EClasses.Name).ToList();
            var equipmentStart = startingEquipment.FirstOrDefault() ?? new The5EStartingEquipment();
            The5ESpellcasting theCastingDesc = spellCasting.Count == 0 ? new The5ESpellcasting() : spellCasting.First();

            var levelFeatures = features.Select(x => features.Where(y => y.Level == x.Level).First()).ToList();
            if (logs) Console.WriteLine($"Writing {the5EClasses.Name}!!");
            // --------- Class making --------------------------
            var newClass = new ClassDto();
            if (logs) Console.WriteLine(" Writing Basics!");
            newClass.Id = (int)the5EClasses.Id;
            newClass.Name = the5EClasses.Name;
            newClass.HitDie = (int)the5EClasses.HitDie;
            if (logs) Console.WriteLine(" Writing Proficiencies!");
            newClass.Proficiencies = the5EClasses.Proficiencies.Select(x => x.Name).ToList();
            newClass.ProficiencyChoices = the5EClasses.ProficiencyChoices.Select(x => new ChoicesEntity<string>
            {
                Choose = (int)x.Choose,
                Type = x.Type.ToString(),
                Choices = x.From.Select(y => y.Name).ToList()
            }).ToList();
            if (logs) Console.WriteLine(" Writing Saves!");
            newClass.SavingThrows = the5EClasses.SavingThrows.Select(x => x.Name).ToList();
            if (logs) Console.WriteLine(" Writing Levels!");

            if (logs) Console.WriteLine($"   Writing Subclasses!");
            newClass.Subclasses = subClasses.Select(subClass =>
            {
                var newSubClass = new SubclassDto();
                newSubClass.Name = subClass.Name;
                newSubClass.SubclassFlavor = subClass.SubclassFlavor;
                newSubClass.Desc = subClass.Desc;
                newSubClass.Class = subClass.Class.Name;
                newSubClass.Desc = subClass.Desc;
                newSubClass.Features = features.Where(x => x.Subclass.Name == subClass.Name).Select(x =>
                {
                    var newFeature = new Feature<object, string>();
                    newFeature.Name = x.Name;
                    newFeature.Info = new Info<string>();
                    newFeature.Info.ClassName = x.Class.Name;
                    newFeature.Info.SubclassName = x.Subclass.Name;
                    newFeature.Info.Level = (int)(x.Level ?? 0);
                    if (x.Choice != null)
                    {
                        var newChoice = new EquipmentChoicesDto();
                        newChoice.Choose = (int)x.Choice.Choose;
                        newChoice.Type = x.Choice.Type.ToString();
                        newChoice.Choices = x.Choice.From.Select(y => new ItemDto
                        {
                            Item = y.Name,
                            Desc = features.Where(z => z.Name == y.Name).First().Desc
                        }).ToList();
                        newFeature.Value = new ChoiceDesc
                        {
                            Choice = newChoice,
                            Desc = x.Desc
                        };
                    }
                    else
                    {
                        newFeature.Value = x.Desc;
                    }

                    return newFeature;
                }).ToList();

                return newSubClass;
            }).ToList();

            newClass.ClassLevels = classLevels.Select(classLevel =>
                {
                    LevelEntity levelEntity = new LevelEntity();
                    int currentLevel = (int)classLevel.Level;
                    if (logs) Console.WriteLine($"  Level {currentLevel} Entity Created!");
                    levelEntity.Info.Level = currentLevel;
                    if (logs) Console.WriteLine("    Level");
                    levelEntity.AbilityScoreBonus = (int)(classLevel.AbilityScoreBonuses ?? 0);
                    if (logs) Console.WriteLine("    AbilityScoreBonus");
                    levelEntity.ProfBonus = (int)(classLevel.ProfBonus ?? 0);
                    if (logs) Console.WriteLine("    ProfBonus");
                    // classLevel.FeatureChoices = x.Features.Select(y => y.Name).ToList();
                    if (logs) Console.WriteLine("    Writing Features!");
                    var currLevel = levelFeatures.Count() > 0 ? levelFeatures.DistinctBy(x => x.Name).Select(x =>
                    {
                        if (x != null) return x;
                        return new The5EFeatures();
                    }).ToList() : new List<The5EFeatures>();
                    if (logs) Console.WriteLine($"     {currLevel.Where(x => x.Level == currentLevel).Count()} features to add!");
                    levelEntity.Features = currLevel.Where(x => x.Level == currentLevel).Select(feature =>
                    {
                        var newFeature = new Feature<object, string>();
                        if (logs) Console.WriteLine($"     Adding Feature {feature.Name}");
                        newFeature.Name = feature.Name;
                        newFeature.Info = new Info<string>();
                        newFeature.Info.ClassName = classLevel.Class.Name;
                        newFeature.Info.SubclassName = classLevel.Subclass.Name;
                        newFeature.Value = features.Where(x => x.Name == feature.Name).Select(x => new BaseDesc { Name = x.Name, Desc = x.Desc }).ToList().First();

                        return newFeature;
                    }).ToList();
                    //var levelClassSpecific = new Feature<object, string>();
                    ClassSpecific classSpecific = classLevel.ClassSpecific ?? new ClassSpecific();
                    if (logs) Console.WriteLine("    Writing Class Specific!");
                    var levelClassSpecific = new Dictionary<string, string>();
                    levelClassSpecific.AddString("ActionSurges", classSpecific.ActionSurges);
                    levelClassSpecific.AddString("ArcaneRecoveryLevels", classSpecific.ArcaneRecoveryLevels);
                    levelClassSpecific.AddString("AdditionalMagicalSecretsMaxLvl", classSpecific?.MagicalSecretsMax5);
                    levelClassSpecific.AddString("RageDamageBonus", classSpecific?.RageDamageBonus);
                    levelClassSpecific.AddString("RageCount", classSpecific?.RageCount);
                    levelClassSpecific.AddString("AuraRange", classSpecific?.AuraRange);
                    levelClassSpecific.AddString("BardicInspirationDie", classSpecific?.BardicInspirationDie);
                    levelClassSpecific.AddString("BrutalCriticalDice", classSpecific?.BrutalCriticalDice);
                    levelClassSpecific.AddString("ChannelDivinityCharges", classSpecific?.ChannelDivinityCharges);
                    levelClassSpecific.AddString("CreatingSpellSlots", classSpecific?.CreatingSpellSlots != null ? JsonConvert.SerializeObject(classSpecific?.CreatingSpellSlots.Select(y => new CreatingSpellSlotDto
                    {
                        SpellSlotLevel = (int)y.SpellSlotLevel,
                        SorceryPointCost = (int)y.SorceryPointCost
                    }).ToList()) : null);
                    levelClassSpecific.AddString("WildShapeMaxCr", classSpecific?.WildShapeMaxCr);
                    levelClassSpecific.AddString("MartialArts", classSpecific?.MartialArts?.DiceValue != null ? JsonConvert.SerializeObject(new MartialArtsDto
                    {
                        DiceValue = (int)(classSpecific?.MartialArts.DiceValue ?? 0),
                        DiceCount = (int)(classSpecific?.MartialArts.DiceCount ?? 0)
                    }) : null);
                    levelClassSpecific.AddString("SneakAttack", classSpecific?.SneakAttack?.DiceValue != null ? JsonConvert.SerializeObject(new MartialArtsDto
                    {
                        DiceValue = (int)(classSpecific?.SneakAttack.DiceValue ?? 0),
                        DiceCount = (int)(classSpecific?.SneakAttack.DiceCount ?? 0)
                    }) : null);
                    levelClassSpecific.AddString("DestroyUndeadCr", classSpecific?.DestroyUndeadCr);
                    levelClassSpecific.AddString("ExtraAttacks", classSpecific?.ExtraAttacks);
                    levelClassSpecific.AddString("FavoredEnemies", classSpecific?.FavoredEnemies);
                    levelClassSpecific.AddString("FavoredTerrain", classSpecific?.FavoredTerrain);
                    levelClassSpecific.AddString("IndomitableUses", classSpecific?.IndomitableUses);
                    levelClassSpecific.AddString("InvocationsKnown", classSpecific?.InvocationsKnown);
                    levelClassSpecific.AddString("MetamagicKnown", classSpecific?.MetamagicKnown);
                    levelClassSpecific.AddString("MysticArcanumLevel6", classSpecific?.MysticArcanumLevel6);
                    levelClassSpecific.AddString("MagicalSecretsMax5", classSpecific?.MagicalSecretsMax5);
                    levelClassSpecific.AddString("MagicalSecretsMax7", classSpecific?.MagicalSecretsMax7);
                    levelClassSpecific.AddString("MagicalSecretsMax9", classSpecific?.MagicalSecretsMax9);
                    levelClassSpecific.AddString("MysticArcanumLevel7", classSpecific?.MysticArcanumLevel7);
                    levelClassSpecific.AddString("MysticArcanumLevel8", classSpecific?.MysticArcanumLevel8);
                    levelClassSpecific.AddString("MysticArcanumLevel9", classSpecific?.MysticArcanumLevel9);
                    levelClassSpecific.AddString("SongOfRestDie", classSpecific?.SongOfRestDie);
                    levelClassSpecific.AddString("SorceryPoints", classSpecific?.SorceryPoints);
                    levelClassSpecific.AddString("UnarmoredMovement", classSpecific?.UnarmoredMovement);
                    levelClassSpecific.AddString("WildShapeFly", classSpecific?.WildShapeFly);
                    levelClassSpecific.AddString("WildShapeSwim", classSpecific?.WildShapeSwim);

                    levelEntity.ClassSpecific = levelClassSpecific;
                    levelEntity.Info.ClassName = classLevel.Class.Name;
                    levelEntity.Info.SubclassName = classLevel.Subclass?.Name ?? string.Empty;
                    if (logs) Console.WriteLine("    Writing Casting?");
                    levelEntity.Spellcasting = classLevel?.Spellcasting?.ToDictionary(y => y.Key, y => (int)y.Value) ?? new Dictionary<string, int>();
                    return levelEntity;
                }).ToList();
            if (logs) Console.WriteLine("  Writing Equipment!");
            newClass.StartingEquipment = new StartingEquipmentDto
            {
                Class = equipmentStart.Class.Name ?? the5EClasses.Name,
                Choice1 = equipmentStart.Choice1.Select(y => new EquipmentChoicesDto
                {
                    Choose = y?.Choose != null ? (int)y.Choose : 0,
                    Type = y?.Type != null ? y.Type.ToString() : "null",
                    Choices = y?.From != null ? y.From.Select(z => new ItemDto
                    {
                        Item = z.Item.Name,
                        Quantity = 0 // Set the quantity to 0 or assign the correct value
                    }).ToList() : new List<ItemDto>()
                }).ToList(),
                Choice2 = equipmentStart.Choice2.Select(y => new EquipmentChoicesDto
                {
                    Choose = y?.Choose != null ? (int)y.Choose : 0,
                    Type = y?.Type != null ? y.Type.ToString() : "null",
                    Choices = y?.From != null ? y.From.Select(z => new ItemDto
                    {
                        Item = z.Item.Name,
                        Quantity = 0
                    }).ToList() : new List<ItemDto>()
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

            };

            return newClass;
        }

        public static SpellDto ToSpellDto(SpellsTwo5E spellsTwo5E, List<The5ESpells> the5ESpells, List<The5ESrdSpellsJson> the5ESrdSpellsJson, bool logs = false)
        {
            var newSpell = new SpellDto();
            var spell2 = the5ESpells.Where(x => x.Name == spellsTwo5E.Name).FirstOrDefault();
            var spell3 = the5ESrdSpellsJson.Where(x => x.Name == spellsTwo5E.Name).FirstOrDefault();
            if (spell2 != null && spell3 != null)
            {
                if (logs) Console.WriteLine(" Writing Spells!");
                if (spellsTwo5E != null)
                {
                    if(spellsTwo5E.Components.Material == true)
                    {
                        newSpell.Name = spellsTwo5E.Name;
                        newSpell.Desc = spellsTwo5E.Description;
                        newSpell.Duration = spellsTwo5E.Duration;
                        newSpell.Range = spellsTwo5E.Range;
                        newSpell.Ritual = spellsTwo5E.Ritual;
                        newSpell.School = spellsTwo5E.School.ToString();
                        newSpell.CastingTime = spellsTwo5E.CastingTime;
                        newSpell.IsMaterial = spellsTwo5E.Components.Material;
                        newSpell.IsSomatic = spellsTwo5E.Components.Somatic;
                        newSpell.IsVerbal = spellsTwo5E.Components.Verbal;
                        newSpell.Materials_Needed = spellsTwo5E.Components.MaterialsNeeded != null ? String.Join(", ", spellsTwo5E.Components.MaterialsNeeded): null;
                    } 
                    if (spellsTwo5E.HigherLevels != null) {
                    newSpell.Name = spellsTwo5E.Name;
                        newSpell.Desc = spellsTwo5E.Description;
                        newSpell.Duration = spellsTwo5E.Duration;
                        newSpell.Range = spellsTwo5E.Range;
                        newSpell.Ritual = spellsTwo5E.Ritual;
                        newSpell.School = spellsTwo5E.School.ToString();
                        newSpell.CastingTime = spellsTwo5E.CastingTime;
                        newSpell.IsMaterial = spellsTwo5E.Components.Material;
                        newSpell.IsSomatic = spellsTwo5E.Components.Somatic;
                        newSpell.IsVerbal = spellsTwo5E.Components.Verbal;
                        newSpell.HigherLevel = spellsTwo5E.HigherLevels; 
                    } else {
                        newSpell.Name = spellsTwo5E.Name;
                        newSpell.Desc = spellsTwo5E.Description;
                        newSpell.Duration = spellsTwo5E.Duration;
                        newSpell.Range = spellsTwo5E.Range;
                        newSpell.Ritual = spellsTwo5E.Ritual;
                        newSpell.School = spellsTwo5E.School.ToString();
                        newSpell.CastingTime = spellsTwo5E.CastingTime;
                        newSpell.IsMaterial = spellsTwo5E.Components.Material;
                        newSpell.IsSomatic = spellsTwo5E.Components.Somatic;
                        newSpell.IsVerbal = spellsTwo5E.Components.Verbal;
                    }
                    
                } else {
                    Console.WriteLine($"Could not find the spellsTwo5E Json! for {spellsTwo5E.Name}");
                }
                if (spell2 != null)
                {
                    newSpell.Concentration = spell2.Concentration;
                    newSpell.Page = spell2.Page;
                    newSpell.Classes = spell2.Classes.Select(x => x.Name.ToString()).ToList();
                    newSpell.SubClasses = spell2.Subclasses.Select(x => x.Name.ToString()).ToList();
                    newSpell.Level = spell2.Level.ToString();
                } else {
                    Console.WriteLine($"Could not find the The5ESpells Json! for {spellsTwo5E.Name}");
                }
                if (spell3 != null)
                {
                    if(spell3.Damage != null && spell3.Damage.DamageType != null){
                        newSpell.DamageType = spell3.Damage.DamageType.Name;
                    } else {
                        if(logs) Console.WriteLine($"Could not find the the5ESrdSpellsJson Json! for {spellsTwo5E.Name} "); 
                        
                    }
                } else {
                    if(logs) Console.WriteLine($"Could not find the the5ESrdSpellsJson Json! for {spellsTwo5E.Name} "); 
                }   
            } else {
                if (logs) Console.WriteLine($"Could not find the {spellsTwo5E.Name} in the json files!");
            }

            return newSpell;
        }

    }
}