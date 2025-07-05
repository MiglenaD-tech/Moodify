using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.DTO;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;
        private readonly IMapper mapper;


        public ActivityController(IActivityService activityService, IMapper mapper)
        {
            this.activityService = activityService;
            this.mapper = mapper;
        }

        [HttpGet("getAllActivities")]
        public IActionResult GetAllActivities()
        {
            var activities = activityService.GetAllActivities();

            var activitiesDto = mapper.Map<List<ActivityDto>>(activities);
            return Ok(activitiesDto);
        }

        [HttpGet("activityById{id}")]
        public IActionResult GetById(int id)
        {
            var activity = activityService.GetById(id);
            if (activity == null) 
                return NotFound();

            var activityDto = mapper.Map<ActivityDto>(activity);
            return Ok(activityDto);
        }

        [HttpGet("{activityId}/playlists")]
        public IActionResult GetPlaylistsForActivity(int activityId)
        {
            var playlistsBasedByActivity = activityService.GetPlaylistsByActivity(activityId);

            // мапване към DTO
            var playlistDtos = mapper.Map<List<PlaylistDto>>(playlistsBasedByActivity);

            return Ok(playlistDtos);
        }
    }
}
