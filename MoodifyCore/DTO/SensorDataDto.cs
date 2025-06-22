using System;

namespace MoodifyCore.DTO
{
    public class SensorDataCreateDto
    {
        public int UserId { get; set; }
        public string? DeviceId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int? HeartRate { get; set; }
        public int? StepCount { get; set; }
        public string? ActivityType { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class SensorDataDto
    {
        public int Id { get; set; }
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