using System.ComponentModel.DataAnnotations;

namespace MoodifyCore.Data
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Кога се е случило

        public string? TriggeredBy { get; set; } // WearOS / Android / Manual / AI
        public string? Note { get; set; }
    }
}
