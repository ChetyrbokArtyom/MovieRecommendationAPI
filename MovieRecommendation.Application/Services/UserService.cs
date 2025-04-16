using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Mappers;
using MovieRecommendation.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MovieRecommendation.Application.Services
{
    class UserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        //    public async Task RegisterUserAsync(string login, string password) 
        //    {
        //        UserDTO user = new UserDTO;
        //        user.To
        //        var user = _usersRepository.AddAsync(UserDTO userDTO); 
        //    }
        //    Task<string> AuthenticateAsync(string login, string password);
        //}
    }
}
