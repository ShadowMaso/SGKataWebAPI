using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Models
{
    public class Room
    {
        [Key]
        public string Name { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
