using MoodifyCore.Data;
using MoodifyCore.DTO;
using MoodifyCore.External.Spotify;
using System.Text.Json;

namespace MoodifyCore.Services
{
    public interface IUserService
    {
        User? GetById(int id);
        void UpdateTimeZone(int userId, string timeZone);
        //User? UpdateSpotifyTokens(int id, string accessToken, string refreshToken);

        void UpdateSpotifyTokens(int userId, string accessToken, string refreshToken, int expiresInSeconds);

        Task<string?> GetValidSpotifyAccessTokenAsync(int userId);
        string? EnsureValidAccessToken(int userId);
    }

    public class UserService : IUserService
    {
        private readonly MoodifyDataContext dbContext;
        private readonly ISpotifyService spotifyService;

        public UserService(MoodifyDataContext dbContext, ISpotifyService spotifyService)
        {
            this.dbContext = dbContext;
            this.spotifyService = spotifyService;
        }

        public User? GetById(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateTimeZone(int userId, string timeZone)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.TimeZone = timeZone;
                dbContext.SaveChanges();
            }
        }
        
        /*
        public User? UpdateSpotifyTokens(int id, string accessToken, string refreshToken)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) 
                return null;

            user.SpotifyAccessToken = accessToken;
            user.SpotifyRefreshToken = refreshToken;
            dbContext.SaveChanges();

            return user;
        }
        */
       
        public void UpdateSpotifyTokens(int userId, string accessToken, string refreshToken, int expiresInSeconds)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.SpotifyAccessToken = accessToken;
                user.SpotifyRefreshToken = refreshToken;
                user.SpotifyTokenExpiresAt = DateTime.UtcNow.AddSeconds(expiresInSeconds);
                dbContext.SaveChanges();
            }
        }

        public async Task<string?> GetValidSpotifyAccessTokenAsync(int userId)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || string.IsNullOrEmpty(user.SpotifyRefreshToken))
                return null;

            // Ако access token-ът е валиден – използвай го
            if (user.SpotifyTokenExpiresAt > DateTime.UtcNow.AddMinutes(10))
                return user.SpotifyAccessToken;

            // Изтекъл токен – изпрати заявка за refresh
            using var http = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", user.SpotifyRefreshToken!),
                new KeyValuePair<string, string>("client_id", "YOUR_CLIENT_ID"), // от spotify dev console
                new KeyValuePair<string, string>("client_secret", "YOUR_CLIENT_SECRET"),
            });

            var response = await http.PostAsync("https://accounts.spotify.com/api/token", content);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<SpotifyTokenResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (tokenData == null || string.IsNullOrEmpty(tokenData.AccessToken))
                return null;

            user.SpotifyAccessToken = tokenData.AccessToken;
            user.SpotifyTokenExpiresAt = DateTime.UtcNow.AddSeconds(tokenData.ExpiresIn);

            // Spotify може понякога да върне нов refresh_token
            if (!string.IsNullOrEmpty(tokenData.RefreshToken))
                user.SpotifyRefreshToken = tokenData.RefreshToken;

            dbContext.SaveChanges();

            return user.SpotifyAccessToken;
        }

        public string? EnsureValidAccessToken(int userId)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || string.IsNullOrEmpty(user.SpotifyAccessToken)) return null;

            if (user.SpotifyTokenExpiresAt != null && user.SpotifyTokenExpiresAt > DateTime.UtcNow)
            {
                // Access token все още е валиден
                return user.SpotifyAccessToken;
            }

            if (string.IsNullOrEmpty(user.SpotifyRefreshToken)) 
                return null;

            var tokenResponse = spotifyService.RefreshAccessToken(user.SpotifyRefreshToken!);
            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken)) return null;

            // Обновяваме в базата
            user.SpotifyAccessToken = tokenResponse.AccessToken;
            user.SpotifyTokenExpiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);

            // Spotify понякога не връща нов refresh token → пазим стария
            if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
            {
                user.SpotifyRefreshToken = tokenResponse.RefreshToken;
            }

            dbContext.SaveChanges();
            return user.SpotifyAccessToken;
        }
        
    }
}
