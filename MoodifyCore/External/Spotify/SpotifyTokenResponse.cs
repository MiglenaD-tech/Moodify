namespace MoodifyCore.External.Spotify
{
    public class SpotifyTokenResponse
    {
        public string AccessToken { get; set; } = null!;
        public string TokenType { get; set; } = null!;
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
        public string? Scope { get; set; }
    }
}
