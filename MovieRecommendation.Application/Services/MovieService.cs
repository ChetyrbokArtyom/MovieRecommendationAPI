using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Mappers;
using MovieRecommendation.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MovieRecommendation.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }
        public async Task<MovieDTO> AddMoviesAsync(CreateMovieDTO movieDTO) 
        {
            var movie = movieDTO.ToEntity();
            await _movieRepository.AddAsync(movie);
            return movie.ToDto();
        }

        public async Task<IEnumerable<MovieDTO>> SearchMovieByFilter(string? title, List<string>? genres, int page, int pageSize)
        {
            var query = _movieRepository.Search(title, genres);

            var movies = await query
                .OrderBy(m => m.MeanRating)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieDTO { Id = m.Id, Title = m.Title, Genre = m.Genre })
                .ToListAsync();

            return movies;
        }

    }
}
