using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int Age { get; set; }
        public string Affiliation { get; set; }
        public bool IsNPC { get; set; }
        public bool IsHostile { get; set; }
    }
}
