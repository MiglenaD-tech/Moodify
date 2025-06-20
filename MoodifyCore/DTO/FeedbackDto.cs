namespace MoodifyCore.DTO
{
    public class FeedbackDto
    {
        public int OwnerUserId { get; set; }
        public int? PlaylistId { get; set; }
        public int? ActivityId { get; set; }
        public bool IsCorrect { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
} 