using MoodifyCore.Data;

namespace MoodifyCore.Services
{
    public interface IActivityService
    {
        List<Activity> GetAllActivities();
        Activity? GetById(int id);
        List<Playlist> GetPlaylistsByActivity(int activityId);

    }

    public class ActivityService : IActivityService
    {
        private readonly MoodifyDataContext dbContext;

        public ActivityService(MoodifyDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Activity> GetAllActivities()
        {
            var activities =  dbContext.Activities
                .OrderBy(a => a.Name)
                .ToList();

            return activities;
        }

        public Activity? GetById(int id)
        {
            var activity = dbContext.Activities.FirstOrDefault(x => x.Id == id);

            return activity;
        }

        public List<Playlist> GetPlaylistsByActivity(int activityId)
        {
            return (from ap in dbContext.ActivityPlaylists
                    join p in dbContext.Playlists on ap.PlaylistId equals p.Id
                    where ap.ActivityId == activityId
                    select p).ToList();
        }
    }
}
