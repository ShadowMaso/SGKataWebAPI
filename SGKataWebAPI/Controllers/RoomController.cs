using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGKataWebAPI.Models;
using SGKataWebAPI.Models.Dto;
using SGKataWebAPI.Services.Interfaces;

namespace SGKataWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Room
        /// <summary>
        /// List the rooms.
        /// </summary>
        /// <returns>The list of rooms</returns>
        /// <response code="200">Returns the list of rooms</response>
        /// <response code="400">If no room is found</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RoomDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            List<RoomDto> rooms = await _roomService.GetRooms();
            
            if (rooms.Count == 0)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        //// GET: api/Room/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Room
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Room/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/Room/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
