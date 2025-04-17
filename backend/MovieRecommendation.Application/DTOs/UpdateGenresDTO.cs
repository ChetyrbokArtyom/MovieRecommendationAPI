namespace MovieRecommendation.Application.DTOs
{
    public class UpdateGenresDTO
    {
        public Guid UserId { get; set; }
        public string Genres { get; set; } = null!;
    }
}
