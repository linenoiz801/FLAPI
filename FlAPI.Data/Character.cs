using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
