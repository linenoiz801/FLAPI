using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Data
{
    public class History
    {
        /*  
        Id int [pk, increment]
        EventName string
        EventDate datetime
        Description string*/
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
