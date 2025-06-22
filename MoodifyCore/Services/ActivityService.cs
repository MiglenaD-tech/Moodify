using Microsoft.EntityFrameworkCore;
using MoodifyCore.Data;
using MoodifyCore.DTO;

namespace MoodifyCore.Services
{
    public interface IActivityService
    {
        List<Activity> GetAllActivities();
        Activity? GetById(int id);
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
    }
}
