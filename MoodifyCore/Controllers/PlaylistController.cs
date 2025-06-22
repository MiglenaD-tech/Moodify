using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.Data;
using MoodifyCore.DTO;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly MoodifyDataContext dbContext;
        private readonly IPlaylistService playlistService;

        public PlaylistController(IMapper mapper, MoodifyDataContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        // Връща всички плейлисти на потребителя
        [HttpGet("userPlaylists/{userId}")]
        public IActionResult GetUserPlaylists(int userId)
        {
            var playlists = playlistService.GetPlaylistsForUser(userId);

            var playlistsDto = mapper.Map<List<PlaylistDto>>(playlists);
            return Ok(playlistsDto);
        }

        // Връща плейлист по ID (ако потрябва за бъдеща функционалност)
        [HttpGet("playlistById/{id}")]
        public IActionResult GetById(int id)
        {
            var playlist = dbContext.Playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null)
                return NotFound();

            var dto = mapper.Map<PlaylistDto>(playlist);
            return Ok(dto);
        }
    }
}
