using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Users?> GetByIdAsync(Guid id);
        Task AddAsync(Users user);

        Task<Users?> FindUserByLoginAsync(string login);

        Task DeleteAsync(Guid id);
    }
}

