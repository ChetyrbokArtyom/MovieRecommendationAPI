using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Domain.Configurations
{
    public class UserRatingsConfiguration : IEntityTypeConfiguration<UserRatings>
    {
        public void Configure(EntityTypeBuilder<UserRatings> builder) 
        {
            builder.HasKey(ur => new { ur.UserId, ur.MovieId }); //составной ключ

            // Связь с Users (один пользователь может ставить много оценок)
            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.Ratings)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь с Movie (один фильм может иметь много оценок)
            builder.HasOne(ur => ur.Movie)
                   .WithMany(m => m.Ratings)
                   .HasForeignKey(ur => ur.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
