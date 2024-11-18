using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Data;
using KartRacer.FrontEnd.Web.Models.Dto;

namespace KartRacer.FrontEnd.Services.KartShop
{
    public interface IKartShopService
    {
        Task<ResponseDto?> GetAvailableEnginesAsync();
        Task<ResponseDto?> GetAvailableChassisAsync();
        Task<ResponseDto?> GetAvailablePartsAsync();
        Task<ResponseDto?> PurchaseEngineAsync(int EngineId);
        Task<ResponseDto?> PurchaseChassisAsync(int ChassisId);
        Task<ResponseDto?> PurchasePartAsync(int EngineId);
    }
}
