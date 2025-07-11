namespace MoodifyCore.DTO
{
    public class FeedbackCreateDto
    {
        public int UserId { get; set; }
        public int? PlaylistId { get; set; }
        public int? ActivityId { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class FeedbackDto
    {
        public int UserId { get; set; }
        public int? PlaylistId { get; set; }
        public int? ActivityId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime FeedbackTime { get; set; }
    }
} 