using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DateTime Date { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string RoomName { get; set; }

        public virtual Room Room { get; set; }
    }
}
