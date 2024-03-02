using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaletaApp.DataAccess;
using PaletaApp.Repositories.Implementation;
using PaletaApp.Repositories.Interfaces;
using PaletaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("PaletaAppConnectionString"));
            });  

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
