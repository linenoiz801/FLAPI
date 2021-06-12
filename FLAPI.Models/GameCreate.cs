using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class GameCreate
    {
        
        public string GameName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
