using System;
using Data.Context;
using Data.Repositories;
using Data.UnitOfWor;
using Domain.Entidades;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.UnitOfWork.Interfaces;
using Email.DependencyResolver;
using Identity.DependencyResolver;
using Identity.Services;
using Identity.Stores;
using Logger.DependencyResolver;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DepedencyResolver
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomIdentity(configuration);
            services.AddCustomLoggerConfig(configuration);
            services.AddEmailConfig(configuration);

            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")))
                .AddTransient<IUserStore<Usuario>, UserStore>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}