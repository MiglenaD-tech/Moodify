using MoodifyCore.Data;
using MoodifyCore.DTO;

namespace MoodifyCore.Services
{
    public interface IActivityPlaylistService
    {
        ActivityPlaylist GetById(int id);
        List<ActivityPlaylist> GetListOfActivityPlaylistsByUser(int userId);
        void Link(ActivityPlaylist entity);
        void Unlink(int id);
    }
    public class ActivityPlaylistService : IActivityPlaylistService
    {
        private readonly MoodifyDataContext dbContext;

        public ActivityPlaylistService(MoodifyDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActivityPlaylist GetById(int id)
        {
            var activityPlaylistById = dbContext.ActivityPlaylists.FirstOrDefault(x => x.Id == id);
            if (activityPlaylistById == null)
                return null;

            return activityPlaylistById;
        }

        public List<ActivityPlaylist> GetListOfActivityPlaylistsByUser(int userId)
        {
            var activityPlaylists = dbContext.ActivityPlaylists
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.LinkedAt)
                .ToList();

            if (activityPlaylists == null)
                return null;

            return activityPlaylists;
        }

        public void Link(ActivityPlaylist entity)
        {
            dbContext.ActivityPlaylists.Add(entity);
            dbContext.SaveChanges();
        }

        public void Unlink(int id)
        {
            var entity = dbContext.ActivityPlaylists.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dbContext.ActivityPlaylists.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
