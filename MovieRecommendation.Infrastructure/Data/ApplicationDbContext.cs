using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieRecommendation.Domain.Configurations;
using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<UserRatings> UserRatings  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UserRatingsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
