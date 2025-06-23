using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoodifyCore.Data;
using MoodifyCore.DTO.Auth;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoodifyCore.Services
{
    public interface IAuthService
    {
        Task<User?> GetUserByIdAsync(int userId);
        string GenerateJwtToken(User user, string deviceId);
        Task<GoogleLoginResponseDto> LoginWithGoogleAsync(GoogleLoginRequestDto requestDto);
        Task<User> CreateUserFromGoogleAsync(GoogleJsonWebSignature.Payload payload, string deviceId);
    }
    public class AuthService : IAuthService
    {
        private readonly MoodifyDataContext dbContext;

        private readonly IConfiguration configuration;

        public AuthService(MoodifyDataContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await dbContext.Users.FindAsync(userId);
        }


        public async Task<GoogleLoginResponseDto> LoginWithGoogleAsync(GoogleLoginRequestDto requestDto)
        {
            // 1. Потърси потребител с такъв DeviceId
            var userByDevice = await dbContext.Users.FirstOrDefaultAsync(u => u.DeviceId == requestDto.DeviceId);

            // 2. Ако намериш такъв, върни го директно (автоматичен вход)
            if (userByDevice != null)
            {
                var token = GenerateJwtToken(userByDevice, userByDevice.DeviceId!);
                return new GoogleLoginResponseDto
                {
                    UserId = userByDevice.Id,
                    Email = userByDevice.Email,
                    JwtToken = token,
                    Message = "Auto-login with device"
                };
            }

            // 3. Иначе продължи с валидация на Google Token
            GoogleJsonWebSignature.Payload payload;
            // Валидиране на Google токен
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(requestDto.IdToken);
                if (payload.ExpirationTimeSeconds.HasValue &&
                    DateTimeOffset.FromUnixTimeSeconds(payload.ExpirationTimeSeconds.Value) < DateTimeOffset.UtcNow)
                    {
                        return new GoogleLoginResponseDto { Message = "Expired Google token" };
                    }

            }
            catch (Exception)
            {
                return new GoogleLoginResponseDto
                {
                    Message = "Invalid Google token"
                };
            }
            // Търсене по GoogleId или Email + DeviceId
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u =>
                    u.GoogleId == payload.Subject || (u.Email == payload.Email && u.DeviceId == requestDto.DeviceId));

            var isNewUser = false;

            if (user == null)
            {
                isNewUser = true;
                user = await CreateUserFromGoogleAsync(payload, requestDto.DeviceId);
            }
            else if (user.DeviceId != requestDto.DeviceId)
            {
                user.DeviceId = requestDto.DeviceId;
                await dbContext.SaveChangesAsync();
            }

            var jwt = GenerateJwtToken(user, requestDto.DeviceId);

            return new GoogleLoginResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsNewUser = isNewUser,
                JwtToken = jwt
            };
        }

        public async Task<User> CreateUserFromGoogleAsync(GoogleJsonWebSignature.Payload payload, string deviceId)
        {
            var user = new User
            {
                GoogleId = payload.Subject,
                Email = payload.Email,
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                DeviceId = deviceId,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public string GenerateJwtToken(User user, string deviceId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("device_id", deviceId)
        };

            if (!string.IsNullOrEmpty(user.TimeZone))
                claims.Add(new Claim("time_zone", user.TimeZone));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
