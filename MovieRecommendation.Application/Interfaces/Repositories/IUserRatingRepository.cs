using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Interfaces.Repositories
{
    public interface IUserRatingRepository
    {   
        Task UpdateUserRatingAsync(Guid MovieId, Guid UserId, float newRating);
    
    }
}
