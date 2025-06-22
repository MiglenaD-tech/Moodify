using System;
using System.ComponentModel.DataAnnotations;

namespace MoodifyCore.Data;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? GoogleId { get; set; }

    [StringLength(200)]
    public string? DeviceId { get; set; }
    public string? SpotifyAccessToken { get; set; }
    public string? SpotifyRefreshToken { get; set; }
    public DateTime? SpotifyTokenExpiresAt { get; set; }
    public string? TimeZone { get; set; }
}