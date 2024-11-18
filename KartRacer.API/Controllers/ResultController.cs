using KartRacer.API.Models.Dto;
using KartRacer.API.Repositories.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartRacer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepsoitory;
        private readonly ILogger<ResultController> _logger;

        public ResultController(IResultRepository resultRepository, ILogger<ResultController> iLogger)
        {
            this._logger = iLogger;
            this._resultRepsoitory = resultRepository;
        }

        // GET: api/result/sessionResults
        [HttpGet("SessionResults/{sessionId}")]
        public async Task<ActionResult<ResponseDto>> GetSessionResultsAsync(int sessionId)
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var results = await _resultRepsoitory.GetSessionResultsAsync(sessionId);
                resp = results;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetSessionResultsAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/result/sessionResultLapsForDriver
        [HttpGet("SessionResultLapsForDriver")]
        public async Task<ActionResult<ResponseDto>> GetSessionResultsForDriverAsync(ResultRequestDto resultRequest)
        {
            try
            {
                ResponseDto resp = new ResponseDto();

                var results = await _resultRepsoitory.GetSessionResultLapsForDriverAsync(resultRequest.SessionId, resultRequest.DriverId  );
                resp.Result = results;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetSessionResultsForDriverAsync)}");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
