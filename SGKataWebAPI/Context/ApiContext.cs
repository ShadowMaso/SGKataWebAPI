using Microsoft.EntityFrameworkCore;
using SGKataWebAPI.Models;

namespace SGKataWebAPI.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext()
        { }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
