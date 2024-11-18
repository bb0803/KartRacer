using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Repositories.Events
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAvailableEventsAsync();
        Task<List<EntriesDto>> GetEntriesAsync();
        Task<ResponseDto> GetEntrySessionsAsync();
        Task<List<EntriesDto>> GetEntriesForEventAsync(int EventId);
        Task<Event> GetNextEventAsync();
        Task<ResponseDto> CreateEntryAsync(int eventId);
        Task<ResponseDto> GetRecentEventSessionsForDriver();
        


    }
}
