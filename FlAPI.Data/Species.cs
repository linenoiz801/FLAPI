using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Species
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SpeciesName { get; set; }
        [Required]
        public string Weakness { get; set; }
        public string Strength { get; set; }
        [ForeignKey(nameof(History))]
        public int? HistoryId { get; set; }
        public virtual History History { get; set; }     
        public virtual ICollection<Game> ListOfGames { get; set; }
        public Species()
        {
            ListOfGames = new HashSet<Game>();
        }
    }
}
