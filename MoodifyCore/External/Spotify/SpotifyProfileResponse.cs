namespace MoodifyCore.External.Spotify
{
    public class SpotifyProfileResponse
    {
        public string Id { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Product { get; set; } = null!; // "premium", "free", etc.
        public string Type { get; set; } = null!;    // "user"
        public string Uri { get; set; } = null!;
        public string Href { get; set; } = null!;

        public SpotifyImage[]? Images { get; set; }

        public class SpotifyImage
        {
            public string Url { get; set; } = null!;
            public int? Width { get; set; }
            public int? Height { get; set; }
        }
    }
}
