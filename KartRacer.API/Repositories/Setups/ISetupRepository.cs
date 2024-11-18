using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Repositories.Setups
{
    public interface ISetupRepository
    {
        Task<int> ChangeAxleAsync();
        Task<ResponseDto> SaveSetupAsync(Setup setup);
        Task<ResponseDto> SaveSetupFavouriteAsync(SetupFavourite setupFavourite);
        Task<ResponseDto> LoadSetupFavouriteAsync(int setupId);
        Task<int> ChangeCurrentSetupAsync(Setup setup);
        Task<int> ChangeTyreAsync(int newTyre);
        Task<int> ChangeChassisAsync(int chassisId);
        Task<bool> SetupExists (Setup setup);
        Task<ResponseDto> GetSetupFavorites();
        Task<ResponseDto> GetSetupAsync();
        Task<ResponseDto> GetAllSetupsAsync();
            
           

    }
}
