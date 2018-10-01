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
    public class RoomService : IRoomService
    {
        private ApiContext _context { get; set; }

        public RoomService(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<RoomDto>> GetRooms()
        {
            return await _context.Rooms.Select(r =>
                new RoomDto()
                {
                    Name = r.Name
                }).ToListAsync();
        }

        public async Task<bool> RoomExist(string name)
        {
            return await _context.Rooms.AnyAsync(r => r.Name == name);
        }
    }
}
