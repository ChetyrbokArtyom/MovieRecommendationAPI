namespace MovieRecommendation.Application.DTOs
{
    public class UserRatingDTO
    {
        public float Rating { get; set; }
        public Guid UserId { get; set; }

        public int MovieId { get; set; }
    }
}
