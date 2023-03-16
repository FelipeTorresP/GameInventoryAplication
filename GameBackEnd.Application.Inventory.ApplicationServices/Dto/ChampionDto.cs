using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd.Application.Inventory.ApplicationServices.Dto
{
    public class ChampionDto
    {
        required public string Id { get; set; }
        required public string Name { get; set; }
        required public string Ascension { get; set; }
        required public string Claws { get; set; }
        required public string CoreEssence { get; set; }
        required public string Divinity { get; set; }
        required public string Edition { get; set; }
        required public string Family { get; set; }
        required public string Piercing { get; set; }
        required public string Horns { get; set; }
        required public string Tail { get; set; }
        required public string Wings { get; set; }
        required public string Description { get; set; }
        public int Stats { get; set; }
        public int Levels { get; set; }
    }
}
