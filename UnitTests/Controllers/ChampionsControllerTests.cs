namespace UnitTests.Controllers
{
    using GameBackEnd.Application.Inventory.ApplicationServices;
    using GameBackEnd.Application.Inventory.ApplicationServices.Dto;
    using InventoryAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    [TestClass]
    public class ChampionsControllerTests
    {
        private Mock<IAuthenticationService> _authenticationServiceMock;
        private Mock<IChampionsService> _championsServiceMock;
        private ChampionsController _championsController;

        [TestInitialize]
        public void Initialize()
        {
            _authenticationServiceMock = new Mock<IAuthenticationService>();
            _championsServiceMock = new Mock<IChampionsService>();
            _championsController = new ChampionsController(_authenticationServiceMock.Object, _championsServiceMock.Object);
        }

        [TestMethod]
        public async Task GetInventory_WithValidToken_ReturnsListOfChampions()
        {
            // Arrange
            var userId = "1";
            var championList = new List<ChampionDto> { };
            _authenticationServiceMock.Setup(x => x.GetUserId()).Returns(userId);
            _championsServiceMock.Setup(x => x.GetChampions(userId)).ReturnsAsync(championList);

            // Act
            var result = await _championsController.GetInventory();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(championList, okResult.Value);
        }

        [TestMethod]
        public async Task GetInventory_WithInvalidToken_ReturnsBadRequest()
        {
            // Arrange
            _authenticationServiceMock.Setup(x => x.GetUserId()).Returns("");

            // Act
            var result = await _championsController.GetInventory();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual("No se puede obtener el id del usuario desde el token.", badRequestResult.Value);
        }

        [TestMethod]
        public async Task GetInventory_WithNullChampions_ReturnsNotFound()
        {
            // Arrange
            var userId = "1";
            _authenticationServiceMock.Setup(x => x.GetUserId()).Returns(userId);
            _championsServiceMock.Setup(x => x.GetChampions(userId)).ReturnsAsync((List<ChampionDto>)null);

            // Act
            var result = await _championsController.GetInventory();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

    }
}