using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Mappers;
using MovieRecommendation.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRatingRepository _userRatingRepository;
        public MovieService(IMovieRepository movieRepository, IUserRatingRepository userRatingRepository) 
        {
            _movieRepository = movieRepository;
            _userRatingRepository = userRatingRepository;
        }
        public async Task<MovieDTO> AddMoviesAsync(CreateMovieDTO movieDTO) 
        {
            var movie = movieDTO.ToEntity();
            await _movieRepository.AddAsync(movie);
            return movie.ToDto();
        }

        public async Task<IEnumerable<MovieDTO>> SearchMovieByFilter(string? title, List<string>? genres, int page, int pageSize)
        {
            var query = _movieRepository.SearchMovie(title, genres);

            var movies = await query
                .OrderBy(m => m.MeanRating)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieDTO { Id = m.Id, Title = m.Title, Genre = m.Genre })
                .ToListAsync();

            return movies;
        }

        public async Task UpdateMovieRatingAsync(int movieId)
        {
            var ratings = _userRatingRepository.GetRatingsForMovie(movieId);

            if (ratings.Any()) 
            {
                var averageRating = await ratings.AverageAsync(ur => ur.Rating);

                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie != null)
                {
                    movie.MeanRating = averageRating;
                    await _movieRepository.UpdateAsync(movie);
                }
            }
        }

    }
}
