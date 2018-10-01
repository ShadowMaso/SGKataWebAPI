using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SGKataWebAPI.TestsMS
{
    [TestClass]
    public class RoomControllerTests
    {
        Mock<Services.Interfaces.IRoomService> _roomServiceMock;

        public RoomControllerTests()
        {
            _roomServiceMock = new Mock<Services.Interfaces.IRoomService>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var rooms = new List<Models.Dto.RoomDto> { new Models.Dto.RoomDto { Name = "Chambre 1" } };
            _roomServiceMock.Setup(_ => _.GetRooms()).ReturnsAsync(rooms);

            Controllers.RoomController roomController = new Controllers.RoomController(_roomServiceMock.Object);
            Task<IActionResult> result = await roomController.Get();
        }
    }
}
