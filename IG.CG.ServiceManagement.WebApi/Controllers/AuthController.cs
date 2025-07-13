using AutoMapper;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    //[Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILoginService authService, IMapper _mapper, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity?.Name != null)
            {
                string? userId = User.Identity.Name;
                _authService.RemoveExpiredRefreshTokens(userId);
                await _authService.UserLogHistoryAsync(userId, "LogOut");
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                var userInfo = await _authService.ValidateUserAsync(loginModel);
                if (userInfo != null)
                {
                    return Ok(userInfo);
                }
                else
                {
                    return NotFound("Email id or password is not correct.");
                }
            }
        }
        [AllowAnonymous]
        [HttpPost("ValidateCustomer")]
        public async Task<IActionResult> ValidateCustomer(string mobileNo, string otp)
        {
            UserInfo? userInfo = await _authService.ValidateCustomerAsync(mobileNo, otp);
            if (userInfo != null)
            {
                return Ok(userInfo);
            }
            else
            {
                return NotFound("Otp is not correct.");
            }
        }



        [HttpPost("ChangePassword")]
        // [Authorize(Policy = "NonOtpOnly")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel loginModel)
        {
            var otpAuthenticated = User.FindFirst("OtpAuthenticated")?.Value;
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var userInfo = await _authService.ChangePasswordAsync(loginModel);
                if (userInfo != null)
                {
                    return Ok(userInfo);
                }
                else
                {
                    return NotFound("password is not correct.");
                }
            }
        }

        [HttpGet("EncryptText")]
        // [Authorize(Policy = "MobileOtpRequired")]
        public async Task<string> EncryptText(string textToEncrypt)
        {
            // var otpAuthenticated = User.FindFirst("OtpAuthenticated")?.Value;
            var encrText = await _authService.EncryptText(textToEncrypt);
            if (encrText != null)
                return encrText;
            else
                return "";
        }

        [HttpGet("DecryptText")]
        public async Task<string> DecryptText(string textToDecrypt)
        {
            var decrText = await _authService.DecryptText(textToDecrypt);
            if (decrText != null)
                return decrText;
            else
                return "";
        }

        [HttpPost("IsForgotPassword")]

        public async Task<IActionResult> IsForgotPassword(TicketListModel objT)
        {

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var userInfo = await _authService.IsForgotPassword(objT.UserId, objT.IPAddress);
                if (userInfo != null)
                {
                    return Ok(userInfo);
                }
                else
                {
                    return NotFound("not correct.");
                }
            }
        }
    }
}
