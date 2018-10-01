using Microsoft.EntityFrameworkCore;
using SGKataWebAPI.Context;
using SGKataWebAPI.Models;
using SGKataWebAPI.Models.Dto;
using SGKataWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Services
{
    public class BookingService : IBookingService
    {
        private ApiContext _context { get; set; }

        public BookingService(ApiContext context)
        {
            _context = context;
        }

        public async Task<BookingDto> CreateBooking(BookingDto booking)
        {
            var test = _context.Bookings.ToList();

            bool booked = await _context.Bookings.AnyAsync(b => b.RoomName == booking.Room && ((b.From >= booking.From && b.From <= booking.To) || (b.To >= booking.From && b.To <= booking.To)));

            if (booked)
            {
                return null;
            }

            booking.Date = booking.Date.Date;

            Booking created = new Booking
            {
                User = booking.User,
                Date = booking.Date,
                From = booking.From,
                To = booking.To,
                RoomName = booking.Room
            };

            _context.Bookings.Add(created);
            await _context.SaveChangesAsync();

            booking.Id = created.Id;

            return booking;
        }

        public async Task<List<BookingDto>> GetAvailableBookings(BookingDto booking)
        {
            List<BookingDto> available = new List<BookingDto>();
            List<Booking> booked = await _context.Bookings.Where(b => b.RoomName == booking.Room).OrderBy(b => b.From).ToListAsync();

            int from = 0;
            int to = -1;
            booking.Date = booking.Date.Date;

            foreach (Booking b in booked)
            {
                if (b.From > from)
                {
                    to = b.From;
                    available.Add(new BookingDto
                    {
                        User = booking.User,
                        Date = booking.Date,
                        From = from,
                        To = to - 1,
                        Room = booking.Room
                    });
                }
                from = b.To + 1;
            }

            if (to != -1 && from < 24)
            {
                available.Add(new BookingDto
                {
                    User = booking.User,
                    Date = booking.Date,
                    From = from,
                    To = 23,
                    Room = booking.Room
                });
            }

            return available;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            Booking booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return false;
            }
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
