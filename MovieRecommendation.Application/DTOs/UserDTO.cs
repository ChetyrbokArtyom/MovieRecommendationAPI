namespace MovieRecommendation.Application.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Genres { get; set; }

    }
}
