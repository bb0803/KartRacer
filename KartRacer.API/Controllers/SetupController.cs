using KartRacer.API.Models.Data;
using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Setups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartRacer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SetupController : ControllerBase
    {
        private readonly ISetupRepository _setupRepository;
        private readonly ILogger<SetupController> _logger;

        public SetupController(ISetupRepository setupRepository, ILogger<SetupController> logger)
        {
            this._setupRepository = setupRepository;
            this._logger = logger;
        }

        // GET: api/setup/favourites
        [HttpGet("Favourites")]
        public async Task<ActionResult<ResponseDto>> GetSetupFavouritesAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var setupFavourites = await _setupRepository.GetSetupFavorites();
                resp = setupFavourites;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetSetupFavouritesAsync)}");
                return StatusCode(500, ex.Message);
            }
        }
        // PUT: api/setup/axle
        [HttpPut("Axle")]
        public async Task<ActionResult<ResponseDto?>> ChangeAxleAsync(int Axle)
        {
            throw new NotImplementedException();
        }

        //// Post: api/setup/save
        //[HttpPost("Save")]
        //public async Task<ActionResult<ResponseDto?>> SaveSetupAsync(Models.Data.Setup setup)
        //{
        //    try
        //    {
        //        ResponseDto resp = new ResponseDto();
        //        var setupFavourites = await _setupRepository.SaveSetupAsync(setup);
        //        resp.Result = setupFavourites;
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error Performing GET in {nameof(SaveSetupAsync)}");
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        //// PUT: api/setup/load
        //[HttpPut("Load")]
        //public async Task<ActionResult<ResponseDto?>> LoadSetupAsync()
        //{
        //    try
        //    {
        //        ResponseDto resp = new ResponseDto();
        //        var setupFavourites = await _setupRepository.Load(setup);
        //        resp.Result = setupFavourites;
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error Performing GET in {nameof(SaveSetupAsync)}");
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        // Put: api/setup
        [HttpPut]
        public async Task<ActionResult<ResponseDto?>> ChangeCurrentSetupAsync(Models.Data.Setup setup)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var currentSetup = await _setupRepository.ChangeCurrentSetupAsync(setup);
                resp.Result = currentSetup;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(ChangeCurrentSetupAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // Put: api/setup/tyre
        [HttpGet("Tyre")]
        public async Task<ActionResult<ResponseDto?>> ChangeTyreAsync(int Tyre)
        {
            throw new NotImplementedException();
        }

        // PUT: api/setup/chassis
        [HttpPost("Chassis")]
        public async Task<ActionResult<ResponseDto?>> ChangeChassisAsync(int Chassis)
        {
            throw new NotImplementedException();
        }

        // Put: api/setup/favourites/save
        [HttpPut("Favourites")]
        public async Task<ActionResult<ResponseDto>> SaveSetupFavouriteAsync(SetupFavourite setupFavourite) 
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var setup = await _setupRepository.SaveSetupFavouriteAsync(setupFavourite);
                resp.Result = setup;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(SaveSetupFavouriteAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // Put: api/setup/favourites/load
        [HttpGet("Favourites/Load")]
        public async Task<ActionResult<ResponseDto>> LoadSetupFavouriteAsync(int setupId)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var setupFavourite = await _setupRepository.LoadSetupFavouriteAsync(setupId);
                resp.Result = setupFavourite;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(LoadSetupFavouriteAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/setup/exists
        [HttpGet("exists")]
        public async Task<ActionResult<ResponseDto>> SetupExistsAsync(Models.Data.Setup setup)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var exists = await _setupRepository.SetupExists(setup);
                resp.Result = exists;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(SetupExistsAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/setup/
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetSetupAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var data = await _setupRepository.GetSetupAsync();
                resp = data;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetSetupAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/setup/all
        [HttpGet("all")]
        public async Task<ActionResult<ResponseDto>> GetAllSetupsAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var exists = await _setupRepository.GetAllSetupsAsync();
                resp.Result = exists;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAllSetupsAsync)}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
