using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class VaultListItem
    {
        public int VaultId { get; set; }
        public string VaultName { get; set; }
        public string VaultNumber { get; set; }
        public int? LocationId { get; set; }
        public int? GameId { get; set; }
        public string LocationUrl { get; set; }
        public string GameUrl { get; set; }
    }
}
