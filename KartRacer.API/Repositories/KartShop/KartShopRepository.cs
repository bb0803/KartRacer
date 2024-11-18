using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KartRacer.API.Repositories.Karts
{
    public class KartShopRepository : IKartShopRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly ILogger<KartShopRepository> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public KartShopRepository(IAuthRepository authRepository, DataContext context, ILogger<KartShopRepository> logger, IHttpContextAccessor contextAccessor)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._logger = logger;
            this._contextAccessor = contextAccessor;
        }

        public async Task<List<AvailableEngineDto>> GetAvailableEnginesAsync()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<AvailableEngineDto>($"Exec GetAvailableEngines @UserName = {UserName}").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableEnginesAsync)}." + ex.Message);
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }
        public async Task<List<AvailableChassisDto>> GetAvailableChassisAsync()
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<AvailableChassisDto>($"Exec GetAvailableChassis @UserName = {UserName}").AsEnumerable().ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailableChassisAsync)}." + ex.Message);
                return null; // Problem($"Something Went Wrong in the {nameof(GetShareholdersAsync)}", statusCode: 500);
            }
        }

        public async Task<ResponseDto> GetAvailablePartsAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var data = await _context.Database.SqlQuery<AvailablePartDto>($"Exec GetAvailableParts @Username = {usr.Username}").ToListAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = data,
                    Message = "Data successfully returned"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAvailablePartsAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"{nameof(GetAvailablePartsAsync)} failed - {ex.Message}"
                };
            }
        }


        public async Task<ResponseDto> PurchaseEngineAsync(int engineId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<Engine>($"Exec PurchaseEngine @Username = {UserName}, @X_EngineId = {engineId}").AsEnumerable().FirstOrDefault();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The engine was successfully purchased.",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PurchaseEngineAsync)}." + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "An error occurred. The engine was not purchased!!",
                    Result = null
                };
            }
        }

        public async Task<ResponseDto> PurchaseChassisAsync(int chassisId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = _context.Database.SqlQuery<int>($"Exec PurchaseChassis @Username = {UserName}, @X_ChassisId = {chassisId}").AsEnumerable().FirstOrDefault();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The chassis was successfully purchased.",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PurchaseChassisAsync)}." + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "An error occurred. The chassis was not purchased!!",
                    Result = null
                };
            }
        }

        public async Task<ResponseDto> PurchasePartAsync(int partId)
        {
            try
            {
                string UserName = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var result = await _context.Database.SqlQuery<Part>($"Exec PurchasePart @Username = {UserName}, @XPartId = {partId}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The part was successfully purchased.",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PurchasePartAsync)}." + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"An error occurred. The part was not purchased!! - {ex.Message}",
                    Result = null
                };
            }
        }
    }
}
