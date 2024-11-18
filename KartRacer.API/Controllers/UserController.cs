using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using KartRacer.API.Repositories.User;
using KartRacer.API.Models.Data;
using KartRacer.API.Repositories.Results;
using KartRacer.API.Models.Dto;

namespace R1.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        /*
         *   Changes ir retrives user settings
         * 
         */
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetUserSetting()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var userSetting = await userRepository.GetUserSettingAsync();

                if (userSetting == null)
                {
                    logger.LogWarning($"Record Not Found: {nameof(GetUserSetting)}");
                    return NotFound();
                }
                resp.Result = userSetting;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetUserSetting)}");
                return StatusCode(500, ex.Message);
            }
        }


        // PUT: api/user/changeDriverId
        [HttpPut("ChangeDriverId/{newDriverId}")]
        public async Task<IActionResult> ChangeDriverId(int newDriverId)
        {
            var userSettingDto = await userRepository.GetUserSettingAsync();

            if (userSettingDto == null)
            {
                logger.LogWarning($"{nameof(userSettingDto)} record not found in {nameof(ChangeDriverId)}");
                return NotFound();
            }

            userSettingDto.DriverId = newDriverId;

            try
            {
                await userRepository.ChangeUserSettingAsync(userSettingDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(ChangeDriverId)}");
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }

        // PUT: api/user/changeNickName
        [HttpPut("ChangeNickName")]
        public async Task<IActionResult> ChangeNickName(string nickName)
        {
            var userSettingDto = await userRepository.GetUserSettingAsync();

            if (userSettingDto == null)
            {
                logger.LogWarning($"{nameof(userSettingDto)} record not found in {nameof(ChangeNickName)}");
                return NotFound();
            }

            userSettingDto.NickName = nickName;

            try
            {
                await userRepository.ChangeUserSettingAsync(userSettingDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(ChangeNickName)}");
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }
    }
}
