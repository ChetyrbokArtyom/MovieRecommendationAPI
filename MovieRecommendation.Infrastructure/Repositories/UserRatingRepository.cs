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
        public async Task UpdateUserRatingAsync(Guid MovieId,Guid UserId,float newRating) 
        {
            var existingUserRating = await _dbContext.UserRatings.FindAsync(UserId, MovieId);
            if (existingUserRating == null)
                throw new KeyNotFoundException("Оценка не найдена");

            existingUserRating.Rating = newRating;

            await _dbContext.SaveChangesAsync();
        }
    }
}
