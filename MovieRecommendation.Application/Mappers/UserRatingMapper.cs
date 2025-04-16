using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Mappers
{
    public static class UserRatingMapper
    {
        public static UserRatingDTO ToDto(this UserRatings userRating) 
        {
            return new UserRatingDTO
            {
                MovieId = userRating.MovieId,
                UserId = userRating.UserId,
                Rating = userRating.Rating
            };        
        }
        public static UserRatings ToEntity(this UserRatingDTO userRatingDTO) 
        {
            return new UserRatings
            {
                Rating = userRatingDTO.Rating,
                UserId = userRatingDTO.UserId,
                MovieId = userRatingDTO.MovieId
            };
        }
    }
}
