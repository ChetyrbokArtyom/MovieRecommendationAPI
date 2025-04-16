namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(string login, string password);
        Task<string> AuthenticateAsync(string login, string password);
    }
}
