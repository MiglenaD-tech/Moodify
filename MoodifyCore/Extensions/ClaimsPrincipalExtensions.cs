using System.Security.Claims;

namespace MoodifyCore.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new Exception("UserId claim is missing.");

            return int.Parse(userIdClaim.Value);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            var emailClaim = user.FindFirst(ClaimTypes.Email)?.Value;
            return emailClaim ?? throw new Exception("Email claim missing");
        }

        public static string? GetDeviceId(this ClaimsPrincipal user)
        {
            return user.FindFirst("device_id")?.Value;
        }
        public static string? GetTimeZone(this ClaimsPrincipal user)
        {
            return user.FindFirst("time_zone")?.Value;
        }
    }
}
