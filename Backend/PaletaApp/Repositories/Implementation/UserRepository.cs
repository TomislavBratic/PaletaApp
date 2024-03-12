using Microsoft.EntityFrameworkCore;
using PaletaApp.DataAccess;
using PaletaApp.Models;
using PaletaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext dbContext;

        public UserRepository(UserContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AddUsernameAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var persons = await dbContext.Users.ToListAsync();
            return persons;
        }

        public async Task<bool> CheckUsername(string username)
        {
           return await dbContext.Users.AnyAsync(x => x.Username == username);

        }

        public async Task<User> GetUsername(string username)
        {
            return await dbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> GetUserDetail(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public Task<User> GetUserById(int id)
        {
            return dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
