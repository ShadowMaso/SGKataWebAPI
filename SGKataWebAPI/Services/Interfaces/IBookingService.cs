using SGKataWebAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto> CreateBooking(BookingDto booking);

        Task<List<BookingDto>> GetAvailableBookings(BookingDto booking);

        Task<bool> DeleteBooking(int id);
    }
}
