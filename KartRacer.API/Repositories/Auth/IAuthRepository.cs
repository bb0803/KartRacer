using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Repositories.Generic;


namespace KartRacer.API.Repositories.Auth
{
    public interface IAuthRepository : IGenericRepository<Data.User>
    {
        Task<UserSetting> GetUserAsync();
    }
}
