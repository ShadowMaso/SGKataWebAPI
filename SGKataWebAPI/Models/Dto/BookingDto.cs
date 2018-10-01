using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Models.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int From { get; set; }

        [Required]
        public int To { get; set; }

        [Required]
        public string Room { get; set; }
    }
}
