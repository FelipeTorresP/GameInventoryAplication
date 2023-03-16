using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;


namespace IdentityAutenticator
{
    public class LoginManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginManager> _logger;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginManager(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger<LoginManager> logger,
            IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string> SignInAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                _logger.LogError($"Failed login attempt for User: {userName}");
                throw new Exception("Credenciales inválidas. Por favor, verifique su correo usuario y contraseña e intente nuevamente.");
            }

            var result = await _userManager.CheckPasswordAsync(user, password);
            if (!result)
            {
                _logger.LogError($"Failed login attempt for email: {userName}");
                throw new Exception("Credenciales inválidas. Por favor, verifique su correo usuario y contraseña e intente nuevamente.");
            }

            return _jwtGenerator.GenerateToken(user);
        }

        public async Task SignOutAsync(ClaimsPrincipal user)
        {
            var userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogError("Failed logout attempt: user ID not found in claims.");
                throw new Exception("No se pudo cerrar sesión.");
            }

            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                _logger.LogError($"Failed logout attempt: user with ID {userId} not found.");
                throw new Exception("No se pudo cerrar sesión.");
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            _logger.LogInformation($"User {currentUser.Email} signed out.");
        }
    }
}
