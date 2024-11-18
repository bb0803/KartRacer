using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Data;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;
using KartRacer.FrontEnd.Web.Models.Dto;

namespace KartRacer.FrontEnd.Services.KartShop
{
    public class KartShopService : IKartShopService
    { 
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";
        public KartShopService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAvailableChassisAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/kartshop/availableChassis"
            });
        }

        public async Task<ResponseDto?> GetAvailableEnginesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/kartshop/availableEngines"
            });
        }

        public async Task<ResponseDto?> GetAvailablePartsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/kartshop/availableParts"
            });
        }

        public async Task<ResponseDto?> PurchaseChassisAsync(int ChassisId)
        {
            PurchaseChassisDto chassis = new PurchaseChassisDto()
            {
                chassisId = ChassisId
            };

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = chassis,
                Url = APIHostAddress + "/api/kartshop/purchaseChassis"
            });
        }

        public async Task<ResponseDto?> PurchaseEngineAsync(int engineId)
        {
            SingleIntDto engine = new SingleIntDto()
            {
                Id = engineId
            };

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = engine,
                Url = APIHostAddress + "/api/kartshop/purchaseEngine"
            });
        }

        public async Task<ResponseDto?> PurchasePartAsync(int partId)
        {
            SingleIntDto part = new SingleIntDto()
            {
                Id = partId
            };

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = part,
                Url = APIHostAddress + "/api/kartshop/purchasePart"
            });
        }
    }
}
