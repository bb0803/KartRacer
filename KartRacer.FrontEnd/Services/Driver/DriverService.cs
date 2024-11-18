using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;

namespace KartRacer.FrontEnd.Services.Driver
{
    public class DriverService : IDriverService
    {
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";
        public DriverService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateDriverAsync(string DriverName)
        {
            try
            {
                DriverNameDto driver = new DriverNameDto() { DriverName = DriverName };
                return await _baseService.SendAsync(new RequestDto()
                {
                    ApiType = "Post",
                    Data = driver,
                    Url = APIHostAddress + "/api/driver"
                });
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        public async Task<ResponseDto> GetDriverAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/driver"
            });
        }

        public async Task<ResponseDto> UpdateDriverAsync(Models.Data.Driver driver)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = driver,
                Url = APIHostAddress + "/api/driver"
            });
        }

        public async Task<ResponseDto> GetCurrentEnginesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/driver/currentEngines"
            });
        }

        public async Task<ResponseDto> GetCurrentChassisAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/driver/currentChassis"
            });
        }

        public async Task<ResponseDto> GetCurrentPartsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/driver/currentParts"
            });
        }
    }
}
