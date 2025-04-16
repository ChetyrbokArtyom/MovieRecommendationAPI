using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDto(this Users user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Login = user.Login,
                Email = user.Email,
                Genres = user.Genres
            };
        }
        public static Users ToEntity(this RegisterUserDTO userDto)
        {
            return new Users
            {
                UserId = Guid.NewGuid(),
                Login = userDto.Login,
                Email = userDto.Email,
                Password = userDto.Password,
            };
        }
    }
}
