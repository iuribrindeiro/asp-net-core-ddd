using System;
using Domain.Services.Interfaces;
using Logger.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace Logger.DependencyResolver
{
    public static class LoggerDependencyResolverExtension
    {
        public static void AddCustomLoggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILogger>(c =>
            {
                var logFile = Environment.GetEnvironmentVariable("USUARIOS_LOGGER_FILE");
                var interval = Environment.GetEnvironmentVariable("USUARIOS_LOGGER_INTERVAL_PERIOD");
                return new LoggerConfiguration().MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(
                        $"{logFile}",
                        rollingInterval: (RollingInterval)Enum.Parse(typeof(RollingInterval), 
                        !String.IsNullOrEmpty(interval) ? interval : "Day")
                    ).CreateLogger();
            });
            services.AddTransient<ILoggerService, LoggerService>();
        }
    }
}