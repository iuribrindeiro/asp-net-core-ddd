using System;
using Domain.Services.Interfaces;
using Logger.Configuration;
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
                var config = configuration.GetSection("LoggeerFile").Get<LoggerFileConfiguration>();
                return new LoggerConfiguration().MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(
                        $"{config.Path}\\{config.FileName}",
                        rollingInterval: (RollingInterval)Enum.Parse(typeof(RollingInterval), config.IntervalPeriod)).CreateLogger();
            });
            services.AddTransient<ILoggerService, LoggerService>();
        }
    }
}