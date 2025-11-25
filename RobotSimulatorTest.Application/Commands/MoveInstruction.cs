using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Application.Commands;

public class MoveInstruction : IInstruction
{
    public Task ExecuteInstructionsAsync(ISimulationService simulationService)
    {
        simulationService.MoveRobot();
        return Task.CompletedTask;
    }
}