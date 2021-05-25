using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class SpeciesGame
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Species))]
        public int SpeciesId { get; set; }
        public virtual Species Species { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
