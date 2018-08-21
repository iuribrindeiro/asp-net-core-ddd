using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.DependencyResolver
{
    public static class IdentityResolverDependencyResolver
    {
        public static void AddCustomIdentityServer(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddSigningCredential(new SigningCredentials(new JsonWebKey(), "jwtmegalogica123*123#awsd"));
        }
    }
}