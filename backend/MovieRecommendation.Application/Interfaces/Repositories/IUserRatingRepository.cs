using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Interfaces.Repositories
{
    public interface IUserRatingRepository
    {
        Task UpdateUserRatingAsync(int MovieId, Guid UserId, float newRating);
        IQueryable<UserRatings> GetRatingsForMovie(int movieId);


    }
}
