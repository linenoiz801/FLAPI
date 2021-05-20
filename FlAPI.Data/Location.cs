using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(History))]
        public int HistoryId { get; set; }
        public virtual History History { get; set; }
    }
}
