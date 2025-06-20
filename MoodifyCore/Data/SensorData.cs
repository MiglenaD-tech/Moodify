using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodifyCore.Data;

[Table("SensorData")]
public class SensorData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [StringLength(200)]
    public string? DeviceId { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    public int? HeartRate { get; set; }

    public int? StepCount { get; set; }

    [StringLength(200)]
    public string? ActivityType { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
} 