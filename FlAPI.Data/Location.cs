using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class Location
    {
        //Id int[pk, increment]
        //Name string
        //MetroArea string
        //Country string

        public int Id { get; set; }
        public string Name { get; set; }
        public string MetroArea { get; set; }
        public string Country { get; set; }
    }
}
