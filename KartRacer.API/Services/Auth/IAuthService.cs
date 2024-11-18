using KartRacer.API.Models.Dto;
using KartRacer.API.Models.User;

namespace KartRacer.API.Services.Auth
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
