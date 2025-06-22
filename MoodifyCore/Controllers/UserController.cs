using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.DTO;
using MoodifyCore.Extensions;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.GetUserId(); // сега можеш лесно да вземеш текущия потребител
            return Ok(userId);
        }

        [HttpGet("userById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = userService.GetById(id);
            if (user == null) return NotFound();

            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("update-timezone")]
        public IActionResult UpdateTimeZone([FromQuery] int id, [FromQuery] string timeZone)
        {
            userService.UpdateTimeZone(id, timeZone);
            return Ok();
        }

        [HttpPost("update-spotify-tokens")]
        public IActionResult UpdateSpotifyTokens([FromBody] SpotifyTokenDto tokenDto)
        {
            userService.UpdateSpotifyTokens(tokenDto.UserId, tokenDto.AccessToken, tokenDto.RefreshToken, tokenDto.ExpiresIn);
            return Ok();
        }
    }
}
