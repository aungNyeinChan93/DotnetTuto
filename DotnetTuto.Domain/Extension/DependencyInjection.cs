using DotnetTuto.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.Extension
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDomain(this IServiceCollection service)
        {
            service.AddScoped<UserService>();

            return service;
        }
    }
}
