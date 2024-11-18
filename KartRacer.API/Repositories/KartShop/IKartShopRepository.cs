using KartRacer.API.Models.Dto;

namespace KartRacer.API.Repositories.Karts
{
    public interface IKartShopRepository 
    {
        Task<List<AvailableEngineDto>> GetAvailableEnginesAsync();
        Task<List<AvailableChassisDto>> GetAvailableChassisAsync();
        Task<ResponseDto> GetAvailablePartsAsync();
        Task<ResponseDto> PurchaseEngineAsync(int EngineId);
        Task<ResponseDto> PurchaseChassisAsync(int ChassisId);
        Task<ResponseDto> PurchasePartAsync(int PartId);
    }
}
