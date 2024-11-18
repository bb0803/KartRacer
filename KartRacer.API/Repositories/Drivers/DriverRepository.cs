
using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KartRacer.API.Repositories.Drivers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<DriverRepository> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DriverRepository(DataContext content, ILogger<DriverRepository> logger, IAuthRepository authRepository, IHttpContextAccessor contextAccessor)
        {
            this._context = content;
            this._logger = logger;
            this._authRepository = authRepository;
            this._contextAccessor = contextAccessor;
        }
        public async Task<Models.Data.Driver> GetDriverAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Drivers.Where(e => e.Id == usr.DriverId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetDriverAsync)}");
                return null; 
            }
        }

        public async Task<ResponseDto> UpdateDriverAsync(Models.Data.Driver driver)
        {
            try
            {
                _context.Update(driver);
                _context.SaveChanges();

                ResponseDto responseDto = new ResponseDto() { 
                    IsSuccess = true,
                    Message = "The update was successful",
                    Result = driver
                };

                return responseDto ;
            }
            catch (Exception ex)
            {
                _logger.LogError("Change Driver Id failed - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Change Driver Id failed - " + ex.Message
                };
            }
        }

        public async Task<ResponseDto> CreateDriverAsync(string driverName)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<Models.Data.Driver>($"Exec CreateDriver @Username = {UserName}, @DriverName = {driverName} ").AsEnumerable().FirstOrDefault();
                return new ResponseDto() {
                    IsSuccess = true,
                    Message = "The driver was successfully created.",
                    Result = result
                };

            }
            catch (Exception ex)
            {
                _logger.LogError("Create Driver failed - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Create Driver failed - " + ex.Message
                };
            }
        }
        public async Task<List<Engine>> GetCurrentEnginesAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Engines.Where(e => e.DriverId == usr.DriverId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentEnginesAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<List<Chassis>> GetCurrentChassisAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                return await _context.Chassis.Where(e => e.DriverId == usr.DriverId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentChassisAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }
        public async Task<ResponseDto> GetCurrentPartsAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<CurrentPartDto>($"Exec GetCurrentParts @Username = {usr.Username}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Parts returned successfully.",
                    Result = data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentChassisAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };             
            }
        }

        public async Task<ResponseDto> GetEventSessions()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.EventSessions.Join(_context.Entries, es => es.EventId, e => e.EventId,
                        (es, e) => new {es.Id, es.EventId, StartDate = es.SessionDate, e.DriverId  })
                    .Where(e => e.DriverId == usr.DriverId)
                    .ToListAsync();
                return new ResponseDto()
                {
                    Result = data,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentChassisAsync)}");
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<ResponseDto> GetPracticeSessions()
        {
            throw new NotImplementedException();
        }
    }
}
