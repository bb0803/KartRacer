using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Data;

namespace KartRacer.FrontEnd.Services.Setup
{
    public interface ISetupService
    {
        Task<ResponseDto?> ChangeAxleAsync(int Axle);
        Task<ResponseDto?> SaveSetupAsync(Models.Data.Setup setup);
        //Task<ResponseDto?> LoadSetupAsync();
        Task<ResponseDto?> ChangeCurrentSetupAsync(Models.Data.Setup setup);
        Task<ResponseDto?> ChangeTyreAsync(int Tyre);
        Task<ResponseDto?> ChangeChassisAsync(int Chassis);
        Task<ResponseDto> SaveSetupFavouriteAsync(SetupFavourite setupFavourite);
        Task<ResponseDto> LoadSetupFavouriteAsync(int setupId);
        Task<ResponseDto> SetupExistsAsync(Models.Data.Setup setup);
        Task<ResponseDto> GetSetupFavoritesAsync();
        Task<ResponseDto> GetSetupAsync();
        Task<ResponseDto?> GetAllSetupAsync();
    }
}
