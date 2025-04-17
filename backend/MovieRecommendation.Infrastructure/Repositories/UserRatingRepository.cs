using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Infrastructure.Data;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Application.Interfaces.Repositories;



namespace MovieRecommendation.Infrastructure.Repositories
{
    public class UserRatingRepository : IUserRatingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRatingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UpdateUserRatingAsync(int movieId,Guid userId,float newRating) 
        {
            var UserRating = await _dbContext.UserRatings.FindAsync(userId, movieId);
            if (UserRating != null)
                UserRating.Rating = newRating;
            else
                UserRating = new UserRatings
                {
                    UserId = userId,
                    MovieId = movieId,
                    Rating = newRating
                };
                

                await _dbContext.SaveChangesAsync();
        }
    }
}
