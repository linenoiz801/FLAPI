using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    class SpeciesListItem
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
