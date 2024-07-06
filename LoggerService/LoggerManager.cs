using Contracts;
using Microsoft.Extensions.Logging;

namespace LoggerService;

public class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger;
    public LoggerManager(ILogger logger) => _logger = logger;

    public void Debug(string message)
    {
        _logger.LogDebug(message);
    }

    public void Error(string message)
    {
        _logger.LogError(message);
    }

    public void Information(string message)
    {
        _logger.LogInformation(message);
    }

    public void Warning(string message)
    {
        _logger.LogWarning(message);
    }
}
