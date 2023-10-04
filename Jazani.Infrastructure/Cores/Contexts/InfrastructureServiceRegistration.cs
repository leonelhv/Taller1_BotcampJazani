
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Admins.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            );

            services.AddTransient<IPeriocityRepository, PeriocityRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
