using Microsoft.AspNetCore.Mvc;
using Moq;
using SGKataWebAPI.Controllers;
using SGKataWebAPI.Models.Dto;
using SGKataWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SGKataWebAPI.Tests
{
    public class RoomControllerTests
    {
        private RoomController _roomController;
        private Mock<IRoomService> _mockRoomService;

        public RoomControllerTests()
        {
            List<RoomDto> rooms = new List<RoomDto>
            {
                new RoomDto { Name = "room0" },
                new RoomDto { Name = "room1" },
                new RoomDto { Name = "room2" },
            };

            _mockRoomService = new Mock<IRoomService>();
            _mockRoomService.Setup(repo => repo.GetRooms()).ReturnsAsync(rooms);

            _roomController = new RoomController(_mockRoomService.Object);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            IActionResult result = await _roomController.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllRooms()
        {
            OkObjectResult okResult = await _roomController.Get() as OkObjectResult;

            List<RoomDto> items = Assert.IsType<List<RoomDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
