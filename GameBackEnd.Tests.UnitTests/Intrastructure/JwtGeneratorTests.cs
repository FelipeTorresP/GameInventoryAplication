using IdentityAutenticator;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;

namespace GameBackEnd.Tests.UnitTests.Intrastructure
{
    [TestClass]
    public class JwtGeneratorTests
    {
        private readonly Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
        private readonly JwtGenerator _jwtGenerator;

        public JwtGeneratorTests()
        {
            _mockConfig.SetupGet(x => x["Jwt:SecretKey"]).Returns("mysecretkeyasdafsa56sf46s45f6a");

            _jwtGenerator = new JwtGenerator(_mockConfig.Object);
        }

        [TestMethod]
        public void GenerateToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new IdentityUser
            {
                UserName = "testuser",
                Id = "1"
            };

            // Act
            var token = _jwtGenerator.GenerateToken(user);

            // Assert
            Assert.IsNotNull(token);
            Assert.IsInstanceOfType(token, typeof(string));
        }
    }
}