using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(string login, string password);
        Task<string> AuthenticateAsync(string login, string password);
    }
}
