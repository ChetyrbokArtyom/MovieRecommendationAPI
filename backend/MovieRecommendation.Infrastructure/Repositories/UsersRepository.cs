using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Application.Interfaces;
using MovieRecommendation.Infrastructure.Data;
using MovieRecommendation.Application.Interfaces.Repositories;
namespace MovieRecommendation.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public UsersRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Users?> GetByIdAsync(Guid id) 
        {
            return await _dbcontext.Users
                   .AsNoTracking()
                   .FirstOrDefaultAsync(us => us.UserId == id);
        }
        public async Task AddAsync(Users user) 
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Users?> FindUserByLoginAsync(string login) 
        {
            return await _dbcontext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(us => us.Login == login);
        }
        public async Task<Users?> FindUserByEmailAsync(string email)
        {
            return await _dbcontext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(us => us.Email == email);
        }


        public async Task DeleteAsync(Guid id) 
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user == null)
                throw new KeyNotFoundException("Пользователь не найден");

            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
