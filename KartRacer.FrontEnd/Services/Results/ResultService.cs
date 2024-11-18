using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;
using Microsoft.Extensions.Logging;

namespace KartRacer.FrontEnd.Services.Results
{
    public class ResultService : IResultService
    {
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";

        public ResultService(IBaseService baseService) 
        {
            this._baseService = baseService;
        }

        public async Task<ResponseDto> GetSessionResultLapsAsync(int sessionId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/result/sessionResultLaps"
            });
        }

        public async Task<ResponseDto> GetSessionResultsAsync(int sessionId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + $"/api/result/sessionResults/{sessionId}"
            });
        }

        public async Task<ResponseDto> GetSessionResultLapsForDriverAsync(int driverId, int sessionId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/result/sessionResultsForDriver"
            });
        }

        public async Task<ResponseDto> GetCircuitResultsforDriverAsync(int circuitId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/result/circuitResultsForDriver"
            });
        }

        public async Task<ResponseDto> GetEventResultsforDriverAsync(int eventId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/result/eventResultsForDriver"
            });
        }
    }
}
