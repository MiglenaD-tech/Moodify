using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.Data;
using MoodifyCore.DTO;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityPlaylistController : ControllerBase
    {
        private readonly IActivityPlaylistService activityPlaylistService;
        private readonly IMapper mapper;

        public ActivityPlaylistController(IActivityPlaylistService activityPlaylistService, IMapper mapper)
        {
            this.activityPlaylistService = activityPlaylistService;
            this.mapper = mapper;
        }

        [HttpGet("ativityPlaylistById/{id}")]
        public ActionResult<ActivityPlaylistDto> GetById(int id)
        {
            var entity = activityPlaylistService.GetById(id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<ActivityPlaylistDto>(entity);
            return Ok(dto);
        }

        [HttpGet("activityPlaylistsByUser/{userId}")]
        public ActionResult<List<ActivityPlaylistDto>> GetListOfActivityPlaylistsByUser(int userId)
        {
            var entities = activityPlaylistService.GetListOfActivityPlaylistsByUser(userId);
            var dtos = mapper.Map<List<ActivityPlaylistDto>>(entities);
            return Ok(dtos);
        }

        [HttpPost("linkActivityPlaylist")]
        public IActionResult Link([FromBody] ActivityPlaylistLinkDto dto)
        {
            var entity = new ActivityPlaylist
            {
                PlaylistId = dto.PlaylistId,
                ActivityId = dto.ActivityId,
                UserId = dto.UserId,
                LinkedAt = DateTime.UtcNow
            };

            activityPlaylistService.Link(entity);
            return Ok("Activity linked to playlist successfully.");
        }

        [HttpDelete("unlink/{id}")]
        public IActionResult Unlink(int id)
        {
            activityPlaylistService.Unlink(id);
            return Ok("Link removed.");
        }
    }
}
