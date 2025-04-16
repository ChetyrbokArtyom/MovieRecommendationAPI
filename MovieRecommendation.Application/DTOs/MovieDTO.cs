namespace MovieRecommendation.Application.DTOs
{
    public class MovieDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public float? MeanRating { get; set; }

    }
}
