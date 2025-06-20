namespace MoodifyCore.DTO
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Emoji { get; set; }
        public int OwnerUserId { get; set; }
    }
} 