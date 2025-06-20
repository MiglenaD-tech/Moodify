using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodifyCore.Data;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ExternalId { get; set; } = null!; // Spotify/YouTube/etc
    public string Platform { get; set; } = null!; // "Spotify", "YouTube", etc
    public int UserId { get; set; }
} 