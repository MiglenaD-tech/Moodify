using System.ComponentModel.DataAnnotations;

namespace MoodifyCore.Data
{
    public class ActivityPlaylist
    {
        [Key]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int ActivityId { get; set; }
        public DateTime LinkedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
    }
}
