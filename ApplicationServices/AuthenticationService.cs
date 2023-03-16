using ApplicationServices.Dto;
using IdentityAutenticator;
using Microsoft.AspNetCore.Identity;

namespace ApplicationServices.Interfaces
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthenticationService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtGenerator jwtGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.User);
            if (user == null)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "User does not exist" }
                };
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName ?? "", loginDto.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "Invalid Password" }
                };
            }

            var token = _jwtGenerator.GenerateToken(user);
            return new AuthenticationResponse
            {
                Token = token,
                Success = result.Succeeded,
            };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}