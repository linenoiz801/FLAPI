using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class LocationListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string MetroArea { get; set; }
        public int GameId { get; set; }
        public int HistoryId { get; set; }

    }
}
