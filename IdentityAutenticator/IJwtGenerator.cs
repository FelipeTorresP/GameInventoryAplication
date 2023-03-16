using Microsoft.AspNetCore.Identity;

namespace IdentityAutenticator
{
    public interface IJwtGenerator
    {
        string GenerateToken(IdentityUser user);
    }
}