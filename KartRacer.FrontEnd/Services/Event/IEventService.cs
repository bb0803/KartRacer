using KartRacer.FrontEnd.Models.API;

namespace KartRacer.FrontEnd.Services.Event
{
    public interface IEventService
    {
        Task<ResponseDto> GetAvailableEventsAsync();
        Task<ResponseDto> GetEntriesAsync();
        Task<ResponseDto> GetEntrySessionsAsync();
        Task<ResponseDto> GetEntriesForEventAsync(int eventId);
        Task<ResponseDto> GetNextEventAsync();
        Task<ResponseDto> CreateEntryAsync(int eventId);
        Task<ResponseDto> GetRecentEventSessionsForDriver();
    }
}
