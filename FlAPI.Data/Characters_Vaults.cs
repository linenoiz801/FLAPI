using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Characters_Vaults
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
        [ForeignKey(nameof(Vault))]
        public int VaultId { get; set; }
        public virtual Vault Vault { get; set; }
    }
}
