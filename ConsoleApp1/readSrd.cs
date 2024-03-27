using DndClassJson;
using DndSubClassJson;
using DndFeatureJson;
using DndClassLevelsJson;
using DndStartingEquipmentJson;
using DndEquipmentJson;
using DndSkillsJson;
using DndSpellsJson;
using DndAbilityScoreJson;
using DndConditionsJson;
using DndDamageTypesJson;
using DndEquipmentCategoryJson;
using DndLanguagesJson;
using DndRacesJson;
using DndMagicSchoolJson;
using DndMonstersJson;
using DndRaceTraitJson;
using DndSubRaceJson;
using DndSpellCastingJson;
using Newtonsoft.Json;

class ReadSrd
{
    public void WriteJson<T>(string fileName, T data)
    {
        using (var writer = new StreamWriter($"./srdFormat/{fileName}.json"))
        {
            Console.WriteLine($"Writing {fileName}.json");
            writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
            Console.WriteLine($"Finished Writing {fileName}.json");

        }
    }
    public List<The5EClasses> readClassesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/classes.json"))
        {
            string json = r.ReadToEnd();
            return The5EClasses.FromJson(json);
        }
    }

    public List<The5ESubClasses> readSubClassesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/subclasses.json"))
        {
            string json = r.ReadToEnd();
            return The5ESubClasses.FromJson(json);
        }
    }

    public List<The5EFeatures> readFeaturesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/features.json"))
        {
            string json = r.ReadToEnd();
            return The5EFeatures.FromJson(json);
        }
    }

    public List<The5EClassLevels> readClassLevelsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/levels.json"))
        {
            string json = r.ReadToEnd();
            return The5EClassLevels.FromJson(json);
        }
    }

    public List<The5EStartingEquipment> readStartingEquipmentJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/startingEquipment.json"))
        {
            string json = r.ReadToEnd();
            return The5EStartingEquipment.FromJson(json);
        }
    }

    public List<The5EEquipment> readEquipmentJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/equipment.json"))
        {
            string json = r.ReadToEnd();
            return The5EEquipment.FromJson(json);
        }
    }

    public List<The5ESkills> readSkillsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/skills.json"))
        {
            string json = r.ReadToEnd();
            return The5ESkills.FromJson(json);
        }
    }

    public List<The5ESpells> readSpellsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/spells.json"))
        {
            string json = r.ReadToEnd();
            return The5ESpells.FromJson(json);
        }
    }

    public List<The5EAbilityScore> readAbilityScoreJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/abilityScores.json"))
        {
            string json = r.ReadToEnd();
            return The5EAbilityScore.FromJson(json);
        }
    }

    public List<The5EConditions> readConditionsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/conditions.json"))
        {
            string json = r.ReadToEnd();
            return The5EConditions.FromJson(json);
        }
    }

    public List<The5EDamageType> readDamageTypesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/damageTypes.json"))
        {
            string json = r.ReadToEnd();
            return The5EDamageType.FromJson(json);
        }
    }

    public List<The5EEquipmentCategory> readEquipmentCategoryJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/equipmentCategories.json"))
        {
            string json = r.ReadToEnd();
            return The5EEquipmentCategory.FromJson(json);
        }
    }

    public List<The5ELanguages> readLanguagesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/languages.json"))
        {
            string json = r.ReadToEnd();
            return The5ELanguages.FromJson(json);
        }
    }

    public List<The5ERaces> readRacesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/races.json"))
        {
            string json = r.ReadToEnd();
            return The5ERaces.FromJson(json);
        }
    }

    public List<The5EMagicSchool> readMagicSchoolsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/magicSchools.json"))
        {
            string json = r.ReadToEnd();
            return The5EMagicSchool.FromJson(json);
        }
    }

    public List<The5EMonsters> readMonstersJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/monsters.json"))
        {
            string json = r.ReadToEnd();
            return The5EMonsters.FromJson(json);
        }
    }

    public List<The5ERaceTrait> readRaceTraitsJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/raceTraits.json"))
        {
            string json = r.ReadToEnd();
            return The5ERaceTrait.FromJson(json);
        }
    }

    public List<The5ESubRace> readSubRacesJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/subraces.json"))
        {
            string json = r.ReadToEnd();
            return The5ESubRace.FromJson(json);
        }
    }

    public List<The5ESpellcasting> readSpellCastingJson()
    {
        using (StreamReader r = new StreamReader("./srdJson/spellcasting.json"))
        {
            string json = r.ReadToEnd();
            return The5ESpellcasting.FromJson(json);
        }
    }
}