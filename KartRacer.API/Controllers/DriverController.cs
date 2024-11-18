using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using KartRacer.API.Repositories.Drivers;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ILogger<DriverController> _logger;

        public DriverController(IDriverRepository driverRepository, ILogger<DriverController> logger)
        {
            this._driverRepository = driverRepository;
            this._logger = logger;
        }

        // GET: api/driver
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetDriverAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var driver = await _driverRepository.GetDriverAsync();
                resp.Result = driver;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetDriverAsync)}");
                return StatusCode(500, ex.Message);
            }
        }


        // POST: api/driver
        [HttpPost]
        public async Task<ActionResult> CreateDriverAsync([FromBody] DriverNameDto driverName)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var results = await _driverRepository.CreateDriverAsync(driverName.DriverName);

                return Ok(results);
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                _logger.LogError(ex, $"Error Performing POST in {nameof(CreateDriverAsync)}", driverName);
                resp.IsSuccess = false;
                resp.Message = "Create Driver - " + ex.Message;
                return BadRequest(resp);
            }

        }

        // PUT: api/driver
        [HttpPut]
        public async Task<ActionResult<ResponseDto>> UpdateDriverAsync(Models.Data.Driver driver)
        {
            try
            {
                var results = await _driverRepository.UpdateDriverAsync(driver);
                return results;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                _logger.LogError(ex, $"Error Performing PUT in {nameof(UpdateDriverAsync)}", driver);
                resp.IsSuccess = false;
                resp.Message = "Update Driver - " +  ex.Message;
                return resp;
            }
            
        }
        // GET: api/driver/currentEngines
        [HttpGet("CurrentEngines")]
        public async Task<ActionResult<ResponseDto>> GetCurrentEnginesAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var currentEngine = await _driverRepository.GetCurrentEnginesAsync();
                resp.Result = currentEngine;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetCurrentEnginesAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/driver/currentChassis
        [HttpGet("CurrentChassis")]
        public async Task<ActionResult<ResponseDto>> GetCurrentChassisAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var currentChassis = await _driverRepository.GetCurrentChassisAsync();
                resp.Result = currentChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetCurrentChassisAsync)}");
                return StatusCode(500, ex.Message);
            }
        }
        // GET: api/driver/currentParts
        [HttpGet("CurrentParts")]
        public async Task<ActionResult<ResponseDto>> GetCurrentPartsAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var currentChassis = await _driverRepository.GetCurrentPartsAsync();
                resp = currentChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetCurrentPartsAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
