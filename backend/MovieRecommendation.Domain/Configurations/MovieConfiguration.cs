using MovieRecommendation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MovieRecommendation.Domain.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder) 
        {
            builder.HasKey(m => m.Id);

            builder
                .HasMany(m => m.Ratings)
                .WithOne(ur => ur.Movie)
                .HasForeignKey(ur => ur.MovieId)
                .OnDelete(DeleteBehavior.Cascade)
                ;
        }
    }
}
