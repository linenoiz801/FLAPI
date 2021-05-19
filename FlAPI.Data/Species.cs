﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Creature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
