using System;
using Data.Context;
using Data.Repositories;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Identity.Services;
using Identity.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class DepedencyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Usuario, TipoUsuario>().AddDefaultTokenProviders();
            
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")))
                .AddTransient<IUserStore<Usuario>, UserStore>()
                .AddTransient<IUserPasswordStore<Usuario>, UserPassowordStore>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IUsuariosService, UsuarioService>()
                .AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}