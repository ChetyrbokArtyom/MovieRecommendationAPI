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
        public async Task<string> RegisterUserAsync(RegisterUserDTO registerUserDto)
        {
            var existingUser = await _usersRepository.FindUserByLoginAsync(registerUserDto.Login);
            if (existingUser != null)
                throw new InvalidOperationException("Пользователь с таким логином уже существует");

            var user = registerUserDto.ToEntity();
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _usersRepository.AddAsync(user);
            return _jwtTokenService.GenerateToken(user);
        }

        public async Task<string> AuthenticateUserAsync(AuthenticateUserDto authenticateUserDto) 
        {
            Users? user = null;

            if (!string.IsNullOrWhiteSpace(authenticateUserDto.Login))
            {
                user = await _usersRepository.FindUserByLoginAsync(authenticateUserDto.Login);
            }
            else if (!string.IsNullOrWhiteSpace(authenticateUserDto.Email))
            {
                user = await _usersRepository.FindUserByEmailAsync(authenticateUserDto.Email);
            }
            if (user == null)
                throw new UnauthorizedAccessException("Пользователь не найден");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, authenticateUserDto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Неверный пароль");

            return _jwtTokenService.GenerateToken(user);
        }


    }
}
