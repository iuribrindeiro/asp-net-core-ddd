using Bus.Events;
using Bus.Handlers;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bus.DependencyResolver
{
    public static class HandlersDependencyResolverExtension
    {
        public static void AddHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AsyncRequestHandler<CommitEvent>, CommitHandler>()
                .AddTransient<AsyncRequestHandler<UserCreatedEvent>, EmailUserCreatedHandler>();
        }
    }
}