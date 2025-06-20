namespace MoodifyCore.DTO.Auth
{
    public class GoogleLoginRequestDto // request from Android to API
    {
        public string IdToken { get; set; } = null!;
        public string DeviceId { get; set; } = null!;
    }
}
