using MoodifyCore.Data;

namespace MoodifyCore.Services
{
    public interface IFeedbackService
    {
        Feedback GetById(int id);
        List<Feedback> GetFeedbacksByUser(int userId);
        void AddFeedback(Feedback entity);
    }
    public class FeedbackService : IFeedbackService
    {
        private readonly MoodifyDataContext dbContext;

        public FeedbackService(MoodifyDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Feedback GetById(int id)
        {
            var feedbackById = dbContext.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedbackById == null)
                return null;

            return feedbackById;
        }

        public List<Feedback> GetFeedbacksByUser(int userId)
        {
            var feedbacksByUser = dbContext.Feedbacks
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.FeedbackTime)
                .ToList();

            if (feedbacksByUser.Count == 0)
                return null ;

            return feedbacksByUser;
        }

        public void AddFeedback(Feedback entity)
        {
            entity.FeedbackTime = DateTime.UtcNow;
            dbContext.Feedbacks.Add(entity);
            dbContext.SaveChanges();
        }
    }
}
