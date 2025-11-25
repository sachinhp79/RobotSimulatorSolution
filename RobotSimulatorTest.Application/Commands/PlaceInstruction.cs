using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Application.Commands;

public class PlaceInstruction(int x, int y, Direction direction) : IInstruction
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public Direction Direction { get; } = direction;

    public Task ExecuteInstructionsAsync(ISimulationService simulationService)
    {
        simulationService.PlaceRobot(X, Y, Direction);
        return Task.CompletedTask;
    }
}