using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IRatingService
    {
        Task<Movie> RateFilm(int MovieId,Guid UserID,float rate); 
    }
}
