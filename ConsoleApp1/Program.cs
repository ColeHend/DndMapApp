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
using DndProficencyJson;
using DndBackgroundsJson;
using DndFeatsJson;
using SecondSpells5e;
using SRDSpellsjson;



void Main()
{
    var readSrd = new ReadSrd();
    // Dto && Models Created
    Console.WriteLine("Reading Files!");
    // ------- Equipment --------
    List<The5EEquipment> equipment = readSrd.readEquipmentJson();
    var the5EEquipment = equipment.Select(equip => Extensions.ToItemDto(equip));

    readSrd.WriteJson("equipment", the5EEquipment);

    // --------- Classes ------------
    List<The5EClasses> classes = readSrd.readClassesJson();
    List<The5EClassLevels> classLevels = readSrd.readClassLevelsJson();
    List<The5ESubClasses> subClasses = readSrd.readSubClassesJson();
    List<The5EFeatures> features = readSrd.readFeaturesJson();
    List<The5EStartingEquipment> startingEquipment = readSrd.readStartingEquipmentJson();
    List<The5ESpellcasting> spellCasting = readSrd.readSpellCastingJson();
    Console.WriteLine("Writing Files!");
    var theClasses = classes.Select(theClass => Extensions.ToClassDto(theClass, classLevels, subClasses, features, startingEquipment, equipment, spellCasting));

    readSrd.WriteJson("classes", theClasses);
    // -------------------------------
    List<The5EProficency> proficencies = readSrd.readProficencyJson();
    // --------- Races -------------
    List<The5ERaceTrait> raceTraits = readSrd.readRaceTraitsJson();
    List<The5ERaces> races = readSrd.readRacesJson();
    List<The5ESubRace> subRaces = readSrd.readSubRacesJson();
    var theRaces = races.Select(theRace => Extensions.ToRaceDto(theRace, subRaces, raceTraits, proficencies));
    
    readSrd.WriteJson("races", theRaces);
    // ------ Backgrounds -----------
    List<The5EBackgrounds> backgrounds = readSrd.readBackgroundsJson();
    List<The5ELanguages> languages = readSrd.readLanguagesJson();

    var theBackgrounds = backgrounds.Select(theBackground => Extensions.ToBackgroundDto(theBackground, proficencies, languages, equipment));

    readSrd.WriteJson("backgrounds", theBackgrounds);

    // ------- Feats ---------
    List<The5EFeats> feats = readSrd.readFeatsJson();
    var theFeats = feats.Select(theFeat => Extensions.ToFeatDto(theFeat));

    readSrd.WriteJson("feats", theFeats);
    
    // ------- Spells --------
    List<The5ESpells> spells = readSrd.readSpellsJson();
    List<SpellsTwo5E> spells2 = readSrd.readSpellsTwoJson();
    List<The5ESrdSpellsJson> spells3 = readSrd.readSrdSpellsJson();

    var theSpells = spells2.Select(spell => Extensions.ToSpellDto(spell,spells,spells3)).Where(x => x.Name != string.Empty);

    readSrd.WriteJson("spells", theSpells);



}


Main();

