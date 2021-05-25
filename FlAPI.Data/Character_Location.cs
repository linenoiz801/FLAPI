using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Character_Location
    {
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }

    }
}
