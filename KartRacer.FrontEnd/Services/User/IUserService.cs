using KartRacer.FrontEnd.Models.API;

namespace KartRacer.FrontEnd.Services.User
{
    public interface IUserService
    {
        Task<ResponseDto?> ChangeDriverIdAsync(int driverId);
        Task<ResponseDto?> ChangeNickNameAsync(string nickName);
        Task<ResponseDto?> ChangeSessionAsync(int SessionId);
        Task<ResponseDto?> GetUserSettingAsync();
    }
}
