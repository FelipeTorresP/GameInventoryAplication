using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserApi.Controllers;

namespace UserApi.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly Mock<IAuthenticationService> _authenticationServiceMock = new Mock<IAuthenticationService>();
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _controller = new UserController(_authenticationServiceMock.Object);
        }

        [TestMethod]
        public async Task Login_Returns_Ok_With_Valid_Login()
        {
            // Arrange
            var expectedResponse = new AuthenticationResponse { Success = true };
            var loginDto = new LoginDto() { User = "user1", Password = "Password" };

            _authenticationServiceMock.Setup(x => x.LoginAsync(loginDto)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as AuthenticationResponse;
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public async Task Login_Returns_Unauthorized_With_Invalid_Login()
        {
            // Arrange
            var expectedResponse = new AuthenticationResponse { Success = false };
            var loginDto = new LoginDto() { User = "user1", Password = "Password" };


            _authenticationServiceMock.Setup(x => x.LoginAsync(loginDto)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            Assert.IsNotNull(result);
            var okResult = result.Result as UnauthorizedObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as AuthenticationResponse;
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public async Task Logout_Returns_Ok()
        {
            // Arrange

            // Act
            var result = await _controller.Logout();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}