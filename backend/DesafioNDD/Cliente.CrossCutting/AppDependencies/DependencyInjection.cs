

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cliente.Infrastructure.Context;
using Cliente.Infrastructure.Repositories;
using Cliente.Domain.Abstractions;
using Cliente.Application.ClientesApp.Commands.Validations;
using FluentValidation;
using System.Reflection;
using MediatR;

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

            var myhandlers = AppDomain.CurrentDomain.Load("Cliente.Application");
            services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(myhandlers);
                    cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                });

            services.AddValidatorsFromAssembly(Assembly.Load("Cliente.Application"));

            return services;
        }
    }
}