namespace MoodifyCore.DTO
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ExternalId { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public int OwnerUserId { get; set; }
    }
} 