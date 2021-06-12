﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Models
{
    public class ArmorCreate
    {
        public string Name { get; set; }
        public string Prereq { get; set; }
        public string Description { get; set; }
        public int GameId { get; set; }
        public int? HistoryId { get; set; }
    }
}
