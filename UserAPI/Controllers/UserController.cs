using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginDto loginDto)
        {
            var result = await _authenticationService.LoginAsync(loginDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _authenticationService.LogoutAsync();
            return Ok();
        }
    }
}