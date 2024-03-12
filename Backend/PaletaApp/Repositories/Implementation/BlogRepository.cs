using Microsoft.EntityFrameworkCore;
using PaletaApp.DataAccess;
using PaletaApp.Models;
using PaletaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Implementation
{
    public class BlogRepository:IBlogRepository
    {
        private readonly UserContext dbContext;
        public BlogRepository(UserContext dbContext)
        {
            this.dbContext = dbContext;
        }
     
        public async Task<Blog> AddBlogs(Blog blog)
        {
            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<List<Blog>> GetBlogs()
        {
            var blogs = await dbContext.Blogs.ToListAsync();
            return blogs;
        }
    }
}
