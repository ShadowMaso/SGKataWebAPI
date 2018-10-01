using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SGKataWebAPI.Tests
{
    public class RoomControllerTests
    {
        Mock<Services.Interfaces.IRoomService> _roomServiceMock;

        public RoomControllerTests()
        {
            _roomServiceMock = new Mock<Services.Interfaces.IRoomService>();
        }

        [Fact]
        public void GetRooms()
        {
            List<Models.Dto.RoomDto> rooms = new List<Models.Dto.RoomDto> { new Models.Dto.RoomDto { Name = "room0" } };
            _roomServiceMock.Setup(_ => _.GetRooms()).ReturnsAsync(rooms);

            Controllers.RoomController roomController = new Controllers.RoomController(_roomServiceMock.Object);
            Task<IActionResult> result = roomController.Get();

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == 200);
        }
    }
}
