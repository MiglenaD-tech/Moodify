using MoodifyCore.Data;
using MoodifyCore.DTO;

namespace MoodifyCore.Services
{
    public interface IPlaylistService
    {
        List<PlaylistDto> GetPlaylistsForUser(int userId);
    }
    public class PlaylistService : IPlaylistService
    {
        private readonly MoodifyDataContext dbContext;

        public PlaylistService(MoodifyDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PlaylistDto> GetPlaylistsForUser(int userId)
        {
            return dbContext.Playlists
                .Where(p => p.UserId == userId)
                .Select(p => new PlaylistDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ExternalId = p.ExternalId,
                    Platform = p.Platform,
                    ImageUrl = p.ImageUrl
                })
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
