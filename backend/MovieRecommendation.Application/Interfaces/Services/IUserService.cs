using MovieRecommendation.Application.DTOs;

namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<string> AuthenticateUserAsync(AuthenticateUserDto authenticateUserDto);
    }
}
