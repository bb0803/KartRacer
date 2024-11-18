using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Repositories.Drivers
{
    public interface IDriverRepository
    {
        Task<Models.Data.Driver> GetDriverAsync();
        Task<ResponseDto> UpdateDriverAsync(Models.Data.Driver driver);
        Task<ResponseDto> CreateDriverAsync(string DriverName);
        Task<List<Engine>> GetCurrentEnginesAsync();
        Task<List<Chassis>> GetCurrentChassisAsync();
        Task<ResponseDto> GetCurrentPartsAsync();
        Task<ResponseDto> GetEventSessions();
        Task<ResponseDto> GetPracticeSessions();
    }
}
