using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Mappers;
using MovieRecommendation.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IUserRatingRepository _userRatingRepository;
        public RatingService(IMovieRepository movieRepository, IUsersRepository usersRepository, IUserRatingRepository userRatingRepository) 
        {
            _movieRepository = movieRepository;
            _usersRepository = usersRepository;
            _userRatingRepository = userRatingRepository;
        }
        public async Task<Movie> RateFilm(int MovieID,Guid UserId,float rate) 
        {
            var movie = await _movieRepository.GetByIdAsync(MovieID);
            var user = await _usersRepository.GetByIdAsync(UserId);
            if (user != null || movie != null) 
            {
                throw new Exception("Movie or user not found.");
            }
            await _userRatingRepository.UpdateUserRatingAsync(MovieID,UserId,rate); 
            return movie;
        }
    }
}
