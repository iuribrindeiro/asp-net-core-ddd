using System;
using Data.Context;
using Data.Repositories;
using Domain.Entidades;
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
            services.AddIdentity<Usuario, TipoUsuario>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                options.User.RequireUniqueEmail = true;
            }).AddDefaultTokenProviders();
            
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")))
                .AddTransient<IUserStore<Usuario>, UserStore>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IUsuariosService, UsuarioService>()
                .AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}