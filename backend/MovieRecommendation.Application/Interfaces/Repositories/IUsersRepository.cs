using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Users?> GetByIdAsync(Guid id);
        Task AddAsync(Users user);

        Task<Users?> FindUserByLoginAsync(string login);
        Task<Users?> FindUserByEmailAsync(string Email);

        Task DeleteAsync(Guid id);
    }
}

