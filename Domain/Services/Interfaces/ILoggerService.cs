using System;

namespace Domain.Services.Interfaces
{
    public interface ILoggerService
    {
        void LogError(Exception exception, string message, params object[] args);

        void LogInfo(Exception exception, string message, params object[] args);

        void LogInfo(string message, params object[] args);
    }
}