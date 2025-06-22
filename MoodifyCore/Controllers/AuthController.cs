using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.DTO.Auth;
using MoodifyCore.Extensions;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;


        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("google/login")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleLoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.LoginWithGoogleAsync(request);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var userId = User.GetUserId();
            var deviceId = User.GetDeviceId();

            if (userId == null || string.IsNullOrEmpty(deviceId))
                return Unauthorized("Invalid JWT claims.");

            var user = await authService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            var newJwt = authService.GenerateJwtToken(user, deviceId);

            return Ok(new { JwtToken = newJwt });
        }

    }
}
