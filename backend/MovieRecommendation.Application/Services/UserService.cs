using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Application.Interfaces.Services;
using MovieRecommendation.Application.Mappers;
using MovieRecommendation.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MovieRecommendation.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MovieRecommendation.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly PasswordHasher<Users> _passwordHasher;

        public UserService(IUsersRepository usersRepository, IJwtTokenService jwtTokenService)
        {
            _usersRepository = usersRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = new PasswordHasher<Users>();
        }
            public async Task<string> RegisterAsync(UserDTO userDto)
        {
            
        }
        
        
    }
}
