using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class VaultCreate
    {
        [Required]
        public string VaultName { get; set; }
        [Required]
        public string VaultNumber { get; set; }
    }
}
