namespace MoodifyCore.External.Spotify
{
    public class SpotifyPlaylistsResponse
    {
        public string Href { get; set; } = null!;
        public int Limit { get; set; }
        public string? Next { get; set; }
        public int Offset { get; set; }
        public string? Previous { get; set; }
        public int Total { get; set; }

        public List<SpotifyPlaylistItem> Items { get; set; } = new();
    }

    public class SpotifyPlaylistItem
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Uri { get; set; } = null!;
        public string Href { get; set; } = null!;
        public string Type { get; set; } = null!;

        public SpotifyPlaylistImages[]? Images { get; set; }
        public SpotifyUser Owner { get; set; } = null!;
    }

    public class SpotifyPlaylistImages
    {
        public string Url { get; set; } = null!;
        public int? Height { get; set; }
        public int? Width { get; set; }
    }

    public class SpotifyUser
    {
        public string Id { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Uri { get; set; } = null!;
    }
}
