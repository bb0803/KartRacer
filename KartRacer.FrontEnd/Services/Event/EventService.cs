using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;

namespace KartRacer.FrontEnd.Services.Event
{
    public class EventService : IEventService
    { 
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";
        public EventService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetAvailableEventsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/event/availableEvents"
            });
        }

        public async Task<ResponseDto> GetEntriesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/event/entries"
            });
        }

        public async Task<ResponseDto> GetEntrySessionsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/event/entrySessions"
            });
        }
        public async Task<ResponseDto> GetEntriesForEventAsync(int eventId)
        {
            SingleIntDto evt = new SingleIntDto() { Id = eventId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Data = evt,
                Url = APIHostAddress + "/api/event/entriesForEvent"
            });
        }

        public async Task<ResponseDto> GetNextEventAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/event/nextEvent"
            });
        }

        public async Task<ResponseDto> CreateEntryAsync(int eventId)
        {
            SingleIntDto evt = new SingleIntDto() { Id = eventId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = evt,
                Url = APIHostAddress + "/api/event/entry"
            });
        }

        public async Task<ResponseDto> GetRecentEventSessionsForDriver()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/event/recentEventSessions"
            });
        }


    }
}
