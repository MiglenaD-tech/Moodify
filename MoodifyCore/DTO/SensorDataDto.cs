using System;

namespace MoodifyCore.DTO
{
    public class SensorDataDto
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public int? HeartRate { get; set; }
        public int? StepCount { get; set; }
        public string? ActivityType { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
} 