﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class WeaponListItem
    {
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public string Description { get; set; }
        // public enum AmmoType TypeOfAmmo { get; set; }
        // public enum WeaponType TypeOfWeapon { get; set; }
        public string BaseDamage { get; set; }
    }
}
