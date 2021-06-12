using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Prereq { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(History))]
        public int? HistoryId { get; set; }
        public virtual History History { get; set; }
    }
}
