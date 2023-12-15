using System;

namespace VehicleServiceManagementSystem.SystemLogger
{
    public class SystemLogger : ISystemLogger
    {
        private readonly ILogger _logger;

        public void Exception(Exception exception)
        {
            _logger.LogError($"{exception.Message}");
        }

        public void Information(string source, string description, Exception exception)
        {
            _logger.LogInformation($" {source} and error description - {description}. Other details {exception.Message}");
        }

        public void Warning(string source, string description, Exception exception)
        {
            _logger.LogWarning($" {source} and error description - {description}. Other details {exception.Message}");
        }

        public void Error(string source, string description, Exception exception)
        {
            _logger.LogCritical($" {source} and error description - {description}. Other details {exception.Message}");
        }
    }
}
