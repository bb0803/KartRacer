using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace KartRacer.API.Repositories.Results
{
    public class ResultRepository : IResultRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public ResultRepository(IAuthRepository authRepository, DataContext context, ILogger<ResultRepository> logger)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._logger = logger;
        }


        public async Task<ResponseDto> GetSessionResultLapsAsync(int sessionId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<ResultsDto>($"Exec GetSessionResultLaps @Username = {usr.Username}, @SessionId = {sessionId}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionResultLapsAsync)}");
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetSessionResultLapsAsync)} failed - {ex.Message}"
                };
            }
        }

        public async Task<ResponseDto> GetSessionResultsAsync(int sessionId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<ResultsDto>($"Exec GetSessionResults @Username = {usr.Username}, @SessionId = {sessionId}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionResultsAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetSessionResultsAsync)} failed - {ex.Message}"
                };
            }
        }

        public async Task<ResponseDto> GetSessionResultLapsForDriverAsync(int driverId, int sessionId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<ResultsDto>($"Exec GetSessionResultLapsForDriver @Username = {usr.Username}, @SessionId = {sessionId}, @DriverId = {driverId}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionResultLapsForDriverAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetSessionResultLapsForDriverAsync)} failed - {ex.Message}"
                };
            }
        }

        public async Task<ResponseDto> GetCircuitResultsforDriverAsync(int circuitId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<ResultsDto>($"Exec GetCircuitResultsForDriver @Username = {usr.Username}, @CircuitId = {circuitId}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCircuitResultsforDriverAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetCircuitResultsforDriverAsync)} failed - {ex.Message}"
                };
            }
        }

        public async Task<ResponseDto> GetEventResultsforDriverAsync(int eventId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<ResultsDto>($"Exec GetEventResultsForDriver @Username = {usr.Username}, @EventId = {eventId}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetEventResultsforDriverAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetEventResultsforDriverAsync)} failed - {ex.Message}"
                };
            }
        }
    }
}
