using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MoodifyCore.External.Spotify;
using MoodifyCore.Services;
using System.Web;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyService spotifyService;
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public SpotifyController(ISpotifyService spotifyService, IUserService userService, IConfiguration configuration)
        {
            this.spotifyService = spotifyService;
            this.userService = userService;
            this.configuration = configuration;
        }

        /*
        [HttpGet("login")]
        public IActionResult Login()
        {
            var clientId = "твоя-client-id";
            var redirectUri = "https://твояапи/api/spotify/callback";
            var scope = "playlist-read-private";
            var state = Guid.NewGuid().ToString(); // За сигурност

            var url = $"https://accounts.spotify.com/authorize?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope={scope}&state={state}";
            return Redirect(url);
        }*/

        // STEP 1: Redirect user to Spotify login
        [HttpGet("login")]
        public IActionResult Login([FromQuery] int userId)
        {
            var clientId = configuration["Spotify:ClientId"];
            var redirectUri = configuration["Spotify:RedirectUri"];
            var scope = "playlist-read-private";
            var state = userId.ToString(); // Запазваме userId в state + съхраняваме userId за callback-а

            var authUrl = $"https://accounts.spotify.com/authorize?response_type=code" +
                          $"&client_id={clientId}" +
                          $"&redirect_uri={HttpUtility.UrlEncode(redirectUri)}" +
                          $"&scope={HttpUtility.UrlEncode(scope)}" +
                          $"&state={HttpUtility.UrlEncode(state)}";

            return Redirect(authUrl);
        }


        // STEP 2: Callback from Spotify (Spotify will redirect here with code & state)
        [HttpGet("callback")]
        public IActionResult Callback([FromQuery] string code, [FromQuery] string state)
        {
            if (!int.TryParse(state, out var userId))
                return BadRequest("Invalid state parameter (userId).");

            var tokenResponse = spotifyService.ExchangeCodeForTokens(code);
            if (tokenResponse == null)
                return BadRequest("Unable to retrieve access token from Spotify.");

            // Записваме в базата
            userService.UpdateSpotifyTokens(
                userId,
                tokenResponse.AccessToken,
                tokenResponse.RefreshToken ?? "", // някои случаи не връща нов
                tokenResponse.ExpiresIn
            );

            return Ok("Spotify account linked successfully!");
        }

        /// STEP 3: Sync playlists for a user
        [HttpPost("sync-playlists/{userId}")]
        public IActionResult SyncPlaylists(int userId)
        {
            var user = userService.GetById(userId);
            if (user == null)
                return BadRequest("User not found or not linked to Spotify.");

            var accessToken = userService.EnsureValidAccessToken(userId);
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized("Spotify token missing or expired.");

            var playlists = spotifyService.GetUserPlaylists(accessToken);
            if (playlists == null || playlists.Items.Count == 0)
                return BadRequest("Unable to retrieve playlists.");

            spotifyService.SaveUserPlaylists( userId, playlists.Items );

            return Ok("Playlists synced successfully.");
        }
    }
}
