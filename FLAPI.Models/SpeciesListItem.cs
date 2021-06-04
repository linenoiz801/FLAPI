using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class SpeciesListItem
    {
        public int Id { get; set; }
        public string SpeciesName { get; set; }
        public string Weakness { get; set; }
        public string Strength { get; set; }
        public int? HistoryId { get; set; }
        public string HistoryUrl { get; set; }
    }
}
