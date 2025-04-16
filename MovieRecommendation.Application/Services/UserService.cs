using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Repositories;
using MovieRecommendation.Application.Interfaces.Services;
namespace MovieRecommendation.Application.Services
{
    class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository; 
        }
        public async Task RegisterUserAsync(string login, string password) 
        {
            UserDTO user = new UserDTO;
            user.To
            var user = _usersRepository.AddAsync(UserDTO userDTO); 
        }
        Task<string> AuthenticateAsync(string login, string password);
    }
}
