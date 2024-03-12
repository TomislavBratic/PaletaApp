using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaletaApp.Models;
using PaletaApp.Models.DTO.Blogs;
using PaletaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogRepository blogRepository;
        private readonly IUserRepository userRepository;
        public BlogController(IBlogRepository blogRepository,IUserRepository userRepository)
        {
            this.blogRepository = blogRepository;
            this.userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogs(List<BlogListDto> request)
        {

            foreach (var blogs in request)
            {
                var user = await userRepository.GetUserById(blogs.UserId);
                if(user!= null)
                {
                    var blog = new Blog
                    {
                        Title = blogs.Title,
                        Content = blogs.Content,
                        Status = blogs.Status,
                        DateAdded = blogs.DateAdded,
                        LikeCount = blogs.LikeCount,
                        UserId=blogs.UserId
                    };
                    await blogRepository.AddBlogs(blog);
                }
               
            }

            return Ok();

        }
        
        [HttpGet]
        public async Task<List<BlogListDto>> GetBlogs()
        {
            var allBLogsList = await blogRepository.GetBlogs();

            var blogDTO = allBLogsList.Select(blog => new BlogListDto
            {
                Title = blog.Title,
                Content = blog.Content,
                Status = blog.Status,
                DateAdded = blog.DateAdded,
                LikeCount = blog.LikeCount,
                UserId = blog.UserId
            }).ToList();


            return blogDTO;
        }
    }
}
