using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Vault
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VaultName { get; set; }
        [Required]
        public string VaultNumber { get; set; }
    }
}
