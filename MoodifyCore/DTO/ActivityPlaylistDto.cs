using System;

namespace MoodifyCore.DTO
{
    public class LinkDto
    {
        public int PlaylistId { get; set; }
        public int ActivityId { get; set; }
    }

    public class ActivityPlaylistDto
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int ActivityId { get; set; }
        public DateTime LinkedAt { get; set; }
    }
} 