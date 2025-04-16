using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Application.Interfaces.Repositories;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Infrastructure.Data;

namespace MovieRecommendation.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Movie?> GetByIdAsync(int id) 
        {
            return await _dbContext.Movie
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<Movie>?> GetByTitle(string title) 
        {
            var movies = await _dbContext.Movie
                .AsNoTracking()
                .Where(m => m.Title == title)
                .ToListAsync();
            return movies.Count > 0 ? movies : null;
        }

        public IQueryable<Movie> SearchMovie(string? title, List<string>? genres) 
        {
            var query = _dbContext.Movie.AsQueryable();
            if (!string.IsNullOrEmpty(title))
                query = query.Where(m => m.Title.Contains(title));
            if (genres != null && genres.Any())
                query = query.Where(m => genres.Contains(m.Genre));
            return query;
        }

        public async Task AddAsync(Movie movie) 
        {
            _dbContext.Movie.Add(movie);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(Movie movie) 
        {
            var existingMovie = await _dbContext.Movie.FindAsync(movie.Id);
            if (existingMovie == null)
                throw new KeyNotFoundException("Movie not found");

            _dbContext.Entry(existingMovie).CurrentValues.SetValues(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id) 
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie == null)
                throw new KeyNotFoundException("Movie not found");

            _dbContext.Movie.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
