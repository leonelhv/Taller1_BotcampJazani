﻿

using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPeriocityService, PeriocityService>();
            return services;
        }
    }
}
