using System;
using Bus.Events;
using Bus.Handlers;
using Data.Context;
using Data.Repositories;
using Data.UnitOfWor;
using Domain.Entidades;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.UnitOfWork.Interfaces;
using Identity.DependencyResolver;
using Identity.Services;
using Identity.Stores;
using MediatR;
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
            services.AddCustomIdentity();
            services.AddMediatR();
            
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")))
                .AddTransient<IUserStore<Usuario>, UserStore>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IUsuariosService, UsuarioService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<INotificationHandler<CommitEvent>, CommitHandler>();
        }
    }
}