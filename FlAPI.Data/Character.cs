using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Affiliation { get; set; }
        [Required]
        public bool IsNPC { get; set; }
        [Required]
        public bool IsHostile { get; set; }

        [ForeignKey(nameof(Species))]
        public int? SpeciesId { get; set; }
        public virtual Species Species { get; set; }

        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(History))]
        public int? HistoryId { get; set; }
        public virtual History History { get; set; }

        public virtual ICollection<Location> ListOfLocations { get; set; }
        public virtual ICollection<Vault> ListOfVaults { get; set; }
        public Character()
        {
            ListOfLocations = new HashSet<Location>();
            ListOfVaults = new HashSet<Vault>();
        }
    }
}
