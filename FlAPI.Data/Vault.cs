using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Vault
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VaultName { get; set; }
        [Required]
        public string VaultNumber { get; set; }
        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<Character> ListOfCharacters { get; set; }

        public Vault()
        {
            ListOfCharacters = new HashSet<Character>();
        }
    }
}
