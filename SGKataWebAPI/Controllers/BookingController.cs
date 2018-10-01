using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGKataWebAPI.Models.Dto;
using SGKataWebAPI.Services.Interfaces;

namespace SGKataWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        private IRoomService _roomService;

        public BookingController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        //// GET: api/booking
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "booking1", "booking2" };
        //}

        //// GET: api/booking/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "booking";
        //}

        // POST: api/booking
        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id": 0,
        ///        "user": "morphee",
        ///        "date": "2018-10-01",
        ///        "from": 12, // 0 -> 23
        ///        "to": 14, // 0 -> 23
        ///        "room": "room0"
        ///     }
        ///
        /// </remarks>
        /// <param name="booking"></param>
        /// <returns>The created booking or all available bookings for this day</returns>
        /// <response code="200">Returns the created booking</response>
        /// <response code="204">If no booking is available</response>
        /// <response code="400">If the booking is incorrect</response>
        /// <response code="409">Returns the list of available bookings</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(BookingDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] BookingDto booking)
        {
            if (!ModelState.IsValid || !await _roomService.RoomExist(booking.Room))
            {
                return BadRequest(ModelState);
            }

            BookingDto created = await _bookingService.CreateBooking(booking);

            if (created != null)
            {
                return Ok(created);
            }

            List<BookingDto> available = await _bookingService.GetAvailableBookings(booking);

            if (available != null && available.Count > 0)
            {
                return Conflict(available);
            }

            return NoContent();
        }

        //// PUT: api/booking/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/booking/5
        /// <summary>
        /// Deletes a booking.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">The booking is deleted</response>
        /// <response code="404">If the booking is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _bookingService.DeleteBooking(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
