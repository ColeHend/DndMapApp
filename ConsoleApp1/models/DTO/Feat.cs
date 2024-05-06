using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassesDto;

namespace ConsoleApp1.models.DTO
{
    public class FeatEntity
    {
        public string Name { get; set; }
        public List<string> Desc { get; set; }
        public List<Feature<string, string>> PreReqs { get; set; } 
    }
}