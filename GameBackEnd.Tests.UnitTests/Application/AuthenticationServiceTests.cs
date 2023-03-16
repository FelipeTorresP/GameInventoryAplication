using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using IdentityAutenticator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace GameBackEnd.Tests.UnitTests.Utils
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private Mock<IJwtGenerator> _jwtGeneratorMock;
        private IAuthenticationService _authenticationService;

        [TestInitialize]
        public void Initialize()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(_userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(), null, null, null, null);
            _jwtGeneratorMock = new Mock<IJwtGenerator>();
            _authenticationService = new AuthenticationService(_signInManagerMock.Object, _userManagerMock.Object, _jwtGeneratorMock.Object);
        }

        [TestMethod]
        public async Task LoginAsync_UserNotFound_ReturnsError()
        {
            // Arrange
            var loginDto = new LoginDto { User = "nonexistentuser@example.com", Password = "password" };
            _userManagerMock.Setup(m => m.FindByEmailAsync(loginDto.User)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authenticationService.LoginAsync(loginDto);

            // Assert
            Assert.IsFalse(result.Success);
            CollectionAssert.Contains(result.Errors.ToList(), "User does not exist");
        }

        [TestMethod]
        public async Task LoginAsync_InvalidPassword_ReturnsError()
        {
            // Arrange
            var loginDto = new LoginDto { User = "validuser@example.com", Password = "invalidpassword" };
            var user = new ApplicationUser { UserName = "validuser", Email = "validuser@example.com" };
            _userManagerMock.Setup(m => m.FindByEmailAsync(loginDto.User)).ReturnsAsync(user);
            _signInManagerMock.Setup(m => m.PasswordSignInAsync(user.UserName, loginDto.Password, false, false)).ReturnsAsync(SignInResult.Failed);

            // Act
            var result = await _authenticationService.LoginAsync(loginDto);

            // Assert
            Assert.IsFalse(result.Success);
            CollectionAssert.Contains(result.Errors.ToList(), "Invalid Password");
        }
    }
}