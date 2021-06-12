using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string GameName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Species> ListOfSpecies { get; set; }
        public Game()
        {
            ListOfSpecies = new HashSet<Species>();
        }
    }
}
