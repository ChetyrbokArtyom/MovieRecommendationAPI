using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(Guid id);
        Task<List<Movie>?> GetByTitle(string title);
        IQueryable<Movie> Search(string? title, List<string>? genres);
        Task AddAsync(Movie movie);

        Task UpdateAsync(Movie movie);

        Task DeleteAsync(Guid id);
    }
}
