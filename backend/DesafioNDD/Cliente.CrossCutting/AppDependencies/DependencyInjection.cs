

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cliente.Infrastructure.Context;
using Cliente.Infrastructure.Repositories;
using Cliente.Domain.Abstractions;

namespace Cliente.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                  this IServiceCollection services,
                  IConfiguration configuration)
        {
            var mySqlConnection = configuration
                              .GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(mySqlConnection));

            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}