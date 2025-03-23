using ChatApp.Infrastructure.Repositories.Interfaces;
using ChatApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
    
namespace ChatApp.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ChatDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("MainDbConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
