using KartRacer.API.Models.Dto;
using KartRacer.API.Models.User;
using KartRacer.API.Repositories.User;
using KartRacer.API.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
     * This controller handles autntication for the API
     * It passes through auth requests to the auth service
     * 
     * TODO: Add reset password functionality
     */

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;
        public AuthController(IAuthService authService, IConfiguration configuration, IUserRepository userRepository)
        {
            _authService = authService;
            _configuration = configuration;
            _userRepository = userRepository;
            _response = new();
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            var userSettingResponse = await _userRepository.AddAsync(new KartRacer.API.Models.Data.UserSetting { Username = model.Email });
            return Ok(_response);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);

        }

        // POST: api/auth/assignRole
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);

        }
    }
}
