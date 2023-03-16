using ApplicationServices.Dto;

namespace ApplicationServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
    }
}