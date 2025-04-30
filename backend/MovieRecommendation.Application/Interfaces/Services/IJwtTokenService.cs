using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(Users user);
    }
}
