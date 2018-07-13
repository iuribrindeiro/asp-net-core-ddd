using System;
using Domain.Entidades;
using Domain.Services.Interfaces;
using Identity.Errors;
using Identity.Services;
using Identity.Services.Delegators;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.DependencyResolver
{
    public static class IdentityDependencyResolverExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services
                .AddTransient<IUsuariosService>(s =>
                {
                    var userManager = s.GetService<UserManager<Usuario>>();
                    return new UsuarioServiceDelegator(new UsuarioService(userManager), userManager, s.GetService<IMediator>());
                })
                .AddTransient<IAuthenticationService, AuthenticationService>();
            
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
            }).AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorDescriber>();
        }
    }
}