using System;
using Domain.Services.Interfaces;
using Serilog;

namespace Logger.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;
        
        public LoggerService(ILogger logger) => _logger = logger;

        public void LogError(Exception exception, string message, params object[] args) => _logger.Error(exception, message, args);

        public void LogInfo(Exception exception, string message, params object[] args) => _logger.Information(exception, message, args);

        public void LogInfo(string message, params object[] args) => _logger.Information(message, args);
    }
}