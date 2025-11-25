using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Application.Interfaces;

public interface ILoggerService
{
    Task LogInformation(string message, LogLevel? logLevel);
}