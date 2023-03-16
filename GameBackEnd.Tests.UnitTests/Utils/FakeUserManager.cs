using IdentityAutenticator;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace GameBackEnd.Tests.UnitTests.Utils
{
    public class FakeUserManager : UserManager<ApplicationUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<ApplicationUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<ApplicationUser>>().Object,
                  new IUserValidator<ApplicationUser>[0],
                  new IPasswordValidator<ApplicationUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
        {
        }

        public override Task<ApplicationUser> FindByEmailAsync(string email)
        {
            if (email == "validuser@test.com")
            {
                return Task.FromResult(new ApplicationUser
                {
                    Id = "1",
                    UserName = "validuser@test.com",
                    Email = "validuser@test.com"
                });
            }

            return Task.FromResult<ApplicationUser>(null);
        }
    }
}