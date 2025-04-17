using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRecommendation.Core.Domain.Core.Entities;
namespace MovieRecommendation.Core.Domain.Core.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder) 
        {
            builder.HasKey(us => us.UserId);

            builder
                .HasMany(us => us.Ratings)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
