using PaletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Interfaces
{
   public interface IBlogRepository
    {
        Task<Blog> AddBlogs(Blog blog);
        Task<List<Blog>> GetBlogs();
    }
}
