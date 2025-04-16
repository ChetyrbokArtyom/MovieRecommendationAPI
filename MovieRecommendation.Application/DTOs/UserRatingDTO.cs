namespace MovieRecommendation.Application.DTOs
{
    public class UserRatingDTO
    {
        public float Rating { get; set; }
        public Guid UserId { get; set; }

        public Guid MovieId { get; set; }
    }
}
