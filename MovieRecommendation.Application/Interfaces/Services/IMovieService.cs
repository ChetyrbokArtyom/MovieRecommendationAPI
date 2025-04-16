using MovieRecommendation.Application.DTOs;


namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieDTO> AddMoviesAsync(CreateMovieDTO movieDTO);
        Task<IEnumerable<MovieDTO>> SearchMovieByFilter(string? title, List<string>? genres, int page, int pageSize);
    }
}
