namespace MoodifyCore.DTO.Auth
{
    public class GoogleLoginResponseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsNewUser { get; set; } = false;
    }
}
