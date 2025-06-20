using System;
using System.ComponentModel.DataAnnotations;

namespace MoodifyCore.Data;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? SpotifyAccessToken { get; set; }
}