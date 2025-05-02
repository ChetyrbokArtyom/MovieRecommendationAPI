namespace MovieRecommendation.Application.DTOs
{
    public class AuthenticateUserDto
    {
        public string? Login { get; set; }
        public string? Email { get; set; }

        public string Password { get; set; }
    }
}
