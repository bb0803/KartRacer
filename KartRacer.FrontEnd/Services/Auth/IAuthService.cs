using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.User;

namespace KartRacer.FrontEnd.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> LogoutAsync();
    }
}
