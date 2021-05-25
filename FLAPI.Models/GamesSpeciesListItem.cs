using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class GamesSpeciesListItem
    {
        public int GameId { get; set; }
        public List<int> SpeciesIds { get; set; }
    }
}
