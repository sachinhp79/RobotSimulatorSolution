using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    public Task LogInformation(string message, LogLevel? logLevel = null!)
    {
        Console.WriteLine($"{logLevel} : {message}");
        return Task.CompletedTask;
    }

}