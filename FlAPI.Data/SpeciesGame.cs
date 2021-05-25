﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class SpeciesGame
    {
        [Key, Column(Order = 0)]
        public int SpeciesId { get; set; }
        [Key, Column(Order = 1)]
        public int GameId { get; set; }
    }
}
