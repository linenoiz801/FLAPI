﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Armor
    {
        //Id int[pk, increment]
        //Name string
        //Prereq string
        //Description string
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Prereq { get; set; }
        public string Description { get; set; }
    }
}
