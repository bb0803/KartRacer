using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Auth;
using KartRacer.API.Repositories.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KartRacer.API.Repositories.Setups
{
    public class SetupRepository : ISetupRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<SetupRepository> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public SetupRepository(DataContext content, ILogger<SetupRepository> logger, IAuthRepository authRepository, IHttpContextAccessor contextAccessor)
        {
            this._context = content;
            this._logger = logger;
            this._authRepository = authRepository;
            this._contextAccessor = contextAccessor;
        }
        public async Task<int> ChangeAxleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> ChangeChassisAsync(int chassisId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ChangeCurrentSetupAsync(Setup setup)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ChangeTyreAsync(int newTyre)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> LoadSetupFavouriteAsync(int setupId)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var drv = _context.Drivers.Where(d => d.Id == usr.DriverId).FirstOrDefault();
                drv.CurrentSetupId = setupId;
                _context.Drivers.Update(drv);
                _context.SaveChanges();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The driver was successfully created.",
                    Result = drv
                };

            }
            catch (Exception ex)
            {
                _logger.LogError("Load Setup failed - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Load setup failed - " + ex.Message
                };
            }

        }

        public async Task<ResponseDto> SaveSetupFavouriteAsync(SetupFavourite setupFavorite)
        {
            //Save list of setups in SetupFavourites
            try
            {
                await _context.SetupFavourites.AddAsync(setupFavorite);
                await _context.SaveChangesAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The driver was successfully created.",
                    Result = setupFavorite
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

        //public async Task<ResponseDto> SaveSetupAsync(Setup setup)
        //{
        //    try
        //    {
        //        await _context.Setups.AddAsync(setup);
        //        await _context.SaveChangesAsync();
        //        return new ResponseDto()
        //        {
        //            IsSuccess = true,
        //            Message = "The setup was successfully saved.",
        //            Result = setup
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("The attempt to save the setup failed - " + ex.Message);
        //        return new ResponseDto()
        //        {
        //            IsSuccess = false,
        //            Message = "The attempt to save the setup failed - " + ex.Message
        //        };
        //    }
        //}

        public async Task<bool> SetupExists(Setup setup)
        {
            return false;
        }

        public async Task<ResponseDto> GetSetupFavorites()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var setupFavourites = await _context.Database.SqlQuery<SetupFavouriteDto>($"Exec GetSetupFavourites @Username = {usr.Username}").ToListAsync();
                //var setupFavourites = await _context.SetupFavourites.Where(s => s.DriverId == usr.DriverId).ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The setup was successfully saved.",
                    Result = setupFavourites
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("The attempt to get favourites failed failed - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "The attempt to get favourites failed failed - " + ex.Message
                };
            }
        }

        public async Task<ResponseDto> GetSetupAsync()
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var setup = await _context.Database.SqlQuery<Setup>($"Exec GetCurrentSetup @Username = {usr.Username}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The setup was successfully retrieved.",
                    Result = setup
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve set ups - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "The attempt to get setup failed - " + ex.Message
                };
            }
        }

        public async Task<ResponseDto> GetAllSetupsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> SaveSetupAsync(Setup setup)
        {
            try
            {
                var usr = await _authRepository.GetUserAsync();
                var saveSetup = await _context.Database.SqlQuery<Setup>($"Exec SaveSetup @Username = {usr.Username}, @FrontWidth = {setup.FrontWidth}, @Camber = {setup.Camber}, @Caster = {setup.Caster}, @Toe = {setup.Toe}, @RearWidth = {setup.RearWidth}, @rearAxle = {setup.RearAxle}, @FrontSprcoket = {setup.FrontSprocket}, @RearSprocket = {setup.RearSprocket}, @TyrePressure = {setup.TyrePressure}").ToListAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "The setup was successfully saved.",
                    Result = setup
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save set up - " + ex.Message);
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "The attempt to save setup failed - " + ex.Message
                };
            }
        }
    }
}
