using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    class SpeciesCreate
    {
        [Required]
        public string GameName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
