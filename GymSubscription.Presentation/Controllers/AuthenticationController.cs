using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.UserDto;

namespace GymSubscription.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }


        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);
            if (!result.Item1.Succeeded)
            {
                foreach (var error in result.Item1.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);

            }
            try
            {
                BackgroundJob.Enqueue(() => _service.EmailService.AccountEmailAsync(userForRegistrationDto, result.Item2));
            }catch (Exception ex)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailDto confirmEmailDto)
        {
            if(string.IsNullOrEmpty(confirmEmailDto.UserId) || string.IsNullOrEmpty(confirmEmailDto.Token))
            {
                return BadRequest(ModelState);
            } 

            var result = await _service.AuthenticationService.ConfirmEmail(confirmEmailDto);
            if (!result.Succeeded)
            {
                return StatusCode(400);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }

        [AllowAnonymous]
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string emailOrUserName)
        {


            var result = await _service.AuthenticationService.ForgotPassword(emailOrUserName);
            if (result is null)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(PasswordResetDto resetPassword)
        {
            var result = await _service.AuthenticationService.ResetPassword(resetPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {

            var result = await _service.AuthenticationService.ChangePassword(changePasswordDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo(string email, UpdateUserDto updateUser)
        {
            await _service.AuthenticationService.UpdateUserInfo(email, updateUser);

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet("getalluser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _service.AuthenticationService.GetAllUserInfo();

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser(string email)
        {
            var result = await _service.AuthenticationService.GetUserByEmail(email);

            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Deleteuser(string email)
        {
            await _service.AuthenticationService.DeleteUser(email);

            return NoContent();
        }
       
    }
}

