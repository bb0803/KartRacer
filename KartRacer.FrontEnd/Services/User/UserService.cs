using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;

namespace KartRacer.FrontEnd.Services.User
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";
        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> ChangeDriverIdAsync(int driverId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Url = APIHostAddress + $"/api/user/ChangeDriverId/{driverId}"
            });
        }

        public async Task<ResponseDto?> ChangeNickNameAsync(string nickName)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = nickName,
                Url = APIHostAddress + "/api/user/changeNickName"
            });
        }

        public async Task<ResponseDto?> ChangeSessionAsync(int SessionId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = SessionId,
                Url = APIHostAddress + "/api/user/changeSessionId"
            });
        }

        public async Task<ResponseDto?> GetUserSettingAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/user"
            });
        }
    }
}
