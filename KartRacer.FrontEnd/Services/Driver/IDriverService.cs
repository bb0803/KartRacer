using KartRacer.FrontEnd.Models.API;

namespace KartRacer.FrontEnd.Services.Driver
{
    public interface IDriverService
    {
        Task<ResponseDto> GetDriverAsync();
        Task<ResponseDto> UpdateDriverAsync(Models.Data.Driver driver);
        Task<ResponseDto> CreateDriverAsync(string DriverName);
        Task<ResponseDto> GetCurrentEnginesAsync();
        Task<ResponseDto> GetCurrentChassisAsync();
        Task<ResponseDto> GetCurrentPartsAsync();
    }
}
