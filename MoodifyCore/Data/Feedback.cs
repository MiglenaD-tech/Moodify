using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodifyCore.Data;

public class Feedback
{
    [Key]
    public int Id { get; set; }
    public DateTime FeedbackTime { get; set; }
    public int UserId { get; set; }
    public int? PlaylistId { get; set; } 
    public int? ActivityId { get; set; }
    public bool IsCorrect { get; set; } //yes or no 
} 