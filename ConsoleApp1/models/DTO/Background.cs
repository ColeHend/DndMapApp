using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassesDto;

namespace ConsoleApp1.models.DTO
{
    public class BackgroundEntity
    {
        public string Name { get; set; }
        public List<Feature<string, string>>? StartingProficiencies { get; set; }
        public ChoicesEntity<string>? LanguageChoice { get; set; }

        public List<ItemDto> StartingEquipment { get; set; }

        public List<EquipmentChoicesDto> StartingEquipmentChoices { get; set; }

        public List<Feature<List<string>, string>>? Feature { get; set; }
    }
}