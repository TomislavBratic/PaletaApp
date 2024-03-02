using PaletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserNameAsync(User person);
        Task<List<User>> GetUsersAsync();
        Task<bool> CheckUserName(string UserName);
        Task<User> GetUserName(string UserName);
        Task<User> GetUserDetail(int id);
    }
}
