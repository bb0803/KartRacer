using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using KartRacer.API.Repositories.Karts;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KartShopController : ControllerBase
    {
        private readonly IKartShopRepository _kartShopRepository;
        private readonly ILogger<KartShopController> _logger;

        public KartShopController(IKartShopRepository kartShopRepository, ILogger<KartShopController> logger)
        {
            this._kartShopRepository = kartShopRepository;
            this._logger = logger;
        }

        

        // GET: api/kartShop/availableEngines
        [HttpGet("AvailableEngines")]
        public async Task<ActionResult<ResponseDto>> GetAvailableEngines()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableEngines = await _kartShopRepository.GetAvailableEnginesAsync();
                resp.Result = availableEngines;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableEngines)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/kartShop/availableChassis
        [HttpGet("AvailableChassis")]
        public async Task<ActionResult<ResponseDto>> GetAvailableChassis()
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var availableChassis = await _kartShopRepository.GetAvailableChassisAsync();
                //var shareholderDtos = mapper.Map<IEnumerable<Shareholder>>(shareholders);
                resp.Result = availableChassis;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableChassis)}");
                return StatusCode(500, ex.Message);
            }
        }



        // POST: api/kartshop/purchaseEngine
        
        [HttpPost("PurchaseEngine")]
        public async Task<ActionResult<ResponseDto>> PurchaseEngine(SingleIntDto engine)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var results = await _kartShopRepository.PurchaseEngineAsync(engine.Id);

                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The engine was purchased successfully.";
                return resp;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                _logger.LogError(ex, $"Error Performing POST in {nameof(PurchaseEngine)}", engine);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
            
        }

        // POST: api/kartshop/purchaseChassis
        
        [HttpPost("PurchaseChassis")]
        public async Task<ActionResult<ResponseDto>> PurchaseChassis(PurchaseChassisDto chassis)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var results = await _kartShopRepository.PurchaseChassisAsync(chassis.chassisId);
                resp.Result = results;
                resp.IsSuccess = true;
                resp.Message = "The chassis was purchased successfully.";
                return resp;
            }
            catch (Exception ex)
            {
                ResponseDto resp = new ResponseDto();
                _logger.LogError(ex, $"Error Performing POST in {nameof(PurchaseChassis)}", chassis);
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return resp;
            }
        }

        // Post: api/kartshop/purchasePart
        [HttpPost("PurchasePart")]
        public async Task<ActionResult<ResponseDto>> PurchasePartAsync(SingleIntDto part)
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var partStatus = await _kartShopRepository.PurchasePartAsync(part.Id);
                resp = partStatus;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(PurchasePartAsync)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // GET: api/car/availableParts
        [HttpGet("AvailableParts")]
        public async Task<ActionResult<ResponseDto>> GetAvailableParts()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var availableParts = await _kartShopRepository.GetAvailablePartsAsync();
                resp = availableParts;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableParts)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
