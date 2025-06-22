using Microsoft.EntityFrameworkCore;
using MoodifyCore.Data;
using MoodifyCore.External.Spotify;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MoodifyCore.Services
{
    public interface ISpotifyService
    {
        SpotifyTokenResponse? ExchangeCodeForTokens(string code);
        SpotifyTokenResponse? RefreshAccessToken(string refreshToken);
        SpotifyPlaylistsResponse? GetUserPlaylists(string accessToken);
        void SaveUserPlaylists(int userId, List<SpotifyPlaylistItem> items);
    }
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient httpClient;
        private readonly MoodifyDataContext dbContext;
        private readonly IConfiguration config;

        public SpotifyService(HttpClient httpClient, MoodifyDataContext dbContext, IConfiguration config    )
        {
            this.httpClient = httpClient;
            this.dbContext = dbContext;
            this.config = config;
        }

        public SpotifyTokenResponse? ExchangeCodeForTokens(string code)
        {
            var clientId = config["Spotify:ClientId"];
            var clientSecret = config["Spotify:ClientSecret"];
            var redirectUri = config["Spotify:RedirectUri"];

            var body = new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri!},
                {"client_id", clientId!},
                {"client_secret", clientSecret!}
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token")
            {
                Content = new FormUrlEncodedContent(body)
            };

            var response = httpClient.Send(request);
            if (!response.IsSuccessStatusCode) return null;

            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<SpotifyTokenResponse>(content);
        }

        public SpotifyTokenResponse? RefreshAccessToken(string refreshToken)
        {
            var clientId = config["Spotify:ClientId"];
            var clientSecret = config["Spotify:ClientSecret"];

            var body = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token"},
                {"refresh_token", refreshToken!},
                {"client_id", clientId!},
                {"client_secret", clientSecret!}
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token")
            {
                Content = new FormUrlEncodedContent(body)
            };

            var response = httpClient.Send(request);
            if (!response.IsSuccessStatusCode) return null;

            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<SpotifyTokenResponse>(content);
        }

        public SpotifyPlaylistsResponse? GetUserPlaylists(string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spotify.com/v1/me/playlists");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = httpClient.Send(request);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<SpotifyPlaylistsResponse>(content);
        }

        public void SaveUserPlaylists(int userId, List<SpotifyPlaylistItem> items)
        {
            // Изтриваме старите плейлисти
            var existing = dbContext.Playlists.Where(p => p.UserId == userId).ToList();
            dbContext.Playlists.RemoveRange(existing);

            foreach (var item in items)
            {
                dbContext.Playlists.Add(new Playlist
                {
                    UserId = userId,
                    Name = item.Name,
                    ExternalId = item.Id,
                    Platform = "Spotify",
                    ImageUrl = item.Images?.FirstOrDefault()?.Url
                });
            }
            dbContext.SaveChanges();
        }
    }
}