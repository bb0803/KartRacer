using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Repositories.Results
{
    public interface IResultRepository
    {
        Task<ResponseDto> GetSessionResultLapsAsync(int sessionId);
        Task<ResponseDto> GetSessionResultsAsync(int sessionId);
        Task<ResponseDto> GetSessionResultLapsForDriverAsync(int driverId, int sessionId);
        Task<ResponseDto> GetEventResultsforDriverAsync(int eventId);
        Task<ResponseDto> GetCircuitResultsforDriverAsync(int circuitId);
    }
}
