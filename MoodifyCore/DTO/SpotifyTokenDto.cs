﻿namespace MoodifyCore.DTO
{
    public class SpotifyTokenDto
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public int ExpiresIn { get; set; }
    }
}
