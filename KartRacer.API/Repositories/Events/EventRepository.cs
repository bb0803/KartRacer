using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using KartRacer.API.Repositories.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KartRacer.API.Repositories.Events
{
    public class EventRepository : IEventRepository
    {

        private readonly DataContext _context;
        private readonly ILogger<EventRepository> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public EventRepository(DataContext content, ILogger<EventRepository> logger, IAuthRepository authRepository, IHttpContextAccessor contextAccessor)
        {
            this._context = content;
            this._logger = logger;
            this._authRepository = authRepository;
            this._contextAccessor = contextAccessor;
        }
        public async Task<List<Event>> GetAvailableEventsAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return _context.Database.SqlQuery<Event>($"Exec GetAvailableEvents @Username = {usr.Username}").AsEnumerable().ToList();   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableEventsAsync)}");
                return null;
            }
        }

        public async Task<List<EntriesDto>> GetEntriesAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return _context.Database.SqlQuery<EntriesDto>($"Exec GetEntries @Username = {usr.Username}").AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetEntriesAsync)}");
                return null;
            }
        }

        public async Task<Event> GetNextEventAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Events.Where(e => e.Id == usr.DriverId)
                    .OrderBy(e => e.StartDate)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetNextEventAsync)}");
                return null;
            }
        }

        public async Task<List<EntriesDto>> GetEntriesForEventAsync(int eventId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return _context.Database.SqlQuery<EntriesDto>($"Exec GetEntriesForEvent @EventId = {eventId}").AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetEntriesForEventAsync)}");
                return null;
            }
        }

        public async Task<ResponseDto> CreateEntryAsync(int eventId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<Entry>($"Exec CreateEntry @Username = {UserName}, @EventId = {eventId} ").AsEnumerable().FirstOrDefault();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The entry was successfully created.",
                    Result = result
                };

            }
            catch (Exception ex)
            {
                _logger.LogError("Create Entry failed - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Create Entry failed - " + ex.Message
                };
            }
        }

        public async Task<ResponseDto> GetRecentEventSessionsForDriver()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = await _context.Database.SqlQuery<SessionHistoryDto>($"Exec GetRecentEventSessionsForDriver @Username = {UserName}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Data was sucessfully retrieved.",
                    Result = result
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Recent Event Sessions failed - {ex.Message}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Recent Event Sessions failed - " + ex.Message
                };
            }
        }

        public async Task<ResponseDto> GetEntrySessionsAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<EntrySessionsDto>($"Exec GetEntrySessions @Username = {usr.Username}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Entry Sessions were successfully retrieved.",
                    Result = data
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetEntriesAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"An error occurred retirvig entry sessions - {ex.Message}"
                };
            }
        }
    }
}
