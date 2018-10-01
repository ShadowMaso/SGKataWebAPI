using SGKataWebAPI.Models;
using SGKataWebAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGKataWebAPI.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetRooms();

        Task<bool> RoomExist(string name);
    }
}
