using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class LocationCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter More Charaters.")]
        [MaxLength(6000, ErrorMessage = "You Entered Too Many Characters.")]

        public string Name { get; set; }

        public string Country { get; set; }

        public string MetroArea { get; set; }
        public int GameId { get; set; }
        public int HistoryId { get; set; }
    }
}
