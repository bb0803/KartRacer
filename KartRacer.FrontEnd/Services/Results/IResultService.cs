using KartRacer.FrontEnd.Models.API;

namespace KartRacer.FrontEnd.Services.Results
{
    public interface IResultService
    {
        Task<ResponseDto> GetSessionResultLapsAsync(int sessionId);
        Task<ResponseDto> GetSessionResultsAsync(int sessionId);
        Task<ResponseDto> GetSessionResultLapsForDriverAsync(int driverId, int sessionId);
        Task<ResponseDto> GetEventResultsforDriverAsync(int eventId);
        Task<ResponseDto> GetCircuitResultsforDriverAsync(int circuitId);
    }
}
