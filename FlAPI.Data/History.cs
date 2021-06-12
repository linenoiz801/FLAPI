using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
