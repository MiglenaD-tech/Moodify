using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodifyCore.Data;

public class Activity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Emoji { get; set; } // Optional
    
    [ForeignKey("UserId")]
    public int UserId { get; set; }
} 