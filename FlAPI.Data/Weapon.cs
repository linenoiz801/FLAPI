using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    //public enum AmmoType
    //{
    //    None,

    //}
    //public enum WeaponType
    //{
    //    Unarmed,
    //    Melee,
    //    Pistol,
    //    SMG,
    //    Rifle,
    //    Shotgun,
    //    Unique,
    //    EnergyPistol,
    //    EnergyRifle,
    //    Throwing,
    //    Trap
    //}
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        [Required]
        public string WeaponName { get; set; }
        [Required]
        public string Description { get; set; }
        public string AmmoType { get; set; }
        [Required]
        public string WeaponType { get; set; }
        public string BaseDamage { get; set; }
        // *Stretch: public enum AmmoType TypeOfAmmo { get; set; }
        // *Stretch: public enum WeaponType TypeOfWeapon { get; set; }
    }
}
