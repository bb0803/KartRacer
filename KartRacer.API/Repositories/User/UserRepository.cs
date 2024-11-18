using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using KartRacer.API.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;


namespace KartRacer.API.Repositories.User
{
    public class UserRepository : GenericRepository<UserSetting>, IUserRepository
    {
        private readonly IAuthRepository _authRepository;
        private readonly DataContext _context;
        private readonly ILogger<UserRepository> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor, IAuthRepository authRepository, DataContext context, ILogger<UserRepository> logger) : base (context)
        {
            this._authRepository = authRepository;
            this._context = context;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto> ChangeUserSettingAsync(UserSetting settings)
        {
            try
            {
                _context.Update(settings);
                _context.SaveChanges();

                ResponseDto resp = new ResponseDto()
                {
                    Result = settings,
                    Message = "The update was successful",
                    IsSuccess = true
                };
                return resp;
            }
            catch(Exception ex)
            {
                _logger.LogError("Change Driver Id failed - " + ex.Message);
                ResponseDto resp = new ResponseDto()
                {
                    Result = settings,
                    Message = "Change Driver Id failed - " + ex.Message,
                    IsSuccess = false
                };
                return resp;
            }
        }

        public async Task<UserSetting> GetUserSettingAsync()
        {
            try
            {
                return await _context.UserSettings.AsNoTracking().Where(u => u.Username == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Get User Setting failed - " + ex.Message);
                return null;
            }
        }

        public async Task<ResponseDto> CreateUserSetting()
        {
            try
            {
                UserSetting usr = await _context.UserSettings.AsNoTracking().Where(u => u.Username == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value).FirstOrDefaultAsync();
                _context.UserSettings.Add(new UserSetting { Username = usr.Username });
                _context.SaveChanges();
                return new ResponseDto { IsSuccess = true, Message = "The user Setting was created successfully" };
            }
            catch (Exception ex) {
                _logger.LogError("Change User Setting failed - " + ex.Message);
                return new ResponseDto { IsSuccess = false, Message = "Change User Setting failed - " + ex.Message };
            }

        }
    }
}
