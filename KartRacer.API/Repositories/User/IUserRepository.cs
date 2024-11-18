using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Generic;

namespace KartRacer.API.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserSetting>
    {
        Task<ResponseDto> ChangeUserSettingAsync(UserSetting setting);
        Task<UserSetting> GetUserSettingAsync();
        Task<ResponseDto?> CreateUserSetting();

    }
}
