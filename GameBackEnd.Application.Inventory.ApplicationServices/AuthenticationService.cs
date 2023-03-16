using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace GameBackEnd.Application.Inventory.ApplicationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return null;
            }

            var userId = user.FindFirst(ClaimTypes.Name);
            return userId?.Value;
        }
    }
}