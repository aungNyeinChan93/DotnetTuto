using DotnetTuto.Database.Data;
using DotnetTuto.Database.Repositry;
using DotnetTuto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Database
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDatabase(this IServiceCollection service ,IConfiguration configration)
        {
            service.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configration.GetConnectionString("default"));
            });

            service.AddScoped<IUserRepositry,UserRepositry>();

            return service;
        }
    }
}
