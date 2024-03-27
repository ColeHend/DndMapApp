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
using MyExtensions;
using ClassesDto;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;



void Main()
{
    var readSrd = new ReadSrd();
    // Dto && Models Created
    Console.WriteLine("Reading Files!");
    List<The5EClasses> classes = readSrd.readClassesJson();
    List<The5EClassLevels> classLevels = readSrd.readClassLevelsJson();
    List<The5ESubClasses> subClasses = readSrd.readSubClassesJson();
    List<The5EFeatures> features = readSrd.readFeaturesJson();
    List<The5EStartingEquipment> startingEquipment = readSrd.readStartingEquipmentJson();
    List<The5EEquipment> equipment = readSrd.readEquipmentJson();
    List<The5ESpellcasting> spellCasting = readSrd.readSpellCastingJson();

    List<The5ESpells> spells = readSrd.readSpellsJson();
    // Dto to be created

    // List<The5EEquipmentCategory> equipmentCategories = readSrd.readEquipmentCategoryJson();
    // List<The5ESkills> skills = readSrd.readSkillsJson();
    // List<The5EAbilityScore> abilityScores = readSrd.readAbilityScoreJson();
    // List<The5EConditions> conditions = readSrd.readConditionsJson();
    // List<The5EDamageType> damageTypes = readSrd.readDamageTypesJson();
    // List<The5ELanguages> languages = readSrd.readLanguagesJson();
    // List<The5EMagicSchool> magicSchools = readSrd.readMagicSchoolsJson();
    // List<The5EMonsters> monsters = readSrd.readMonstersJson();
    // List<The5ERaceTrait> raceTraits = readSrd.readRaceTraitsJson();
    // List<The5ERaces> races = readSrd.readRacesJson();
    // List<The5ESubRace> subRaces = readSrd.readSubRacesJson();
    Console.WriteLine("Creating DTOs!");
    var theClasses = classes.Select(theClass => Extensions.ToClassDto(theClass, classLevels, subClasses, features, startingEquipment, equipment, spellCasting));

    Console.WriteLine("Writing Files!");
    readSrd.WriteJson("classes", theClasses);
    
}

Main();

