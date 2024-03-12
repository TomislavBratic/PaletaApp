using PaletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUsernameAsync(User person);
        Task<List<User>> GetUsersAsync();
        Task<bool> CheckUsername(string UserName);
        Task<User> GetUsername(string UserName);
        Task<User> GetUserDetail(int id);
        Task<User> GetUserById(int id);
    }
}
