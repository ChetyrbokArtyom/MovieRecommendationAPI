namespace MovieRecommendation.Application.DTOs
{
    public class AuthenticateUserDto
    {
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; }
    }
}
